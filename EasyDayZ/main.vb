' EasyDayZ - Tool for managing a DayZ SA server by battleye
' Uses the BattleNET (v1.3.4) Library 
' EasyDayZ is not affiliated with or authorized by Bohemia Interactive

Imports System.Collections.Concurrent
Imports System.ComponentModel
Imports System.IO
Imports BattleNET
Imports System.Threading

'Bugs
' disconnect in loop (auto reconnect) not working, e.g. wrong password

' Todo
' - welcome message

Public Class main
    ' Battleye connection through BattleNET lib
    Public b As BattlEyeClient
    ' Dictionary of all received server messages
    Public responses_dict As New ConcurrentDictionary(Of Integer, String)
    ' Dictionary of pending responses form the server
    Public responses_to_handel As New ConcurrentDictionary(Of Integer, String)
    ' Dictionary for guid receive retries
    Public whitelist_ban_seconde_chance_no_guid As New ConcurrentDictionary(Of Integer, String)
    ' Debug mode switch
    Public DEBUG_MODE As Boolean = True
    ' The start of unix timestamps
    Public timestamp_start_date As New DateTime(1970, 1, 1)
    ' Schedule help variables
    Public schedule_last_tick As Long = 0
    Public schedule_current_tick As Long

    ' Locks and vars to prevent unwanted async behaviour 
    Public connection_lock As New Object()
    Public whitelist_second_chance_lock As New Object()
    Public whitelist_second_chance_thread_started As Boolean = False

    ' Log stuff
    Public Sub DoLog(txt As String)
        AppendTextBox(rtxt_log, Now.ToLocalTime & " - " & txt & vbCrLf)
    End Sub

    ' Threadsafty stuff start
    Private Delegate Sub AppendTextBoxDelegate(ByVal TB As RichTextBox, ByVal txt As String)

    Private Sub AppendTextBox(ByVal TB As RichTextBox, ByVal txt As String)
        Try
            If TB.InvokeRequired Then
                TB.Invoke(New AppendTextBoxDelegate(AddressOf AppendTextBox), New Object() {TB, txt})
            Else
                TB.AppendText(txt)
            End If
        Catch
            'can fire while closing and logging is running
        End Try
    End Sub

    Public Delegate Sub AddRowDatagridviewDelegate(ByVal DGV As DataGridView, ByVal row As String())

    Public Sub AddRowDatagridview(ByVal DGV As DataGridView, ByVal row As String())
        If DGV.InvokeRequired Then
            DGV.Invoke(New AddRowDatagridviewDelegate(AddressOf AddRowDatagridview), New Object() {DGV, row})
        Else
            DGV.Rows.Add(row)
            If DGV Is Me.data_player_history Then save_player_history()
        End If
    End Sub

    Private Delegate Sub RemoveRowDatagridviewDelegate(ByVal DGV As DataGridView, ByVal row As DataGridViewRow)

    Private Sub RemoveRowDatagridview(ByVal DGV As DataGridView, ByVal row As DataGridViewRow)
        If DGV.InvokeRequired Then
            DGV.Invoke(New RemoveRowDatagridviewDelegate(AddressOf RemoveRowDatagridview), New Object() {DGV, row})
        Else
            DGV.Rows.Remove(row)
        End If
    End Sub

    Private Delegate Sub UpdateRowDatagridviewDelegate(ByVal DGV As DataGridView, ByVal row_id As Integer, ByVal values As String())

    Private Sub UpdateRowDatagridview(ByVal DGV As DataGridView, ByVal row_id As Integer, ByVal values As String())
        If DGV.InvokeRequired Then
            DGV.Invoke(New UpdateRowDatagridviewDelegate(AddressOf UpdateRowDatagridview), New Object() {DGV, row_id, values})
        Else
            DGV.Rows(row_id).SetValues(values)
            If DGV Is Me.data_player_history Then save_player_history()
        End If
    End Sub

    Private Delegate Sub RefreshDatagridviewDelegate(ByVal DGV As DataGridView)

    Private Sub RefreshDatagridview(ByVal DGV As DataGridView)
        If DGV.InvokeRequired Then
            DGV.Invoke(New RefreshDatagridviewDelegate(AddressOf RefreshDatagridview), New Object() {DGV})
        Else
            DGV.Refresh()
        End If
    End Sub

    ' Threadsafty stuff end

    ' If you kick a player to fast after joining, he won't be kicked
    ' Dirty workaround: poll kick commands for 10 secs
    ' Todo: Stop polling after player disconnect message
    Private Sub kickThread(ByRef playername As String)
        For i As Integer = 1 To 10
            b.SendCommand("#kick " & playername)
            Thread.Sleep(1000)
        Next
    End Sub

    ' New in DayZ 1.0:
    ' Player will be listed as joined before their guid gets checked/received
    ' workaround: If no guid has been send yet, retry after 2 sec
    Private Sub whitelist_second_chance_thread()
        Thread.Sleep(2000)
        DoLog("whitelist_second_chance_thread finished waiting.")
        SyncLock whitelist_second_chance_lock
            whitelist_second_chance_thread_started = False
        End SyncLock
        BattlEyeUpdatePlayer()
    End Sub

    ' Send a battleye command as string
    Public Function BattlEyeCommandSend(ByVal command As String) As Boolean
        If BattlEyeIsConnected() Then
            b.SendCommand(command)
            Return True
        Else
            MsgBox("You need to connect before you send commands!", vbExclamation)
            Return False
        End If
    End Function

    ' Send a 'native' battleye command of the BattleNET lib
    Public Function BattlEyeCommandSend(ByVal command As BattlEyeCommand) As Boolean
        If BattlEyeIsConnected() Then
            b.SendCommand(command)
            Return True
        Else
            MsgBox("You need to connect before you send commands!", vbExclamation)
            Return False
        End If
    End Function

    ' Handler for server messages
    Public Sub BattlEyeMessageReceived(args As BattlEyeMessageEventArgs)
        Dim response_id As Integer = args.Id
        Dim response_text As String = args.Message

        If responses_dict IsNot Nothing Then
            ' add new message to dictionary
            responses_dict.TryAdd(response_id, response_text)
            If responses_to_handel.ContainsKey(response_id) Then
                Select Case responses_to_handel.Item(response_id)
                    Case "playerupdate"
                        BattlEyeUpdatePlayer(response_id)
                End Select
                'DoLog(response_text)
            Else
                DoLog(response_text)
                If response_text.StartsWith("Player #") And response_text.EndsWith("connected") Then
                    BattlEyeUpdatePlayer()
                End If
            End If
        End If
    End Sub

    ' Handler for new established connections to battleye
    Public Sub BattlEyeConnected(args As BattlEyeConnectEventArgs)
        DoLog(args.Message)

        If Not b.Connected Then
            If chk_reconnect.Checked = True Then
                timer_reconnect.Enabled = True
            Else
                btn_connect.Enabled = True
                btn_disconnect.Enabled = False
            End If
            Exit Sub
        End If
        Application.DoEvents()

        responses_dict = New ConcurrentDictionary(Of Integer, String)
        responses_to_handel = New ConcurrentDictionary(Of Integer, String)

        BattlEyeUpdatePlayer()
    End Sub

    ' Handler for lost connections to battleye
    Public Sub BattlEyeDisconnected(args As BattlEyeDisconnectEventArgs)
        DoLog(args.Message)

        If chk_reconnect.Checked And btn_disconnect.Enabled Then
            btn_connect_Click(Nothing, Nothing)
        End If
    End Sub

    ' Function to determine if battleye is connected
    Public Function BattlEyeIsConnected() As Boolean
        If b Is Nothing Then
            Return False
        Else
            Return b.Connected
        End If
    End Function

    ' Method to update the playerlist
    Public Sub BattlEyeUpdatePlayer()
        If Not BattlEyeIsConnected() Then Exit Sub
        Dim my_request_id = b.SendCommand(BattlEyeCommand.Players)
        responses_to_handel.TryAdd(my_request_id, "playerupdate")
    End Sub

    ' Method to update the playerlist based on a server response
    ' Bans, whitelisting ...
    Public Sub BattlEyeUpdatePlayer(my_request_id As Integer)
        SyncLock whitelist_second_chance_lock
            If whitelist_second_chance_thread_started = True Then Exit Sub
        End SyncLock

        If Not BattlEyeIsConnected() Then Exit Sub
        Dim retrys As Integer
        While retrys < 50 And Not responses_dict.ContainsKey(my_request_id)
            retrys += 1
            System.Threading.Thread.Sleep(100)
            Application.DoEvents()
        End While

        If Not responses_dict.ContainsKey(my_request_id) Then
            b.Disconnect()
            Exit Sub
        End If

        Dim my_string_reader As New StringReader(responses_dict.Item(my_request_id))
        Dim current_line As String
        Dim row_counter As Integer = 0
        Dim cols As String()

        Dim list_guid_on_server As New List(Of String)
        Dim player_found As Boolean
        Dim player_history_found As Boolean
        Dim guid As String
        Dim player_id As Integer = -1
        Dim player_added_to_whitelist_second_chance As Boolean = False

        ' add new connected players
        While my_string_reader.Peek() > -1
            current_line = my_string_reader.ReadLine()
            player_found = False
            player_history_found = False

            If Len(current_line) > 0 And Not current_line.StartsWith("(") And Not current_line.StartsWith("[") And Not current_line.StartsWith("-") And Not current_line.StartsWith("Players on server:") Then
                cols = current_line.Split(" ", 5, StringSplitOptions.RemoveEmptyEntries)
                guid = clear_guid(cols(3))
                list_guid_on_server.Add(guid)
                player_id = Integer.Parse(cols(0))

                ' players on server
                For Each row As DataGridViewRow In data_players.Rows
                    If row.IsNewRow Then Exit For
                    If row.Cells(2).Value.ToString() = guid Then
                        player_found = True
                        Exit For
                    End If
                Next

                ' players history
                If guid <> "-" Then
                    For Each row As DataGridViewRow In data_player_history.Rows
                        If row.IsNewRow Then Exit For
                        If row.Cells(1).Value.ToString() = guid Then
                            UpdateRowDatagridview(data_player_history, row.Index, New String() {clear_playername(cols(4)), guid, get_sortable_date(), row.Cells(3).Value.ToString()})
                            player_history_found = True
                            Exit For
                        End If
                    Next
                Else
                    ' do not generate an history entry for players with no guid 
                    player_history_found = True
                End If

                If Not player_found Then AddRowDatagridview(data_players, New String() {cols(0), clear_playername(cols(4)), guid, cols(1), cols(2)})
                If Not player_history_found Then AddRowDatagridview(data_player_history, New String() {clear_playername(cols(4)), guid, get_sortable_date(), get_sortable_date()})
                If guid <> "-" OrElse whitelist_ban_seconde_chance_no_guid.ContainsKey(player_id) Then
                    If whitelist_ban_seconde_chance_no_guid.ContainsKey(player_id) Then whitelist_ban_seconde_chance_no_guid.TryRemove(player_id, clear_playername(cols(4)))
                    BattlEyeCheckWhitelisting(guid, cols(4))
                    BattlEyeCheckBan(guid, cols(4))
                Else
                    whitelist_ban_seconde_chance_no_guid.TryAdd(player_id, clear_playername(cols(4)))
                    player_added_to_whitelist_second_chance = True
                    If DEBUG_MODE Then DoLog("Second chance for " & clear_playername(cols(4)))
                End If

            End If
            row_counter += 1
        End While

        ' remove disconnected players
        For Each row As DataGridViewRow In data_players.Rows
            If row.IsNewRow Then Exit For
            player_found = False
            For Each guid In list_guid_on_server
                If row.Cells(2).Value.ToString() = guid Then
                    player_found = True
                    Exit For
                End If
            Next

            If Not player_found Then
                player_id = Integer.Parse(row.Cells(0).Value.ToString())
                If whitelist_ban_seconde_chance_no_guid.ContainsKey(player_id) Then whitelist_ban_seconde_chance_no_guid.TryRemove(player_id, row.Cells(1).Value.ToString())
                RemoveRowDatagridview(data_players, row)
            End If


        Next

        RefreshDatagridview(data_players)

        ' start a second chance thread
        If player_added_to_whitelist_second_chance Then
            SyncLock whitelist_second_chance_lock
                whitelist_second_chance_thread_started = True
                Dim new_whitelist_thread = New Thread(Sub() Me.whitelist_second_chance_thread())
                new_whitelist_thread.Start()
                If DEBUG_MODE Then DoLog("Second chance timer started")
            End SyncLock
        End If
    End Sub

    ' Method to check if a player is whitelisted and kick him, if required
    Public Sub BattlEyeCheckWhitelisting(ByVal guid As String, ByVal playername As String)
        If chk_whitelist_enabled.Checked = False Then Exit Sub
        For Each row As DataGridViewRow In data_whitelist.Rows
            If row.IsNewRow Then Exit For
            If row.Cells(0).Value.ToString() = guid Then
                If DEBUG_MODE Then DoLog("DEBUG: Player (" & playername & ") is on whitelist.")
                Exit Sub
            End If
        Next
        DoLog("Player (" & playername & ") is not on whitelist and will be kicked.")
        BattlEyeKickPlayerByName(playername, txt_whitelist_kick_text.Text)
    End Sub

    ' Method to check if a player is banned and kick him, if required
    Public Sub BattlEyeCheckBan(ByVal guid As String, ByVal playername As String)
        For Each row As DataGridViewRow In data_bans.Rows
            If row.IsNewRow Then Exit For
            If row.Cells(0).Value.ToString() = guid Then
                DoLog("Player (" & playername & ") is banned and will be kicked.")
                BattlEyeKickPlayerByName(playername, "You are banned!")
                Exit Sub
            End If
        Next
    End Sub

    ' Kick player by ID without reason (kicking by id seems to be broken in DayZ SA)
    Public Sub BattlEyeKickPlayerByID(ByVal id As Integer)
        BattlEyeKickPlayerByID(id, "")
    End Sub

    ' Kick player by ID with reason (kicking by id seems to be broken in DayZ SA)
    Public Sub BattlEyeKickPlayerByID(ByVal id As Integer, ByVal reason As String)
        DoLog("kicking by id seems to be broken in DayZ SA")
        Exit Sub
        b.SendCommand("#kick """ & id.ToString() & """ " & reason)
        DoLog("#kick """ & id.ToString() & """ " & reason)
    End Sub

    ' Kick player by name without reason
    Public Sub BattlEyeKickPlayerByName(ByVal playername As String)
        playername = clear_playername(playername)
        BattlEyeKickPlayerByName(playername, "")
    End Sub

    ' Kick player by name with reason (kicking with a reason seems broken in DayZ SA)
    Public Sub BattlEyeKickPlayerByName(ByVal playername As String, ByVal reason As String)
        playername = clear_playername(playername)
        Dim new_kicker_thread = New Thread(Sub() Me.kickThread(playername))
        new_kicker_thread.Start()
        DoLog("#kick " & playername & " (be patient it can take a while, till the disconnect message of the kicked player appears")
    End Sub

    ' Disconnect on closing
    Private Sub main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If BattlEyeIsConnected() = True Then btn_disconnect_Click(Nothing, Nothing)
    End Sub

    Private Sub chk_show_password_CheckedChanged(sender As Object, e As EventArgs) Handles chk_show_password.CheckedChanged
        If chk_show_password.Checked = False Then
            txt_rcon_password.PasswordChar = "*"
        Else
            txt_rcon_password.PasswordChar = ""
        End If
    End Sub

    Private Sub btn_connect_Click(sender As Object, e As EventArgs) Handles btn_connect.Click
        SyncLock connection_lock
            If BattlEyeIsConnected() Then Exit Sub

            btn_connect.Enabled = False
            btn_disconnect.Enabled = True

            Dim loginCredentials As BattlEyeLoginCredentials = New BattlEyeLoginCredentials
            loginCredentials.Host = System.Net.IPAddress.Parse(txt_ip.Text)
            loginCredentials.Port = Integer.Parse(txt_port.Text)
            loginCredentials.Password = txt_rcon_password.Text


            If b Is Nothing Then
                b = New BattlEyeClient(loginCredentials)

                AddHandler b.BattlEyeMessageReceived, AddressOf BattlEyeMessageReceived
                AddHandler b.BattlEyeConnected, AddressOf BattlEyeConnected
                AddHandler b.BattlEyeDisconnected, AddressOf BattlEyeDisconnected

                b.ReconnectOnPacketLoss = False
            End If


            b.Connect()
        End SyncLock
    End Sub

    Private Sub btn_disconnect_Click(sender As Object, e As EventArgs) Handles btn_disconnect.Click
        timer_reconnect.Enabled = False
        btn_connect.Enabled = True
        btn_disconnect.Enabled = False
        b.Disconnect()
    End Sub

    Private Sub timer_reconnect_Tick(sender As Object, e As EventArgs) Handles timer_reconnect.Tick
        timer_reconnect.Enabled = False
        If chk_reconnect.Checked And btn_disconnect.Enabled Then btn_connect_Click(Nothing, Nothing)
    End Sub

    Private Sub btn_commandline_send_Click(sender As Object, e As EventArgs) Handles btn_commandline_send.Click
        If BattlEyeCommandSend(txt_commandline.Text) Then txt_commandline.Text = ""
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_all()
    End Sub

    ' Debug button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BattlEyeCommandSend(BattlEyeCommand.Players)
        'BattlEyeUpdatePlayer()
        'MsgBox(check_server_is_running())
        'do_backup(txt_mission_folder.Text, txt_backup_folder.Text, Integer.Parse(txt_backup_revisions.Text))
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        save_all()
    End Sub

    Private Sub btn_save_whitelist_Click(sender As Object, e As EventArgs) Handles btn_save_whitelist.Click
        save_all()
    End Sub

    ' Execute scheduled tasks
    Private Sub timer_schedule_Tick(sender As Object, e As EventArgs) Handles timer_schedule.Tick
        timer_schedule.Enabled = False
        schedule_current_tick = (Now.Subtract(timestamp_start_date)).TotalSeconds
        If BattlEyeIsConnected() And Math.Abs(schedule_current_tick - schedule_last_tick) > 0 Then
            For Each row As DataGridViewRow In data_schedule.Rows
                If row.IsNewRow Then Exit For
                If InStr(row.Cells(0).Value.ToString(), day_of_week_to_short_string(Now.DayOfWeek)) > 0 _
                    And row.Cells(1).Value.ToString() = get_24h_time() Then
                    Select Case LCase(row.Cells(2).Value.ToString())
                        Case "#restart"
                            timer_watchdog.Enabled = False
                            b.SendCommand("#shutdown")
                            wait_for_server_to_shutdown()
                            If chk_backup_on_restart.Checked Then
                                DoLog("Backup started")
                                do_backup(txt_mission_folder.Text, txt_backup_folder.Text, Integer.Parse(txt_backup_revisions.Text))
                                DoLog("Backup finished")
                            End If
                            timer_watchdog_Tick(Nothing, Nothing)
                        Case "#shutdown"
                            timer_watchdog.Enabled = False
                            b.SendCommand("#shutdown")
                            wait_for_server_to_shutdown()
                            If chk_backup_on_restart.Checked Then
                                DoLog("Backup started")
                                do_backup(txt_mission_folder.Text, txt_backup_folder.Text, Integer.Parse(txt_backup_revisions.Text))
                                DoLog("Backup finished")
                            End If
                            If Not btn_watchdog_start.Enabled Then timer_watchdog.Enabled = True
                        Case Else
                            b.SendCommand(row.Cells(2).Value.ToString())
                    End Select
                End If
            Next
        End If
        schedule_last_tick = schedule_current_tick
        timer_schedule.Enabled = True
    End Sub

    Private Sub btn_schedule_add_Click(sender As Object, e As EventArgs) Handles btn_schedule_add.Click
        If btn_schedule_add.Text = "new" Then
            data_schedule.CurrentRow.Selected = False
            Exit Sub
        End If

        Dim new_schedule_days As String = ""
        For Each curr_control As Control In grp_schedule_day.Controls
            If curr_control.GetType Is GetType(CheckBox) Then
                If CType(curr_control, CheckBox).Checked Then
                    If Len(new_schedule_days) > 0 Then new_schedule_days &= ","
                    new_schedule_days &= Mid(curr_control.Name, Len(curr_control.Name) - 1)
                End If
            End If
        Next
        If Len(new_schedule_days) < 1 Then
            MsgBox("You need to select a day!", vbExclamation)
            Exit Sub
        End If

        If Len(txt_schedule_command.Text) < 1 Then
            MsgBox("You need to set a command!", vbExclamation)
        End If

        data_schedule.Rows.Add(New String() {new_schedule_days, get_24h_time(datetime_schedule_time.Value), txt_schedule_command.Text})

        data_schedule.CurrentRow.Selected = False

        clear_schedule_inputs()

        save_schedule()
    End Sub

    Private Sub data_schedule_SelectionChanged(sender As Object, e As EventArgs) Handles data_schedule.SelectionChanged
        If data_schedule.Rows.Count > 0 AndAlso data_schedule.CurrentRow.Selected = True Then
            txt_schedule_command.Text = data_schedule.CurrentRow.Cells(2).Value.ToString()
            datetime_schedule_time.Value = DateTime.ParseExact(data_schedule.CurrentRow.Cells(1).Value.ToString(), "HH:mm:ss", Nothing)

            For Each curr_control As Control In grp_schedule_day.Controls
                If curr_control.GetType Is GetType(CheckBox) Then
                    If InStr(data_schedule.CurrentRow.Cells(0).Value.ToString(), Mid(curr_control.Name, Len(curr_control.Name) - 1)) > 0 Then
                        CType(curr_control, CheckBox).Checked = True
                    Else
                        CType(curr_control, CheckBox).Checked = False
                    End If
                End If
            Next

            btn_schedule_add.Text = "new"
            btn_schedule_change.Enabled = True
            btn_schedule_delete.Enabled = True
        Else
            btn_schedule_add.Text = "add"
            clear_schedule_inputs()
            btn_schedule_change.Enabled = False
            btn_schedule_delete.Enabled = False
        End If
    End Sub

    Private Sub btn_schedule_delete_Click(sender As Object, e As EventArgs) Handles btn_schedule_delete.Click
        data_schedule.Rows.RemoveAt(data_schedule.CurrentRow.Index)
        btn_schedule_change.Enabled = False
        btn_schedule_delete.Enabled = False
        If data_schedule.Rows.Count > 0 Then data_schedule.CurrentRow.Selected = False
        save_schedule()
    End Sub

    Private Sub btn_save_schedule_Click(sender As Object, e As EventArgs) Handles btn_save_schedule.Click
        save_schedule()
    End Sub

    Private Sub btn_schedule_change_Click(sender As Object, e As EventArgs) Handles btn_schedule_change.Click
        Dim new_schedule_days As String = ""
        For Each curr_control As Control In grp_schedule_day.Controls
            If curr_control.GetType Is GetType(CheckBox) Then
                If CType(curr_control, CheckBox).Checked Then
                    If Len(new_schedule_days) > 0 Then new_schedule_days &= ","
                    new_schedule_days &= Mid(curr_control.Name, Len(curr_control.Name) - 1)
                End If
            End If
        Next
        data_schedule.CurrentRow.SetValues(New String() {new_schedule_days, get_24h_time(datetime_schedule_time.Value), txt_schedule_command.Text})
        save_schedule()
    End Sub

    Private Sub btn_serverfolder_search_Click(sender As Object, e As EventArgs) Handles btn_serverfolder_search.Click
        If folderbrowser_server.ShowDialog() = DialogResult.OK Then
            If do_exist_server_files(folderbrowser_server.SelectedPath) Then
                txt_server_folder.Text = folderbrowser_server.SelectedPath
                If do_exist_battleye_files(folderbrowser_server.SelectedPath & "\battleye") Then txt_battleye_folder.Text = folderbrowser_server.SelectedPath & "\battleye"
                If do_exist_mission_files(folderbrowser_server.SelectedPath & "\mpmissions\dayzOffline.chernarusplus") Then txt_mission_folder.Text = folderbrowser_server.SelectedPath & "\mpmissions\dayzOffline.chernarusplus"
            Else
                MsgBox("Server files could not be found in this directory.", vbExclamation)
            End If
        End If
    End Sub

    Private Sub btn_battleyefolder_search_Click(sender As Object, e As EventArgs) Handles btn_battleyefolder_search.Click
        If folderbrowser_server.ShowDialog() = DialogResult.OK Then
            If do_exist_battleye_files(folderbrowser_server.SelectedPath) Then
                txt_battleye_folder.Text = folderbrowser_server.SelectedPath
            Else
                MsgBox("This seems to be not the mission folder, the file beserver.dll could not be found.", vbExclamation)
            End If
        End If
    End Sub

    Private Sub btn_backupfolder_search_Click(sender As Object, e As EventArgs) Handles btn_backupfolder_search.Click
        folderbrowser_server.ShowNewFolderButton = True
        If folderbrowser_server.ShowDialog() = DialogResult.OK Then
            txt_backup_folder.Text = folderbrowser_server.SelectedPath
        End If
        folderbrowser_server.ShowNewFolderButton = False
    End Sub

    Private Sub btn_missionfolder_search_Click(sender As Object, e As EventArgs) Handles btn_missionfolder_search.Click
        If folderbrowser_server.ShowDialog() = DialogResult.OK Then
            If do_exist_mission_files(folderbrowser_server.SelectedPath) Then
                txt_mission_folder.Text = folderbrowser_server.SelectedPath
            Else
                MsgBox("This seems to be not the mission folder, the file init.c could not be found.", vbExclamation)
            End If
        End If
    End Sub

    ' Autoscroll in log
    Private Sub rtxt_log_TextChanged(sender As Object, e As EventArgs) Handles rtxt_log.TextChanged
        If chk_autoscroll.Checked Then
            rtxt_log.SelectionStart = rtxt_log.Text.Length
            rtxt_log.ScrollToCaret()
        End If
    End Sub

    Private Sub chk_backup_on_restart_CheckedChanged(sender As Object, e As EventArgs) Handles chk_backup_on_restart.CheckedChanged
        If Len(txt_mission_folder.Text) < 1 Or Len(txt_backup_folder.Text) < 1 Then
            MsgBox("You must set the mission folder and backup folder first.", vbExclamation)
            Exit Sub
        End If
    End Sub

    Private Sub txt_backup_revisions_TextChanged(sender As Object, e As EventArgs) Handles txt_backup_revisions.TextChanged
        If Len(txt_backup_revisions.Text) > 0 AndAlso Integer.Parse(txt_backup_revisions.Text) < 1 Then
            MsgBox("Only numbers greater than 0 are allowed.", vbExclamation)
            txt_backup_revisions.Text = "20"
        End If
    End Sub

    Private Sub txt_backup_revisions_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_backup_revisions.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txt_backup_revisions_LostFocus(sender As Object, e As EventArgs) Handles txt_backup_revisions.LostFocus
        If Len(txt_backup_revisions.Text) < 1 OrElse Integer.Parse(txt_backup_revisions.Text) < 1 Then
            MsgBox("Only numbers greater than 0 are allowed.", vbExclamation)
            txt_backup_revisions.Text = "20"
        End If
    End Sub

    ' Start the watchdog to monitor if server is still running
    Private Sub btn_watchdog_start_Click(sender As Object, e As EventArgs) Handles btn_watchdog_start.Click
        If Len(txt_server_folder.Text) < 1 Then
            MsgBox("You must set the serverfolder to use the watchdog.", vbInformation)
            Exit Sub
        End If

        If Len(txt_battleye_folder.Text) < 1 Then
            Dim response As MsgBoxResult = MsgBox("No BattlEye folder is selected, all other features of EasyDayZ won't work without BattlEye!" & vbCrLf & vbCrLf &
                                                  "Do you want to continue?", vbYesNo + vbExclamation)
            If response = vbNo Then Exit Sub
        End If

        btn_watchdog_start.Enabled = False
        btn_watchdog_stop.Enabled = True
        timer_watchdog_Tick(Nothing, Nothing)
    End Sub

    Private Sub btn_watchdog_stop_Click(sender As Object, e As EventArgs) Handles btn_watchdog_stop.Click
        btn_watchdog_start.Enabled = True
        btn_watchdog_stop.Enabled = False
        timer_watchdog.Enabled = False
    End Sub

    ' Check if server is running and start it, if required
    Private Sub timer_watchdog_Tick(sender As Object, e As EventArgs) Handles timer_watchdog.Tick
        timer_watchdog.Enabled = False

        If Not do_exist_server_files(txt_server_folder.Text) Then
            btn_watchdog_start.Enabled = True
            btn_watchdog_stop.Enabled = False
            DoLog("Could not find server files in " & txt_server_folder.Text & "! Watchdog disabled!")
            Exit Sub
        End If

        If Len(txt_battleye_folder.Text) > 0 AndAlso Not do_exist_battleye_files(txt_battleye_folder.Text) Then
            btn_watchdog_start.Enabled = True
            btn_watchdog_stop.Enabled = False
            DoLog("Could not find battleye files in " & folderbrowser_server.SelectedPath & "! Watchdog disabled!")
            Exit Sub
        End If

        If Not check_server_is_running() Then
            start_server(txt_server_folder.Text, txt_battleye_folder.Text, txt_port.Text, txt_mods.Text)
            timer_watchdog.Interval = 10000
        End If

        If Not btn_watchdog_start.Enabled Then timer_watchdog.Enabled = True
    End Sub

    ' Send commands
    Private Sub txt_commandline_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_commandline.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(txt_commandline.Text) > 0 Then
                btn_commandline_send_Click(sender, e)
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    ' Add a player to the whitelist
    Private Sub add_player_to_whitelist(ByVal guid As String, ByVal playername As String)
        For Each row As DataGridViewRow In data_whitelist.Rows
            If row.IsNewRow Then Exit For
            If row.Cells(0).Value.ToString() = guid Then
                MsgBox("This GUID is already whitelisted.", vbInformation)
                Exit Sub
            End If
        Next
        AddRowDatagridview(data_whitelist, New String() {guid, playername})
        MsgBox("GUID has been added to the whitelist.", vbInformation)
    End Sub

    ' Add a player to the banlist
    Private Sub add_player_to_banlist(ByVal guid As String, ByVal playername As String, ByVal reason As String)
        For Each row As DataGridViewRow In data_bans.Rows
            If row.IsNewRow Then Exit For
            If row.Cells(0).Value.ToString() = guid Then
                MsgBox("This GUID is already banned.", vbInformation)
                Exit Sub
            End If
        Next
        AddRowDatagridview(data_bans, New String() {guid, playername, get_sortable_date(), reason})
        save_bans()
        MsgBox("GUID has been banned.", vbInformation)
    End Sub

    ' Remove a player from the banlist
    Private Sub remove_player_from_banlist(ByVal guid As String)
        For Each row As DataGridViewRow In data_bans.Rows
            If row.IsNewRow Then Exit For
            If row.Cells(0).Value.ToString() = guid Then
                RemoveRowDatagridview(data_bans, row)
                save_bans()
                MsgBox("The GUID has been unbanned.", vbInformation)
                Exit Sub
            End If
        Next

        MsgBox("GUID not found.", vbExclamation)
    End Sub

    Private Sub context_menu_send_message_to_player(ByVal playerid As String, ByVal playername As String)
        Dim message As String = InputBox("Enter the message for " & playername & ":")
        If Len(message) > 0 Then
            BattlEyeCommandSend("say " & playerid & " " & message)
        End If
    End Sub

    Private Sub context_menu_ban_player(ByVal guid As String, ByVal playername As String)
        Dim reason As String = InputBox("Reason for ban " & playername & ":")
        If Len(reason) < 1 Then
            MsgBox("No reason entered, ban cancelled.")
            Exit Sub
        End If
        add_player_to_banlist(guid, playername, reason)
    End Sub

    Private Sub data_players_MouseClick(sender As Object, e As MouseEventArgs) Handles data_players.MouseClick
        If e.Button = MouseButtons.Right Then

            Dim m As New ContextMenu()

            Dim row_id As Integer = data_players.HitTest(e.X, e.Y).RowIndex
            Dim menu_item_kick As New MenuItem("kick")
            Dim menu_item_whitelist As New MenuItem("whitelist")
            Dim menu_item_send_message As New MenuItem("send message")
            Dim menu_item_ban As New MenuItem("ban")

            AddHandler menu_item_kick.Click, Sub() BattlEyeKickPlayerByName(data_players.Rows(row_id).Cells(1).Value.ToString)
            AddHandler menu_item_whitelist.Click, Sub() add_player_to_whitelist(data_players.Rows(row_id).Cells(2).Value.ToString, data_players.Rows(row_id).Cells(1).Value.ToString)
            AddHandler menu_item_send_message.Click, Sub() context_menu_send_message_to_player(data_players.Rows(row_id).Cells(0).Value.ToString, data_players.Rows(row_id).Cells(1).Value.ToString)
            AddHandler menu_item_ban.Click, Sub() context_menu_ban_player(data_players.Rows(row_id).Cells(2).Value.ToString, data_players.Rows(row_id).Cells(1).Value.ToString)

            If row_id >= 0 Then
                m.MenuItems.Add(menu_item_kick)
                m.MenuItems.Add(menu_item_whitelist)
                m.MenuItems.Add(menu_item_send_message)
                m.MenuItems.Add(menu_item_ban)
            End If

            m.Show(data_players, New Point(e.X, e.Y))

        End If
    End Sub

    Private Sub data_player_history_MouseClick(sender As Object, e As MouseEventArgs) Handles data_player_history.MouseClick
        If e.Button = MouseButtons.Right Then
            Dim m As New ContextMenu()

            Dim row_id As Integer = data_player_history.HitTest(e.X, e.Y).RowIndex
            Dim menu_item_whitelist As New MenuItem("whitelist")
            Dim menu_item_ban As New MenuItem("ban")

            AddHandler menu_item_whitelist.Click, Sub() add_player_to_whitelist(data_player_history.Rows(row_id).Cells(1).Value.ToString, data_player_history.Rows(row_id).Cells(0).Value.ToString)
            AddHandler menu_item_ban.Click, Sub() context_menu_ban_player(data_player_history.Rows(row_id).Cells(1).Value.ToString, data_player_history.Rows(row_id).Cells(0).Value.ToString)

            If row_id >= 0 Then
                m.MenuItems.Add(menu_item_whitelist)
                m.MenuItems.Add(menu_item_ban)
            End If

            m.Show(data_player_history, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub data_bans_MouseClick(sender As Object, e As MouseEventArgs) Handles data_bans.MouseClick
        If e.Button = MouseButtons.Right Then
            Dim m As New ContextMenu()

            Dim row_id As Integer = data_bans.HitTest(e.X, e.Y).RowIndex
            Dim menu_item_unban As New MenuItem("unban")

            AddHandler menu_item_unban.Click, Sub() remove_player_from_banlist(data_bans.Rows(row_id).Cells(0).Value.ToString)

            If row_id >= 0 AndAlso Not data_bans.Rows(row_id).IsNewRow Then
                m.MenuItems.Add(menu_item_unban)
            End If

            m.Show(data_bans, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub data_whitelist_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles data_whitelist.CellEndEdit
        save_whitelist()
        save_settings()
    End Sub

    Private Sub data_bans_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles data_bans.CellEndEdit
        save_bans()
    End Sub

    Private Sub btn_save_startup_parameter_Click(sender As Object, e As EventArgs) Handles btn_save_startup_parameter.Click
        save_settings()
    End Sub
End Class


Imports System.IO

Module help_methods
    Private Function check_process_is_running(ByVal process_name As String) As Boolean
        Dim p() As Process
        p = Process.GetProcessesByName(process_name)
        If p.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function check_server_is_running() As Boolean
        Return check_process_is_running("DayZServer_x64")
    End Function

    Public Sub start_server(ByVal path_server As String, ByVal path_battleye As String, ByVal port As String, ByVal mods_list As String)
        Dim battleye_arg As String = ""
        Dim mods_arg As String = ""
        If Len(path_battleye) > 0 Then battleye_arg = " ""-BEpath=" & path_battleye & """"
        If Len(mods_list) > 0 Then mods_arg = " ""-mod=" & Trim(mods_list) & """"
        'MsgBox(path_server & "\DayZServer_x64.exe " & """-config=" & path_server & "\serverDZ.cfg"" -port=" & port & " -dologs -adminlog -netlog -freezecheck" & battleye_arg)
        main.DoLog("(Debug) Server-Args: " & """-config=" & path_server & "\serverDZ.cfg"" -port=" & port & " -dologs -adminlog -netlog -freezecheck" & battleye_arg & mods_arg)

        Dim myprocess As ProcessStartInfo = New ProcessStartInfo
        myprocess.WorkingDirectory = path_server
        If main.chk_dzsalmod.Checked = False Then
            myprocess.FileName = "DayZServer_x64.exe"
            'Process.Start(path_server & "\DayZServer_x64.exe", """-config=" & path_server & "\serverDZ.cfg"" -port=" & port & " -dologs -adminlog -netlog -freezecheck" & battleye_arg & mods_arg)
        Else
            myprocess.FileName = "DZSALModServer.exe"
            'Process.Start(path_server & "\DZSALModServer.exe", """-config=" & path_server & "\serverDZ.cfg"" -port=" & port & " -dologs -adminlog -netlog -freezecheck" & battleye_arg & mods_arg)
        End If
        myprocess.Arguments = """-config=" & path_server & "\serverDZ.cfg"" -port=" & port & " -dologs -adminlog -netlog -freezecheck" & battleye_arg & mods_arg
        Process.Start(myprocess)
    End Sub

    Public Sub wait_for_server_to_shutdown()
        While check_server_is_running()
            Threading.Thread.Sleep(100)
            Application.DoEvents()
        End While
    End Sub

    Public Sub do_backup(ByVal path_mission As String, ByVal path_backup As String, ByVal max_backups As Integer)
        If Not Directory.Exists(path_backup) Then
            main.DoLog("Backup-Dir not found! No backup done!")
            Exit Sub
        End If

        If Not Directory.Exists(path_mission & "\storage_1") Then
            main.DoLog("Misson storage (" & path_mission & "\storage_1) not found! No backup done!")
            Exit Sub
        End If

        wait_for_server_to_shutdown()


        Dim backups_found As New List(Of String)
        For Each dir As String In Directory.GetDirectories(path_backup, "EasyDayz-Backup-*")
            backups_found.Add(dir)
        Next

        If backups_found.Count >= max_backups Then
            backups_found.Sort()
            While backups_found.Count >= max_backups
                Directory.Delete(backups_found.Item(0), True)
                backups_found.RemoveAt(0)
            End While
        End If

        Dim new_directory As String = path_backup & "\EasyDayz-Backup-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")
        Directory.CreateDirectory(new_directory)
        My.Computer.FileSystem.CopyDirectory(path_mission & "\storage_1", new_directory)
    End Sub

    Public Function do_exist_server_files(ByVal path As String) As Boolean
        Return File.Exists(path & "\DayZServer_x64.exe") And File.Exists(path & "\serverDZ.cfg")
    End Function

    Public Function do_exist_battleye_files(ByVal path As String) As Boolean
        Return File.Exists(path & "\beserver.dll") Or File.Exists(path & "\BEServer_x64.dll")
    End Function

    Public Function do_exist_mission_files(ByVal path As String) As Boolean
        Return File.Exists(path & "\init.c")
    End Function

    Public Function get_sortable_date()
        Return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    End Function

    Public Function get_24h_time() As String
        Return DateTime.Now.ToString("HH:mm:ss")
    End Function

    Public Function get_24h_time(ByVal in_time As DateTime) As String
        Return in_time.ToString("HH:mm:ss")
    End Function

    Public Function clear_guid(ByVal guid As String) As String
        If InStr(guid, "(") > 0 Then
            Return Mid(guid, 1, InStr(guid, "(") - 1)
        Else
            Return guid
        End If
    End Function

    Public Function clear_playername(ByVal playername As String) As String
        Return playername.Replace(" (Lobby)", "")
    End Function

    Public Function day_of_week_to_short_string(ByVal day_of_week As Integer) As String
        Dim days As String() = {"su", "mo", "tu", "we", "th", "fr", "sa"}
        Return days(day_of_week)
    End Function

    Public Sub clear_schedule_inputs()
        main.txt_schedule_command.Text = ""
        For Each curr_control As Control In main.grp_schedule_day.Controls
            If curr_control.GetType Is GetType(CheckBox) Then
                CType(curr_control, CheckBox).Checked = False
            End If
        Next
    End Sub

    Public Function cell_to_string(ByVal my_in As DataGridViewTextBoxCell) As String
        If my_in.Value Is Nothing Then
            Return ""
        Else
            Return my_in.Value.ToString()
        End If
    End Function

    Public Function get_application_version() As String
        Dim my_version As String = My.Application.Info.Version.ToString
        Return Left(my_version, my_version.LastIndexOf("."))
    End Function
End Module
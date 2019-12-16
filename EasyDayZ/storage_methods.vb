Imports System.IO

Module storage_methods
    Dim storage_path As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath)

    ' Help function to save the state of all textboxes
    Private Function get_all_textboxes(ByVal skip_password As Boolean) As List(Of TextBox)
        Dim all_textboxes As New List(Of TextBox)
        all_textboxes.Add(main.txt_ip)
        all_textboxes.Add(main.txt_port)
        all_textboxes.Add(main.txt_server_folder)
        all_textboxes.Add(main.txt_battleye_folder)
        all_textboxes.Add(main.txt_backup_folder)
        all_textboxes.Add(main.txt_mission_folder)
        all_textboxes.Add(main.txt_whitelist_kick_text)
        all_textboxes.Add(main.txt_backup_revisions)
        all_textboxes.Add(main.txt_mods)

        If skip_password = False Then
            all_textboxes.Add(main.txt_rcon_password)
        Else
            Dim dummy_textbox As New TextBox
            dummy_textbox.Name = "txt_rcon_password"
            all_textboxes.Add(dummy_textbox)
        End If

        Return all_textboxes
    End Function

    ' Help function to save the state of all checkboxes
    Private Function get_all_checkboxes() As List(Of CheckBox)
        Dim all_checkboxes As New List(Of CheckBox)
        all_checkboxes.Add(main.chk_reconnect)
        all_checkboxes.Add(main.chk_save_password)
        all_checkboxes.Add(main.chk_show_password)
        all_checkboxes.Add(main.chk_whitelist_enabled)
        all_checkboxes.Add(main.chk_backup_on_restart)
        all_checkboxes.Add(main.chk_dzsalmod)

        Return all_checkboxes
    End Function

    ' restore broken savefiles
    Private Sub restore_broken_files(ByVal file_to_check As String)
        If File.Exists(file_to_check & ".tmp") Then
            If File.Exists(file_to_check) Then
                File.Delete(file_to_check & ".tmp")
            Else
                File.Move(file_to_check & ".tmp", file_to_check)
            End If
        End If
    End Sub

    ' save a datagrid to a file
    Public Sub datagrid_to_file(ByRef my_datagrid As DataGridView, ByVal filename As String)
        Dim path As String = storage_path & "\" & filename

        Dim output As String = ""
        Dim curr_line As String = ""

        For Each row As DataGridViewRow In my_datagrid.Rows
            If row.IsNewRow Then Exit For
            If Len(output) > 0 Then output &= vbCrLf
            curr_line = ""
            For Each cell As DataGridViewCell In row.Cells
                If Len(curr_line) > 0 Then
                    curr_line &= vbTab
                End If
                If Not cell.Value Is Nothing Then
                    curr_line &= cell_to_string(cell).Replace(vbTab, " ")
                Else
                    curr_line &= "-"
                End If
            Next
            output &= curr_line
        Next

        File.WriteAllText(path & ".tmp", output)

        If File.Exists(path) Then File.Delete(path)
        File.Move(path & ".tmp", path)
    End Sub

    ' load a file to a datagrid
    Public Sub file_2_datagrid(ByVal filename As String, ByRef my_datagrid As DataGridView)
        Dim path As String = storage_path & "\" & filename

        restore_broken_files(path)
        If Not File.Exists(path) Then Exit Sub

        Dim file_content = File.ReadAllText(path)
        Dim my_string_reader As New StringReader(file_content)
        Dim current_line As String
        Dim current_cols As String()

        While my_string_reader.Peek() > -1
            current_line = my_string_reader.ReadLine()
            If Len(current_line) < 1 Then Continue While

            current_cols = current_line.Split(vbTab)
            If my_datagrid.Columns.Count <> current_cols.Count Then Continue While

            main.AddRowDatagridview(my_datagrid, current_cols)
        End While
    End Sub

    Public Sub save_all()
        save_settings()
        save_whitelist()
        save_schedule()
        'save_player_history()
        save_bans()
    End Sub

    Public Sub load_all()
        load_settings()
        load_whitelist()
        load_schedule()
        load_player_history()
        load_bans()
    End Sub

    Public Sub save_settings()
        Dim all_textboxes As List(Of TextBox) = get_all_textboxes(Not main.chk_save_password.Checked)
        Dim all_checkboxes As List(Of CheckBox) = get_all_checkboxes()

        Dim config_file_path As String = storage_path & "\config.cfg"

        Dim output As String = ""
        For Each curr_textbox As TextBox In all_textboxes
            If Len(output) > 0 Then output &= vbCrLf
            output &= curr_textbox.Name & "=" & curr_textbox.Text
        Next

        For Each curr_checkbox As CheckBox In all_checkboxes
            If Len(output) > 0 Then output &= vbCrLf
            output &= curr_checkbox.Name & "=" & curr_checkbox.Checked.ToString()
        Next

        File.WriteAllText(config_file_path & ".tmp", output)

        If File.Exists(config_file_path) Then File.Delete(config_file_path)
        File.Move(config_file_path & ".tmp", config_file_path)
    End Sub

    Public Sub load_settings()
        Dim all_textboxes As List(Of TextBox) = get_all_textboxes(False)
        Dim all_checkboxes As List(Of CheckBox) = get_all_checkboxes()

        Dim config_file_path As String = storage_path & "\config.cfg"

        restore_broken_files(config_file_path)

        If Not File.Exists(config_file_path) Then Exit Sub
        Dim config_file_content = File.ReadAllText(config_file_path)

        Dim my_string_reader As New StringReader(config_file_content)

        Dim current_line As String
        Dim current_name As String
        Dim current_value As String
        Dim current_type As String

        While my_string_reader.Peek() > -1
            current_line = my_string_reader.ReadLine()
            If Len(current_line) < 1 Or InStr(current_line, "_") < 2 Or InStr(current_line, "=") < InStr(current_line, "_") Then Continue While
            current_name = Mid(current_line, 1, InStr(current_line, "=") - 1)
            current_value = Mid(current_line, InStr(current_line, "=") + 1)
            current_type = Mid(current_line, 1, InStr(current_line, "_") - 1)

            Select Case current_type
                Case "txt"
                    For Each current_textbox As TextBox In all_textboxes
                        If current_textbox.Name = current_name Then
                            current_textbox.Text = current_value
                            Exit For
                        End If
                    Next
                Case "chk"
                    For Each current_checkbox As CheckBox In all_checkboxes
                        If current_checkbox.Name = current_name Then
                            current_checkbox.Checked = Boolean.Parse(current_value)
                            Exit For
                        End If
                    Next
            End Select
        End While

    End Sub

    Public Sub save_whitelist()
        Dim whitelist_file_path As String = storage_path & "\whitelist.txt"

        Dim output As String = ""

        For Each row As DataGridViewRow In main.data_whitelist.Rows
            If row.IsNewRow Then Exit For
            If Len(cell_to_string(row.Cells(0))) < 1 Then Continue For

            If Len(output) > 0 Then output &= vbCrLf

            output &= cell_to_string(row.Cells(0)) & " " & cell_to_string(row.Cells(1))
        Next

        File.WriteAllText(whitelist_file_path & ".tmp", output)

        If File.Exists(whitelist_file_path) Then File.Delete(whitelist_file_path)
        File.Move(whitelist_file_path & ".tmp", whitelist_file_path)
    End Sub

    Public Sub load_whitelist()
        Dim whitelist_file_path As String = storage_path & "\whitelist.txt"

        restore_broken_files(whitelist_file_path)

        If Not File.Exists(whitelist_file_path) Then Exit Sub
        Dim whitelist_file_content = File.ReadAllText(whitelist_file_path)

        Dim my_string_reader As New StringReader(whitelist_file_content)

        Dim current_line As String

        While my_string_reader.Peek() > -1
            current_line = my_string_reader.ReadLine()
            If Len(current_line) < 1 Then Continue While

            If InStr(current_line, " ") > 1 And Len(current_line) > 3 Then
                main.data_whitelist.Rows.Add(New String() {Mid(current_line, 1, InStr(current_line, " ") - 1), Mid(current_line, InStr(current_line, " ") + 1)})
            Else
                main.data_whitelist.Rows.Add(New String() {current_line, ""})
            End If
        End While
    End Sub

    Public Sub save_schedule()
        Dim schedule_file_path As String = storage_path & "\schedule.txt"

        Dim output As String = ""

        For Each row As DataGridViewRow In main.data_schedule.Rows
            If row.IsNewRow Then Exit For
            If Len(cell_to_string(row.Cells(0))) < 1 Then Continue For

            If Len(output) > 0 Then output &= vbCrLf
            output &= cell_to_string(row.Cells(0)) & " " & cell_to_string(row.Cells(1)) & " " & cell_to_string(row.Cells(2))
        Next

        File.WriteAllText(schedule_file_path & ".tmp", output)

        If File.Exists(schedule_file_path) Then File.Delete(schedule_file_path)
        File.Move(schedule_file_path & ".tmp", schedule_file_path)
    End Sub

    Public Sub load_schedule()
        Dim schedule_file_path As String = storage_path & "\schedule.txt"

        restore_broken_files(schedule_file_path)

        If Not File.Exists(schedule_file_path) Then Exit Sub
        Dim schedule_file_content = File.ReadAllText(schedule_file_path)

        Dim my_string_reader As New StringReader(schedule_file_content)

        Dim current_line As String
        Dim current_days As String

        While my_string_reader.Peek() > -1
            current_line = my_string_reader.ReadLine()
            If Len(current_line) < 1 Then Continue While

            If InStr(current_line, " ") > 1 And Len(current_line) > 3 Then
                current_days = Mid(current_line, 1, InStr(current_line, " ") - 1)
                current_line = Mid(current_line, Len(current_days) + 2)
                If InStr(current_line, " ") > 1 And Len(current_line) > 3 Then
                    main.data_schedule.Rows.Add(New String() {current_days, Mid(current_line, 1, InStr(current_line, " ") - 1), Mid(current_line, InStr(current_line, " ") + 1)})
                End If
            End If
        End While
    End Sub

    Public Sub save_bans()
        datagrid_to_file(main.data_bans, "bans.txt")
    End Sub

    Public Sub load_bans()
        file_2_datagrid("bans.txt", main.data_bans)
    End Sub

    Public Sub save_player_history()
        datagrid_to_file(main.data_player_history, "player_history.txt")
    End Sub

    Public Sub load_player_history()
        file_2_datagrid("player_history.txt", main.data_player_history)
    End Sub
End Module

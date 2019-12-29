Module chat_methods
    Private Function get_chat_message(ByVal be_message As String) As BEChatMessage
        Dim chat_tag = "(Global)"
        Dim message_start_tag = ": "
        If Left(be_message, Len(chat_tag)) = chat_tag Then
            Dim chat_start As Integer = be_message.IndexOf(message_start_tag)
            If chat_start > -1 Then
                If chat_start + 3 <= Len(be_message) Then
                    Dim chat_message = Mid(be_message, chat_start + 3)
                    ' -1 for the space after chat_tag
                    Dim chat_sender = Mid(be_message, Len(chat_tag) + 2, chat_start - Len(chat_tag) - 1)

                    Return New BEChatMessage(chat_tag, chat_sender, chat_message)
                End If
            End If
        End If
        Return Nothing
    End Function

    Public Sub chat_commands_find(ByVal be_message As String, ByRef main_form As EasyDayZ.main)
        Dim msg_obj As BEChatMessage = get_chat_message(be_message)
        Dim command_tag As String = "!"
        If msg_obj IsNot Nothing Then
            If Left(msg_obj.message, 1) = command_tag Then
                chat_commands_handle(msg_obj.sender, Mid(msg_obj.message, 2), main_form)
            End If
        End If
    End Sub

    Private Sub chat_commands_handle(ByVal sender As String, ByVal command_text As String, ByRef main_form As EasyDayZ.main)
        Dim command As String = ""
        Dim command_args_text As String = ""
        If command_text.IndexOf(" ") > -1 Then
            command = Left(command_text, command_text.IndexOf(" "))
            command_args_text = Mid(command_text, command_text.IndexOf(" ") + 2)
        Else
            command = command_text
        End If

        Dim command_sender_id As Integer = get_player_id_by_name(sender, main_form.data_players)
        If command_sender_id < 0 Then
            main_form.DoLog("Player for command not found - Sender: " & sender & " // Command: " & command & " // Command_args: " & command_args_text)
            Exit Sub
        End If

        Select Case LCase(command)
            Case "help"
                main_form.BattlEyeCommandSend("say " & command_sender_id & " Following commands are available:")
                main_form.BattlEyeCommandSend("say " & command_sender_id & " !ping - for checking the server connection, the server vill response with ""Pong!""")
                main_form.BattlEyeCommandSend("say " & command_sender_id & " !players - will list all connected players")
                main_form.DoLog("Handled command - Sender: " & sender & " // Command: " & command & " // Command_args: " & command_args_text)
            Case "ping"
                main_form.BattlEyeCommandSend("say " & command_sender_id & " Pong!")
                main_form.DoLog("Handled command - Sender: " & sender & " // Command: " & command & " // Command_args: " & command_args_text)
            Case "players"
                chat_commands_players(command_sender_id, main_form)
                main_form.DoLog("Handled command - Sender: " & sender & " // Command: " & command & " // Command_args: " & command_args_text)
            Case Else
                main_form.BattlEyeCommandSend("say " & command_sender_id & " Unknown command!")
                main_form.DoLog("Unknown command - Sender: " & sender & " // Command: " & command & " // Command_args: " & command_args_text)
        End Select

    End Sub

    Private Sub chat_commands_players(ByVal command_sender_id As Integer, ByRef main_form As EasyDayZ.main)
        Dim players_list As String = ""
        For Each row As DataGridViewRow In main_form.data_players.Rows
            If row.IsNewRow Then Exit For
            If Len(players_list) > 0 Then
                players_list &= " ," & cell_to_string(row.Cells(1))
            Else
                players_list = cell_to_string(row.Cells(1))
            End If
        Next

        main_form.BattlEyeCommandSend("say " & command_sender_id & " This players are connected to the server: " & players_list)
    End Sub
End Module

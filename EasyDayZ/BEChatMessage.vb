Public Class BEChatMessage
    Public scope As String
    Public sender As String
    Public message As String

    Public Sub New()
        sender = ""
        message = ""
        scope = ""
    End Sub

    Public Sub New(ByVal in_scope As String, ByVal in_sender As String, ByVal in_message As String)
        scope = in_scope
        sender = in_sender
        message = in_message
    End Sub
End Class

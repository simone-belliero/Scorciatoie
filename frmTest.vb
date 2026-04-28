



Public Class frmTest
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tx As String = My.Computer.FileSystem.ReadAllText(MyPath & "Shorcuts.shr")


        tx = tx.Replace("[form]", Chr(29))

        Dim str() As String = tx.Split(Chr(29))


        Dim a = 0

    End Sub
End Class
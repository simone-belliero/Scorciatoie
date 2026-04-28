Public Class Form1

    Public x As Integer = 0
    Public y As Integer = 0
    Public pos As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Load_CFG()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = x
        Label2.Text = y
        Label3.Text = pos

    End Sub
End Class

Public Class Group
    Public Property Name As String = ""
    Public Property Color As Color = Color.DodgerBlue
    Public Property PositionX As Integer = 0
    Public Property PositionY As Integer = 0
    Public Property IsVisible As Boolean = True
    Public Property Elements As New List(Of Element)
End Class
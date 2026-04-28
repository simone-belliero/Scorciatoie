Public Class Settings

    ' === Informazioni App ===
    Public Property AppVersion As String = "6.4"
    Public Property MyPath As String = System.AppDomain.CurrentDomain.BaseDirectory
    Public Property MyIniFilePath As String = ""

    ' === Aspetto Generale ===
    Public Property ButtonSize As Integer = 32

    ' === Posizione predefinita ===
    Public Property DefaultPositionX As Integer = 50
    Public Property DefaultPositionY As Integer = 100

    ' === Comportamento ===
    Public Property ShowTooltips As Boolean = True
    Public Property AnimationSpeed As Integer = 150

    ' === Path e Config ===
    Public Property ConfigFilePath As String = ""
    Public Property IconsFolder As String = ""

    ' === Aspetto Barre ===
    Public Property BarSize As New Size(42, 42)
    Public Property BarWidth As Integer = 42
    Public Property DefaultOffset As Integer = 0
    Public Property SpaceBetweenBars As Integer = 10

    ' === Colori ===
    Public Property BarColor As Color = Color.FromArgb(30, 30, 30)
    Public Property HoverColor As Color = Color.FromArgb(60, 60, 60)
    Public Property TextColor As Color = Color.White

    ' === Clipboard ===
    Public Property ClipboardCloseColor As Color = Color.DarkGray
    Public Property ClipboardOpenColor As Color = Color.LightGray
    Public Property ClipboardTextColor As Color = Color.Black
    Public Property ClipboardElementsNumber As Integer = 5

    ' === Testi Fissi ===
    Public Property FixedTextCloseColor As Color = Color.DarkGray
    Public Property FixedTextOpenColor As Color = Color.LightGray
    Public Property FixedTextTextColor As Color = Color.Black
    Public Property FixedTextElementsNumber As Integer = 5

    ' === Dati principali ===
    Public Property Groups As New List(Of Group)

    ' === Altre proprietà comuni ===
    Public Property IniSplitChar As String = "|"
    Public Property TotalWidth As Integer = 0
    Public Property LinkFileName As String = ""
    Public Property AlwaysOnTop As Boolean = True
    Public Property Opacity As Double = 0.95

End Class
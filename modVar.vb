Imports Microsoft.Win32
Imports IWshRuntimeLibrary
Imports System.IO


Module modVar




    Public MyPath As String = System.AppDomain.CurrentDomain.BaseDirectory '& "\"
    Public MyIniFilePath As String = MyPath & "cfg.ini"
    Public myInifile As New IniFile

    '[main]
    'Public _form_number As Integer = 1
    Public _offset_position As Integer = 0 ' offset dal centro
    Public _width As Integer = 10
    Public _ini_split_char As String = "|"
    Public _link_file_name As String = ""
    Public mySize As New Size(20, 5)


    Public _clipboard_close_color As Color
    Public _clipboard_open_color As Color
    Public _clipboard_text_color As Color
    Public _clipboard_elements_number As Integer = 5

    Public _clipboard_fixed_lines As New List(Of String)

    Public _fixedtext_close_color As Color
    Public _fixedtext_open_color As Color
    Public _fixedtext_text_color As Color
    Public _fixedtext_elements_number As Integer = 5

    Public _fixedtext_fixed_lines As New List(Of String)

    'array per form
    Public _closed_color(10) As Color
    Public _opened_color(10) As Color
    Public _text_color(10) As Color



    Public _space_between_forms As Integer = 10

    Public LockOpen As Integer = -1 ' As Boolean = False

    Public SplitChar As String = "|"

    Public ActualFormOpened As Integer = -1

    Public FormList As New List(Of frmElementsGroup)

    Public at_least_one_CMS_opened As Boolean = False


    Public at_least_one_form_opened As Boolean = False

    Public LinkList As New List(Of String) ' ObjectModel.ReadOnlyCollection(Of String)

    Public distance_between_form_elements As Integer = 10

    Public total_width As Integer

    Public SpecialFoldersName As New List(Of String)
    Public SpecialFoldersIndex As New List(Of Integer)
    Public SpecialFoldersDescription As New List(Of String)

    'Public cfg() As String

    Public Sub MakeShortCut(ByVal arguments As String, ByVal targetPath As String,
                            ByVal windowstyle As Integer, ByVal description As String,
                            ByVal workingDirectory As String, ByVal iconLocation As String, ByVal LinkName As String)

        Dim wsh As WshShell = New WshShell
        Dim shortcut As IWshRuntimeLibrary.IWshShortcut

        shortcut = CType(wsh.CreateShortcut((Environment.GetFolderPath _
            (Environment.SpecialFolder.Startup) & "\" & LinkName & ".lnk")),
            IWshRuntimeLibrary.IWshShortcut)
        shortcut.Arguments = arguments
        shortcut.TargetPath = targetPath
        shortcut.WindowStyle = windowstyle
        shortcut.Description = description
        shortcut.WorkingDirectory = workingDirectory
        shortcut.IconLocation = iconLocation
        shortcut.Save()
    End Sub

    Public Sub CreateShortCut()
        MakeShortCut("", Application.ExecutablePath, 1, "Scorciatoie_" & My.Application.Info.Version.ToString, Application.StartupPath, Application.ExecutablePath, "Scorciatoie_" & My.Application.Info.Version.ToString) ' Application.ProductName)
    End Sub

    Public Sub RemoveShortCut()
        'To create Start shortcut in the windows Startup folder: 
        Dim Shortcut As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)

        'Name the Shortcut you want to delete, Example \ScreenLocker.Ink
        Dim ShortcutPath As String = Shortcut & "\" & "Scorciatoie_" & My.Application.Info.Version.ToString & ".lnk" ' Application.ProductName & ".lnk"


        'To delete the shortcut:
        If LinkExist() Then
            IO.File.Delete(ShortcutPath)
        End If

    End Sub

    Public Function LinkExist() As Boolean
        'To create Start shortcut in the windows Startup folder: 
        Dim Shortcut As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)

        'Name the Shortcut you want to delete, Example \ScreenLocker.Ink
        Dim ShortcutPath As String = Shortcut & "\" & "Scorciatoie_" & My.Application.Info.Version.ToString & ".lnk" ' Application.ProductName & ".lnk"

        'To delete the shortcut:
        If IO.File.Exists(ShortcutPath) Then
            Return True
        End If

        Return False
    End Function


End Module

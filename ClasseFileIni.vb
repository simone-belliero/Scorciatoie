
Public Class FileIni

	Public Shared FileIniPath As String = System.AppDomain.CurrentDomain.BaseDirectory & "\fileini.ini"
    Public Shared EnabledError As Boolean = True
    Public Shared BoolTrueValue As String = "1"
    Public Shared BoolFalseValue As String = "0"

#Region "--- API ---"

    Private Declare Auto Function GetPrivateProfileString Lib "kernel32.dll" (ByVal lpApplicationName As String, _
            ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, _
            ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Private Declare Auto Function GetPrivateProfileSection Lib "kernel32.dll" (ByVal lpApplicationName As String, _
             ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Private Declare Auto Function WritePrivateProfileString Lib "kernel32.dll" (ByVal lpApplicationName As String, _
            ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "--- READ FUNCTIONS ---"

    Public Shared Function ReadString(ByVal Section As String, ByVal Key As String, Optional ByVal Value As String = "") As String
        Dim Result As String
        Dim RetVal As String = New String(" ", 255)
        Dim LenResult As Integer
        Dim ErrString As String = ""
        LenResult = GetPrivateProfileString(Section, Key, "", RetVal, RetVal.Length, FileIniPath)
        If LenResult = 0 Then
            If Not (My.Computer.FileSystem.FileExists(FileIniPath)) Then
                ErrString = "Impossibile trovare il file " & FileIniPath
            Else
                ErrString = "Impossibile eseguire l'operazione: la sezione o la chiave sono errate oppure l'accesso al file non è consentito"
            End If
            'If EnabledError Then Throw New IniException(ErrString)
            Return Value
        End If
        Result = RetVal.Substring(0, LenResult)
        Return Result
    End Function

    Public Shared Function ReadBool(ByVal Section As String, ByVal Key As String, Optional ByVal Value As Boolean = False) As Boolean
        Dim Result As String
        Dim RetVal As String = New String(" ", 255)
        Dim LenResult As Integer
        Dim ErrString As String = ""
        LenResult = GetPrivateProfileString(Section, Key, "", RetVal, RetVal.Length, FileIniPath)
        If LenResult = 0 Then
            If Not (My.Computer.FileSystem.FileExists(FileIniPath)) Then
                ErrString = "Impossibile trovare il file " & FileIniPath
            Else
                ErrString = "Impossibile eseguire l'operazione: la sezione o la chiave sono errate oppure l'accesso al file non è consentito"
            End If
            If EnabledError Then Throw New IniException(ErrString)
            Return Value
        End If
        Result = RetVal.Substring(0, LenResult)
        Return IIf(Result = BoolTrueValue, True, False)
    End Function

    Public Shared Function ReadInt(ByVal Section As String, ByVal Key As String, Optional ByVal Value As Integer = 0) As Integer
        Dim Result As String
        Dim RetVal As String = New String(" ", 255)
        Dim LenResult As Integer
        Dim ErrString As String = ""
        LenResult = GetPrivateProfileString(Section, Key, "", RetVal, RetVal.Length, FileIniPath)
        If LenResult = 0 Then
            If Not (My.Computer.FileSystem.FileExists(FileIniPath)) Then
                ErrString = "Impossibile trovare il file " & FileIniPath
            Else
                ErrString = "Impossibile eseguire l'operazione: la sezione o la chiave sono errate oppure l'accesso al file non è consentito"
            End If
            If EnabledError Then Throw New IniException(ErrString)
            Return Value
        End If
        Result = RetVal.Substring(0, LenResult)
        Return CInt(Result)
    End Function

    Public Shared Function ReadAll(ByVal Section As String) As Dictionary(Of String, String)

        Dim ErrString As String = ""

        If My.Computer.FileSystem.FileExists(FileIniPath) Then
            Dim fileContents As String = My.Computer.FileSystem.ReadAllText(FileIniPath)

            Dim pos As Integer = fileContents.IndexOf("[" & Section & "]")
            If pos > -1 Then
                Dim pos1 As Integer = fileContents.IndexOf("]", pos)
                Dim pos2 As Integer = fileContents.IndexOf("[", pos1)
                Dim lung As Integer = IIf(pos2 > pos1, pos2 - pos1 - 1, fileContents.Length - pos1 - 1)
                Dim tmp() As String = Trim(fileContents.Substring(pos1 + 1, lung)).Replace(vbCr & vbLf, vbCr).Split(vbCr)
                Dim dati As New Dictionary(Of String, String)
                For f = 0 To tmp.Length - 1
                    If Trim(tmp(f).Replace(vbLf, "")) <> "" Then
                        Dim dd() As String = Trim(tmp(f).Replace(vbLf, "")).Split("=")
                        dati.Add(Trim(dd(0)), Trim(dd(1)))
                    End If
                Next
                Return dati
            Else
                ErrString = "Impossibile trovare la sezione " & Section
                Return Nothing
                If EnabledError Then Throw New IniException(ErrString)
            End If

        Else
            ErrString = "Impossibile trovare il file " & FileIniPath
            Return Nothing
            If EnabledError Then Throw New IniException(ErrString)
        End If




    End Function

    Public Shared Function ReadArray(ByVal Section As String) As String()
        If Not My.Computer.FileSystem.FileExists(FileIniPath) Then
            Dim ErrString As String = "Impossibile trovare il file " & FileIniPath
            If EnabledError Then Throw New IniException(ErrString)
            Return Nothing
            Exit Function
        End If
        Dim tmp As Dictionary(Of String, String) = ReadAll(Section)
        Dim dati(tmp.Count - 1) As String
        For Each tt In tmp
            dati(CInt(tt.Key)) = tt.Value
        Next
        Return dati

    End Function
#End Region

#Region "--- WRITE FUNCTIONS ---"

    Public Shared Function WriteString(ByVal Section As String, ByVal Key As String, ByVal Value As String) As Boolean
        Dim LenResult As Integer
        Dim ErrString As String = ""
        LenResult = WritePrivateProfileString(Section, Key, Value, FileIniPath)
        If LenResult = 0 Then
            If Not (My.Computer.FileSystem.FileExists(FileIniPath)) Then
                ErrString = "Impossibile trovare il file " & FileIniPath
            Else
                ErrString = "Impossibile eseguire l'operazione: accesso al file non consentito"
            End If
            If EnabledError Then Throw New IniException(ErrString)
            Return False
        End If
        Return True
    End Function

    Public Shared Function WriteBool(ByVal Section As String, ByVal Key As String, ByVal Value As Boolean) As Boolean
        Dim LenResult As Integer
        Dim ErrString As String = ""
        LenResult = WritePrivateProfileString(Section, Key, IIf(Value, BoolTrueValue, BoolFalseValue), FileIniPath)
        If LenResult = 0 Then
            If Not (My.Computer.FileSystem.FileExists(FileIniPath)) Then
                ErrString = "Impossibile trovare il file " & FileIniPath
            Else
                ErrString = "Impossibile eseguire l'operazione: accesso al file non consentito"
            End If
            If EnabledError Then Throw New IniException(ErrString)
            Return False
        End If
        Return True
    End Function

    Public Shared Function WriteInt(ByVal Section As String, ByVal Key As String, ByVal Value As Integer) As Boolean
        Dim LenResult As Integer
        Dim ErrString As String = ""
        LenResult = WritePrivateProfileString(Section, Key, CStr(Value), FileIniPath)
        If LenResult = 0 Then
            If Not (My.Computer.FileSystem.FileExists(FileIniPath)) Then
                ErrString = "Impossibile trovare il file " & FileIniPath
            Else
                ErrString = "Impossibile eseguire l'operazione: accesso al file non consentito"
            End If
            If EnabledError Then Throw New IniException(ErrString)
            Return False
        End If
        Return True
    End Function

    Public Shared Function WriteArray(ByVal Section As String, ByVal Values() As String) As Boolean
        If Not My.Computer.FileSystem.FileExists(FileIniPath) Then
            Dim ErrString As String = "Impossibile trovare il file " & FileIniPath
            If EnabledError Then Throw New IniException(ErrString)
            Return False
            Exit Function
        End If


        Dim LenResult As Integer
        For f = 0 To Values.Length - 1
            LenResult = WritePrivateProfileString(Section, f, CStr(Values(f)), FileIniPath)
        Next

        Return True
    End Function

#End Region

End Class

Public Class IniException
    Inherits Exception

    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New(message, inner)
    End Sub
End Class

Public Module modVar

    ' Nuova struttura centralizzata
    Public My_Settings As New Settings()
    Public CurrentGroup As Group = Nothing

    ' Variabili runtime (usate durante drag & drop ecc.)
    Public IsDragging As Boolean = False
    Public DraggedElement As Element = Nothing
    Public LastMousePosition As Point

    ' === Variabili vecchie mantenute temporaneamente (per ridurre errori) ===
    Public MyPath As String = System.AppDomain.CurrentDomain.BaseDirectory
    Public MyIniFilePath As String = MyPath & "cfg.ini"
    Public myInifile As New IniFile

    Public FormList As New List(Of frmElementsGroup)
    Public ActualFormOpened As Integer = -1
    Public at_least_one_form_opened As Boolean = False
    Public at_least_one_CMS_opened As Boolean = False
    Public LockOpen As Integer = -1

End Module
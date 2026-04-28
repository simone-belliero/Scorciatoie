


Public Class Element
    Inherits Label

    Public Event Element_click()


    Public Enum ElementType
        general = 0
        special_folder = 1
        document = 2
        executable = 3
        separator = 4
    End Enum

    Private _type As ElementType = ElementType.general
    Private _link As String = ""
    Private _text As String = ""

#Region "----------------- Public properties ---------------------------------"

    Public Property Element_Type As ElementType
        Get
            Return _type
        End Get
        Set(value As ElementType)
            _type = value
        End Set
    End Property

    Public Property Link As String
        Get
            Return _link
        End Get
        Set(value As String)
            _link = value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
        End Set
    End Property

#End Region

    Public Sub New(NewString As String)
        Dim data() As String = NewString.Split(_ini_split_char)
        If data.Length = 1 Then
            _text = data(0)
            _link = data(0)

        ElseIf data.Length >= 2 Then
            _text = data(0)
            _link = data(1)

        End If
    End Sub


End Class


Public Class ClipboardElement
    Inherits Label

    Public Event Element_click()

    Private _link As String = ""
    Private _text As String = ""

#Region "----------------- Public properties ---------------------------------"

    Public Property Link As String
        Get
            Return _link
        End Get
        Set(value As String)
            _link = value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
        End Set
    End Property

#End Region

    Public Sub New(NewString As String)
        Dim data() As String = NewString.Split(_ini_split_char)
        If data.Length = 1 Then
            _text = data(0).Replace(vbCr, "\r").Replace(vbLf, "\n")
            _link = data(0)

        ElseIf data.Length >= 2 Then
            _text = data(0)
            _link = data(1).Replace(vbCr, "\r").Replace(vbLf, "\n")

        End If
    End Sub


End Class



Public Class FixedTextElemet
    Inherits Label

    Public Event Element_click()

    Private _link As String = ""
    Private _text As String = ""

#Region "----------------- Public properties ---------------------------------"

    Public Property Link As String
        Get
            Return _link
        End Get
        Set(value As String)
            _link = value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
        End Set
    End Property

#End Region

    Public Sub New(NewString As String)
        Dim data() As String = NewString.Split(_ini_split_char)
        If data.Length = 1 Then
            _text = data(0).Replace(vbCr, "\r").Replace(vbLf, "\n")
            _link = data(0)

        ElseIf data.Length >= 2 Then
            _text = data(0)
            _link = data(1).Replace(vbCr, "\r").Replace(vbLf, "\n")

        End If
    End Sub


End Class




Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Imports Ini.Net

Public Class frmFixedText



#Region "---------- ENUM -----------------"
    Enum ASSOCF
        ASSOCF_INIT_NOREMAPCLSID = &H1
        ASSOCF_INIT_BYEXENAME = &H2
        ASSOCF_OPEN_BYEXENAME = &H2
        ASSOCF_INIT_DEFAULTTOSTAR = &H4
        ASSOCF_INIT_DEFAULTTOFOLDER = &H8
        ASSOCF_NOUSERSETTINGS = &H10
        ASSOCF_NOTRUNCATE = &H20
        ASSOCF_VERIFY = &H40
        ASSOCF_REMAPRUNDLL = &H80
        ASSOCF_NOFIXUPS = &H100
        ASSOCF_IGNOREBASECLASS = &H200
    End Enum
    Enum ASSOCSTR
        ASSOCSTR_COMMAND = 1
        ASSOCSTR_EXECUTABLE
        ASSOCSTR_FRIENDLYDOCNAME
        ASSOCSTR_FRIENDLYAPPNAME
        ASSOCSTR_NOOPEN
        ASSOCSTR_SHELLNEWVALUE
        ASSOCSTR_DDECOMMAND
        ASSOCSTR_DDEIFEXEC
        ASSOCSTR_DDEAPPLICATION
        ASSOCSTR_DDETOPIC
        ASSOCSTR_INFOTIP
        ASSOCSTR_QUICKTIP
        ASSOCSTR_TILEINFO
        ASSOCSTR_CONTENTTYPE
        ASSOCSTR_DEFAULTICON
        ASSOCSTR_SHELLEXTENSION
        ASSOCSTR_MAX
    End Enum

#End Region

    Const C_EMPTY = "==== EMPTY ===="

#Region "----------------- Local variables ---------------------------------"
    Dim top_border_space As Integer = 3
    Dim left_border_space As Integer = 8
    Dim SpaceBetweenElement As Integer = 5

    Dim InForm As Boolean = False
    'Dim Scorciatoie As List(Of String)
    Dim Count As Integer = 0
    Dim FormHeight As Integer = 0

    'Dim MaxLabelWidth As Integer = 0
    Dim MaxElementWidth As Integer = 0

    Dim ElementHeigth As Integer = 0

    Dim LeftTopPoint_Label As Point



    Dim visto_fuori_form As Boolean = False


    Dim _mx As Integer = 0
    Dim _my As Integer = 0

    Dim LastClipboard As String = ""




#End Region

#Region "----------------- Public variables ---------------------------------"
    Public FormOpened As Boolean = False
#End Region

#Region "----------------- Private variables ---------------------------------"
    Private Const MAX_PATH = 260
    Private Shared InstanceCount As Integer = 0

    Private _closed_color As Color = Color.Lime
    Private _opened_color As Color = Color.Lime
    Private _text_color As Color = Color.Black

    Private _elements_number As Integer = 8

    Private _fixed_element_list As New List(Of FixedTextElemet)
    Private _element_list As New List(Of FixedTextElemet)

    Private _myInstanceNumber As Integer = 0


#End Region

#Region "----------------- Public properties ---------------------------------"

    Public Property ClosedColor As Color
        Get
            Return _closed_color
        End Get
        Set(value As Color)
            _closed_color = value
        End Set
    End Property

    Public Property OpenedColor As Color
        Get
            Return _opened_color
        End Get
        Set(value As Color)
            _opened_color = value
        End Set
    End Property

    Public Property TextColor As Color
        Get
            Return _text_color
        End Get
        Set(value As Color)
            _text_color = value
        End Set
    End Property

    Public Property ElementsNumber As Integer
        Get
            Return _elements_number
        End Get
        Set(value As Integer)
            _elements_number = value
        End Set
    End Property


    Public Property myInstanceNumber As Integer
        Get
            Return _myInstanceNumber
        End Get
        Set(value As Integer)
            _myInstanceNumber = value
        End Set
    End Property

    'Public Property FixedElementList As List(Of FixedTextElemet)
    '    Get
    '        Return _fixed_element_list
    '    End Get
    '    Set(value As List(Of FixedTextElemet))
    '        _fixed_element_list = value
    '    End Set
    'End Property

    Public Property ElementList As List(Of FixedTextElemet)
        Get
            Return _element_list
        End Get
        Set(value As List(Of FixedTextElemet))
            _element_list = value
        End Set
    End Property

    'Public ReadOnly Property FormOpened
    '    Get
    '        If Me.Height > My_Settings.BarSize.Height Then

    '        End If
    '    End Get
    'End Property


#End Region

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        ' === nessuna ====
    End Sub


#Region "----------------- FORM EVENTS ---------------------------------"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = My_Settings.BarSize
        'Me.Location = New Point((My.Computer.Screen.WorkingArea.Width / 2) + My_Settings.DefaultOffset + (Me.Width + _space_between_forms) * _myInstanceNumber, 0)
        Me.Location = New Point((My.Computer.Screen.WorkingArea.Width / 2) + My_Settings.DefaultOffset + (Me.Width + My_Settings.SpaceBetweenBars) * _myInstanceNumber, 0)
        Me.AllowDrop = True
        Me.TopMost = True
        Me.BackColor = _closed_color

        ' Set up the delays for the ToolTip.
        ToolTip1.AutoPopDelay = 5000
        ToolTip1.InitialDelay = 1000
        ToolTip1.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        ToolTip1.ShowAlways = True

        LoadElementList()

        Timer1.Enabled = True

        Dim a = 0

    End Sub

    Public Sub LoadElementList()
        Dim trovato As Boolean = False

        ElementList.Clear()

        If _fixedtext_fixed_lines.Count > 0 Then
            For Each F In _fixedtext_fixed_lines
                Dim EL As New FixedTextElemet(F)
                trovato = True
                ElementList.Add(EL)
            Next
        End If


        If Not trovato Then
            Dim EL As New FixedTextElemet(C_EMPTY)
            ElementList.Add(EL)
        End If
    End Sub

    Private Sub frmElementsGroup_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        PopolaForm()
    End Sub

    Private Sub frmMain_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim gg As Graphics = e.Graphics
        Try
            If FormOpened Then

                gg.DrawRectangle(New Pen(_text_color), 8, LeftTopPoint_Label.Y - 2, Me.Width - (16), (ElementHeigth + SpaceBetweenElement) - 4)


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub frmMain_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Try
            Dim a = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub frmMain_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        _mx = e.X
        _my = e.Y
    End Sub





#End Region

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            '#Region "Check almeno un form aperto"
            '            Dim trovato As Boolean = False
            '            For Each frm As frmElementsGroup In My_Settings.Groups
            '                If frm.FormOpened Then
            '                    trovato = True
            '                End If
            '            Next

            '            If frmMultiClipboard.FormOpened Then
            '                trovato = True
            '            End If

            '            If Me.FormOpened Then
            '                trovato = True
            '            End If

            '            If Not trovato Then
            '                Me.TopMost = True
            '            End If
            '#End Region







            'If at_least_one_CMS_opened Then
            '    Exit Sub
            'End If

            Dim p As Point = Cursor.Position
            Dim offset_border = 0
            'InForm = p.X >= Me.Left - offset_border And p.X <= Me.Left + Me.Width + offset_border And p.Y >= Me.Top - offset_border And p.Y <= Me.Top + Me.Height + offset_border

            InForm = p.X >= Me.Left And p.X <= Me.Left + My_Settings.BarSize.Width And p.Y >= Me.Top And p.Y <= Me.Top + My_Settings.BarSize.Height _
            Or p.X >= Me.Left And p.X <= Me.Left + Me.Width And p.Y >= Me.Top + My_Settings.BarSize.Height And p.Y <= Me.Top + Me.Height

            If (InForm Or LockOpen = _myInstanceNumber) Then

                Me.TopMost = True
                Me.Show()

                Me.BackColor = _opened_color


                Me.Size = New Size(MaxElementWidth, FormHeight + (SpaceBetweenElement * 2))
                FormOpened = True
                ActualFormOpened = _myInstanceNumber

                For Each frm As frmElementsGroup In My_Settings.Groups
                    If Not frm.Equals(Me) Then
                        frm.Size = My_Settings.BarSize
                    End If
                Next

                If visto_fuori_form Then Me.Invalidate()

            ElseIf Not InForm And LockOpen <> _myInstanceNumber Then

                Me.BackColor = _closed_color
                Me.Size = My_Settings.BarSize
                Me.Location = New Point((My.Computer.Screen.WorkingArea.Width / 2) - (My_Settings.TotalWidth / 2) + My_Settings.DefaultOffset + (Me.Width + My_Settings.SpaceBetweenBars) * _myInstanceNumber, 0)
                FormOpened = False
                If ActualFormOpened = _myInstanceNumber Then ActualFormOpened = -1
                Me.Invalidate()
            End If

            If Not InForm And LockOpen = _myInstanceNumber Then
                visto_fuori_form = True
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#Region "--------------- FUNCTIONS ---------------------"

    Public Sub PopolaForm()

        Try

            Me.Controls.Clear()


            Count = 0

            MaxElementWidth = 0

            'For Each E In FixedElementList
            '    Aggiungi_Elemento(E)
            'Next

            For Each E In ElementList
                Aggiungi_Elemento(E)
            Next

            For Each F As FixedTextElemet In ElementList
                F.AutoSize = False
                F.Size = New Size(MaxElementWidth, ElementHeigth)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub Aggiungi_Elemento(L As FixedTextElemet)
        Try

            ' Set up the ToolTip text for the Button and Checkbox.
            ToolTip1.SetToolTip(L, L.Link)

            L.Name = "L_" & Count
            L.AutoSize = True

            ElementHeigth = L.Height
            L.Top = top_border_space + Count * (ElementHeigth + SpaceBetweenElement)
            L.Left = left_border_space
            L.ForeColor = _text_color
            Dim f As Font = New Font("Comic Sans MS", 11.2, FontStyle.Italic)
            L.Font = f
            L.BackColor = Color.FromArgb(0, 255, 255, 255)
            L.BorderStyle = BorderStyle.None

            RemoveHandler L.MouseEnter, AddressOf Element_MouseEnter
            RemoveHandler L.MouseLeave, AddressOf Element_MouseLeave
            RemoveHandler L.MouseClick, AddressOf Element_MouseClick

            AddHandler L.MouseEnter, AddressOf Element_MouseEnter
            AddHandler L.MouseLeave, AddressOf Element_MouseLeave
            AddHandler L.MouseClick, AddressOf Element_MouseClick
            Me.Controls.Add(L)

            Dim Str = L.Text
            Dim sz As New SizeF
            If Str.Length > 100 Then
                Str = Str.Substring(0, 80) & "...." & Str.Substring(Str.Length - 10)
                L.Text = Str
                Dim a = 0
            End If
            L.Invalidate()

            Dim gg = L.CreateGraphics
            sz = gg.MeasureString(L.Text, L.Font)

            MaxElementWidth = Math.Max(MaxElementWidth, sz.Width + 16) ' L.Width)
            Count += 1

            FormHeight = top_border_space + Count * (ElementHeigth + SpaceBetweenElement) + top_border_space

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub EliminaElemento(L As FixedTextElemet)


        ElementList.Remove(L)

        Me.Controls.Clear()

        Count = 0

        WriteShorcutFile()

        PopolaForm()

    End Sub

    Private Function TrimNull(s As String) As String
        Dim pos As Long
        pos = InStr(s, Chr(0))
        If pos <> 0 Then
            TrimNull = Trim(s.Substring(0, pos - 1))
        Else
            TrimNull = Trim(s)
        End If
    End Function

#End Region

#Region "--------------- ELEMENTS EVENTS --------------"

    Private Sub Element_MouseClick(sender As Object, e As MouseEventArgs)

        If e.Button = MouseButtons.Left Then
            Try

                Dim L As FixedTextElemet = DirectCast(sender, FixedTextElemet)

                My.Computer.Clipboard.SetText(L.Link)


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Errore")
            End Try
        ElseIf e.Button = MouseButtons.Right Then

            Dim L As FixedTextElemet = DirectCast(sender, FixedTextElemet)
            EliminaElemento(L)
            Dim a = 0
        End If


    End Sub

    Private Sub Element_MouseEnter(sender As Object, e As EventArgs)
        Try

            Dim El As FixedTextElemet = DirectCast(sender, FixedTextElemet)


            LeftTopPoint_Label = New Point(SpaceBetweenElement, El.Location.Y)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Errore")
        End Try

        Me.Invalidate()

    End Sub

    Private Sub Element_MouseLeave(sender As Object, e As EventArgs)

        Try
            'Dim L As Label = DirectCast(sender, Label)
            Dim El As FixedTextElemet = DirectCast(sender, FixedTextElemet)

            If LockOpen <> _myInstanceNumber Then LeftTopPoint_Label = New Point(Me.Top, -10000)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Errore")
        End Try

        Me.Invalidate()


    End Sub

#End Region


    Private Sub Timer_PortaInPrimoPiano_Tick(sender As Object, e As EventArgs) Handles Timer_PortaInPrimoPiano.Tick
        Timer_PortaInPrimoPiano.Interval = 1000 * 60 * 2
        Me.TopMost = True
    End Sub



End Class

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Imports Ini.Net

Public Class frmElementsGroup

    '    Private Declare Function AssocQueryString Lib "shlwapi.dll" Alias _
    '"AssocQueryStringA" (ByVal flags As ASSOCF, ByVal str As ASSOCSTR,
    'ByVal pszAssoc As String, ByVal pszExtra As String,
    'ByVal pszOut As String, ByRef pcchOut As Long) As Long

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

#Region "----------------- Local variables ---------------------------------"
    Dim top_border_space As Integer = 3
    Dim left_border_space As Integer = 8
    Dim SpaceBetweenElement As Integer = 5

    Dim InForm As Boolean = False
    Dim Scorciatoie As List(Of String)
    Dim Count As Integer = 0
    Dim FormHeight As Integer = 0

    'Dim MaxLabelWidth As Integer = 0
    Dim MaxElementWidth As Integer = 0

    Dim ElementHeigth As Integer = 0

    Dim LeftTopPoint_Label As Point

    Dim visto_fuori_form As Boolean = False

    Dim ElementToMove As Element

    Dim SelectFinalPosition As Boolean = False
    Dim SelectInsertPosition As Boolean = False

    Dim InsertPosition As Integer = -1

    Dim _mx As Integer = 0
    Dim _my As Integer = 0

    Dim Dynamic_height As Integer = 0




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

    Private _myInstanceNumber As Integer = 0
    Private _element_list As New List(Of Element)



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

    Public Property myInstanceNumber As Integer
        Get
            Return _myInstanceNumber
        End Get
        Set(value As Integer)
            _myInstanceNumber = value
        End Set
    End Property

    Public Property ElementList As List(Of Element)
        Get
            Return _element_list
        End Get
        Set(value As List(Of Element))
            _element_list = value
        End Set
    End Property



#End Region

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        _myInstanceNumber = InstanceCount

        If _myInstanceNumber > 0 Then
            niScorciatoie.Visible = False
        End If


        InstanceCount += 1



    End Sub


#Region "----------------- FORM EVENTS ---------------------------------"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = My_Settings.BarSize
        'Me.Location = New Point((My.Computer.Screen.WorkingArea.Width / 2) + My_Settings.DefaultOffset + (Me.Width + _space_between_forms) * _myInstanceNumber, 0)
        Me.Location = New Point((My.Computer.Screen.WorkingArea.Width / 2) + My_Settings.DefaultOffset + (Me.Width + My_Settings.SpaceBetweenBars) * _myInstanceNumber, 0)
        Me.AllowDrop = True
        Me.TopMost = True
        Me.BackColor = _closed_color
        Timer1.Enabled = True

        Dim SpecialFolder As New List(Of String)

        ' Set up the delays for the ToolTip.
        ToolTip1.AutoPopDelay = 5000
        ToolTip1.InitialDelay = 1000
        ToolTip1.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        ToolTip1.ShowAlways = True

        Dim a = 0

    End Sub

    Private Sub frmElementsGroup_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.TopMost = True
    End Sub

    Private Sub frmElementsGroup_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        PopolaForm()
    End Sub

    Private Sub frmMain_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim gg As Graphics = e.Graphics
        Try
            If FormOpened Then

                If InsertPosition >= 0 Then
                    If InsertPosition > 3 Then
                        Dim hh = 0
                    End If
                    Dim Y As Integer = InsertPosition * (ElementHeigth + SpaceBetweenElement) - 1
                    Form1.x = ElementHeigth + SpaceBetweenElement
                    Form1.y = Y
                    Form1.pos = InsertPosition
                    gg.DrawRectangle(New Pen(_text_color), 0, Y, Me.Width - 1, 2)
                Else
                    gg.DrawRectangle(New Pen(_text_color), 8, LeftTopPoint_Label.Y - 2, Me.Width - (16), (ElementHeigth + SpaceBetweenElement) - 4)
                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub frmMain_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Try
            Dim a = 0
            If SelectFinalPosition Then

                MoveElementInPosition(ElementToMove, InsertPosition)
                SelectFinalPosition = False
                InsertPosition = -4
                Form1.pos = InsertPosition
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub frmMain_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        _mx = e.X
        _my = e.Y
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop

        ' Handle FileDrop data.
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            ' Assign the file names to a string array, in 
            ' case the user has selected multiple files.
            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            Try
                For Each f In files
                    ' da rivedere ---- Aggiungi_Elemento(SplitChar & f)
                    'My.Computer.FileSystem.WriteAllText(_shortcut_file_name, vbCrLf & SplitChar & f, True)
                    Dim El = New Element(f)
                    If SelectInsertPosition Then
                        InsertNewElementInPosition(El, InsertPosition)
                        SelectInsertPosition = False
                        InsertPosition = -5
                        Form1.pos = InsertPosition
                    Else
                        ElementList.Add(El)
                    End If

                Next

                Me.Controls.Clear()

                Count = 0

                WriteShorcutFile()

                PopolaForm()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
        ElseIf e.Data.GetDataPresent(DataFormats.Text) Then
            Try
                Dim T = e.Data.GetData(DataFormats.Text)
                'Aggiungi_Elemento(SplitChar & T)
                'My.Computer.FileSystem.WriteAllText(_shortcut_file_name, vbCrLf & SplitChar & T, True)
                'Dim c = 0

                Dim El = New Element(T)
                If SelectInsertPosition Then
                    InsertNewElementInPosition(El, InsertPosition)
                    SelectInsertPosition = False
                    InsertPosition = -6
                    Form1.pos = InsertPosition
                Else
                    ElementList.Add(El)
                End If

                'ElementList.Add(El)

                SelectInsertPosition = False
                InsertPosition = -7
                Form1.pos = InsertPosition

                Me.Controls.Clear()

                Count = 0

                WriteShorcutFile()

                PopolaForm()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If


        ' Force the form to be redrawn with the image.
        Me.Invalidate()
    End Sub

    Private Sub Form1_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles MyBase.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
                SelectInsertPosition = True
            ElseIf e.Data.GetDataPresent(DataFormats.Text) Then
                SelectInsertPosition = True
                e.Effect = DragDropEffects.Copy
                'Else
                '    e.Effect = DragDropEffects.None
                '    SelectInsertPosition = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frmElementsGroup_DragLeave(sender As Object, e As EventArgs) Handles Me.DragLeave

        SelectInsertPosition = False
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

            '            If frmFixedText.FormOpened Then
            '                trovato = True
            '            End If

            '            If Not trovato Then
            '                Me.TopMost = True
            '            End If
            '#End Region

            Dim p As Point = Cursor.Position

            InForm = p.X >= Me.Left And p.X <= Me.Left + My_Settings.BarSize.Width And p.Y >= Me.Top And p.Y <= Me.Top + My_Settings.BarSize.Height _
            Or p.X >= Me.Left And p.X <= Me.Left + Me.Width And p.Y >= Me.Top + My_Settings.BarSize.Height And p.Y <= Me.Top + Me.Height

            If at_least_one_CMS_opened Then
                Exit Sub
            End If

            If ActualFormOpened = -1 And (InForm Or LockOpen = _myInstanceNumber) Then



                Me.TopMost = True
                Me.Show()

                Me.BackColor = _opened_color


                Me.Size = New Size(MaxElementWidth + (SpaceBetweenElement * 2), FormHeight)

                FormOpened = True
                ActualFormOpened = _myInstanceNumber

                For Each frm As frmElementsGroup In My_Settings.Groups
                    If Not frm.Equals(Me) Then
                        frm.Size = My_Settings.BarSize
                    End If
                Next

                Me.Invalidate()
            ElseIf Not InForm And LockOpen <> _myInstanceNumber Then

                Dynamic_height = 0

                'T_Open.Enabled = False

                Me.BackColor = _closed_color
                Me.Size = My_Settings.BarSize
                Me.Location = New Point((My.Computer.Screen.WorkingArea.Width / 2) - (My_Settings.TotalWidth / 2) + My_Settings.DefaultOffset + (Me.Width + My_Settings.SpaceBetweenBars) * _myInstanceNumber, 0)
                FormOpened = False
                SelectFinalPosition = False
                SelectInsertPosition = False
                InsertPosition = -2
                Form1.pos = InsertPosition
                If ActualFormOpened = _myInstanceNumber Then ActualFormOpened = -1
                Me.Invalidate()
            End If

            If InForm And visto_fuori_form And Not cmsElement.Focused Then
                LockOpen = -1 'False
                visto_fuori_form = False
            End If

            If Not InForm And LockOpen = _myInstanceNumber Then
                visto_fuori_form = True
            End If


            If SelectFinalPosition Or SelectInsertPosition Then
                InsertPosition = (p.Y - Me.Top - top_border_space) / (ElementHeigth + SpaceBetweenElement)
                'Form1.pos = InsertPosition
            Else
                InsertPosition = -3
                Form1.pos = InsertPosition
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
            For Each E In ElementList
                Aggiungi_Elemento(E)
            Next

            For Each F As Element In ElementList
                F.AutoSize = False
                F.Size = New Size(MaxElementWidth, ElementHeigth)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub Aggiungi_Elemento(L As Element)
        Try
            L.Name = "L_" & Count
            L.AutoSize = True

            ' Set up the ToolTip text for the Button and Checkbox.
            ToolTip1.SetToolTip(L, L.Link)

            ElementHeigth = L.Height
            L.Top = top_border_space + Count * (ElementHeigth + SpaceBetweenElement)
            L.Left = left_border_space
            L.ContextMenuStrip = cmsElement
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

            MaxElementWidth = Math.Max(MaxElementWidth, sz.Width * 1.3) ' L.Width)
            Count += 1

            FormHeight = top_border_space + Count * (ElementHeigth + SpaceBetweenElement) + top_border_space

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub EliminaElemento(L As Element)


        ElementList.Remove(L)

        Me.Controls.Clear()

        Count = 0

        WriteShorcutFile()

        PopolaForm()

    End Sub

    Sub RinominaElemento(L As Element, newName As String)
        L.Text = newName
        Me.Controls.Clear()

        Count = 0

        WriteShorcutFile()

        PopolaForm()

    End Sub

    Sub PortaElementoAllInizio(L As Element)

        ElementList.Remove(L)
        ElementList.Insert(0, L)

        Me.Controls.Clear()

        Count = 0

        WriteShorcutFile()

        PopolaForm()

    End Sub

    Sub SpostaElementoSopra(L As Element)

        Dim idx As Integer = ElementList.IndexOf(L)

        If idx = 0 Then Exit Sub

        Dim TE As Element = ElementList(idx - 1)
        ElementList(idx - 1) = L
        ElementList(idx) = TE

        Me.Controls.Clear()

        Count = 0

        WriteShorcutFile()

        PopolaForm()

    End Sub

    Sub SpostaElementoSotto(L As Element)

        Dim idx As Integer = ElementList.IndexOf(L)

        If idx = ElementList.Count - 1 Then Exit Sub

        Dim TE As Element = ElementList(idx + 1)
        ElementList(idx + 1) = L
        ElementList(idx) = TE



        WriteShorcutFile()

        PopolaForm()

    End Sub

    Sub PortaElementoAllaFine(L As Element)
        ElementList.Remove(L)
        ElementList.Add(L)

        Me.Controls.Clear()

        Count = 0

        WriteShorcutFile()

        PopolaForm()

    End Sub

    Sub MoveElementInPosition(L As Element, Position As Integer)


        ElementList.Remove(L)
        ElementList.Insert(Position, L)

        Me.Controls.Clear()

        Count = 0

        WriteShorcutFile()

        PopolaForm()

    End Sub


    Sub InsertNewElementInPosition(L As Element, Position As Integer)



        ElementList.Insert(Position, L)

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
                If SelectFinalPosition Then

                    MoveElementInPosition(ElementToMove, InsertPosition)
                    SelectFinalPosition = False
                    Exit Sub

                End If

                Dim L As Element = DirectCast(sender, Element)
                Dim Extension As String = Path.GetExtension(L.Link.ToString)

                Dim HTML As Boolean = False

                Dim pattern As String
                Dim urlStr As String = L.Link
                pattern = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"

                HTML = Regex.IsMatch(urlStr, pattern)

                If L.Element_Type = Element.ElementType.separator Then

                Else
                    If Extension <> "" Or HTML Then
                        Dim psi = New ProcessStartInfo(L.Link.ToString)
                        psi.UseShellExecute = True
                        Process.Start(psi)

                    Else
                        'Process.Start("explorer.exe", " /select ," & L.Link)
                        Process.Start("explorer.exe", L.Link)
                    End If
                End If




            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Errore")
            End Try
        ElseIf e.Button = MouseButtons.Left Then
            Dim a = 0
        End If


    End Sub

    Private Sub Element_MouseEnter(sender As Object, e As EventArgs)
        Try

            Dim El As Element = DirectCast(sender, Element)


            LeftTopPoint_Label = New Point(SpaceBetweenElement, El.Location.Y)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Errore")
        End Try

        Me.Invalidate()

    End Sub

    Private Sub Element_MouseLeave(sender As Object, e As EventArgs)

        Try
            'Dim L As Label = DirectCast(sender, Label)
            Dim El As Element = DirectCast(sender, Element)

            If LockOpen <> _myInstanceNumber Then LeftTopPoint_Label = New Point(Me.Top, -10000)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Errore")
        End Try

        Me.Invalidate()


    End Sub

#End Region

#Region "--------------- MENU FUNCTIONS ------------------"


    Private Sub mnuEsci_Click(sender As Object, e As EventArgs) Handles mnuEsci.Click
        If MsgBox("Sei sicuro di voler uscire?", vbOKCancel + vbQuestion, "Esci") = vbOK Then
            Me.Close()
        End If
    End Sub

    Private Sub mnuImpostazioni_Click(sender As Object, e As EventArgs) Handles mnuImpostazioni.Click
        Try
            frmImpostazioni.ShowDialog()

            For Each L In Me.Controls
                If L.GetType().Name = GetType(Element).Name Then
                    Dim El = DirectCast(L, Element)

                    El.ForeColor = _text_color

                    Dim a = 0
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

#End Region

#Region "--------------- CONTEXT MENU FUNCTIONS ------------------"

    Private Sub mnuRemove_Click(sender As Object, e As EventArgs) Handles mnuRemove.Click
        Dim mnu = DirectCast(sender, ToolStripMenuItem)
        Dim cms = DirectCast(mnu.Owner, ContextMenuStrip)
        Dim L As Element = DirectCast(cms.SourceControl, Element)
        EliminaElemento(L)
    End Sub

    Private Sub mnuInsertSeparator_Click(sender As Object, e As EventArgs) Handles mnuInsertSeparator.Click

    End Sub

    Private Sub mnuRename_Click(sender As Object, e As EventArgs) Handles mnuRename.Click
        LockOpen = _myInstanceNumber ' True
        Dim mnu = DirectCast(sender, ToolStripMenuItem)
        Dim cms = DirectCast(mnu.Owner, ContextMenuStrip)
        Dim L As Element = DirectCast(cms.SourceControl, Element)

        Dim s = InputBox("Inserisci il nuovo nome", "Rename", L.Text)

        If s <> L.Text And s <> "" Then
            RinominaElemento(L, s)

            PopolaForm()


        End If



        'LockOpen = True
        Dim a = 0
    End Sub

    Private Sub cmsElement_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles cmsElement.Closing
        'LockOpen = False
        at_least_one_CMS_opened = False
    End Sub

    Private Sub cmsElement_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsElement.Opening
        LockOpen = _myInstanceNumber ' = True
        at_least_one_CMS_opened = True

        Dim L As Element = cmsElement.SourceControl
        If L.Element_Type = Element.ElementType.separator Then
            mnuRename.Enabled = False
        Else
            mnuRename.Enabled = True
        End If
    End Sub

    Private Sub cmsElement_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles cmsElement.Closed
        'LockOpen = False
    End Sub

    Private Sub mnuMoveFirst_Click(sender As Object, e As EventArgs) Handles mnuMoveFirst.Click
        Dim L As Element = cmsElement.SourceControl
        PortaElementoAllInizio(L)
    End Sub

    Private Sub mnuMoveUp_Click(sender As Object, e As EventArgs) Handles mnuMoveUp.Click
        Dim L As Element = cmsElement.SourceControl
        SpostaElementoSopra(L)
    End Sub

    Private Sub mnuMoveDown_Click(sender As Object, e As EventArgs) Handles mnuMoveDown.Click
        Dim L As Element = cmsElement.SourceControl
        SpostaElementoSotto(L)
    End Sub

    Private Sub mnuMoveLast_Click(sender As Object, e As EventArgs) Handles mnuMoveLast.Click
        Dim L As Element = cmsElement.SourceControl
        PortaElementoAllaFine(L)
    End Sub

    Private Sub mnuMoveInNewPosition_Click(sender As Object, e As EventArgs) Handles mnuMoveInNewPosition.Click
        Try
            ElementToMove = cmsElement.SourceControl

            SelectFinalPosition = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub mnuPaste_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click
        Try
            If My.Computer.Clipboard.ContainsText() Then

                Dim T As String = My.Computer.Clipboard.GetText()
                If Not T.Contains("|") And Not T.Contains(vbCrLf) And Not T.Contains(vbCr) And Not T.Contains(vbLf) Then
                    Dim El = New Element(T)
                    InsertNewElementInPosition(El, ElementList.Count)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        Dim mnu = DirectCast(sender, ToolStripMenuItem)
        Dim cms = DirectCast(mnu.Owner, ContextMenuStrip)
        Dim L As Element = DirectCast(cms.SourceControl, Element)

        My.Computer.Clipboard.SetText(L.Link)

        LockOpen = -1 'False
        visto_fuori_form = False

    End Sub

    Private Sub Timer_PortaInPrimoPiano_Tick(sender As Object, e As EventArgs) Handles Timer_PortaInPrimoPiano.Tick
        Timer_PortaInPrimoPiano.Interval = 1000 * 60 * 2
        Me.TopMost = True
    End Sub








#End Region


End Class

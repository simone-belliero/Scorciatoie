
Public Class frmImpostazioni

    Public _idx As Integer = 0

    Dim primo_giro_fatto As Boolean = False

    Dim OpenText = "▼▼▼▼▼"
    Dim CloseText = "▲▲▲▲▲"

    Dim GroupLocation As New Point(5, 110)

    Private Sub frmImpostazioni_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '►◄

        Me.Height = 615
        Me.Width = 282
        TabControl1.SelectTab(TabPageGroup)


        gbGroupElement.Left = GroupLocation.X

        gbFolders.Visible = False

        numWidth.Value = My_Settings.BarSize.Width
        numOffset.Value = My_Settings.DefaultOffset

        numFormIndex.Value = 1

        numFormIndex.Maximum = My_Settings.Groups.Count

        _idx = 0


        chkAutomaticStart.Checked = LinkExist()

        loadFormvalues(_idx)

        btDeleteForm.Enabled = My_Settings.Groups.Count > 1

        btDeleteForm.Enabled = My_Settings.Groups.Count > 1
        btNewForm.Enabled = My_Settings.Groups.Count < 10


        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False

        For Each El In My_Settings.Groups(_idx).ElementList
            If El.Element_Type = Element.ElementType.special_folder Then



                Select Case El.Link
                    Case Environment.GetFolderPath(CheckBox1.Tag)
                        CheckBox1.Checked = True
                    Case Environment.GetFolderPath(CheckBox2.Tag)
                        CheckBox2.Checked = True
                    Case Environment.GetFolderPath(CheckBox3.Tag)
                        CheckBox3.Checked = True
                    Case Environment.GetFolderPath(CheckBox4.Tag)
                        CheckBox4.Checked = True
                    Case Environment.GetFolderPath(CheckBox5.Tag)
                        CheckBox5.Checked = True
                    Case Environment.GetFolderPath(CheckBox6.Tag)
                        CheckBox6.Checked = True
                    Case Environment.GetFolderPath(CheckBox7.Tag)
                        CheckBox7.Checked = True
                    Case Environment.GetFolderPath(CheckBox8.Tag)
                        CheckBox8.Checked = True
                    Case Environment.GetFolderPath(CheckBox9.Tag)
                        CheckBox9.Checked = True
                    Case Environment.GetFolderPath(CheckBox10.Tag)
                        CheckBox10.Checked = True
                End Select
            End If

        Next


        lbColorClipboard.BackColor = My_Settings.ClipboardCloseColor
        lbBackColorClipboard.BackColor = My_Settings.ClipboardOpenColor 
        lbTextColorClipboard.BackColor = _clipboard_text_color

        numElementsNumber.Value =My_Settings.ClipboardElementsNumber

        lbColorFixed.BackColor = My_Settings.FixedTextCloseColor
        lbBackColorFixed.BackColor = My_Settings.FixedTextOpenColor
        lbTextColorFixed.BackColor = My_Settings.FixedTextTextColor


        Dim T As String = ""

        For Each l In _fixedtext_fixed_lines
            T &= IIf(T = "", "", vbCrLf) & l
        Next

        txFixedText.Text = T

        primo_giro_fatto = True

    End Sub

    Private Sub frmImpostazioni_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        My_Settings.Groups(_idx).PopolaForm()

        My_Settings.BarSize = New Size(numWidth.Value, 5)
        My_Settings.DefaultOffset = numOffset.Value

        myInifile.SetKeyValue_Integer("main", "_width", numWidth.Value)
        myInifile.SetKeyValue_Integer("main", "My_Settings.DefaultOffset", My_Settings.DefaultOffset)

        myInifile.SetKeyValue_String("clipboard", "My_Settings.ClipboardCloseColor", DaColorAStringRgb(My_Settings.ClipboardCloseColor, ","))
        myInifile.SetKeyValue_String("clipboard", "My_Settings.ClipboardOpenColor ", DaColorAStringRgb(My_Settings.ClipboardOpenColor , ","))
        myInifile.SetKeyValue_String("clipboard", "_clipboard_text_color", DaColorAStringRgb(_clipboard_text_color, ","))
        myInifile.SetKeyValue_Integer("clipboard", "_clipboard_elements_number",My_Settings.ClipboardElementsNumber)

        myInifile.SetKeyValue_String("fixedtext", "My_Settings.FixedTextCloseColor", DaColorAStringRgb(My_Settings.FixedTextCloseColor, ","))
        myInifile.SetKeyValue_String("fixedtext", "My_Settings.FixedTextOpenColor", DaColorAStringRgb(My_Settings.FixedTextOpenColor, ","))
        myInifile.SetKeyValue_String("fixedtext", "My_Settings.FixedTextTextColor", DaColorAStringRgb(My_Settings.FixedTextTextColor, ","))


        Dim T As String = ""
        _fixedtext_fixed_lines.Clear()

        For Each l In txFixedText.Lines
            If l <> "" Then
                T &= IIf(T = "", "", ";") & l
                _fixedtext_fixed_lines.Add(l)
            End If
        Next


        myInifile.SetKeyValue_String("fixedtext_fixed_lines", "array", T)

        frmFixedText.LoadElementList()
        frmFixedText.PopolaForm()


        myInifile.Save(MyIniFilePath)
    End Sub

    Private Sub lbColor_MouseClick(sender As Object, e As MouseEventArgs) Handles lbColor.MouseClick
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbColor.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbColor.BackColor = OCD.Color
        End If

        My_Settings.Groups(_idx).ClosedColor = lbColor.BackColor

        WriteShorcutFile()

        My_Settings.Groups(_idx).PopolaForm()
    End Sub

    Private Sub lbBackColor_MouseClick(sender As Object, e As MouseEventArgs) Handles lbBackColor.MouseClick
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbBackColor.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbBackColor.BackColor = OCD.Color

        End If
        My_Settings.Groups(_idx).OpenedColor = lbBackColor.BackColor

        WriteShorcutFile()

        My_Settings.Groups(_idx).PopolaForm()
    End Sub

    Private Sub lbTextColor_MouseClick(sender As Object, e As MouseEventArgs) Handles lbTextColor.MouseClick
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbTextColor.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbTextColor.BackColor = OCD.Color

        End If
        My_Settings.Groups(_idx).TextColor = lbTextColor.BackColor

        WriteShorcutFile()

        My_Settings.Groups(_idx).PopolaForm()
    End Sub

    Private Sub chkAutomaticStart_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutomaticStart.CheckedChanged
        If chkAutomaticStart.Checked Then
            CreateShortCut()
        Else
            RemoveShortCut()
        End If
    End Sub

    Private Sub lbApriGestione_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbApriGestione.LinkClicked
        Dim psi = New ProcessStartInfo(My_Settings.LinkFileName)
        psi.UseShellExecute = True
        Process.Start(psi)
    End Sub

    Private Sub numFormIndex_ValueChanged(sender As Object, e As EventArgs) Handles numFormIndex.ValueChanged
        If Not primo_giro_fatto Then Exit Sub
        My_Settings.Groups(_idx).PopolaForm()
        _idx = numFormIndex.Value - 1
        loadFormvalues(_idx)

        btDeleteForm.Enabled = My_Settings.Groups.Count > 1
        btNewForm.Enabled = My_Settings.Groups.Count < 10

        btMoveLeft.Enabled = numFormIndex.Value > 1
        btMoveRight.Enabled = numFormIndex.Value < numFormIndex.Maximum

    End Sub
    Sub loadFormvalues(idx As Integer)


        lbColor.BackColor = My_Settings.Groups(_idx).ClosedColor
        lbBackColor.BackColor = My_Settings.Groups(_idx).OpenedColor
        lbTextColor.BackColor = My_Settings.Groups(_idx).TextColor


    End Sub

    Private Sub btMoveUp_Click(sender As Object, e As EventArgs) Handles btMoveRight.Click
        Dim F = My_Settings.Groups(_idx)
        My_Settings.Groups(_idx) = My_Settings.Groups(_idx + 1)
        My_Settings.Groups(_idx + 1) = F

        My_Settings.Groups(_idx).myInstanceNumber -= 1
        My_Settings.Groups(_idx + 1).myInstanceNumber += 1

        _idx += 1

        numFormIndex.Value = _idx + 1

        WriteShorcutFile()



        loadFormvalues(_idx)

    End Sub

    Private Sub btMoveDown_Click(sender As Object, e As EventArgs) Handles btMoveLeft.Click
        Dim F = My_Settings.Groups(_idx)
        My_Settings.Groups(_idx) = My_Settings.Groups(_idx - 1)
        My_Settings.Groups(_idx - 1) = F

        My_Settings.Groups(_idx).myInstanceNumber += 1
        My_Settings.Groups(_idx - 1).myInstanceNumber -= 1

        _idx -= 1

        numFormIndex.Value = _idx + 1

        WriteShorcutFile()



        loadFormvalues(_idx)

    End Sub

    Private Sub btNewForm_Click(sender As Object, e As EventArgs) Handles btNewForm.Click
        'Dim T As String = ""

        'T &= vbCrLf & "[form]" & vbCrLf
        'T &= "color:0;255;0" & vbCrLf
        'T &= "back_color:255;255;255" & vbCrLf
        'T &= "text_color:0;0;0" & vbCrLf
        'T &= "" & vbCrLf

        'Dim P As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
        'Dim SystemDisc As String = P.Substring(0, P.IndexOf("\") + 1)
        'Dim L = "System disk : " & SystemDisc & _ini_split_char & SystemDisc

        'T &= "link:" & L & vbCrLf


        'My.Computer.FileSystem.WriteAllText(My_Settings.MyPath & My_Settings.LinkFileName, T, True)

        Dim frm As New frmElementsGroup

        frm.ElementList.Clear()
        frm.ClosedColor = Color.Lime
        frm.BackColor = Color.White
        frm.TextColor = Color.Black

        Dim El = GenereteNewFormCFG()
        frm.ElementList.Add(El)


        frm.PopolaForm()
        My_Settings.Groups.Add(frm)

        numFormIndex.Maximum = My_Settings.Groups.Count
        numFormIndex.Value = My_Settings.Groups.Count

        _idx = numFormIndex.Value - 1


        Dim c = 0
        For Each F In My_Settings.Groups
            F.myInstanceNumber = c
            F.PopolaForm()
            c += 1
        Next



        loadFormvalues(_idx)

        frm.Show()

        btDeleteForm.Enabled = My_Settings.Groups.Count > 1
        btNewForm.Enabled = My_Settings.Groups.Count < 10
        Dim a = 0



    End Sub

    Private Sub btDeleteForm_Click(sender As Object, e As EventArgs) Handles btDeleteForm.Click

        If My_Settings.Groups.Count <= 1 Then Exit Sub

        If MsgBox("Are you sure you want to delete the current group?", vbQuestion + vbOKCancel, "Detele") = vbCancel Then Exit Sub


        Dim d = My.Application.OpenForms


        For f = d.Count - 1 To 0 Step -1
            If d(f).GetType = GetType(frmElementsGroup) Then
                Dim FE = DirectCast(d(f), frmElementsGroup)
                If FE.myInstanceNumber = _idx Then
                    FE.Close()
                    Exit For
                End If
            End If
        Next



        If _idx = 0 Then
            My_Settings.Groups.Remove(My_Settings.Groups(_idx))
        ElseIf _idx = My_Settings.Groups.Count - 1 Then
            My_Settings.Groups.Remove(My_Settings.Groups(_idx))
            _idx -= 1
            numFormIndex.Value = My_Settings.Groups.Count
        Else
            My_Settings.Groups.Remove(My_Settings.Groups(_idx))
        End If

        numFormIndex.Maximum = My_Settings.Groups.Count

        Dim c = 0

        WriteShorcutFile()

        For Each F In My_Settings.Groups
            F.myInstanceNumber = c
            F.PopolaForm()
            c += 1
        Next

        loadFormvalues(_idx)

        'LoadGroupsConfiguration()

        'For Each F In My_Settings.Groups
        '    F.Show()
        'Next


        btDeleteForm.Enabled = My_Settings.Groups.Count > 1
        btNewForm.Enabled = My_Settings.Groups.Count < 10
    End Sub



    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox4.CheckedChanged, CheckBox5.CheckedChanged, CheckBox6.CheckedChanged, CheckBox7.CheckedChanged, CheckBox8.CheckedChanged, CheckBox9.CheckedChanged, CheckBox10.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim folder_idx As Integer = chk.Tag
        Dim folder = Environment.GetFolderPath(folder_idx)

        If chk.Checked Then
            Dim El As Element
            For Each El In My_Settings.Groups(_idx).ElementList
                If El.Link = folder Then
                    Exit Sub
                End If
            Next

            Dim list_pos = SpecialFoldersIndex.IndexOf(folder_idx)
            Dim T = SpecialFoldersName(list_pos) & _ini_split_char & folder
            El = New Element(T)
            El.Element_Type = Element.ElementType.special_folder

            My_Settings.Groups(_idx).ElementList.Add(El)

            My_Settings.Groups(_idx).Aggiungi_Elemento(El)

            My_Settings.Groups(_idx).PortaElementoAllInizio(El)

        Else
            For Each El In My_Settings.Groups(_idx).ElementList
                If El.Link = folder Then
                    My_Settings.Groups(_idx).ElementList.Remove(El)
                    Exit Sub
                End If
            Next
        End If

        WriteShorcutFile()
        'My_Settings.Groups(_idx).PopolaForm()


    End Sub

    Private Sub lbColorClipboard_Click(sender As Object, e As EventArgs) Handles lbColorClipboard.Click
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbColorClipboard.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbColorClipboard.BackColor = OCD.Color
        End If

        My_Settings.ClipboardCloseColor = lbColorClipboard.BackColor
        frmMultiClipboard.ClosedColor = My_Settings.ClipboardCloseColor

        frmMultiClipboard.PopolaForm()
    End Sub

    Private Sub lbBackColorClipboard_Click(sender As Object, e As EventArgs) Handles lbBackColorClipboard.Click
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbBackColorClipboard.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbBackColorClipboard.BackColor = OCD.Color
        End If

        My_Settings.ClipboardOpenColor  = lbBackColorClipboard.BackColor
        frmMultiClipboard.OpenedColor = My_Settings.ClipboardOpenColor 

        frmMultiClipboard.PopolaForm()
    End Sub

    Private Sub lbTextColorClipboard_Click(sender As Object, e As EventArgs) Handles lbTextColorClipboard.Click
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbTextColorClipboard.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbTextColorClipboard.BackColor = OCD.Color
        End If

        _clipboard_text_color = lbTextColorClipboard.BackColor
        frmMultiClipboard.TextColor = _clipboard_text_color

        frmMultiClipboard.PopolaForm()
    End Sub

    Private Sub numElementsNumber_ValueChanged(sender As Object, e As EventArgs) Handles numElementsNumber.ValueChanged

        If Not primo_giro_fatto Then Exit Sub

       My_Settings.ClipboardElementsNumber = numElementsNumber.Value
        frmMultiClipboard.ElementsNumber =My_Settings.ClipboardElementsNumber

    End Sub


    '####################################

    Private Sub lbColorFixedText_Click(sender As Object, e As EventArgs) Handles lbColorFixed.Click
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbColorFixed.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbColorFixed.BackColor = OCD.Color
        End If

        My_Settings.FixedTextCloseColor = lbColorFixed.BackColor
        frmFixedText.ClosedColor = My_Settings.FixedTextCloseColor

        frmFixedText.PopolaForm()
    End Sub

    Private Sub lbBackColorFixed_Click(sender As Object, e As EventArgs) Handles lbBackColorFixed.Click
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbBackColorFixed.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbBackColorFixed.BackColor = OCD.Color
        End If

        My_Settings.FixedTextOpenColor = lbBackColorFixed.BackColor
        frmFixedText.BackColor = My_Settings.FixedTextOpenColor

        frmFixedText.PopolaForm()
    End Sub

    Private Sub lbTextColorFixed_Click(sender As Object, e As EventArgs) Handles lbTextColorFixed.Click
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbTextColorFixed.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbTextColorFixed.BackColor = OCD.Color
        End If

        My_Settings.FixedTextTextColor = lbTextColorFixed.BackColor
        frmFixedText.TextColor = My_Settings.FixedTextTextColor

        frmFixedText.PopolaForm()
    End Sub

    Private Sub TabControl1_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.TabIndexChanged
        Dim a = 0
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim a = 0
        If TabControl1.SelectedIndex = 2 Then

        Else
            Me.Height = 615
            Me.Width = 282
        End If
    End Sub
End Class
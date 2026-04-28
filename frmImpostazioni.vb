
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

        numWidth.Value = mySize.Width
        numOffset.Value = _offset_position

        numFormIndex.Value = 1

        numFormIndex.Maximum = FormList.Count

        _idx = 0


        chkAutomaticStart.Checked = LinkExist()

        loadFormvalues(_idx)

        btDeleteForm.Enabled = FormList.Count > 1

        btDeleteForm.Enabled = FormList.Count > 1
        btNewForm.Enabled = FormList.Count < 10


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

        For Each El In FormList(_idx).ElementList
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


        lbColorClipboard.BackColor = _clipboard_close_color
        lbBackColorClipboard.BackColor = _clipboard_open_color
        lbTextColorClipboard.BackColor = _clipboard_text_color

        numElementsNumber.Value = _clipboard_elements_number

        lbColorFixed.BackColor = _fixedtext_close_color
        lbBackColorFixed.BackColor = _fixedtext_open_color
        lbTextColorFixed.BackColor = _fixedtext_text_color


        Dim T As String = ""

        For Each l In _fixedtext_fixed_lines
            T &= IIf(T = "", "", vbCrLf) & l
        Next

        txFixedText.Text = T

        primo_giro_fatto = True

    End Sub

    Private Sub frmImpostazioni_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        FormList(_idx).PopolaForm()

        mySize = New Size(numWidth.Value, 5)
        _offset_position = numOffset.Value

        myInifile.SetKeyValue_Integer("main", "_width", numWidth.Value)
        myInifile.SetKeyValue_Integer("main", "_offset_position", _offset_position)

        myInifile.SetKeyValue_String("clipboard", "_clipboard_close_color", DaColorAStringRgb(_clipboard_close_color, ","))
        myInifile.SetKeyValue_String("clipboard", "_clipboard_open_color", DaColorAStringRgb(_clipboard_open_color, ","))
        myInifile.SetKeyValue_String("clipboard", "_clipboard_text_color", DaColorAStringRgb(_clipboard_text_color, ","))
        myInifile.SetKeyValue_Integer("clipboard", "_clipboard_elements_number", _clipboard_elements_number)

        myInifile.SetKeyValue_String("fixedtext", "_fixedtext_close_color", DaColorAStringRgb(_fixedtext_close_color, ","))
        myInifile.SetKeyValue_String("fixedtext", "_fixedtext_open_color", DaColorAStringRgb(_fixedtext_open_color, ","))
        myInifile.SetKeyValue_String("fixedtext", "_fixedtext_text_color", DaColorAStringRgb(_fixedtext_text_color, ","))


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

        FormList(_idx).ClosedColor = lbColor.BackColor

        WriteShorcutFile()

        FormList(_idx).PopolaForm()
    End Sub

    Private Sub lbBackColor_MouseClick(sender As Object, e As MouseEventArgs) Handles lbBackColor.MouseClick
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbBackColor.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbBackColor.BackColor = OCD.Color

        End If
        FormList(_idx).OpenedColor = lbBackColor.BackColor

        WriteShorcutFile()

        FormList(_idx).PopolaForm()
    End Sub

    Private Sub lbTextColor_MouseClick(sender As Object, e As MouseEventArgs) Handles lbTextColor.MouseClick
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbTextColor.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbTextColor.BackColor = OCD.Color

        End If
        FormList(_idx).TextColor = lbTextColor.BackColor

        WriteShorcutFile()

        FormList(_idx).PopolaForm()
    End Sub

    Private Sub chkAutomaticStart_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutomaticStart.CheckedChanged
        If chkAutomaticStart.Checked Then
            CreateShortCut()
        Else
            RemoveShortCut()
        End If
    End Sub

    Private Sub lbApriGestione_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbApriGestione.LinkClicked
        Dim psi = New ProcessStartInfo(_link_file_name)
        psi.UseShellExecute = True
        Process.Start(psi)
    End Sub

    Private Sub numFormIndex_ValueChanged(sender As Object, e As EventArgs) Handles numFormIndex.ValueChanged
        If Not primo_giro_fatto Then Exit Sub
        FormList(_idx).PopolaForm()
        _idx = numFormIndex.Value - 1
        loadFormvalues(_idx)

        btDeleteForm.Enabled = FormList.Count > 1
        btNewForm.Enabled = FormList.Count < 10

        btMoveLeft.Enabled = numFormIndex.Value > 1
        btMoveRight.Enabled = numFormIndex.Value < numFormIndex.Maximum

    End Sub
    Sub loadFormvalues(idx As Integer)


        lbColor.BackColor = FormList(_idx).ClosedColor
        lbBackColor.BackColor = FormList(_idx).OpenedColor
        lbTextColor.BackColor = FormList(_idx).TextColor


    End Sub

    Private Sub btMoveUp_Click(sender As Object, e As EventArgs) Handles btMoveRight.Click
        Dim F = FormList(_idx)
        FormList(_idx) = FormList(_idx + 1)
        FormList(_idx + 1) = F

        FormList(_idx).myInstanceNumber -= 1
        FormList(_idx + 1).myInstanceNumber += 1

        _idx += 1

        numFormIndex.Value = _idx + 1

        WriteShorcutFile()



        loadFormvalues(_idx)

    End Sub

    Private Sub btMoveDown_Click(sender As Object, e As EventArgs) Handles btMoveLeft.Click
        Dim F = FormList(_idx)
        FormList(_idx) = FormList(_idx - 1)
        FormList(_idx - 1) = F

        FormList(_idx).myInstanceNumber += 1
        FormList(_idx - 1).myInstanceNumber -= 1

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


        'My.Computer.FileSystem.WriteAllText(MyPath & _link_file_name, T, True)

        Dim frm As New frmElementsGroup

        frm.ElementList.Clear()
        frm.ClosedColor = Color.Lime
        frm.BackColor = Color.White
        frm.TextColor = Color.Black

        Dim El = GenereteNewFormCFG()
        frm.ElementList.Add(El)


        frm.PopolaForm()
        FormList.Add(frm)

        numFormIndex.Maximum = FormList.Count
        numFormIndex.Value = FormList.Count

        _idx = numFormIndex.Value - 1


        Dim c = 0
        For Each F In FormList
            F.myInstanceNumber = c
            F.PopolaForm()
            c += 1
        Next



        loadFormvalues(_idx)

        frm.Show()

        btDeleteForm.Enabled = FormList.Count > 1
        btNewForm.Enabled = FormList.Count < 10
        Dim a = 0



    End Sub

    Private Sub btDeleteForm_Click(sender As Object, e As EventArgs) Handles btDeleteForm.Click

        If FormList.Count <= 1 Then Exit Sub

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
            FormList.Remove(FormList(_idx))
        ElseIf _idx = FormList.Count - 1 Then
            FormList.Remove(FormList(_idx))
            _idx -= 1
            numFormIndex.Value = FormList.Count
        Else
            FormList.Remove(FormList(_idx))
        End If

        numFormIndex.Maximum = FormList.Count

        Dim c = 0

        WriteShorcutFile()

        For Each F In FormList
            F.myInstanceNumber = c
            F.PopolaForm()
            c += 1
        Next

        loadFormvalues(_idx)

        'LoadGroupsConfiguration()

        'For Each F In FormList
        '    F.Show()
        'Next


        btDeleteForm.Enabled = FormList.Count > 1
        btNewForm.Enabled = FormList.Count < 10
    End Sub



    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox4.CheckedChanged, CheckBox5.CheckedChanged, CheckBox6.CheckedChanged, CheckBox7.CheckedChanged, CheckBox8.CheckedChanged, CheckBox9.CheckedChanged, CheckBox10.CheckedChanged
        Dim chk = DirectCast(sender, CheckBox)
        Dim folder_idx As Integer = chk.Tag
        Dim folder = Environment.GetFolderPath(folder_idx)

        If chk.Checked Then
            Dim El As Element
            For Each El In FormList(_idx).ElementList
                If El.Link = folder Then
                    Exit Sub
                End If
            Next

            Dim list_pos = SpecialFoldersIndex.IndexOf(folder_idx)
            Dim T = SpecialFoldersName(list_pos) & _ini_split_char & folder
            El = New Element(T)
            El.Element_Type = Element.ElementType.special_folder

            FormList(_idx).ElementList.Add(El)

            FormList(_idx).Aggiungi_Elemento(El)

            FormList(_idx).PortaElementoAllInizio(El)

        Else
            For Each El In FormList(_idx).ElementList
                If El.Link = folder Then
                    FormList(_idx).ElementList.Remove(El)
                    Exit Sub
                End If
            Next
        End If

        WriteShorcutFile()
        'FormList(_idx).PopolaForm()


    End Sub

    Private Sub lbColorClipboard_Click(sender As Object, e As EventArgs) Handles lbColorClipboard.Click
        Dim OCD = New ColorDialog
        OCD.AllowFullOpen = True
        OCD.Color = lbColorClipboard.BackColor
        OCD.FullOpen = True
        If OCD.ShowDialog = DialogResult.OK Then
            lbColorClipboard.BackColor = OCD.Color
        End If

        _clipboard_close_color = lbColorClipboard.BackColor
        frmMultiClipboard.ClosedColor = _clipboard_close_color

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

        _clipboard_open_color = lbBackColorClipboard.BackColor
        frmMultiClipboard.OpenedColor = _clipboard_open_color

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

        _clipboard_elements_number = numElementsNumber.Value
        frmMultiClipboard.ElementsNumber = _clipboard_elements_number

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

        _fixedtext_close_color = lbColorFixed.BackColor
        frmFixedText.ClosedColor = _fixedtext_close_color

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

        _fixedtext_open_color = lbBackColorFixed.BackColor
        frmFixedText.BackColor = _fixedtext_open_color

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

        _fixedtext_text_color = lbTextColorFixed.BackColor
        frmFixedText.TextColor = _fixedtext_text_color

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
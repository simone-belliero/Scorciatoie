<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImpostazioni
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpostazioni))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        numOffset = New NumericUpDown()
        numWidth = New NumericUpDown()
        lbColor = New Label()
        Label4 = New Label()
        chkAutomaticStart = New CheckBox()
        Label5 = New Label()
        lbBackColor = New Label()
        Label7 = New Label()
        lbTextColor = New Label()
        lbApriGestione = New LinkLabel()
        numFormIndex = New NumericUpDown()
        Label6 = New Label()
        btNewForm = New Button()
        btDeleteForm = New Button()
        gbGroupElement = New GroupBox()
        btMoveRight = New Button()
        btMoveLeft = New Button()
        CheckBox1 = New CheckBox()
        CheckBox2 = New CheckBox()
        CheckBox3 = New CheckBox()
        CheckBox4 = New CheckBox()
        CheckBox5 = New CheckBox()
        CheckBox6 = New CheckBox()
        CheckBox7 = New CheckBox()
        CheckBox8 = New CheckBox()
        CheckBox9 = New CheckBox()
        CheckBox10 = New CheckBox()
        Label8 = New Label()
        gbFolders = New GroupBox()
        gbClipboard = New GroupBox()
        numElementsNumber = New NumericUpDown()
        lbBackColorClipboard = New Label()
        Label16 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        lbColorClipboard = New Label()
        Label14 = New Label()
        lbTextColorClipboard = New Label()
        gbClipboardFixedLines = New GroupBox()
        txFixedText = New TextBox()
        GroupBox1 = New GroupBox()
        lbBackColorFixed = New Label()
        Label15 = New Label()
        Label17 = New Label()
        Label18 = New Label()
        lbColorFixed = New Label()
        Label20 = New Label()
        lbTextColorFixed = New Label()
        TabControl1 = New TabControl()
        TabPageGroup = New TabPage()
        TabPageClipboard = New TabPage()
        TabPageFixedTexts = New TabPage()
        CType(numOffset, ComponentModel.ISupportInitialize).BeginInit()
        CType(numWidth, ComponentModel.ISupportInitialize).BeginInit()
        CType(numFormIndex, ComponentModel.ISupportInitialize).BeginInit()
        gbGroupElement.SuspendLayout()
        gbFolders.SuspendLayout()
        gbClipboard.SuspendLayout()
        CType(numElementsNumber, ComponentModel.ISupportInitialize).BeginInit()
        gbClipboardFixedLines.SuspendLayout()
        GroupBox1.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPageGroup.SuspendLayout()
        TabPageClipboard.SuspendLayout()
        TabPageFixedTexts.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(33, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 15)
        Label1.TabIndex = 0
        Label1.Text = "Offset from center :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(67, 10)
        Label2.Name = "Label2"
        Label2.Size = New Size(76, 15)
        Label2.TabIndex = 0
        Label2.Text = "Size (Width) :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(96, 58)
        Label3.Name = "Label3"
        Label3.Size = New Size(42, 15)
        Label3.TabIndex = 0
        Label3.Text = "Color :"
        ' 
        ' numOffset
        ' 
        numOffset.Location = New Point(156, 36)
        numOffset.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        numOffset.Minimum = New Decimal(New Integer() {2000, 0, 0, Integer.MinValue})
        numOffset.Name = "numOffset"
        numOffset.Size = New Size(65, 23)
        numOffset.TabIndex = 1
        ' 
        ' numWidth
        ' 
        numWidth.Location = New Point(156, 8)
        numWidth.Name = "numWidth"
        numWidth.Size = New Size(65, 23)
        numWidth.TabIndex = 1
        ' 
        ' lbColor
        ' 
        lbColor.BorderStyle = BorderStyle.FixedSingle
        lbColor.Location = New Point(151, 54)
        lbColor.Name = "lbColor"
        lbColor.Size = New Size(65, 23)
        lbColor.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(32, 73)
        Label4.Name = "Label4"
        Label4.Size = New Size(162, 15)
        Label4.TabIndex = 0
        Label4.Text = "Automatic start on windows :"
        ' 
        ' chkAutomaticStart
        ' 
        chkAutomaticStart.AutoSize = True
        chkAutomaticStart.Location = New Point(207, 74)
        chkAutomaticStart.Name = "chkAutomaticStart"
        chkAutomaticStart.Size = New Size(15, 14)
        chkAutomaticStart.TabIndex = 2
        chkAutomaticStart.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(29, 92)
        Label5.Name = "Label5"
        Label5.Size = New Size(109, 15)
        Label5.TabIndex = 0
        Label5.Text = "Background Color :"
        ' 
        ' lbBackColor
        ' 
        lbBackColor.BorderStyle = BorderStyle.FixedSingle
        lbBackColor.Location = New Point(151, 88)
        lbBackColor.Name = "lbBackColor"
        lbBackColor.Size = New Size(65, 23)
        lbBackColor.TabIndex = 0
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(72, 124)
        Label7.Name = "Label7"
        Label7.Size = New Size(66, 15)
        Label7.TabIndex = 0
        Label7.Text = "Text Color :"
        ' 
        ' lbTextColor
        ' 
        lbTextColor.BorderStyle = BorderStyle.FixedSingle
        lbTextColor.Location = New Point(151, 120)
        lbTextColor.Name = "lbTextColor"
        lbTextColor.Size = New Size(65, 23)
        lbTextColor.TabIndex = 0
        ' 
        ' lbApriGestione
        ' 
        lbApriGestione.AutoSize = True
        lbApriGestione.Location = New Point(84, 161)
        lbApriGestione.Name = "lbApriGestione"
        lbApriGestione.Size = New Size(77, 15)
        lbApriGestione.TabIndex = 3
        lbApriGestione.TabStop = True
        lbApriGestione.Text = "Open link file"
        ' 
        ' numFormIndex
        ' 
        numFormIndex.Location = New Point(143, 22)
        numFormIndex.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        numFormIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numFormIndex.Name = "numFormIndex"
        numFormIndex.Size = New Size(43, 23)
        numFormIndex.TabIndex = 4
        numFormIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(59, 24)
        Label6.Name = "Label6"
        Label6.Size = New Size(77, 15)
        Label6.TabIndex = 0
        Label6.Text = "Link group n."
        ' 
        ' btNewForm
        ' 
        btNewForm.Location = New Point(17, 199)
        btNewForm.Name = "btNewForm"
        btNewForm.Size = New Size(111, 28)
        btNewForm.TabIndex = 5
        btNewForm.Text = "New link group"
        btNewForm.UseVisualStyleBackColor = True
        ' 
        ' btDeleteForm
        ' 
        btDeleteForm.Location = New Point(129, 199)
        btDeleteForm.Name = "btDeleteForm"
        btDeleteForm.Size = New Size(111, 28)
        btDeleteForm.TabIndex = 5
        btDeleteForm.Text = "Delete link group"
        btDeleteForm.UseVisualStyleBackColor = True
        ' 
        ' gbGroupElement
        ' 
        gbGroupElement.Controls.Add(lbBackColor)
        gbGroupElement.Controls.Add(Label6)
        gbGroupElement.Controls.Add(Label3)
        gbGroupElement.Controls.Add(numFormIndex)
        gbGroupElement.Controls.Add(Label5)
        gbGroupElement.Controls.Add(lbApriGestione)
        gbGroupElement.Controls.Add(lbColor)
        gbGroupElement.Controls.Add(Label7)
        gbGroupElement.Controls.Add(lbTextColor)
        gbGroupElement.Location = New Point(6, 6)
        gbGroupElement.Name = "gbGroupElement"
        gbGroupElement.Size = New Size(245, 187)
        gbGroupElement.TabIndex = 6
        gbGroupElement.TabStop = False
        ' 
        ' btMoveRight
        ' 
        btMoveRight.Location = New Point(129, 233)
        btMoveRight.Name = "btMoveRight"
        btMoveRight.Size = New Size(111, 28)
        btMoveRight.TabIndex = 5
        btMoveRight.Text = "Nove group right"
        btMoveRight.UseVisualStyleBackColor = True
        ' 
        ' btMoveLeft
        ' 
        btMoveLeft.Location = New Point(17, 233)
        btMoveLeft.Name = "btMoveLeft"
        btMoveLeft.Size = New Size(111, 28)
        btMoveLeft.TabIndex = 5
        btMoveLeft.Text = "Move group left"
        btMoveLeft.UseVisualStyleBackColor = True
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(3, 43)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(109, 19)
        CheckBox1.TabIndex = 8
        CheckBox1.Tag = "38"
        CheckBox1.Text = "Program follder"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' CheckBox2
        ' 
        CheckBox2.AutoSize = True
        CheckBox2.Location = New Point(3, 68)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(103, 19)
        CheckBox2.TabIndex = 8
        CheckBox2.Tag = "16"
        CheckBox2.Text = "Desktop folder"
        CheckBox2.UseVisualStyleBackColor = True
        ' 
        ' CheckBox3
        ' 
        CheckBox3.AutoSize = True
        CheckBox3.Location = New Point(3, 93)
        CheckBox3.Name = "CheckBox3"
        CheckBox3.Size = New Size(89, 19)
        CheckBox3.TabIndex = 8
        CheckBox3.Tag = "20"
        CheckBox3.Text = "Fonts folder"
        CheckBox3.UseVisualStyleBackColor = True
        ' 
        ' CheckBox4
        ' 
        CheckBox4.AutoSize = True
        CheckBox4.Location = New Point(3, 118)
        CheckBox4.Name = "CheckBox4"
        CheckBox4.Size = New Size(106, 19)
        CheckBox4.TabIndex = 8
        CheckBox4.Tag = "5"
        CheckBox4.Text = "My documents"
        CheckBox4.UseVisualStyleBackColor = True
        ' 
        ' CheckBox5
        ' 
        CheckBox5.AutoSize = True
        CheckBox5.Location = New Point(3, 143)
        CheckBox5.Name = "CheckBox5"
        CheckBox5.Size = New Size(78, 19)
        CheckBox5.TabIndex = 8
        CheckBox5.Tag = "13"
        CheckBox5.Text = "My music"
        CheckBox5.UseVisualStyleBackColor = True
        ' 
        ' CheckBox6
        ' 
        CheckBox6.AutoSize = True
        CheckBox6.Location = New Point(120, 43)
        CheckBox6.Name = "CheckBox6"
        CheckBox6.Size = New Size(88, 19)
        CheckBox6.TabIndex = 8
        CheckBox6.Tag = "39"
        CheckBox6.Text = "My pictures"
        CheckBox6.UseVisualStyleBackColor = True
        ' 
        ' CheckBox7
        ' 
        CheckBox7.AutoSize = True
        CheckBox7.Location = New Point(120, 68)
        CheckBox7.Name = "CheckBox7"
        CheckBox7.Size = New Size(96, 19)
        CheckBox7.TabIndex = 8
        CheckBox7.Tag = "38"
        CheckBox7.Text = "Program files"
        CheckBox7.UseVisualStyleBackColor = True
        ' 
        ' CheckBox8
        ' 
        CheckBox8.AutoSize = True
        CheckBox8.Location = New Point(120, 93)
        CheckBox8.Name = "CheckBox8"
        CheckBox8.Size = New Size(125, 19)
        CheckBox8.TabIndex = 8
        CheckBox8.Tag = "42"
        CheckBox8.Text = "Program files (x86)"
        CheckBox8.UseVisualStyleBackColor = True
        ' 
        ' CheckBox9
        ' 
        CheckBox9.AutoSize = True
        CheckBox9.Location = New Point(120, 118)
        CheckBox9.Name = "CheckBox9"
        CheckBox9.Size = New Size(77, 19)
        CheckBox9.TabIndex = 8
        CheckBox9.Tag = "2"
        CheckBox9.Text = "Programs"
        CheckBox9.UseVisualStyleBackColor = True
        ' 
        ' CheckBox10
        ' 
        CheckBox10.AutoSize = True
        CheckBox10.Location = New Point(120, 143)
        CheckBox10.Name = "CheckBox10"
        CheckBox10.Size = New Size(64, 19)
        CheckBox10.TabIndex = 8
        CheckBox10.Tag = "7"
        CheckBox10.Text = "Startup"
        CheckBox10.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label8.Location = New Point(44, 19)
        Label8.Name = "Label8"
        Label8.Size = New Size(160, 15)
        Label8.TabIndex = 0
        Label8.Text = "Add/Remove Special folder"
        ' 
        ' gbFolders
        ' 
        gbFolders.Controls.Add(Label8)
        gbFolders.Controls.Add(CheckBox10)
        gbFolders.Controls.Add(CheckBox1)
        gbFolders.Controls.Add(CheckBox2)
        gbFolders.Controls.Add(CheckBox9)
        gbFolders.Controls.Add(CheckBox3)
        gbFolders.Controls.Add(CheckBox8)
        gbFolders.Controls.Add(CheckBox4)
        gbFolders.Controls.Add(CheckBox7)
        gbFolders.Controls.Add(CheckBox5)
        gbFolders.Controls.Add(CheckBox6)
        gbFolders.Location = New Point(6, 267)
        gbFolders.Name = "gbFolders"
        gbFolders.Size = New Size(245, 176)
        gbFolders.TabIndex = 9
        gbFolders.TabStop = False
        gbFolders.Visible = False
        ' 
        ' gbClipboard
        ' 
        gbClipboard.Controls.Add(numElementsNumber)
        gbClipboard.Controls.Add(lbBackColorClipboard)
        gbClipboard.Controls.Add(Label16)
        gbClipboard.Controls.Add(Label10)
        gbClipboard.Controls.Add(Label11)
        gbClipboard.Controls.Add(Label12)
        gbClipboard.Controls.Add(lbColorClipboard)
        gbClipboard.Controls.Add(Label14)
        gbClipboard.Controls.Add(lbTextColorClipboard)
        gbClipboard.Location = New Point(6, 6)
        gbClipboard.Name = "gbClipboard"
        gbClipboard.Size = New Size(245, 187)
        gbClipboard.TabIndex = 6
        gbClipboard.TabStop = False
        ' 
        ' numElementsNumber
        ' 
        numElementsNumber.Location = New Point(170, 150)
        numElementsNumber.Maximum = New Decimal(New Integer() {40, 0, 0, 0})
        numElementsNumber.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        numElementsNumber.Name = "numElementsNumber"
        numElementsNumber.Size = New Size(52, 23)
        numElementsNumber.TabIndex = 1
        numElementsNumber.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' lbBackColorClipboard
        ' 
        lbBackColorClipboard.BorderStyle = BorderStyle.FixedSingle
        lbBackColorClipboard.Location = New Point(151, 88)
        lbBackColorClipboard.Name = "lbBackColorClipboard"
        lbBackColorClipboard.Size = New Size(65, 23)
        lbBackColorClipboard.TabIndex = 0
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(23, 154)
        Label16.Name = "Label16"
        Label16.Size = New Size(141, 15)
        Label16.TabIndex = 0
        Label16.Text = "Elements number (5..40) :"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label10.Location = New Point(93, 24)
        Label10.Name = "Label10"
        Label10.Size = New Size(59, 15)
        Label10.TabIndex = 0
        Label10.Text = "Clipboard"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(96, 58)
        Label11.Name = "Label11"
        Label11.Size = New Size(42, 15)
        Label11.TabIndex = 0
        Label11.Text = "Color :"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(29, 92)
        Label12.Name = "Label12"
        Label12.Size = New Size(109, 15)
        Label12.TabIndex = 0
        Label12.Text = "Background Color :"
        ' 
        ' lbColorClipboard
        ' 
        lbColorClipboard.BorderStyle = BorderStyle.FixedSingle
        lbColorClipboard.Location = New Point(151, 54)
        lbColorClipboard.Name = "lbColorClipboard"
        lbColorClipboard.Size = New Size(65, 23)
        lbColorClipboard.TabIndex = 0
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(72, 124)
        Label14.Name = "Label14"
        Label14.Size = New Size(66, 15)
        Label14.TabIndex = 0
        Label14.Text = "Text Color :"
        ' 
        ' lbTextColorClipboard
        ' 
        lbTextColorClipboard.BorderStyle = BorderStyle.FixedSingle
        lbTextColorClipboard.Location = New Point(151, 120)
        lbTextColorClipboard.Name = "lbTextColorClipboard"
        lbTextColorClipboard.Size = New Size(65, 23)
        lbTextColorClipboard.TabIndex = 0
        ' 
        ' gbClipboardFixedLines
        ' 
        gbClipboardFixedLines.Controls.Add(txFixedText)
        gbClipboardFixedLines.Location = New Point(6, 200)
        gbClipboardFixedLines.Name = "gbClipboardFixedLines"
        gbClipboardFixedLines.Size = New Size(245, 244)
        gbClipboardFixedLines.TabIndex = 6
        gbClipboardFixedLines.TabStop = False
        ' 
        ' txFixedText
        ' 
        txFixedText.BorderStyle = BorderStyle.FixedSingle
        txFixedText.Location = New Point(4, 20)
        txFixedText.Multiline = True
        txFixedText.Name = "txFixedText"
        txFixedText.ScrollBars = ScrollBars.Both
        txFixedText.Size = New Size(235, 218)
        txFixedText.TabIndex = 0
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lbBackColorFixed)
        GroupBox1.Controls.Add(Label15)
        GroupBox1.Controls.Add(Label17)
        GroupBox1.Controls.Add(Label18)
        GroupBox1.Controls.Add(lbColorFixed)
        GroupBox1.Controls.Add(Label20)
        GroupBox1.Controls.Add(lbTextColorFixed)
        GroupBox1.Location = New Point(6, 6)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(245, 187)
        GroupBox1.TabIndex = 6
        GroupBox1.TabStop = False
        ' 
        ' lbBackColorFixed
        ' 
        lbBackColorFixed.BorderStyle = BorderStyle.FixedSingle
        lbBackColorFixed.Location = New Point(151, 88)
        lbBackColorFixed.Name = "lbBackColorFixed"
        lbBackColorFixed.Size = New Size(65, 23)
        lbBackColorFixed.TabIndex = 0
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label15.Location = New Point(93, 24)
        Label15.Name = "Label15"
        Label15.Size = New Size(70, 15)
        Label15.TabIndex = 0
        Label15.Text = "Fixed Texts"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(96, 58)
        Label17.Name = "Label17"
        Label17.Size = New Size(42, 15)
        Label17.TabIndex = 0
        Label17.Text = "Color :"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(29, 92)
        Label18.Name = "Label18"
        Label18.Size = New Size(109, 15)
        Label18.TabIndex = 0
        Label18.Text = "Background Color :"
        ' 
        ' lbColorFixed
        ' 
        lbColorFixed.BorderStyle = BorderStyle.FixedSingle
        lbColorFixed.Location = New Point(151, 54)
        lbColorFixed.Name = "lbColorFixed"
        lbColorFixed.Size = New Size(65, 23)
        lbColorFixed.TabIndex = 0
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(72, 124)
        Label20.Name = "Label20"
        Label20.Size = New Size(66, 15)
        Label20.TabIndex = 0
        Label20.Text = "Text Color :"
        ' 
        ' lbTextColorFixed
        ' 
        lbTextColorFixed.BorderStyle = BorderStyle.FixedSingle
        lbTextColorFixed.Location = New Point(151, 120)
        lbTextColorFixed.Name = "lbTextColorFixed"
        lbTextColorFixed.Size = New Size(65, 23)
        lbTextColorFixed.TabIndex = 0
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPageGroup)
        TabControl1.Controls.Add(TabPageClipboard)
        TabControl1.Controls.Add(TabPageFixedTexts)
        TabControl1.Location = New Point(1, 94)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(264, 479)
        TabControl1.TabIndex = 11
        ' 
        ' TabPageGroup
        ' 
        TabPageGroup.Controls.Add(gbGroupElement)
        TabPageGroup.Controls.Add(btNewForm)
        TabPageGroup.Controls.Add(btMoveRight)
        TabPageGroup.Controls.Add(btDeleteForm)
        TabPageGroup.Controls.Add(gbFolders)
        TabPageGroup.Controls.Add(btMoveLeft)
        TabPageGroup.Location = New Point(4, 24)
        TabPageGroup.Name = "TabPageGroup"
        TabPageGroup.Padding = New Padding(3)
        TabPageGroup.Size = New Size(256, 451)
        TabPageGroup.TabIndex = 0
        TabPageGroup.Text = "Group"
        TabPageGroup.UseVisualStyleBackColor = True
        ' 
        ' TabPageClipboard
        ' 
        TabPageClipboard.Controls.Add(gbClipboard)
        TabPageClipboard.Location = New Point(4, 24)
        TabPageClipboard.Name = "TabPageClipboard"
        TabPageClipboard.Padding = New Padding(3)
        TabPageClipboard.Size = New Size(256, 451)
        TabPageClipboard.TabIndex = 1
        TabPageClipboard.Text = "Clipboard"
        TabPageClipboard.UseVisualStyleBackColor = True
        ' 
        ' TabPageFixedTexts
        ' 
        TabPageFixedTexts.Controls.Add(GroupBox1)
        TabPageFixedTexts.Controls.Add(gbClipboardFixedLines)
        TabPageFixedTexts.Location = New Point(4, 24)
        TabPageFixedTexts.Name = "TabPageFixedTexts"
        TabPageFixedTexts.Padding = New Padding(3)
        TabPageFixedTexts.Size = New Size(256, 451)
        TabPageFixedTexts.TabIndex = 2
        TabPageFixedTexts.Text = "Fixed Texts"
        TabPageFixedTexts.UseVisualStyleBackColor = True
        ' 
        ' frmImpostazioni
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(265, 576)
        Controls.Add(TabControl1)
        Controls.Add(chkAutomaticStart)
        Controls.Add(numWidth)
        Controls.Add(numOffset)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmImpostazioni"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Impostazioni"
        CType(numOffset, ComponentModel.ISupportInitialize).EndInit()
        CType(numWidth, ComponentModel.ISupportInitialize).EndInit()
        CType(numFormIndex, ComponentModel.ISupportInitialize).EndInit()
        gbGroupElement.ResumeLayout(False)
        gbGroupElement.PerformLayout()
        gbFolders.ResumeLayout(False)
        gbFolders.PerformLayout()
        gbClipboard.ResumeLayout(False)
        gbClipboard.PerformLayout()
        CType(numElementsNumber, ComponentModel.ISupportInitialize).EndInit()
        gbClipboardFixedLines.ResumeLayout(False)
        gbClipboardFixedLines.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        TabControl1.ResumeLayout(False)
        TabPageGroup.ResumeLayout(False)
        TabPageClipboard.ResumeLayout(False)
        TabPageFixedTexts.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents numOffset As NumericUpDown
    Friend WithEvents numWidth As NumericUpDown
    Friend WithEvents lbColor As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkAutomaticStart As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lbBackColor As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbTextColor As Label
    Friend WithEvents lbApriGestione As LinkLabel
    Friend WithEvents numFormIndex As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents btNewForm As Button
    Friend WithEvents btDeleteForm As Button
    Friend WithEvents gbGroupElement As GroupBox
    Friend WithEvents btMoveRight As Button
    Friend WithEvents btMoveLeft As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox8 As CheckBox
    Friend WithEvents CheckBox9 As CheckBox
    Friend WithEvents CheckBox10 As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents gbFolders As GroupBox
    Friend WithEvents gbClipboard As GroupBox
    Friend WithEvents numElementsNumber As NumericUpDown
    Friend WithEvents lbBackColorClipboard As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lbColorClipboard As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lbTextColorClipboard As Label
    Friend WithEvents gbClipboardFixedLines As GroupBox
    Friend WithEvents txFixedText As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbBackColorFixed As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lbColorFixed As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lbTextColorFixed As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageGroup As TabPage
    Friend WithEvents TabPageClipboard As TabPage
    Friend WithEvents TabPageFixedTexts As TabPage
End Class

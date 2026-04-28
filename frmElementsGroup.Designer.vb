<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmElementsGroup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElementsGroup))
        Timer1 = New Timer(components)
        niScorciatoie = New NotifyIcon(components)
        cmsIcona = New ContextMenuStrip(components)
        mnuImpostazioni = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        mnuEsci = New ToolStripMenuItem()
        cmsElement = New ContextMenuStrip(components)
        mnuRename = New ToolStripMenuItem()
        mnuInsertSeparator = New ToolStripMenuItem()
        mnuMove = New ToolStripMenuItem()
        mnuMoveInNewPosition = New ToolStripMenuItem()
        ToolStripSeparator4 = New ToolStripSeparator()
        mnuMoveFirst = New ToolStripMenuItem()
        mnuMoveUp = New ToolStripMenuItem()
        mnuMoveDown = New ToolStripMenuItem()
        mnuMoveLast = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        mnuCopy = New ToolStripMenuItem()
        mnuPaste = New ToolStripMenuItem()
        mnuRemove = New ToolStripMenuItem()
        ToolTip1 = New ToolTip(components)
        Timer_PortaInPrimoPiano = New Timer(components)
        cmsIcona.SuspendLayout()
        cmsElement.SuspendLayout()
        SuspendLayout()
        ' 
        ' Timer1
        ' 
        ' 
        ' niScorciatoie
        ' 
        niScorciatoie.BalloonTipText = "Scorciatoie"
        niScorciatoie.ContextMenuStrip = cmsIcona
        niScorciatoie.Icon = CType(resources.GetObject("niScorciatoie.Icon"), Icon)
        niScorciatoie.Text = "Scorciatoie"
        niScorciatoie.Visible = True
        ' 
        ' cmsIcona
        ' 
        cmsIcona.Items.AddRange(New ToolStripItem() {mnuImpostazioni, ToolStripSeparator1, mnuEsci})
        cmsIcona.Name = "cmsIcona"
        cmsIcona.Size = New Size(143, 54)
        ' 
        ' mnuImpostazioni
        ' 
        mnuImpostazioni.Name = "mnuImpostazioni"
        mnuImpostazioni.Size = New Size(142, 22)
        mnuImpostazioni.Text = "Impostazioni"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(139, 6)
        ' 
        ' mnuEsci
        ' 
        mnuEsci.Name = "mnuEsci"
        mnuEsci.Size = New Size(142, 22)
        mnuEsci.Text = "Esci"
        ' 
        ' cmsElement
        ' 
        cmsElement.Items.AddRange(New ToolStripItem() {mnuRename, mnuInsertSeparator, mnuMove, ToolStripSeparator3, mnuCopy, mnuPaste, mnuRemove})
        cmsElement.Name = "cmsElement"
        cmsElement.Size = New Size(156, 142)
        ' 
        ' mnuRename
        ' 
        mnuRename.Name = "mnuRename"
        mnuRename.Size = New Size(155, 22)
        mnuRename.Text = "Rename"
        ' 
        ' mnuInsertSeparator
        ' 
        mnuInsertSeparator.Name = "mnuInsertSeparator"
        mnuInsertSeparator.Size = New Size(155, 22)
        mnuInsertSeparator.Text = "Insert separator"
        ' 
        ' mnuMove
        ' 
        mnuMove.DropDownItems.AddRange(New ToolStripItem() {mnuMoveInNewPosition, ToolStripSeparator4, mnuMoveFirst, mnuMoveUp, mnuMoveDown, mnuMoveLast})
        mnuMove.Name = "mnuMove"
        mnuMove.Size = New Size(155, 22)
        mnuMove.Text = "Move"
        ' 
        ' mnuMoveInNewPosition
        ' 
        mnuMoveInNewPosition.Name = "mnuMoveInNewPosition"
        mnuMoveInNewPosition.Size = New Size(188, 22)
        mnuMoveInNewPosition.Text = "Move in new position"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(185, 6)
        ' 
        ' mnuMoveFirst
        ' 
        mnuMoveFirst.Name = "mnuMoveFirst"
        mnuMoveFirst.Size = New Size(188, 22)
        mnuMoveFirst.Text = "Move first"
        ' 
        ' mnuMoveUp
        ' 
        mnuMoveUp.Name = "mnuMoveUp"
        mnuMoveUp.Size = New Size(188, 22)
        mnuMoveUp.Text = "Move up"
        ' 
        ' mnuMoveDown
        ' 
        mnuMoveDown.Name = "mnuMoveDown"
        mnuMoveDown.Size = New Size(188, 22)
        mnuMoveDown.Text = "Move down"
        ' 
        ' mnuMoveLast
        ' 
        mnuMoveLast.Name = "mnuMoveLast"
        mnuMoveLast.Size = New Size(188, 22)
        mnuMoveLast.Text = "Move last"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(152, 6)
        ' 
        ' mnuCopy
        ' 
        mnuCopy.Name = "mnuCopy"
        mnuCopy.Size = New Size(155, 22)
        mnuCopy.Text = "Copy"
        ' 
        ' mnuPaste
        ' 
        mnuPaste.Name = "mnuPaste"
        mnuPaste.Size = New Size(155, 22)
        mnuPaste.Text = "Paste"
        ' 
        ' mnuRemove
        ' 
        mnuRemove.Name = "mnuRemove"
        mnuRemove.Size = New Size(155, 22)
        mnuRemove.Text = "Remove"
        ' 
        ' Timer_PortaInPrimoPiano
        ' 
        Timer_PortaInPrimoPiano.Enabled = True
        ' 
        ' frmElementsGroup
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(127, 223)
        ControlBox = False
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Location = New Point(10, 10)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmElementsGroup"
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.Manual
        TopMost = True
        cmsIcona.ResumeLayout(False)
        cmsElement.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents niScorciatoie As NotifyIcon
    Friend WithEvents cmsIcona As ContextMenuStrip
    Friend WithEvents mnuImpostazioni As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuEsci As ToolStripMenuItem
    Friend WithEvents cmsElement As ContextMenuStrip
    Friend WithEvents mnuRename As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuRemove As ToolStripMenuItem
    Friend WithEvents mnuMove As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents mnuMoveFirst As ToolStripMenuItem
    Friend WithEvents mnuMoveUp As ToolStripMenuItem
    Friend WithEvents mnuMoveDown As ToolStripMenuItem
    Friend WithEvents mnuMoveLast As ToolStripMenuItem
    Friend WithEvents mnuMoveInNewPosition As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents mnuInsertSeparator As ToolStripMenuItem
    Friend WithEvents mnuPaste As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents mnuCopy As ToolStripMenuItem
    Friend WithEvents Timer_PortaInPrimoPiano As Timer
End Class

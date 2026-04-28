<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFixedText
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
        components = New ComponentModel.Container()
        Timer1 = New Timer(components)
        ToolTip1 = New ToolTip(components)
        Timer_PortaInPrimoPiano = New Timer(components)
        SuspendLayout()
        ' 
        ' Timer1
        ' 
        ' 
        ' Timer_PortaInPrimoPiano
        ' 
        Timer_PortaInPrimoPiano.Enabled = True
        ' 
        ' frmFixedText
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(133, 188)
        ControlBox = False
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmFixedText"
        ShowIcon = False
        ShowInTaskbar = False
        ResumeLayout(False)
    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Timer_PortaInPrimoPiano As Timer
End Class

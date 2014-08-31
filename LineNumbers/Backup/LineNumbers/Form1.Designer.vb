<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.LineNumbers_For_RichTextBox1 = New LineNumbers.LineNumbers_For_RichTextBox
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(29, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ShowSelectionMargin = True
        Me.RichTextBox1.Size = New System.Drawing.Size(364, 298)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'LineNumbers_For_RichTextBox1
        '
        Me.LineNumbers_For_RichTextBox1._SeeThroughMode_ = False
        Me.LineNumbers_For_RichTextBox1.AutoSizing = True
        Me.LineNumbers_For_RichTextBox1.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LineNumbers_For_RichTextBox1.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue
        Me.LineNumbers_For_RichTextBox1.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.LineNumbers_For_RichTextBox1.BorderLines_Color = System.Drawing.Color.SlateGray
        Me.LineNumbers_For_RichTextBox1.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot
        Me.LineNumbers_For_RichTextBox1.BorderLines_Thickness = 1.0!
        Me.LineNumbers_For_RichTextBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LineNumbers_For_RichTextBox1.DockSide = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Left
        Me.LineNumbers_For_RichTextBox1.GridLines_Color = System.Drawing.Color.SlateGray
        Me.LineNumbers_For_RichTextBox1.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot
        Me.LineNumbers_For_RichTextBox1.GridLines_Thickness = 1.0!
        Me.LineNumbers_For_RichTextBox1.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight
        Me.LineNumbers_For_RichTextBox1.LineNrs_AntiAlias = True
        Me.LineNumbers_For_RichTextBox1.LineNrs_AsHexadecimal = False
        Me.LineNumbers_For_RichTextBox1.LineNrs_ClippedByItemRectangle = True
        Me.LineNumbers_For_RichTextBox1.LineNrs_LeadingZeroes = True
        Me.LineNumbers_For_RichTextBox1.LineNrs_Offset = New System.Drawing.Size(0, 0)
        Me.LineNumbers_For_RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.LineNumbers_For_RichTextBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.LineNumbers_For_RichTextBox1.MarginLines_Color = System.Drawing.Color.SlateGray
        Me.LineNumbers_For_RichTextBox1.MarginLines_Side = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Right
        Me.LineNumbers_For_RichTextBox1.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid
        Me.LineNumbers_For_RichTextBox1.MarginLines_Thickness = 1.0!
        Me.LineNumbers_For_RichTextBox1.Name = "LineNumbers_For_RichTextBox1"
        Me.LineNumbers_For_RichTextBox1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.LineNumbers_For_RichTextBox1.ParentRichTextBox = Me.RichTextBox1
        Me.LineNumbers_For_RichTextBox1.Show_BackgroundGradient = True
        Me.LineNumbers_For_RichTextBox1.Show_BorderLines = True
        Me.LineNumbers_For_RichTextBox1.Show_GridLines = True
        Me.LineNumbers_For_RichTextBox1.Show_LineNrs = True
        Me.LineNumbers_For_RichTextBox1.Show_MarginLines = True
        Me.LineNumbers_For_RichTextBox1.Size = New System.Drawing.Size(29, 298)
        Me.LineNumbers_For_RichTextBox1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 298)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.LineNumbers_For_RichTextBox1)
        Me.Name = "Form1"
        Me.Text = "LineNumbers"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LineNumbers_For_RichTextBox1 As LineNumbers.LineNumbers_For_RichTextBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox

End Class

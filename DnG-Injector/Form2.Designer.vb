<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.ChTheme1 = New DnG_Injector.CHTheme()
        Me.ChButton2 = New DnG_Injector.CHButton()
        Me.ChButton1 = New DnG_Injector.CHButton()
        Me.ChGroupBox1 = New DnG_Injector.CHGroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ChTheme1.SuspendLayout()
        Me.ChGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChTheme1
        '
        Me.ChTheme1.BackColor = System.Drawing.Color.Black
        Me.ChTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChTheme1.Controls.Add(Me.ChButton2)
        Me.ChTheme1.Controls.Add(Me.ChButton1)
        Me.ChTheme1.Controls.Add(Me.ChGroupBox1)
        Me.ChTheme1.Customization = "FxcX/wD/AP8="
        Me.ChTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChTheme1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ChTheme1.Image = Nothing
        Me.ChTheme1.Location = New System.Drawing.Point(0, 0)
        Me.ChTheme1.Movable = True
        Me.ChTheme1.Name = "ChTheme1"
        Me.ChTheme1.NoRounding = False
        Me.ChTheme1.Sizable = True
        Me.ChTheme1.Size = New System.Drawing.Size(190, 280)
        Me.ChTheme1.SmartBounds = True
        Me.ChTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.ChTheme1.TabIndex = 0
        Me.ChTheme1.Text = "ChTheme1"
        Me.ChTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChTheme1.Transparent = False
        '
        'ChButton2
        '
        Me.ChButton2.Customization = "AGQA/wD/AP+Q7pD/"
        Me.ChButton2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChButton2.Image = Nothing
        Me.ChButton2.Location = New System.Drawing.Point(103, 238)
        Me.ChButton2.Name = "ChButton2"
        Me.ChButton2.NoRounding = False
        Me.ChButton2.Size = New System.Drawing.Size(75, 23)
        Me.ChButton2.TabIndex = 2
        Me.ChButton2.Text = "Cancel"
        Me.ChButton2.Transparent = False
        '
        'ChButton1
        '
        Me.ChButton1.Customization = "AGQA/wD/AP+Q7pD/"
        Me.ChButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChButton1.Image = Nothing
        Me.ChButton1.Location = New System.Drawing.Point(13, 238)
        Me.ChButton1.Name = "ChButton1"
        Me.ChButton1.NoRounding = False
        Me.ChButton1.Size = New System.Drawing.Size(75, 23)
        Me.ChButton1.TabIndex = 1
        Me.ChButton1.Text = "OK"
        Me.ChButton1.Transparent = False
        '
        'ChGroupBox1
        '
        Me.ChGroupBox1.BackColor = System.Drawing.Color.Black
        Me.ChGroupBox1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChGroupBox1.Controls.Add(Me.ListBox1)
        Me.ChGroupBox1.Customization = "AGQA/wAAAP8A/wD/"
        Me.ChGroupBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChGroupBox1.Image = Nothing
        Me.ChGroupBox1.Location = New System.Drawing.Point(13, 43)
        Me.ChGroupBox1.Movable = True
        Me.ChGroupBox1.Name = "ChGroupBox1"
        Me.ChGroupBox1.NoRounding = False
        Me.ChGroupBox1.Sizable = True
        Me.ChGroupBox1.Size = New System.Drawing.Size(165, 184)
        Me.ChGroupBox1.SmartBounds = True
        Me.ChGroupBox1.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ChGroupBox1.TabIndex = 0
        Me.ChGroupBox1.Text = "Select Process"
        Me.ChGroupBox1.TransparencyKey = System.Drawing.Color.Empty
        Me.ChGroupBox1.Transparent = False
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.Black
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.ForeColor = System.Drawing.Color.Lime
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(4, 32)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(158, 143)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 0
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(190, 280)
        Me.Controls.Add(Me.ChTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.Text = "Lista Procese"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChTheme1.ResumeLayout(False)
        Me.ChGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ChTheme1 As CHTheme
    Friend WithEvents ChButton2 As CHButton
    Friend WithEvents ChButton1 As CHButton
    Friend WithEvents ChGroupBox1 As CHGroupBox
    Friend WithEvents ListBox1 As ListBox
End Class

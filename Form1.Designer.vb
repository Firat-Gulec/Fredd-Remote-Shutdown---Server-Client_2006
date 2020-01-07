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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlTitleBar = New System.Windows.Forms.Panel
        Me.lblTitle = New System.Windows.Forms.Label
        Me.pctTitle03 = New System.Windows.Forms.PictureBox
        Me.pctTitle02 = New System.Windows.Forms.PictureBox
        Me.pnlTitleBar.SuspendLayout()
        CType(Me.pctTitle03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTitle02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(102, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "F r e d d   R C - C l i e n t"
        Me.NotifyIcon1.Visible = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(194, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(42, 77)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Hide"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(92, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Please Click Hide..."
        '
        'pnlTitleBar
        '
        Me.pnlTitleBar.BackColor = System.Drawing.Color.Transparent
        Me.pnlTitleBar.BackgroundImage = CType(resources.GetObject("pnlTitleBar.BackgroundImage"), System.Drawing.Image)
        Me.pnlTitleBar.Controls.Add(Me.lblTitle)
        Me.pnlTitleBar.Controls.Add(Me.pctTitle03)
        Me.pnlTitleBar.Controls.Add(Me.pctTitle02)
        Me.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitleBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitleBar.Name = "pnlTitleBar"
        Me.pnlTitleBar.Size = New System.Drawing.Size(316, 36)
        Me.pnlTitleBar.TabIndex = 56
        '
        'lblTitle
        '
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.LightSlateGray
        Me.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitle.Location = New System.Drawing.Point(64, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(188, 36)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "F r e d d   R C  -  C l i e n t"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctTitle03
        '
        Me.pctTitle03.BackgroundImage = CType(resources.GetObject("pctTitle03.BackgroundImage"), System.Drawing.Image)
        Me.pctTitle03.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitle03.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pctTitle03.Location = New System.Drawing.Point(252, 0)
        Me.pctTitle03.Name = "pctTitle03"
        Me.pctTitle03.Size = New System.Drawing.Size(64, 36)
        Me.pctTitle03.TabIndex = 7
        Me.pctTitle03.TabStop = False
        '
        'pctTitle02
        '
        Me.pctTitle02.BackgroundImage = CType(resources.GetObject("pctTitle02.BackgroundImage"), System.Drawing.Image)
        Me.pctTitle02.Dock = System.Windows.Forms.DockStyle.Left
        Me.pctTitle02.ErrorImage = Global.Fredd_Remote_Shutdown___Client.My.Resources.Resources.monitor_on2
        Me.pctTitle02.Image = Global.Fredd_Remote_Shutdown___Client.My.Resources.Resources.monitor_on2
        Me.pctTitle02.ImageLocation = "center"
        Me.pctTitle02.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pctTitle02.InitialImage = Global.Fredd_Remote_Shutdown___Client.My.Resources.Resources.monitor_on
        Me.pctTitle02.Location = New System.Drawing.Point(0, 0)
        Me.pctTitle02.Name = "pctTitle02"
        Me.pctTitle02.Size = New System.Drawing.Size(64, 36)
        Me.pctTitle02.TabIndex = 5
        Me.pctTitle02.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(316, 110)
        Me.Controls.Add(Me.pnlTitleBar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnlTitleBar.ResumeLayout(False)
        CType(Me.pctTitle03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTitle02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlTitleBar As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pctTitle03 As System.Windows.Forms.PictureBox
    Friend WithEvents pctTitle02 As System.Windows.Forms.PictureBox

End Class

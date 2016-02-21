<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About_RouteVisualizer
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

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About_RouteVisualizer))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.L_ImageMagick = New System.Windows.Forms.Label()
        Me.LL_ImageMagick = New System.Windows.Forms.LinkLabel()
        Me.LL_MagickNet = New System.Windows.Forms.LinkLabel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.L_Description = New System.Windows.Forms.Label()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LL_Github = New System.Windows.Forms.LinkLabel()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        resources.ApplyResources(Me.TableLayoutPanel, "TableLayoutPanel")
        Me.TableLayoutPanel.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 0, 1)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.L_ImageMagick, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LL_ImageMagick, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LL_MagickNet, 1, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'L_ImageMagick
        '
        resources.ApplyResources(Me.L_ImageMagick, "L_ImageMagick")
        Me.L_ImageMagick.Name = "L_ImageMagick"
        Me.TableLayoutPanel1.SetRowSpan(Me.L_ImageMagick, 2)
        '
        'LL_ImageMagick
        '
        resources.ApplyResources(Me.LL_ImageMagick, "LL_ImageMagick")
        Me.LL_ImageMagick.Name = "LL_ImageMagick"
        Me.LL_ImageMagick.TabStop = True
        '
        'LL_MagickNet
        '
        resources.ApplyResources(Me.LL_MagickNet, "LL_MagickNet")
        Me.LL_MagickNet.Name = "LL_MagickNet"
        Me.LL_MagickNet.TabStop = True
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.LabelVersion, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.L_Description, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelProductName, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LL_Github, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.LogoPictureBox, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelCopyright, 1, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'LabelVersion
        '
        resources.ApplyResources(Me.LabelVersion, "LabelVersion")
        Me.LabelVersion.Name = "LabelVersion"
        '
        'L_Description
        '
        resources.ApplyResources(Me.L_Description, "L_Description")
        Me.L_Description.Name = "L_Description"
        '
        'LabelProductName
        '
        resources.ApplyResources(Me.LabelProductName, "LabelProductName")
        Me.LabelProductName.Name = "LabelProductName"
        '
        'LL_Github
        '
        resources.ApplyResources(Me.LL_Github, "LL_Github")
        Me.LL_Github.Name = "LL_Github"
        Me.LL_Github.TabStop = True
        '
        'LogoPictureBox
        '
        resources.ApplyResources(Me.LogoPictureBox, "LogoPictureBox")
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.TableLayoutPanel2.SetRowSpan(Me.LogoPictureBox, 5)
        Me.LogoPictureBox.TabStop = False
        '
        'LabelCopyright
        '
        resources.ApplyResources(Me.LabelCopyright, "LabelCopyright")
        Me.LabelCopyright.Name = "LabelCopyright"
        '
        'OKButton
        '
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Name = "OKButton"
        '
        'About_RouteVisualizer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.OKButton
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About_RouteVisualizer"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents L_Description As Label
    Friend WithEvents LL_Github As LinkLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents L_ImageMagick As Label
    Friend WithEvents LL_ImageMagick As LinkLabel
    Friend WithEvents LL_MagickNet As LinkLabel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
End Class

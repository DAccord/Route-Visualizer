<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Preview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Preview))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSSL_ImageSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSL_Zoom = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.TSB_ZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.TSB_ZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.TSB_OriginalSize = New System.Windows.Forms.ToolStripButton()
        Me.TSB_FitSize = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Help = New System.Windows.Forms.ToolStripButton()
        Me.TLP_ImagePreview = New Route_Visualizer.DoubleBufferedTableLayoutPanel()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSL_ImageSize, Me.TSSL_Zoom})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'TSSL_ImageSize
        '
        Me.TSSL_ImageSize.BackColor = System.Drawing.SystemColors.Control
        Me.TSSL_ImageSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSSL_ImageSize.Name = "TSSL_ImageSize"
        resources.ApplyResources(Me.TSSL_ImageSize, "TSSL_ImageSize")
        '
        'TSSL_Zoom
        '
        Me.TSSL_Zoom.BackColor = System.Drawing.SystemColors.Control
        Me.TSSL_Zoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSSL_Zoom.Name = "TSSL_Zoom"
        resources.ApplyResources(Me.TSSL_Zoom, "TSSL_Zoom")
        Me.TSSL_Zoom.Spring = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSB_ZoomIn, Me.TSB_ZoomOut, Me.TSB_OriginalSize, Me.TSB_FitSize, Me.TSB_Help})
        resources.ApplyResources(Me.ToolStrip2, "ToolStrip2")
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.ShowItemToolTips = False
        Me.ToolStrip2.Stretch = True
        '
        'TSB_ZoomIn
        '
        Me.TSB_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.TSB_ZoomIn, "TSB_ZoomIn")
        Me.TSB_ZoomIn.Name = "TSB_ZoomIn"
        '
        'TSB_ZoomOut
        '
        Me.TSB_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.TSB_ZoomOut, "TSB_ZoomOut")
        Me.TSB_ZoomOut.Name = "TSB_ZoomOut"
        '
        'TSB_OriginalSize
        '
        Me.TSB_OriginalSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.TSB_OriginalSize, "TSB_OriginalSize")
        Me.TSB_OriginalSize.Name = "TSB_OriginalSize"
        '
        'TSB_FitSize
        '
        Me.TSB_FitSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.TSB_FitSize, "TSB_FitSize")
        Me.TSB_FitSize.Name = "TSB_FitSize"
        '
        'TSB_Help
        '
        Me.TSB_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.TSB_Help, "TSB_Help")
        Me.TSB_Help.Name = "TSB_Help"
        '
        'TLP_ImagePreview
        '
        resources.ApplyResources(Me.TLP_ImagePreview, "TLP_ImagePreview")
        Me.TLP_ImagePreview.Name = "TLP_ImagePreview"
        '
        'frm_Preview
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.TLP_ImagePreview)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "frm_Preview"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TLP_ImagePreview As DoubleBufferedTableLayoutPanel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TSSL_ImageSize As ToolStripStatusLabel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents TSB_ZoomIn As ToolStripButton
    Friend WithEvents TSB_ZoomOut As ToolStripButton
    Friend WithEvents TSB_OriginalSize As ToolStripButton
    Friend WithEvents TSB_FitSize As ToolStripButton
    Friend WithEvents TSB_Help As ToolStripButton
    Friend WithEvents TSSL_Zoom As ToolStripStatusLabel
End Class

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
        Me.PB_Preview = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_ZoomOut = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_ResetZoom = New System.Windows.Forms.Button()
        Me.Btn_Fit = New System.Windows.Forms.Button()
        Me.L_ImgSize = New System.Windows.Forms.Label()
        Me.Btn_ZoomIn = New System.Windows.Forms.Button()
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PB_Preview
        '
        resources.ApplyResources(Me.PB_Preview, "PB_Preview")
        Me.PB_Preview.Name = "PB_Preview"
        Me.PB_Preview.TabStop = False
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.PB_Preview)
        Me.Panel1.Name = "Panel1"
        '
        'Btn_ZoomOut
        '
        resources.ApplyResources(Me.Btn_ZoomOut, "Btn_ZoomOut")
        Me.Btn_ZoomOut.Name = "Btn_ZoomOut"
        Me.Btn_ZoomOut.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_ResetZoom, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_ZoomOut, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Fit, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.L_ImgSize, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_ZoomIn, 0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'Btn_ResetZoom
        '
        resources.ApplyResources(Me.Btn_ResetZoom, "Btn_ResetZoom")
        Me.Btn_ResetZoom.Name = "Btn_ResetZoom"
        Me.Btn_ResetZoom.UseVisualStyleBackColor = True
        '
        'Btn_Fit
        '
        resources.ApplyResources(Me.Btn_Fit, "Btn_Fit")
        Me.Btn_Fit.Name = "Btn_Fit"
        Me.Btn_Fit.UseVisualStyleBackColor = True
        '
        'L_ImgSize
        '
        resources.ApplyResources(Me.L_ImgSize, "L_ImgSize")
        Me.L_ImgSize.Name = "L_ImgSize"
        '
        'Btn_ZoomIn
        '
        resources.ApplyResources(Me.Btn_ZoomIn, "Btn_ZoomIn")
        Me.Btn_ZoomIn.Name = "Btn_ZoomIn"
        Me.Btn_ZoomIn.UseVisualStyleBackColor = True
        '
        'frm_Preview
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_Preview"
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PB_Preview As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Btn_ZoomOut As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Btn_ZoomIn As Button
    Friend WithEvents Btn_ResetZoom As Button
    Friend WithEvents Btn_Fit As Button
    Friend WithEvents L_ImgSize As Label
End Class

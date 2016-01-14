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
        Me.Btn_ZoomIn = New System.Windows.Forms.Button()
        Me.Btn_ResetZoom = New System.Windows.Forms.Button()
        Me.Btn_Fit = New System.Windows.Forms.Button()
        Me.L_ImgSize = New System.Windows.Forms.Label()
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PB_Preview
        '
        Me.PB_Preview.Location = New System.Drawing.Point(0, 0)
        Me.PB_Preview.Name = "PB_Preview"
        Me.PB_Preview.Size = New System.Drawing.Size(228, 110)
        Me.PB_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_Preview.TabIndex = 0
        Me.PB_Preview.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.PB_Preview)
        Me.Panel1.Location = New System.Drawing.Point(3, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(618, 329)
        Me.Panel1.TabIndex = 1
        '
        'Btn_ZoomOut
        '
        Me.Btn_ZoomOut.AutoSize = True
        Me.Btn_ZoomOut.Location = New System.Drawing.Point(107, 3)
        Me.Btn_ZoomOut.Name = "Btn_ZoomOut"
        Me.Btn_ZoomOut.Size = New System.Drawing.Size(98, 30)
        Me.Btn_ZoomOut.TabIndex = 2
        Me.Btn_ZoomOut.Text = "-"
        Me.Btn_ZoomOut.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_ResetZoom, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_ZoomOut, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Fit, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.L_ImgSize, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_ZoomIn, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(618, 36)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Btn_ZoomIn
        '
        Me.Btn_ZoomIn.AutoSize = True
        Me.Btn_ZoomIn.Location = New System.Drawing.Point(3, 3)
        Me.Btn_ZoomIn.Name = "Btn_ZoomIn"
        Me.Btn_ZoomIn.Size = New System.Drawing.Size(98, 30)
        Me.Btn_ZoomIn.TabIndex = 4
        Me.Btn_ZoomIn.Text = "+"
        Me.Btn_ZoomIn.UseVisualStyleBackColor = True
        '
        'Btn_ResetZoom
        '
        Me.Btn_ResetZoom.AutoSize = True
        Me.Btn_ResetZoom.Location = New System.Drawing.Point(211, 3)
        Me.Btn_ResetZoom.Name = "Btn_ResetZoom"
        Me.Btn_ResetZoom.Size = New System.Drawing.Size(111, 30)
        Me.Btn_ResetZoom.TabIndex = 3
        Me.Btn_ResetZoom.Text = "Originalgröße"
        Me.Btn_ResetZoom.UseVisualStyleBackColor = True
        '
        'Btn_Fit
        '
        Me.Btn_Fit.AutoSize = True
        Me.Btn_Fit.Location = New System.Drawing.Point(328, 3)
        Me.Btn_Fit.Name = "Btn_Fit"
        Me.Btn_Fit.Size = New System.Drawing.Size(84, 30)
        Me.Btn_Fit.TabIndex = 5
        Me.Btn_Fit.Text = "Einpassen"
        Me.Btn_Fit.UseVisualStyleBackColor = True
        '
        'L_ImgSize
        '
        Me.L_ImgSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.L_ImgSize.AutoSize = True
        Me.L_ImgSize.Location = New System.Drawing.Point(418, 8)
        Me.L_ImgSize.Name = "L_ImgSize"
        Me.L_ImgSize.Size = New System.Drawing.Size(53, 20)
        Me.L_ImgSize.TabIndex = 6
        Me.L_ImgSize.Text = "Label1"
        '
        'frm_Preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(624, 373)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frm_Preview"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Text = "Route Visualizer - Vorschau"
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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_AddEditRoutefile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_AddEditRoutefile))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.L_EditingFollowingFiles = New System.Windows.Forms.Label()
        Me.NUD_LineWidth = New System.Windows.Forms.NumericUpDown()
        Me.NUD_Alpha = New System.Windows.Forms.NumericUpDown()
        Me.L_Linewidth = New System.Windows.Forms.Label()
        Me.L_Alpha = New System.Windows.Forms.Label()
        Me.DGV_EditRoutefiles = New System.Windows.Forms.DataGridView()
        Me.Col_Path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_RouteLineWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_RouteColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Alpha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_ChangeColor = New System.Windows.Forms.Button()
        Me.L_ChangePath = New System.Windows.Forms.Label()
        Me.CD_SelectRouteColor = New System.Windows.Forms.ColorDialog()
        Me.OFD_SelectPath = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NUD_LineWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_Alpha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_EditRoutefiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.L_EditingFollowingFiles, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.NUD_LineWidth, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.NUD_Alpha, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.L_Linewidth, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.L_Alpha, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.DGV_EditRoutefiles, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_ChangeColor, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.L_ChangePath, 0, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'L_EditingFollowingFiles
        '
        resources.ApplyResources(Me.L_EditingFollowingFiles, "L_EditingFollowingFiles")
        Me.TableLayoutPanel1.SetColumnSpan(Me.L_EditingFollowingFiles, 2)
        Me.L_EditingFollowingFiles.Name = "L_EditingFollowingFiles"
        '
        'NUD_LineWidth
        '
        resources.ApplyResources(Me.NUD_LineWidth, "NUD_LineWidth")
        Me.NUD_LineWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NUD_LineWidth.Name = "NUD_LineWidth"
        '
        'NUD_Alpha
        '
        resources.ApplyResources(Me.NUD_Alpha, "NUD_Alpha")
        Me.NUD_Alpha.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NUD_Alpha.Name = "NUD_Alpha"
        '
        'L_Linewidth
        '
        resources.ApplyResources(Me.L_Linewidth, "L_Linewidth")
        Me.L_Linewidth.Name = "L_Linewidth"
        '
        'L_Alpha
        '
        resources.ApplyResources(Me.L_Alpha, "L_Alpha")
        Me.L_Alpha.Name = "L_Alpha"
        '
        'DGV_EditRoutefiles
        '
        Me.DGV_EditRoutefiles.AllowUserToAddRows = False
        Me.DGV_EditRoutefiles.AllowUserToDeleteRows = False
        Me.DGV_EditRoutefiles.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGV_EditRoutefiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV_EditRoutefiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_EditRoutefiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_Path, Me.Col_RouteLineWidth, Me.Col_RouteColor, Me.Col_Alpha})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DGV_EditRoutefiles, 2)
        resources.ApplyResources(Me.DGV_EditRoutefiles, "DGV_EditRoutefiles")
        Me.DGV_EditRoutefiles.MultiSelect = False
        Me.DGV_EditRoutefiles.Name = "DGV_EditRoutefiles"
        Me.DGV_EditRoutefiles.ReadOnly = True
        Me.DGV_EditRoutefiles.RowHeadersVisible = False
        Me.DGV_EditRoutefiles.TabStop = False
        '
        'Col_Path
        '
        Me.Col_Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.Col_Path, "Col_Path")
        Me.Col_Path.Name = "Col_Path"
        Me.Col_Path.ReadOnly = True
        '
        'Col_RouteLineWidth
        '
        Me.Col_RouteLineWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        resources.ApplyResources(Me.Col_RouteLineWidth, "Col_RouteLineWidth")
        Me.Col_RouteLineWidth.Name = "Col_RouteLineWidth"
        Me.Col_RouteLineWidth.ReadOnly = True
        '
        'Col_RouteColor
        '
        Me.Col_RouteColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        resources.ApplyResources(Me.Col_RouteColor, "Col_RouteColor")
        Me.Col_RouteColor.Name = "Col_RouteColor"
        Me.Col_RouteColor.ReadOnly = True
        '
        'Col_Alpha
        '
        Me.Col_Alpha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        resources.ApplyResources(Me.Col_Alpha, "Col_Alpha")
        Me.Col_Alpha.Name = "Col_Alpha"
        Me.Col_Alpha.ReadOnly = True
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_OK, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_Cancel, 1, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'Btn_OK
        '
        resources.ApplyResources(Me.Btn_OK, "Btn_OK")
        Me.Btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'Btn_Cancel
        '
        resources.ApplyResources(Me.Btn_Cancel, "Btn_Cancel")
        Me.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Btn_ChangeColor
        '
        resources.ApplyResources(Me.Btn_ChangeColor, "Btn_ChangeColor")
        Me.Btn_ChangeColor.Name = "Btn_ChangeColor"
        Me.Btn_ChangeColor.UseVisualStyleBackColor = True
        '
        'L_ChangePath
        '
        resources.ApplyResources(Me.L_ChangePath, "L_ChangePath")
        Me.TableLayoutPanel1.SetColumnSpan(Me.L_ChangePath, 2)
        Me.L_ChangePath.Name = "L_ChangePath"
        '
        'OFD_SelectPath
        '
        Me.OFD_SelectPath.FileName = "OpenFileDialog1"
        '
        'frm_AddEditRoutefile
        '
        Me.AcceptButton = Me.Btn_OK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Btn_Cancel
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frm_AddEditRoutefile"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.NUD_LineWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_Alpha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_EditRoutefiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents L_EditingFollowingFiles As Label
    Friend WithEvents Btn_ChangeColor As Button
    Friend WithEvents NUD_LineWidth As NumericUpDown
    Friend WithEvents NUD_Alpha As NumericUpDown
    Friend WithEvents L_Linewidth As Label
    Friend WithEvents L_Alpha As Label
    Friend WithEvents DGV_EditRoutefiles As DataGridView
    Friend WithEvents CD_SelectRouteColor As ColorDialog
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Btn_OK As Button
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents L_ChangePath As Label
    Friend WithEvents OFD_SelectPath As OpenFileDialog
    Friend WithEvents Col_Path As DataGridViewTextBoxColumn
    Friend WithEvents Col_RouteLineWidth As DataGridViewTextBoxColumn
    Friend WithEvents Col_RouteColor As DataGridViewTextBoxColumn
    Friend WithEvents Col_Alpha As DataGridViewTextBoxColumn
End Class

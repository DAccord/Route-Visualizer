<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AnimationSaveDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_AnimationSaveDialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GB_Route = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_RouteColor = New System.Windows.Forms.Button()
        Me.L_RouteColor = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NUD_RouteLineWidth = New System.Windows.Forms.NumericUpDown()
        Me.GB_ImageSize = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.RB_Width = New System.Windows.Forms.RadioButton()
        Me.RB_Height = New System.Windows.Forms.RadioButton()
        Me.Nud_Size = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.NUD_StepSize = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_SymbolColor = New System.Windows.Forms.Button()
        Me.L_SymbolColor = New System.Windows.Forms.Label()
        Me.NUD_SymbolWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_SelectPath = New System.Windows.Forms.Button()
        Me.L_Path = New System.Windows.Forms.Label()
        Me.CMB_Format = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.RB_SingleBackground = New System.Windows.Forms.RadioButton()
        Me.RB_AlwaysBackground = New System.Windows.Forms.RadioButton()
        Me.CD_Colour = New System.Windows.Forms.ColorDialog()
        Me.FBD_SavePath = New System.Windows.Forms.FolderBrowserDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GB_Route.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.NUD_RouteLineWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_ImageSize.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.Nud_Size, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.NUD_StepSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.NUD_SymbolWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.GB_Route, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GB_ImageSize, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'GB_Route
        '
        resources.ApplyResources(Me.GB_Route, "GB_Route")
        Me.GB_Route.Controls.Add(Me.TableLayoutPanel2)
        Me.GB_Route.Name = "GB_Route"
        Me.GB_Route.TabStop = False
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_RouteColor, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.L_RouteColor, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.NUD_RouteLineWidth, 1, 1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'Btn_RouteColor
        '
        resources.ApplyResources(Me.Btn_RouteColor, "Btn_RouteColor")
        Me.Btn_RouteColor.Name = "Btn_RouteColor"
        Me.Btn_RouteColor.UseVisualStyleBackColor = True
        '
        'L_RouteColor
        '
        resources.ApplyResources(Me.L_RouteColor, "L_RouteColor")
        Me.L_RouteColor.Name = "L_RouteColor"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'NUD_RouteLineWidth
        '
        resources.ApplyResources(Me.NUD_RouteLineWidth, "NUD_RouteLineWidth")
        Me.NUD_RouteLineWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NUD_RouteLineWidth.Name = "NUD_RouteLineWidth"
        Me.NUD_RouteLineWidth.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'GB_ImageSize
        '
        resources.ApplyResources(Me.GB_ImageSize, "GB_ImageSize")
        Me.GB_ImageSize.Controls.Add(Me.TableLayoutPanel3)
        Me.GB_ImageSize.Name = "GB_ImageSize"
        Me.GB_ImageSize.TabStop = False
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.RB_Width, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RB_Height, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Nud_Size, 0, 1)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'RB_Width
        '
        resources.ApplyResources(Me.RB_Width, "RB_Width")
        Me.RB_Width.Checked = True
        Me.RB_Width.Name = "RB_Width"
        Me.RB_Width.TabStop = True
        Me.RB_Width.UseVisualStyleBackColor = True
        '
        'RB_Height
        '
        resources.ApplyResources(Me.RB_Height, "RB_Height")
        Me.RB_Height.Name = "RB_Height"
        Me.RB_Height.UseVisualStyleBackColor = True
        '
        'Nud_Size
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.Nud_Size, 2)
        resources.ApplyResources(Me.Nud_Size, "Nud_Size")
        Me.Nud_Size.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.Nud_Size.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.Nud_Size.Name = "Nud_Size"
        Me.Nud_Size.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.NUD_StepSize, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'NUD_StepSize
        '
        resources.ApplyResources(Me.NUD_StepSize, "NUD_StepSize")
        Me.NUD_StepSize.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NUD_StepSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUD_StepSize.Name = "NUD_StepSize"
        Me.NUD_StepSize.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'TableLayoutPanel5
        '
        resources.ApplyResources(Me.TableLayoutPanel5, "TableLayoutPanel5")
        Me.TableLayoutPanel5.Controls.Add(Me.Btn_Cancel, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Btn_OK, 0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        '
        'Btn_Cancel
        '
        resources.ApplyResources(Me.Btn_Cancel, "Btn_Cancel")
        Me.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Btn_OK
        '
        resources.ApplyResources(Me.Btn_OK, "Btn_OK")
        Me.Btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel6
        '
        resources.ApplyResources(Me.TableLayoutPanel6, "TableLayoutPanel6")
        Me.TableLayoutPanel6.Controls.Add(Me.Btn_SymbolColor, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.L_SymbolColor, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.NUD_SymbolWidth, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        '
        'Btn_SymbolColor
        '
        resources.ApplyResources(Me.Btn_SymbolColor, "Btn_SymbolColor")
        Me.Btn_SymbolColor.Name = "Btn_SymbolColor"
        Me.Btn_SymbolColor.UseVisualStyleBackColor = True
        '
        'L_SymbolColor
        '
        resources.ApplyResources(Me.L_SymbolColor, "L_SymbolColor")
        Me.L_SymbolColor.Name = "L_SymbolColor"
        '
        'NUD_SymbolWidth
        '
        resources.ApplyResources(Me.NUD_SymbolWidth, "NUD_SymbolWidth")
        Me.NUD_SymbolWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NUD_SymbolWidth.Name = "NUD_SymbolWidth"
        Me.NUD_SymbolWidth.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'TableLayoutPanel7
        '
        resources.ApplyResources(Me.TableLayoutPanel7, "TableLayoutPanel7")
        Me.TableLayoutPanel7.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.Btn_SelectPath, 2, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.L_Path, 1, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.CMB_Format, 1, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.TableLayoutPanel8, 0, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Btn_SelectPath
        '
        resources.ApplyResources(Me.Btn_SelectPath, "Btn_SelectPath")
        Me.Btn_SelectPath.Name = "Btn_SelectPath"
        Me.Btn_SelectPath.UseVisualStyleBackColor = True
        '
        'L_Path
        '
        resources.ApplyResources(Me.L_Path, "L_Path")
        Me.L_Path.Name = "L_Path"
        '
        'CMB_Format
        '
        Me.TableLayoutPanel7.SetColumnSpan(Me.CMB_Format, 2)
        resources.ApplyResources(Me.CMB_Format, "CMB_Format")
        Me.CMB_Format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_Format.FormattingEnabled = True
        Me.CMB_Format.Items.AddRange(New Object() {resources.GetString("CMB_Format.Items"), resources.GetString("CMB_Format.Items1"), resources.GetString("CMB_Format.Items2"), resources.GetString("CMB_Format.Items3"), resources.GetString("CMB_Format.Items4")})
        Me.CMB_Format.Name = "CMB_Format"
        '
        'TableLayoutPanel8
        '
        resources.ApplyResources(Me.TableLayoutPanel8, "TableLayoutPanel8")
        Me.TableLayoutPanel7.SetColumnSpan(Me.TableLayoutPanel8, 3)
        Me.TableLayoutPanel8.Controls.Add(Me.RB_SingleBackground, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.RB_AlwaysBackground, 0, 0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        '
        'RB_SingleBackground
        '
        resources.ApplyResources(Me.RB_SingleBackground, "RB_SingleBackground")
        Me.RB_SingleBackground.Name = "RB_SingleBackground"
        Me.RB_SingleBackground.UseVisualStyleBackColor = True
        '
        'RB_AlwaysBackground
        '
        resources.ApplyResources(Me.RB_AlwaysBackground, "RB_AlwaysBackground")
        Me.RB_AlwaysBackground.Checked = True
        Me.RB_AlwaysBackground.Name = "RB_AlwaysBackground"
        Me.RB_AlwaysBackground.TabStop = True
        Me.RB_AlwaysBackground.UseVisualStyleBackColor = True
        '
        'frm_AnimationSaveDialog
        '
        Me.AcceptButton = Me.Btn_OK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Btn_Cancel
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frm_AnimationSaveDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GB_Route.ResumeLayout(False)
        Me.GB_Route.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.NUD_RouteLineWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_ImageSize.ResumeLayout(False)
        Me.GB_ImageSize.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.Nud_Size, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.NUD_StepSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.NUD_SymbolWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GB_Route As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Btn_RouteColor As Button
    Friend WithEvents Btn_SymbolColor As Button
    Friend WithEvents L_SymbolColor As Label
    Friend WithEvents CD_Colour As ColorDialog
    Friend WithEvents GB_ImageSize As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents RB_Width As RadioButton
    Friend WithEvents RB_Height As RadioButton
    Friend WithEvents Nud_Size As NumericUpDown
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents CMB_Format As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents L_Path As Label
    Friend WithEvents Btn_SelectPath As Button
    Friend WithEvents FBD_SavePath As FolderBrowserDialog
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_OK As Button
    Friend WithEvents L_RouteColor As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NUD_RouteLineWidth As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents NUD_SymbolWidth As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents NUD_StepSize As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents RB_SingleBackground As RadioButton
    Friend WithEvents RB_AlwaysBackground As RadioButton
End Class

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
        Me.GB_ImageSize = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.RB_Width = New System.Windows.Forms.RadioButton()
        Me.RB_Height = New System.Windows.Forms.RadioButton()
        Me.Nud_Size = New System.Windows.Forms.NumericUpDown()
        Me.L_Size = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TLP_Animation = New System.Windows.Forms.TableLayoutPanel()
        Me.L_LoopCount = New System.Windows.Forms.Label()
        Me.NUD_StepSize = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.L_DelayTime = New System.Windows.Forms.Label()
        Me.NUD_DelayTime = New System.Windows.Forms.NumericUpDown()
        Me.NUD_LoopCount = New System.Windows.Forms.NumericUpDown()
        Me.L_AnimationType = New System.Windows.Forms.Label()
        Me.CMB_AnimationType = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.GB_CurrentPosition = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_SymbolColor = New System.Windows.Forms.Button()
        Me.L_SymbolColor = New System.Windows.Forms.Label()
        Me.NUD_SymbolWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GB_Output = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.L_Output = New System.Windows.Forms.Label()
        Me.Btn_SelectPath = New System.Windows.Forms.Button()
        Me.L_Path = New System.Windows.Forms.Label()
        Me.CMB_Format = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.RB_SingleBackground = New System.Windows.Forms.RadioButton()
        Me.RB_AlwaysBackground = New System.Windows.Forms.RadioButton()
        Me.CD_Colour = New System.Windows.Forms.ColorDialog()
        Me.FBD_SavePath = New System.Windows.Forms.FolderBrowserDialog()
        Me.SFD_SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GB_ImageSize.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.Nud_Size, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TLP_Animation.SuspendLayout()
        CType(Me.NUD_StepSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_DelayTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_LoopCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GB_CurrentPosition.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.NUD_SymbolWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_Output.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.GB_ImageSize, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TLP_Animation, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.GB_CurrentPosition, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GB_Output, 0, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
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
        Me.TableLayoutPanel3.Controls.Add(Me.Nud_Size, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.L_Size, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 2)
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
        resources.ApplyResources(Me.Nud_Size, "Nud_Size")
        Me.Nud_Size.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.Nud_Size.Name = "Nud_Size"
        Me.Nud_Size.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'L_Size
        '
        resources.ApplyResources(Me.L_Size, "L_Size")
        Me.L_Size.Name = "L_Size"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.TableLayoutPanel3.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Name = "Label1"
        '
        'TLP_Animation
        '
        resources.ApplyResources(Me.TLP_Animation, "TLP_Animation")
        Me.TLP_Animation.Controls.Add(Me.L_LoopCount, 0, 2)
        Me.TLP_Animation.Controls.Add(Me.NUD_StepSize, 1, 0)
        Me.TLP_Animation.Controls.Add(Me.Label2, 0, 0)
        Me.TLP_Animation.Controls.Add(Me.L_DelayTime, 0, 1)
        Me.TLP_Animation.Controls.Add(Me.NUD_DelayTime, 1, 1)
        Me.TLP_Animation.Controls.Add(Me.NUD_LoopCount, 1, 2)
        Me.TLP_Animation.Controls.Add(Me.L_AnimationType, 0, 3)
        Me.TLP_Animation.Controls.Add(Me.CMB_AnimationType, 1, 3)
        Me.TLP_Animation.Name = "TLP_Animation"
        '
        'L_LoopCount
        '
        resources.ApplyResources(Me.L_LoopCount, "L_LoopCount")
        Me.L_LoopCount.Name = "L_LoopCount"
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
        'L_DelayTime
        '
        resources.ApplyResources(Me.L_DelayTime, "L_DelayTime")
        Me.L_DelayTime.Name = "L_DelayTime"
        '
        'NUD_DelayTime
        '
        resources.ApplyResources(Me.NUD_DelayTime, "NUD_DelayTime")
        Me.NUD_DelayTime.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUD_DelayTime.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NUD_DelayTime.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUD_DelayTime.Name = "NUD_DelayTime"
        Me.NUD_DelayTime.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'NUD_LoopCount
        '
        resources.ApplyResources(Me.NUD_LoopCount, "NUD_LoopCount")
        Me.NUD_LoopCount.Name = "NUD_LoopCount"
        '
        'L_AnimationType
        '
        resources.ApplyResources(Me.L_AnimationType, "L_AnimationType")
        Me.L_AnimationType.Name = "L_AnimationType"
        '
        'CMB_AnimationType
        '
        resources.ApplyResources(Me.CMB_AnimationType, "CMB_AnimationType")
        Me.CMB_AnimationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_AnimationType.FormattingEnabled = True
        Me.CMB_AnimationType.Items.AddRange(New Object() {resources.GetString("CMB_AnimationType.Items"), resources.GetString("CMB_AnimationType.Items1"), resources.GetString("CMB_AnimationType.Items2")})
        Me.CMB_AnimationType.Name = "CMB_AnimationType"
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
        'GB_CurrentPosition
        '
        resources.ApplyResources(Me.GB_CurrentPosition, "GB_CurrentPosition")
        Me.GB_CurrentPosition.Controls.Add(Me.TableLayoutPanel6)
        Me.GB_CurrentPosition.Name = "GB_CurrentPosition"
        Me.GB_CurrentPosition.TabStop = False
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
        'GB_Output
        '
        resources.ApplyResources(Me.GB_Output, "GB_Output")
        Me.GB_Output.Controls.Add(Me.TableLayoutPanel7)
        Me.GB_Output.Name = "GB_Output"
        Me.GB_Output.TabStop = False
        '
        'TableLayoutPanel7
        '
        resources.ApplyResources(Me.TableLayoutPanel7, "TableLayoutPanel7")
        Me.TableLayoutPanel7.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.L_Output, 0, 1)
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
        'L_Output
        '
        resources.ApplyResources(Me.L_Output, "L_Output")
        Me.L_Output.Name = "L_Output"
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
        resources.ApplyResources(Me.CMB_Format, "CMB_Format")
        Me.TableLayoutPanel7.SetColumnSpan(Me.CMB_Format, 2)
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
        'FBD_SavePath
        '
        resources.ApplyResources(Me.FBD_SavePath, "FBD_SavePath")
        '
        'SFD_SaveFile
        '
        resources.ApplyResources(Me.SFD_SaveFile, "SFD_SaveFile")
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
        Me.GB_ImageSize.ResumeLayout(False)
        Me.GB_ImageSize.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.Nud_Size, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TLP_Animation.ResumeLayout(False)
        Me.TLP_Animation.PerformLayout()
        CType(Me.NUD_StepSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_DelayTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_LoopCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.GB_CurrentPosition.ResumeLayout(False)
        Me.GB_CurrentPosition.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.NUD_SymbolWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_Output.ResumeLayout(False)
        Me.GB_Output.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Btn_SymbolColor As Button
    Friend WithEvents L_SymbolColor As Label
    Friend WithEvents CD_Colour As ColorDialog
    Friend WithEvents GB_ImageSize As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents RB_Width As RadioButton
    Friend WithEvents RB_Height As RadioButton
    Friend WithEvents Nud_Size As NumericUpDown
    Friend WithEvents TLP_Animation As TableLayoutPanel
    Friend WithEvents L_Output As Label
    Friend WithEvents CMB_Format As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents L_Path As Label
    Friend WithEvents Btn_SelectPath As Button
    Friend WithEvents FBD_SavePath As FolderBrowserDialog
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_OK As Button
    Friend WithEvents GB_CurrentPosition As GroupBox
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents NUD_SymbolWidth As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents NUD_StepSize As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents GB_Output As GroupBox
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents RB_SingleBackground As RadioButton
    Friend WithEvents RB_AlwaysBackground As RadioButton
    Friend WithEvents L_DelayTime As Label
    Friend WithEvents NUD_DelayTime As NumericUpDown
    Friend WithEvents L_LoopCount As Label
    Friend WithEvents NUD_LoopCount As NumericUpDown
    Friend WithEvents SFD_SaveFile As SaveFileDialog
    Friend WithEvents L_Size As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents L_AnimationType As Label
    Friend WithEvents CMB_AnimationType As ComboBox
End Class

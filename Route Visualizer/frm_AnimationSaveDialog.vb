Imports System.IO

Public Class frm_AnimationSaveDialog
    Dim Desired_AS As SaveOption
    Dim SupportingTransparency() As String = {".png", ".tif"}
    Dim NotSupportingTransparency() As String = {".jpg", ".png", ".bmp", ".gif", ".tif"}

    Public Sub New(ByRef C_AS As SaveOption)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Desired_AS = C_AS
    End Sub

    Private Sub frm_AnimationSaveDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMB_AnimationType.Items.Clear()
        CMB_AnimationType.Items.Add(My.Resources.AnimationSaveType1)
        CMB_AnimationType.Items.Add(My.Resources.AnimationSaveType2)
        CMB_AnimationType.Items.Add(My.Resources.AnimationSaveType3)

        If Desired_AS.AnimSaveType = AnimationSaveType.InRow_Hold Then
            CMB_AnimationType.SelectedIndex = 0
        ElseIf Desired_AS.AnimSaveType = AnimationSaveType.InRow_NoHold Then
            CMB_AnimationType.SelectedIndex = 1
        ElseIf Desired_AS.AnimSaveType = AnimationSaveType.Together Then
            CMB_AnimationType.SelectedIndex = 2
        End If
        Select Case Desired_AS.SaveType
            Case SaveType.Animation_GIF
                GB_CurrentPosition.Visible = True
                TLP_Animation.Visible = True

                L_AnimationType.Visible = True
                CMB_AnimationType.Visible = True
                RB_AlwaysBackground.Visible = False
                RB_SingleBackground.Visible = False
                L_Output.Visible = False
                CMB_Format.Visible = False
                L_DelayTime.Visible = True
                NUD_DelayTime.Visible = True
                L_LoopCount.Visible = True
                NUD_LoopCount.Visible = True
                If Not Desired_AS.FilePath.Substring(Desired_AS.FilePath.Length - 4, 4).ToLower = ".gif" Then
                    L_Path.Text = Path.Combine(Path.GetDirectoryName(Desired_AS.FilePath), Path.GetFileNameWithoutExtension(Desired_AS.FilePath) & ".gif")
                Else
                    L_Path.Text = Desired_AS.FilePath
                End If
                'Current Position
                L_SymbolColor.BackColor = Desired_AS.SymbolColor
                NUD_SymbolWidth.Value = Desired_AS.SymbolWidth
                'Output
                RB_AlwaysBackground.Checked = Desired_AS.BackgroundAlways
                RB_SingleBackground.Checked = Not Desired_AS.BackgroundAlways
                CMB_Format.SelectedItem = Desired_AS.OutputFormat
                'Step size
                NUD_StepSize.Value = Desired_AS.StepSize
                'Delay Time
                NUD_DelayTime.Value = Desired_AS.DelayTime

                SFD_SaveFile.Filter = My.Resources.AnimationSaveDialog_SFDFilter_GIF
                SFD_SaveFile.FilterIndex = 0

                Me.Text = String.Format(My.Resources.AnimationSaveDialog_WindowTitle1 & " ({0})", My.Resources.AnimationSaveDialog_WindowTitleGIF)
            Case SaveType.Animation_SingleFiles
                GB_CurrentPosition.Visible = True
                TLP_Animation.Visible = True

                L_AnimationType.Visible = True
                CMB_AnimationType.Visible = True
                RB_AlwaysBackground.Visible = True
                RB_SingleBackground.Visible = True
                L_Output.Visible = True
                CMB_Format.Visible = True
                L_DelayTime.Visible = False
                NUD_DelayTime.Visible = False
                L_LoopCount.Visible = False
                NUD_LoopCount.Visible = False
                L_Path.Text = Desired_AS.DirectoryPath
                'Current Position
                L_SymbolColor.BackColor = Desired_AS.SymbolColor
                NUD_SymbolWidth.Value = Desired_AS.SymbolWidth
                'Output
                RB_AlwaysBackground.Checked = Desired_AS.BackgroundAlways
                RB_SingleBackground.Checked = Not Desired_AS.BackgroundAlways
                CMB_Format.SelectedItem = Desired_AS.OutputFormat
                'Step size
                NUD_StepSize.Value = Desired_AS.StepSize
                'Delay Time
                NUD_DelayTime.Value = Desired_AS.DelayTime

                Me.Text = String.Format(My.Resources.AnimationSaveDialog_WindowTitle1 & " ({0})", My.Resources.AnimationSaveDialog_WindowTitleSingleFiles)
            Case SaveType.LayersSeparately_MergeRoutes, SaveType.LayersSeparately_RoutesSeparately
                GB_CurrentPosition.Visible = False
                RB_AlwaysBackground.Visible = False
                RB_SingleBackground.Visible = False
                TLP_Animation.Visible = False
                L_Path.Text = Desired_AS.DirectoryPath

                L_AnimationType.Visible = False
                CMB_AnimationType.Visible = False
                CMB_Format.DataSource = SupportingTransparency
                CMB_Format.SelectedItem = Desired_AS.OutputFormat

                If Desired_AS.SaveType = SaveType.LayersSeparately_MergeRoutes Then
                    Me.Text = String.Format(My.Resources.AnimationSaveDialog_WindowTitle2 & " ({0})", My.Resources.AnimationSaveDialog_WindowTitleMergeRoutes)
                ElseIf Desired_AS.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                    Me.Text = String.Format(My.Resources.AnimationSaveDialog_WindowTitle2 & " ({0})", My.Resources.AnimationSaveDialog_WindowTitleRoutesSeparately)
                End If
            Case SaveType.SimpleImage
                GB_CurrentPosition.Visible = False
                RB_AlwaysBackground.Visible = False
                RB_SingleBackground.Visible = False
                TLP_Animation.Visible = False
                CMB_Format.Visible = False
                L_Output.Visible = False
                L_Path.Text = Desired_AS.FilePath

                L_AnimationType.Visible = False
                CMB_AnimationType.Visible = False
                CMB_Format.DataSource = NotSupportingTransparency
                CMB_Format.SelectedItem = Desired_AS.OutputFormat

                SFD_SaveFile.Filter = My.Resources.SFD_SaveImageFilter
                SFD_SaveFile.FilterIndex = InList(NotSupportingTransparency, Desired_AS.OutputFormat)
                Me.Text = My.Resources.AnimationSaveDialog_WindowTitleSimpleImage
        End Select
        'Image Size
        If Desired_AS.Width > 0 Then
            RB_Width.Checked = True
            Nud_Size.Value = Desired_AS.Width
        Else
            RB_Height.Checked = True
            Nud_Size.Value = Desired_AS.Height
        End If
        SFD_SaveFile.Title = My.Resources.SFD_SaveImageTitle
        FBD_SavePath.Description = My.Resources.FBD_SaveLayersSeperatelyDescription
        If RB_Width.Checked Then
            L_Size.Text = My.Resources.Width & " (px):"
        Else
            L_Size.Text = My.Resources.Height & " (px):"
        End If
    End Sub

    Private Function InList(ByVal L() As String, ByVal S As String) As Integer
        For i As Integer = 0 To L.Count - 1
            If L(i) = S Then
                Return i + 1
            End If
        Next
        Return 0
    End Function

    Dim OverWriteCheck As Boolean = False

    Private Sub Btn_SelectPath_Click(sender As Object, e As EventArgs) Handles Btn_SelectPath.Click
        If Desired_AS.SaveType = SaveType.Animation_SingleFiles OrElse Desired_AS.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse Desired_AS.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
            If FBD_SavePath.ShowDialog() = DialogResult.OK Then
                L_Path.Text = FBD_SavePath.SelectedPath
                OverWriteCheck = True
            End If
        Else
            If SFD_SaveFile.ShowDialog() = DialogResult.OK Then
                L_Path.Text = SFD_SaveFile.FileName
                OverWriteCheck = True
            End If
        End If
    End Sub

    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        If Not OverWriteCheck AndAlso File.Exists(L_Path.Text) AndAlso (Desired_AS.SaveType = SaveType.Animation_GIF OrElse Desired_AS.SaveType = SaveType.SimpleImage) Then
            If MessageBox.Show(My.Resources.AnimationSaveDialog_OverwriteFile, My.Resources.AnimationSaveDialog_OverwriteFile_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Me.DialogResult = DialogResult.Abort
                Exit Sub
            End If
        End If
        If Desired_AS.SaveType = SaveType.Animation_GIF Then
            If NUD_StepSize.Value <= 20 OrElse Nud_Size.Value = 0 OrElse Nud_Size.Value > 1000 Then
                If MessageBox.Show(My.Resources.GIF_Warning, "", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Me.DialogResult = DialogResult.Abort
                    Exit Sub
                End If
            End If
        End If
        If RB_Height.Checked Then
            Desired_AS.Height = CInt(Nud_Size.Value)
            Desired_AS.Width = 0
        Else
            Desired_AS.Width = CInt(Nud_Size.Value)
            Desired_AS.Height = 0
        End If
        Desired_AS.StepSize = CInt(NUD_StepSize.Value)
        Desired_AS.SymbolColor = L_SymbolColor.BackColor
        Desired_AS.SymbolWidth = CInt(NUD_SymbolWidth.Value)

        If Desired_AS.SaveType = SaveType.Animation_SingleFiles Then
            Desired_AS.OutputFormat = CMB_Format.SelectedItem.ToString
            Desired_AS.BackgroundAlways = RB_AlwaysBackground.Checked
            Desired_AS.DirectoryPath = L_Path.Text
        ElseIf Desired_AS.SaveType = SaveType.Animation_GIF Then
            Desired_AS.BackgroundAlways = False
            Desired_AS.FilePath = L_Path.Text
            Desired_AS.DirectoryPath = Path.GetDirectoryName(Desired_AS.FilePath)
            Desired_AS.LoopCount = CInt(NUD_LoopCount.Value)
        ElseIf Desired_AS.SaveType = SaveType.SimpleImage Then
            Desired_AS.OutputFormat = Path.GetExtension(L_Path.Text)
            Desired_AS.FilePath = L_Path.Text
            Desired_AS.DirectoryPath = Path.GetDirectoryName(Desired_AS.FilePath)
        ElseIf Desired_AS.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse Desired_AS.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
            Desired_AS.OutputFormat = CMB_Format.SelectedItem.ToString
            Desired_AS.DirectoryPath = L_Path.Text
        End If
        If CMB_AnimationType.SelectedIndex = 0 Then
            Desired_AS.AnimSaveType = AnimationSaveType.InRow_Hold
        ElseIf CMB_AnimationType.SelectedIndex = 1 Then
            Desired_AS.AnimSaveType = AnimationSaveType.InRow_NoHold
        ElseIf CMB_AnimationType.SelectedIndex = 2 Then
            Desired_AS.AnimSaveType = AnimationSaveType.Together
        End If

        Me.Close()
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Me.Close()
    End Sub

    Private Sub RB_AlwaysBackground_CheckedChanged(sender As Object, e As EventArgs) Handles RB_SingleBackground.CheckedChanged, RB_AlwaysBackground.CheckedChanged
        If RB_AlwaysBackground.Checked Then
            CMB_Format.DataSource = NotSupportingTransparency
        Else
            CMB_Format.DataSource = SupportingTransparency
        End If
    End Sub

    Private Sub NUD_RouteLineWidth_Enter(sender As Object, e As EventArgs) Handles NUD_SymbolWidth.Enter, Nud_Size.Enter, NUD_StepSize.Enter, NUD_DelayTime.Enter, NUD_LoopCount.Enter
        Dim NUD As NumericUpDown = CType(sender, NumericUpDown)
        NUD.Select(0, NUD.ToString.Length)
    End Sub

    Private Sub Btn_SymbolColor_Click(sender As Object, e As EventArgs) Handles Btn_SymbolColor.Click
        CD_Colour.Color = L_SymbolColor.BackColor
        If CD_Colour.ShowDialog() = DialogResult.OK Then
            L_SymbolColor.BackColor = CD_Colour.Color
        End If
    End Sub

    Private Sub RB_Width_CheckedChanged(sender As Object, e As EventArgs) Handles RB_Width.CheckedChanged, RB_Height.CheckedChanged
        If RB_Width.Checked Then
            L_Size.Text = My.Resources.Width & " (px):"
        Else
            L_Size.Text = My.Resources.Height & " (px):"
        End If
    End Sub

    Private Sub frm_AnimationSaveDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = DialogResult.Abort Then
            e.Cancel = True
        End If
    End Sub

    Private Sub frm_AnimationSaveDialog_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim GI As Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentUICulture
            If GI.TwoLetterISOLanguageName = "de" Then
                Process.Start("https://github.com/DAccord/Route-Visualizer/wiki/Speichern%E2%80%90Dialog")
            Else
                Process.Start("https://github.com/DAccord/Route-Visualizer/wiki/Save-Dialog")
            End If
        End If
    End Sub
End Class


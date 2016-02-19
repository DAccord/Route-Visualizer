Imports System.IO

Public Class frm_AnimationSaveDialog
    Dim RouteCol As Color = Color.Blue
    Dim SymbolCol As Color = Color.Red
    Dim Desired_AS As AnimationSaving
    Dim SupportingTransparency() As String = {".png", ".tif"}
    Dim NotSupportingTransparency() As String = {".bmp", ".gif", ".jpg", ".png", ".tif"}

    Public Sub New(ByRef C_AS As AnimationSaving)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Desired_AS = C_AS
    End Sub

    Private Sub frm_AnimationSaveDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Route
        L_RouteColor.BackColor = Desired_AS.RouteColor
        NUD_RouteLineWidth.Value = Desired_AS.RouteLineWidth
        'Current Position
        L_SymbolColor.BackColor = Desired_AS.SymbolColor
        NUD_SymbolWidth.Value = Desired_AS.SymbolWidth
        'Image Size
        If Desired_AS.Width > 0 Then
            RB_Width.Checked = True
            Nud_Size.Value = Desired_AS.Width
        Else
            RB_Height.Checked = True
            Nud_Size.Value = Desired_AS.Height
        End If
        'Output
        RB_AlwaysBackground.Checked = Desired_AS.BackgroundAlways
        RB_SingleBackground.Checked = Not Desired_AS.BackgroundAlways
        CMB_Format.SelectedItem = Desired_AS.OutputFormat
        'Step size
        NUD_StepSize.Value = Desired_AS.StepSize
        'Delay Time
        NUD_DelayTime.Value = Desired_AS.DelayTime

        SFD_SaveFile.Filter = My.Resources.AnimationSaveDialog_SFDFilter
        SFD_SaveFile.Title = My.Resources.SFD_SaveImageTitle
        FBD_SavePath.Description = My.Resources.FBD_SaveLayersSeperatelyDescription

        If Desired_AS.SaveType = SaveType.SingleFiles Then
            RB_AlwaysBackground.Visible = True
            RB_SingleBackground.Visible = True
            L_Output.Visible = True
            CMB_Format.Visible = True
            L_DelayTime.Visible = False
            NUD_DelayTime.Visible = False
            L_LoopCount.Visible = False
            NUD_LoopCount.Visible = False
            L_Path.Text = Desired_AS.DirectoryPath

            Me.Text = String.Format(My.Resources.AnimationSaveDialog_WindowTitle1 & " ({0})", My.Resources.AnimationSaveDialog_WindowTitleSingleFiles)
        ElseIf Desired_AS.SaveType = SaveType.GIF Then
            RB_AlwaysBackground.Visible = False
            RB_SingleBackground.Visible = False
            L_Output.Visible = False
            CMB_Format.Visible = False
            L_DelayTime.Visible = True
            NUD_DelayTime.Visible = True
            L_LoopCount.Visible = True
            NUD_LoopCount.Visible = True
            L_Path.Text = Desired_AS.FilePath

            Me.Text = String.Format(My.Resources.AnimationSaveDialog_WindowTitle1 & " ({0})", My.Resources.AnimationSaveDialog_WindowTitleGIF)
        End If
    End Sub

    Private Sub Btn_SelectPath_Click(sender As Object, e As EventArgs) Handles Btn_SelectPath.Click
        If Desired_AS.SaveType = SaveType.SingleFiles Then
            If FBD_SavePath.ShowDialog() = DialogResult.OK Then
                L_Path.Text = FBD_SavePath.SelectedPath
            End If
        ElseIf Desired_AS.SaveType = SaveType.GIF Then
            If SFD_SaveFile.ShowDialog() = DialogResult.OK Then
                L_Path.Text = SFD_SaveFile.FileName
            End If
        End If
    End Sub

    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        If RB_Height.Checked Then
            Desired_AS.Height = CInt(Nud_Size.Value)
        Else
            Desired_AS.Width = CInt(Nud_Size.Value)
        End If
        Desired_AS.StepSize = CInt(NUD_StepSize.Value)
        Desired_AS.RouteColor = RouteCol
        Desired_AS.SymbolColor = SymbolCol
        Desired_AS.SymbolWidth = CInt(NUD_SymbolWidth.Value)
        Desired_AS.DirectoryPath = L_Path.Text

        If Desired_AS.SaveType = SaveType.SingleFiles Then
            Desired_AS.OutputFormat = CMB_Format.SelectedItem.ToString
            Desired_AS.BackgroundAlways = RB_AlwaysBackground.Checked
        ElseIf Desired_AS.SaveType = SaveType.GIF Then
            Desired_AS.OutputFormat = ".png"
            Desired_AS.BackgroundAlways = False
            Desired_AS.FilePath = L_Path.Text
            Desired_AS.DirectoryPath = Path.GetDirectoryName(Desired_AS.FilePath)
            Desired_AS.LoopCount = CInt(NUD_LoopCount.Value)
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

    Private Sub NUD_RouteLineWidth_Enter(sender As Object, e As EventArgs) Handles NUD_RouteLineWidth.Enter, NUD_SymbolWidth.Enter, Nud_Size.Enter, NUD_StepSize.Enter, NUD_DelayTime.Enter, NUD_LoopCount.Enter
        Dim NUD As NumericUpDown = CType(sender, NumericUpDown)
        NUD.Select(0, NUD.ToString.Length)
    End Sub

    Private Sub Btn_RouteColor_Click(sender As Object, e As EventArgs) Handles Btn_RouteColor.Click
        CD_Colour.Color = RouteCol
        If CD_Colour.ShowDialog() = DialogResult.OK Then
            RouteCol = CD_Colour.Color
            L_RouteColor.BackColor = RouteCol
        End If
    End Sub

    Private Sub Btn_SymbolColor_Click(sender As Object, e As EventArgs) Handles Btn_SymbolColor.Click
        CD_Colour.Color = SymbolCol
        If CD_Colour.ShowDialog() = DialogResult.OK Then
            SymbolCol = CD_Colour.Color
            L_SymbolColor.BackColor = SymbolCol
        End If
    End Sub
End Class

Public Enum SaveType
    GIF
    SingleFiles
End Enum
Public Class AnimationSaving
    Private _Width As Integer = 500
    Private _Height As Integer = 0
    Private _StepSize As Integer = 5
    Private _RouteColor As Color = Color.Blue
    Private _SymbolColor As Color = Color.Red
    Private _OutputFormat As String = ".jpg"
    Private _DirectoryPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Private _FilePath As String = Path.Combine(DirectoryPath, "Output.gif")
    Private _RouteLineWidth As Integer = 15
    Private _SymbolWidth As Integer = 20
    Private _BackGroundAlways As Boolean = True
    Private _DelayTime As Integer = 60 'in 1/100 of a second
    Private _SaveType As SaveType
    Private _LoopCount As Integer = 0

    Public Sub New()

    End Sub

    Public Property FilePath As String
        Get
            Return _FilePath
        End Get
        Set(value As String)
            _FilePath = value
        End Set
    End Property

    Public Property LoopCount As Integer
        Get
            Return _LoopCount
        End Get
        Set(value As Integer)
            _LoopCount = value
        End Set
    End Property

    Public Property DelayTime As Integer
        Get
            Return _DelayTime
        End Get
        Set(value As Integer)
            _DelayTime = value
        End Set
    End Property

    Public Property SaveType As SaveType
        Get
            Return _SaveType
        End Get
        Set(value As SaveType)
            _SaveType = value
        End Set
    End Property

    Public Property BackgroundAlways As Boolean
        Get
            Return _BackGroundAlways
        End Get
        Set(value As Boolean)
            _BackGroundAlways = value
        End Set
    End Property

    Public Property SymbolWidth As Integer
        Get
            Return _SymbolWidth
        End Get
        Set(value As Integer)
            _SymbolWidth = value
        End Set
    End Property

    Public Property RouteLineWidth As Integer
        Get
            Return _RouteLineWidth
        End Get
        Set(value As Integer)
            _RouteLineWidth = value
        End Set
    End Property

    Public Property DirectoryPath As String
        Get
            Return _DirectoryPath
        End Get
        Set(value As String)
            _DirectoryPath = value
        End Set
    End Property

    Public Property Width As Integer
        Get
            Return _Width
        End Get
        Set(value As Integer)
            _Width = value
        End Set
    End Property

    Public Property Height As Integer
        Get
            Return _Height
        End Get
        Set(value As Integer)
            _Height = value
        End Set
    End Property

    Public Property StepSize As Integer
        Get
            Return _StepSize
        End Get
        Set(value As Integer)
            _StepSize = value
        End Set
    End Property

    Public Property RouteColor As Color
        Get
            Return _RouteColor
        End Get
        Set(value As Color)
            _RouteColor = value
        End Set
    End Property

    Public Property SymbolColor As Color
        Get
            Return _SymbolColor
        End Get
        Set(value As Color)
            _SymbolColor = value
        End Set
    End Property

    Public Property OutputFormat As String
        Get
            Return _OutputFormat
        End Get
        Set(value As String)
            _OutputFormat = value
        End Set
    End Property

End Class
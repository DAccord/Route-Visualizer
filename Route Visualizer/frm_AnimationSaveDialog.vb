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
        CMB_Format.SelectedItem = Desired_AS.OutputFormat
        L_Path.Text = Desired_AS.Path
        'Step size
        NUD_StepSize.Value = Desired_AS.StepSize
    End Sub

    Private Sub Btn_SelectPath_Click(sender As Object, e As EventArgs) Handles Btn_SelectPath.Click
        If FBD_SavePath.ShowDialog() = DialogResult.OK Then
            L_Path.Text = FBD_SavePath.SelectedPath
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
        Desired_AS.OutputFormat = CMB_Format.SelectedItem.ToString
        Desired_AS.Path = L_Path.Text
        Desired_AS.BackgroundAlways = RB_AlwaysBackground.Checked

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

    Private Sub NUD_RouteLineWidth_Enter(sender As Object, e As EventArgs) Handles NUD_RouteLineWidth.Enter, NUD_SymbolWidth.Enter, Nud_Size.Enter, NUD_StepSize.Enter
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

Public Class AnimationSaving
    Private _Width As Integer = 500
    Private _Height As Integer = 0
    Private _StepSize As Integer = 5
    Private _RouteColor As Color = Color.Blue
    Private _SymbolColor As Color = Color.Red
    Private _OutputFormat As String = ".jpg"
    Private _Path As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Private _RouteLineWidth As Integer = 15
    Private _SymbolWidth As Integer = 20
    Private _BackGroundAlways As Boolean = True

    Public Sub New()

    End Sub

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

    Public Property Path As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
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
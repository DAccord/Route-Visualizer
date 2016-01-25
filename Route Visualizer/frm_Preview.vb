Public Class frm_Preview
    Dim PanStartPoint As New Point
    Dim OrigSize As Size
    Dim ZoomStep As Double = 1.2
    Dim CtrlHold As Boolean = False

    Public Sub New(img As Image)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        PB_Preview.Width = img.Width
        PB_Preview.Height = img.Height
        OrigSize = New Size(img.Width, img.Height)
        PB_Preview.Image = img
        L_ImgSize.Text = String.Format(L_ImgSize.Text, OrigSize.Width, OrigSize.Height)
    End Sub

    Private Sub PB_Preview_MouseDown(sender As Object, e As MouseEventArgs) Handles PB_Preview.MouseDown
        If e.Button = MouseButtons.Left Then
            Me.Cursor = Cursors.SizeAll
            PanStartPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub PB_Preview_MouseMove(sender As Object, e As MouseEventArgs) Handles PB_Preview.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim DeltaX As Integer = PanStartPoint.X - e.X
            Dim DeltaY As Integer = PanStartPoint.Y - e.Y
            Panel1.AutoScrollPosition = New Point(DeltaX - Panel1.AutoScrollPosition.X, DeltaY - Panel1.AutoScrollPosition.Y)
        End If
    End Sub

    Private Sub Btn_ZoomIn_Click(sender As Object, e As EventArgs) Handles Btn_ZoomIn.Click
        PB_Preview.Width = CInt(PB_Preview.Width * ZoomStep)
        PB_Preview.Height = CInt(PB_Preview.Height * ZoomStep)
        PictureBox_Position()
    End Sub

    Private Sub Btn_ZoomOut_Click(sender As Object, e As EventArgs) Handles Btn_ZoomOut.Click
        PB_Preview.Width = CInt(PB_Preview.Width / ZoomStep)
        PB_Preview.Height = CInt(PB_Preview.Height / ZoomStep)
        PictureBox_Position()
    End Sub

    Private Sub Btn_ResetZoom_Click(sender As Object, e As EventArgs) Handles Btn_ResetZoom.Click
        PB_Preview.Width = OrigSize.Width
        PB_Preview.Height = OrigSize.Height
        PictureBox_Position()
    End Sub

    Private Sub Btn_Fit_Click(sender As Object, e As EventArgs) Handles Btn_Fit.Click
        Dim ratio_Pan As Double = Panel1.Width / Panel1.Height
        Dim ratio_img As Double = OrigSize.Width / OrigSize.Height

        If ratio_Pan >= ratio_img Then
            PB_Preview.Height = Panel1.Height
            PB_Preview.Width = CInt(Panel1.Height * ratio_img)
        Else
            PB_Preview.Width = Panel1.Width
            PB_Preview.Height = CInt(Panel1.Width * ratio_img)
        End If
        PictureBox_Position()
    End Sub

    Private Sub PB_Preview_MouseUp(sender As Object, e As MouseEventArgs) Handles PB_Preview.MouseUp
        Me.Cursor = Cursors.Default
    End Sub

    Sub PictureBox_Position()
        If CInt(Math.Floor((Panel1.Width - PB_Preview.Width) / 2)) > 0 Then
            PB_Preview.Location = New Point(CInt(Math.Floor((Panel1.Width - PB_Preview.Width) / 2)), 0)
        Else
            PB_Preview.Location = New Point(0, 0)
        End If
    End Sub

    Private Sub PB_Preview_SizeChanged(sender As Object, e As EventArgs) Handles PB_Preview.SizeChanged
        PictureBox_Position()
    End Sub
End Class
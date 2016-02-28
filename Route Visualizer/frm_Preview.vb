Imports System.Text

Public Class frm_Preview
    Dim ImgToDraw As Image
    Dim Offset As Point
    Dim DesiredSize As Size
    Dim PanStartPoint As Point
    Dim Fitted As Boolean = True
    Dim ZoomStep As Double = 1.2
    Dim CursorPosition As Point
    Dim CtrlHold As Boolean = False
    Dim OrigImageSize As Size

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TSSL_ImageSize.Text = ""
        TSSL_Zoom.Text = ""
    End Sub

    Public Sub SetImage(img As Image)
        If img Is Nothing Then
            Exit Sub
        End If
        ImgToDraw = img
        DrawImage(img, New Point(0, 0), CalculateFittedImageSize())
        OrigImageSize = img.Size
        TSSL_ImageSize.Text = String.Format(My.Resources.Preview_ImageSize, img.Width, ImgToDraw.Height)
        UpdateZoomLabel()
    End Sub

    Private Sub DrawImage(Img As Image, Offset_F As Point, DesiredSize_F As Size)
        If Img Is Nothing Then
            Exit Sub
        End If
        ImgToDraw = Img

        'Block if user wants to scroll out of image
        If Offset_F.X < TLP_ImagePreview.ClientSize.Width - DesiredSize_F.Width Then
            Offset_F.X = TLP_ImagePreview.ClientSize.Width - DesiredSize_F.Width
        ElseIf Offset_F.X > 0 Then
            Offset_F.X = 0
        End If
        If Offset_F.Y < TLP_ImagePreview.ClientSize.Height - DesiredSize_F.Height Then
            Offset_F.Y = TLP_ImagePreview.ClientSize.Height - DesiredSize_F.Height
        ElseIf Offset_F.Y > 0 Then
            Offset_F.Y = 0
        End If

        'if image is smaller than the available space in one direction, center it in this direction
        If DesiredSize_F.Width < TLP_ImagePreview.ClientSize.Width Then
            Offset_F.X = CInt((TLP_ImagePreview.ClientSize.Width - DesiredSize_F.Width) / 2)
        End If
        If DesiredSize_F.Height < TLP_ImagePreview.ClientSize.Height Then
            Offset_F.Y = CInt((TLP_ImagePreview.ClientSize.Height - DesiredSize_F.Height) / 2)
        End If

        Offset = Offset_F
        If DesiredSize_F.Width > 0 AndAlso DesiredSize_F.Height > 0 Then
            DesiredSize = DesiredSize_F
        End If
        UpdateZoomLabel()
        TLP_ImagePreview.Invalidate()
    End Sub

    Private Sub TLP_ImagePreview_Paint(sender As Object, e As PaintEventArgs) Handles TLP_ImagePreview.Paint
        If ImgToDraw Is Nothing Then
            Exit Sub
        End If
        Dim g As Graphics = e.Graphics
        g.DrawImage(ImgToDraw, Offset.X, Offset.Y, DesiredSize.Width, DesiredSize.Height)
    End Sub

    Private Sub TLP_ImagePreview_MouseDown(sender As Object, e As MouseEventArgs) Handles TLP_ImagePreview.MouseDown
        If e.Button = MouseButtons.Left AndAlso Not Fitted AndAlso (DesiredSize.Width > TLP_ImagePreview.ClientSize.Width OrElse DesiredSize.Height > TLP_ImagePreview.ClientSize.Height) Then
            Me.Cursor = Cursors.SizeAll
            PanStartPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub TLP_ImagePreview_MouseMove(sender As Object, e As MouseEventArgs) Handles TLP_ImagePreview.MouseMove
        If e.Button = MouseButtons.Left AndAlso Not Fitted AndAlso (DesiredSize.Width > TLP_ImagePreview.ClientSize.Width OrElse DesiredSize.Height > TLP_ImagePreview.ClientSize.Height) Then
            Dim DeltaX As Integer = PanStartPoint.X - e.X
            Dim DeltaY As Integer = PanStartPoint.Y - e.Y
            PanStartPoint = New Point(PanStartPoint.X - DeltaX, PanStartPoint.Y - DeltaY)

            DrawImage(ImgToDraw, New Point(Offset.X - DeltaX, Offset.Y - DeltaY), DesiredSize)
        Else
            CursorPosition = e.Location
        End If
    End Sub

    Private Sub TLP_ImagePreview_MouseUp(sender As Object, e As MouseEventArgs) Handles TLP_ImagePreview.MouseUp
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TLP_ImagePreview_SizeChanged(sender As Object, e As EventArgs) Handles TLP_ImagePreview.SizeChanged
        If Fitted Then
            DrawImage(ImgToDraw, New Point(0, 0), CalculateFittedImageSize())
        Else
            DrawImage(ImgToDraw, Offset, DesiredSize)
        End If
    End Sub

    Private Sub TLP_ImagePreview_MouseWheel(sender As Object, e As MouseEventArgs) Handles TLP_ImagePreview.MouseWheel
        If CtrlHold Then
            If e.Delta > 0 Then
                ZoomIn()
            Else
                ZoomOut()
            End If
        Else
            If e.Delta > 0 Then
                DrawImage(ImgToDraw, New Point(Offset.X, Offset.Y + 50), DesiredSize)
            Else
                DrawImage(ImgToDraw, New Point(Offset.X, Offset.Y - 50), DesiredSize)
            End If
        End If
    End Sub

    Private Sub TLP_ImagePreview_MouseLeave(sender As Object, e As EventArgs) Handles TLP_ImagePreview.MouseLeave
        CursorPosition = Nothing
    End Sub

    Private Sub frm_Preview_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.ControlKey Then
            CtrlHold = True
        ElseIf e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus Then
            ZoomIn()
        ElseIf e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus Then
            ZoomOut()
        ElseIf e.KeyCode = Keys.W OrElse e.KeyCode = Keys.Up Then
            DrawImage(ImgToDraw, New Point(Offset.X, Offset.Y + 25), DesiredSize)
        ElseIf e.KeyCode = Keys.S OrElse e.KeyCode = Keys.Down Then
            DrawImage(ImgToDraw, New Point(Offset.X, Offset.Y - 25), DesiredSize)
        ElseIf e.KeyCode = Keys.A OrElse e.KeyCode = Keys.Left Then
            DrawImage(ImgToDraw, New Point(Offset.X + 25, Offset.Y), DesiredSize)
        ElseIf e.KeyCode = Keys.D OrElse e.KeyCode = Keys.Right Then
            DrawImage(ImgToDraw, New Point(Offset.X - 25, Offset.Y), DesiredSize)
        ElseIf e.KeyCode = Keys.F1 Then
            CallHelp()
        Else
            CtrlHold = False
        End If
    End Sub

    Private Sub CallHelp()
        Dim GI As Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentUICulture
        If GI.TwoLetterISOLanguageName = "de" Then
            Process.Start("https://github.com/DAccord/Route-Visualizer/wiki/Vorschau%E2%80%90Fenster")
        Else
            Process.Start("https://github.com/DAccord/Route-Visualizer/wiki/Preview-Window")
        End If
    End Sub

    Private Sub frm_Preview_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.ControlKey Then
            CtrlHold = False
        End If
    End Sub

    Private Sub TSB_ZoomIn_Click(sender As Object, e As EventArgs) Handles TSB_ZoomIn.Click
        ZoomIn()
    End Sub

    Private Sub TSB_ZoomOut_Click(sender As Object, e As EventArgs) Handles TSB_ZoomOut.Click
        ZoomOut()
    End Sub

    Private Sub TSB_OriginalSize_Click(sender As Object, e As EventArgs) Handles TSB_OriginalSize.Click
        If ImgToDraw Is Nothing Then
            Exit Sub
        End If
        Fitted = False
        DrawImage(ImgToDraw, Offset, ImgToDraw.Size)
    End Sub

    Private Sub TSB_FitSize_Click(sender As Object, e As EventArgs) Handles TSB_FitSize.Click
        If ImgToDraw Is Nothing Then
            Exit Sub
        End If
        Fitted = True
        DrawImage(ImgToDraw, New Point(0, 0), CalculateFittedImageSize())
    End Sub

    Private Function CalculateFittedImageSize() As Size
        If ImgToDraw Is Nothing Then
            Return New Size(0, 0)
        End If
        Dim ImgWidth As Integer = TLP_ImagePreview.ClientSize.Width
        Dim ImgHeight As Integer = TLP_ImagePreview.ClientSize.Height
        If TLP_ImagePreview.ClientSize.Width / TLP_ImagePreview.ClientSize.Height > ImgToDraw.Width / ImgToDraw.Height Then
            ImgWidth = CInt(TLP_ImagePreview.Height * ImgToDraw.Width / ImgToDraw.Height)
        Else
            ImgHeight = CInt(TLP_ImagePreview.Width * ImgToDraw.Height / ImgToDraw.Width)
        End If

        Return New Size(ImgWidth, ImgHeight)
    End Function

    Private Sub frm_Preview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DrawImage(ImgToDraw, New Point(0, 0), CalculateFittedImageSize())
    End Sub

    Private Sub TSB_Help_Click(sender As Object, e As EventArgs) Handles TSB_Help.Click
        CallHelp()
    End Sub

    Private Sub HSB_Image_Scroll(sender As Object, e As ScrollEventArgs)
        DrawImage(ImgToDraw, New Point(Offset.X - (e.NewValue - e.OldValue), Offset.Y), DesiredSize)
    End Sub

    Private Sub VSB_Image_Scroll(sender As Object, e As ScrollEventArgs)
        DrawImage(ImgToDraw, New Point(Offset.X, Offset.Y - (e.NewValue - e.OldValue)), DesiredSize)
    End Sub

    Private Sub ZoomOut()
        If DesiredSize.Width / ZoomStep < 50 OrElse DesiredSize.Height / ZoomStep < 50 Then
            Media.SystemSounds.Beep.Play()
            Exit Sub
        End If
        Fitted = False
        Dim X_Percent As Double = 0.5
        Dim Y_Percent As Double = 0.5
        If Not CursorPosition = Nothing Then
            X_Percent = CursorPosition.X / TLP_ImagePreview.ClientSize.Width
            Y_Percent = CursorPosition.Y / TLP_ImagePreview.ClientSize.Height
        End If

        DrawImage(ImgToDraw, New Point(CInt(Offset.X / ZoomStep - TLP_ImagePreview.ClientSize.Width * (1 / ZoomStep - 1) * X_Percent), CInt(Offset.Y / ZoomStep - TLP_ImagePreview.ClientSize.Height * (1 / ZoomStep - 1) * Y_Percent)), New Size(CInt(DesiredSize.Width / ZoomStep), CInt(DesiredSize.Height / ZoomStep)))
    End Sub

    Private Sub ZoomIn()
        If DesiredSize.Width * ZoomStep > 10000000 OrElse DesiredSize.Height * ZoomStep > 10000000 Then
            Media.SystemSounds.Beep.Play()
            Exit Sub
        End If
        Fitted = False
        Dim X_Percent As Double = 0.5
        Dim Y_Percent As Double = 0.5
        If Not CursorPosition = Nothing Then
            X_Percent = CursorPosition.X / TLP_ImagePreview.ClientSize.Width
            Y_Percent = CursorPosition.Y / TLP_ImagePreview.ClientSize.Height
        End If

        DrawImage(ImgToDraw, New Point(CInt(Offset.X * ZoomStep - TLP_ImagePreview.ClientSize.Width * (ZoomStep - 1) * X_Percent), CInt(Offset.Y * ZoomStep - TLP_ImagePreview.ClientSize.Height * (ZoomStep - 1) * Y_Percent)), New Size(CInt(DesiredSize.Width * ZoomStep), CInt(DesiredSize.Height * ZoomStep)))
    End Sub

    Sub UpdateZoomLabel()
        TSSL_Zoom.Text = String.Format(My.Resources.Preview_Zoom, DesiredSize.Width / OrigImageSize.Width)
    End Sub
End Class

Public Class DoubleBufferedTableLayoutPanel
    Inherits TableLayoutPanel

    Public Sub New()
        Me.DoubleBuffered = True
    End Sub
End Class
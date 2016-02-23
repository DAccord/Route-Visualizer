Imports System.IO
Imports Route_Visualizer.Data

Public Class frm_AddEditRoutefile
    Dim _RRs() As RoutefileRow
    Public Sub New(ByRef RRs() As RoutefileRow)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For i As Integer = 0 To RRs.Count - 1
            DGV_EditRoutefiles.Rows.Add()
            DGV_EditRoutefiles.Rows(i).Cells(0).Value = RRs(i).Path
            DGV_EditRoutefiles.Rows(i).Cells(1).Value = RRs(i).RouteLineWidth
            DGV_EditRoutefiles.Rows(i).Cells(2).Value = RRs(i).RouteColor
            DGV_EditRoutefiles.Rows(i).Cells(3).Value = RRs(i).RouteAlpha
        Next

        _RRs = RRs
    End Sub

    Private Sub DGV_EditRoutefiles_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_EditRoutefiles.CellFormatting
        If DGV_EditRoutefiles.Columns(e.ColumnIndex).Name = "Col_RouteColor" Then
            Dim ColStr() As String = DGV_EditRoutefiles.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Split(CType(", ", Char()), StringSplitOptions.RemoveEmptyEntries)
            DGV_EditRoutefiles.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.FromArgb(CInt(ColStr(0)), CInt(ColStr(1)), CInt(ColStr(2)))
            DGV_EditRoutefiles.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.FromArgb(CInt(ColStr(0)), CInt(ColStr(1)), CInt(ColStr(2)))
            DGV_EditRoutefiles.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionForeColor = SystemColors.Highlight
        End If
    End Sub

    Private Sub Btn_ChangeColor_Click(sender As Object, e As EventArgs) Handles Btn_ChangeColor.Click
        If CD_SelectRouteColor.ShowDialog = DialogResult.OK Then
            For j As Integer = 0 To DGV_EditRoutefiles.ColumnCount - 1
                If DGV_EditRoutefiles.Columns(j).Name <> "Col_RouteColor" Then
                    Continue For
                End If
                For i As Integer = 0 To DGV_EditRoutefiles.Rows.Count - 1
                    DGV_EditRoutefiles.Rows(i).Cells(j).Value = CD_SelectRouteColor.Color.R.ToString & ", " & CD_SelectRouteColor.Color.G.ToString & ", " & CD_SelectRouteColor.Color.B.ToString
                Next
            Next
        End If
    End Sub

    Private Sub NUD_LineWidth_ValueChanged(sender As Object, e As EventArgs) Handles NUD_LineWidth.ValueChanged
        For j As Integer = 0 To DGV_EditRoutefiles.ColumnCount - 1
            If DGV_EditRoutefiles.Columns(j).Name <> "Col_RouteLineWidth" Then
                Continue For
            End If
            For i As Integer = 0 To DGV_EditRoutefiles.Rows.Count - 1
                DGV_EditRoutefiles.Rows(i).Cells(j).Value = NUD_LineWidth.Value
            Next
        Next
    End Sub

    Private Sub NUD_Alpha_ValueChanged(sender As Object, e As EventArgs) Handles NUD_Alpha.ValueChanged
        For j As Integer = 0 To DGV_EditRoutefiles.ColumnCount - 1
            If DGV_EditRoutefiles.Columns(j).Name <> "Col_Alpha" Then
                Continue For
            End If
            For i As Integer = 0 To DGV_EditRoutefiles.Rows.Count - 1
                DGV_EditRoutefiles.Rows(i).Cells(j).Value = NUD_Alpha.Value
            Next
        Next
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Me.Close()
    End Sub

    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        For i As Integer = 0 To _RRs.Count - 1
            _RRs(i).Path = DGV_EditRoutefiles.Rows(i).Cells(0).Value.ToString
            _RRs(i).RouteLineWidth = CInt(DGV_EditRoutefiles.Rows(i).Cells(1).Value)
            _RRs(i).RouteColor = DGV_EditRoutefiles.Rows(i).Cells(2).Value.ToString
            _RRs(i).RouteAlpha = CInt(DGV_EditRoutefiles.Rows(i).Cells(3).Value)
        Next
        Me.Close()
    End Sub

    Private Sub DGV_EditRoutefiles_SelectionChanged(sender As Object, e As EventArgs) Handles DGV_EditRoutefiles.SelectionChanged
        DGV_EditRoutefiles.ClearSelection()
    End Sub

    Private Sub DGV_EditRoutefiles_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_EditRoutefiles.CellDoubleClick
        Dim FilePath As String = DGV_EditRoutefiles.Rows(e.RowIndex).Cells("Col_Path").Value.ToString
        OFD_SelectPath.InitialDirectory = Path.GetDirectoryName(FilePath)
        If OFD_SelectPath.ShowDialog = DialogResult.OK Then
            DGV_EditRoutefiles.Rows(e.RowIndex).Cells("Col_Path").Value = OFD_SelectPath.FileName
        End If
    End Sub
End Class
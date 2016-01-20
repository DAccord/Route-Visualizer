Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports Route_Visualizer
Imports Route_Visualizer.Data

Public Class frm_Main
    Dim Coordinates As New List(Of Coordinate)
    Public Property NUD_RowFrom As Object
    Dim LayerDataView As DataView
    Dim TH As New Threading.Thread(AddressOf UpdatePreviewNew)
    Dim SaveOption As New SaveOptions
    Dim UpdateBackground As Boolean = True
    Dim DistZooms As List(Of Integer)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(Path.Combine(Application.StartupPath, "Data.xml")) Then
            Data.ReadXml(Path.Combine(Application.StartupPath, "Data.xml"))
        End If

        LayerDataView = New DataView(Data.Layer)
        LayerDataView.Sort = "Sortindex ASC"
        LayerBindingSource.Sort = "Sortindex ASC"
        LayerBindingSource1.Sort = "Sortindex ASC"
        ZoomBindingSource.Sort = "Zoomvalue ASC"
        ZoomBindingSource1.Sort = "Zoomvalue ASC"
        CLB_Layers.DataSource = LayerDataView
        CLB_Layers.DisplayMember = "Name"

        DistZooms = From row In Data.Zoom
                    Select row.Field(Of Int32)("Zoomvalue")
                    Distinct.ToList
        CMB_Zoom.DataSource = DistZooms

        If My.Application.Info.Version.Major = 0 Then
            Me.Text = "Route Visualizer v" & String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.Minor, My.Application.Info.Version.Build) & " beta"
        Else
            Me.Text = "Route Visualizer v" & String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
        End If
    End Sub

    Sub GUIEnabling(EnabledState As Boolean)
        UpdatePreviewToolStripMenuItem.Enabled = EnabledState
        SaveAsImageToolStripMenuItem.Enabled = EnabledState
        SaveLayersSeparatelyToolStripMenuItem.Enabled = EnabledState

        GB_Route.Enabled = EnabledState
        GB_AdditionalTiles.Enabled = EnabledState
        GB_Layers.Enabled = EnabledState
        GB_Preview.Enabled = EnabledState

        TSPB_Progress.Value = 0
        TSPB_Progress.Visible = Not EnabledState
        TSSL_Progress.Visible = Not EnabledState
        TSSL_EscToAbort.Visible = Not EnabledState
    End Sub

    Public Function CreateLayerImage(ByVal ZR As ZoomRow, MinMaxTiles() As Point, LogSB As StringBuilder) As Image
        Dim Result As Image = New Bitmap((MinMaxTiles(1).X - MinMaxTiles(0).X + 1) * ZR.Tilewidth, (MinMaxTiles(1).Y - MinMaxTiles(0).Y + 1) * ZR.Tileheight)

        Using g As Graphics = Graphics.FromImage(Result)
            For i As Integer = MinMaxTiles(0).Y To MinMaxTiles(1).Y
                For j As Integer = MinMaxTiles(0).X To MinMaxTiles(1).X
                    Dim CurrentPath As String = ZR.Path
                    CurrentPath = CurrentPath.Replace("{C}", j.ToString)
                    CurrentPath = CurrentPath.Replace("{R}", i.ToString)
                    CurrentPath = CurrentPath.Replace("{Z}", ZR.Zoomvalue.ToString)
                    If Not File.Exists(CurrentPath) Then
                        LogSB.AppendLine(String.Format(My.Resources.Main_CouldntFindTile_Path, CurrentPath))
                        Continue For
                    End If
                    Using layer As New Bitmap(CurrentPath)
                        g.DrawImage(layer, (j - MinMaxTiles(0).X) * ZR.Tilewidth, (i - MinMaxTiles(0).Y) * ZR.Tileheight, ZR.Tilewidth, ZR.Tileheight)
                    End Using
                Next
            Next
        End Using

        Return Result
    End Function

    Public Sub UpdatePreviewNew()
        Dim Starttime As DateTime = DateTime.Now
        Dim TilePen As New Pen(New SolidBrush(Color.Blue), 5)
        Dim CurrentZoomRow As ZoomRow
        Dim Cancel As Boolean = False
        Dim Log As New StringBuilder

        Me.Invoke(Sub()
                      GUIEnabling(False)
                  End Sub)

        Dim Zoom As Integer
        Me.Invoke(Sub()
                      If CMB_Zoom.SelectedItem Is Nothing AndAlso Not Cancel Then
                          MessageBox.Show(My.Resources.Main_SelectZoom, My.Resources.Main_SelectZoom_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                          Cancel = True
                      End If
                      If Not Cancel Then
                          Zoom = CInt(CMB_Zoom.SelectedItem.ToString)
                      End If
                  End Sub)

        Me.Invoke(Sub()
                      If CLB_Layers.CheckedItems.Count = 0 AndAlso Not Cancel Then
                          MessageBox.Show(My.Resources.Main_SelectLayer, My.Resources.Main_SelectZoom_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                          Cancel = True
                      End If
                  End Sub)

        Me.Invoke(Sub()
                      If Data.Routefile.Rows.Count = 0 AndAlso Not Cancel Then
                          MessageBox.Show(My.Resources.Main_ImportFile, My.Resources.Main_ImportFile_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                          Cancel = True
                      End If
                  End Sub)

        If Not SaveOption.Preview AndAlso Not SaveOption.SaveLayersSeparately AndAlso Not Cancel Then 'Save image
            Me.Invoke(Sub()
                          If Not SFD_SaveImage.ShowDialog() = DialogResult.OK Then
                              GUIEnabling(True)
                              Cancel = True
                          End If
                      End Sub)
        End If

        If Not SaveOption.Preview AndAlso SaveOption.SaveLayersSeparately AndAlso Not Cancel Then 'Save layers
            Me.Invoke(Sub()
                          If Not FBD_SaveLayersSeperately.ShowDialog() = DialogResult.OK Then
                              GUIEnabling(True)
                              Cancel = True
                          End If
                      End Sub)
        End If

        If Cancel Then
            Me.Invoke(Sub()
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If

        Me.Invoke(Sub()
                      TSPB_Progress.Value = 0
                      TSPB_Progress.Maximum = CLB_Layers.CheckedIndices.Count + Data.Routefile.Select("Visibility = " & True & " AND RouteLineWidth > 0").Length + 1
                      TSPB_Progress.Visible = True
                      TSSL_Progress.Visible = True
                      TSSL_EscToAbort.Visible = True
                  End Sub)

        Dim Result As Image
        Dim MyCoordinates As New List(Of Coordinate)
        Dim RRs() As RoutefileRow = CType(Data.Routefile.Select("Visibility = " & True & " AND RouteLineWidth > 0"), RoutefileRow())
        If RRs.Length = 0 Then
            MessageBox.Show(String.Format(My.Resources.Main_NoRoutesToPlot, Environment.NewLine), My.Resources.Main_NoRoutesToPlot_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Invoke(Sub()
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If
        Dim ReadCoordinates(RRs.Length - 1) As List(Of Coordinate)
        Dim cnt As Integer = -1
        For Each RR As RoutefileRow In RRs
            cnt += 1
            Dim Res As New List(Of Coordinate)
            Try
                Res = ImportCoordinatesFromFile(RR)
            Catch ArgNullEx As ArgumentNullException
                Log.AppendLine(String.Format(My.Resources.Main_PathNull, RR.ID))
            Catch FNFEx As FileNotFoundException
                Log.AppendLine(String.Format(My.Resources.Main_FileNotFound, RR.Path))
            Catch ex As Exception
                Log.AppendLine(String.Format(My.Resources.Main_ErrorWhileImporting, RR.Path) & Environment.NewLine & ex.Message & Environment.NewLine & ex.InnerException.ToString & Environment.NewLine & ex.InnerException.StackTrace)
            End Try
            ReadCoordinates(cnt) = Res
            If Res.Count = 0 Then
                Log.AppendLine(String.Format(My.Resources.Main_CouldntImportCoordinatesFromFile, RR.Path))
                Continue For
            End If
            MyCoordinates.AddRange(Res)
        Next

        If MyCoordinates.Count = 0 Then
            Log.AppendLine(My.Resources.Main_NoCoordinates)
            WriteLog(Starttime, Log)
            Me.Invoke(Sub()
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If

        Me.Invoke(Sub()
                      TSPB_Progress.Value += 1
                  End Sub)

        Dim Tiles() As Point 'array for minimum and maximum tiles
        For k As Integer = 0 To CLB_Layers.Items.Count - 1
            If Not CLB_Layers.GetItemChecked(k) Then
                Continue For
            End If

            Dim DRV As DataRowView = CType(CLB_Layers.Items(k), DataRowView)
            Dim CurrentLayer As LayerRow = CType(DRV.Row, LayerRow)
            Dim ZRs() As ZoomRow = CType(Data.Zoom.Select("LayerID = " & CurrentLayer.ID & " And Zoomvalue = " & Zoom), ZoomRow())
            If ZRs.Length = 0 Then
                Log.AppendLine(String.Format(My.Resources.Main_NoTilesLayerZoom, CurrentLayer.Name, Zoom))
                Continue For
            End If
            CurrentZoomRow = ZRs(0)

            Tiles = CalcMinMaxTiles(MyCoordinates, CurrentZoomRow)

            If Not UpdateBackground AndAlso File.Exists(Path.Combine(Application.StartupPath, "TempBackground.png")) Then
                Result = Image.FromFile(Path.Combine(Application.StartupPath, "TempBackground.png"))
                Exit For
            End If

            If Result Is Nothing OrElse SaveOption.SaveLayersSeparately Then
                Result = New Bitmap((Tiles(1).X - Tiles(0).X + 1) * CurrentZoomRow.Tilewidth, (Tiles(1).Y - Tiles(0).Y + 1) * CurrentZoomRow.Tileheight)
            End If

            Using g As Graphics = Graphics.FromImage(Result)
                Using Img As Image = CreateLayerImage(CurrentZoomRow, Tiles, Log)
                    g.DrawImage(Img, 0, 0, Img.Width, Img.Height)
                End Using
            End Using
            If SaveOption.SaveLayersSeparately Then
                Result.Save(Path.Combine(FBD_SaveLayersSeperately.SelectedPath, "Layer" & k & ".png"), Imaging.ImageFormat.Png)
            End If
            Me.Invoke(Sub()
                          TSPB_Progress.Value += 1
                      End Sub)
        Next

        If UpdateBackground Then
            Result.Save(Path.Combine(Application.StartupPath, "TempBackground.png"))
            UpdateBackground = False
        End If

        If Result Is Nothing OrElse SaveOption.SaveLayersSeparately Then
            Result = New Bitmap((Tiles(1).X - Tiles(0).X + 1) * CurrentZoomRow.Tilewidth, (Tiles(1).Y - Tiles(0).Y + 1) * CurrentZoomRow.Tileheight)
        End If
        cnt = 0
        Using g As Graphics = Graphics.FromImage(Result)
            Dim RR As RoutefileRow
            For j As Integer = 0 To ReadCoordinates.Length - 1
                RR = RRs(j)
                Dim RoutePen As New Pen(Color.FromArgb(RR.RouteAlpha, CInt(RR.RouteColor.Replace(" ", "").Split(CType(", ", Char()))(0)), CInt(RR.RouteColor.Replace(" ", "").Split(CType(", ", Char()))(1)), CInt(RR.RouteColor.Replace(" ", "").Split(CType(", ", Char()))(2))), RR.RouteLineWidth)
                RoutePen.EndCap = Drawing2D.LineCap.Round
                RoutePen.StartCap = Drawing2D.LineCap.Round
                For i As Integer = 0 To ReadCoordinates(j).Count - 2
                    If ReadCoordinates(j).Item(i).PixelCoordinate(CurrentZoomRow).X = ReadCoordinates(j).Item(i + 1).PixelCoordinate(CurrentZoomRow).X AndAlso ReadCoordinates(j).Item(i).PixelCoordinate(CurrentZoomRow).Y = ReadCoordinates(j).Item(i + 1).PixelCoordinate(CurrentZoomRow).Y Then
                        Continue For
                    End If
                    g.DrawLine(RoutePen, ReadCoordinates(j).Item(i).PixelCoordinate(CurrentZoomRow).X - Tiles(0).X * CurrentZoomRow.Tilewidth, ReadCoordinates(j).Item(i).PixelCoordinate(CurrentZoomRow).Y - Tiles(0).Y * CurrentZoomRow.Tileheight, ReadCoordinates(j).Item(i + 1).PixelCoordinate(CurrentZoomRow).X - Tiles(0).X * CurrentZoomRow.Tilewidth, ReadCoordinates(j).Item(i + 1).PixelCoordinate(CurrentZoomRow).Y - Tiles(0).Y * CurrentZoomRow.Tileheight)
                Next
                Me.Invoke(Sub()
                              TSPB_Progress.Value += 1
                          End Sub)
                If SaveOption.SaveRoutesSeparately Then
                    Result.Save(Path.Combine(FBD_SaveLayersSeperately.SelectedPath, "Route" & cnt & ".png"), Imaging.ImageFormat.Png)
                    g.Clear(Color.Transparent)
                    cnt += 1
                End If
            Next

            If SaveOption.Preview Then 'Draw tile lines
                Dim Str As String = String.Format("{0}: {1}. {2}: {3}.", "R", 2 ^ CurrentZoomRow.Zoomvalue, "C", 2 ^ CurrentZoomRow.Zoomvalue)
                Dim FS As Integer = 50
                Dim StrFont As New Font("Arial", FS)
                Dim StrSize As SizeF = g.MeasureString(Str, StrFont)
                While (StrSize.Width > CurrentZoomRow.Tilewidth) OrElse (StrSize.Height > CurrentZoomRow.Tileheight)
                    StrFont = New Font("Arial", StrFont.Size - 1)
                    StrSize = g.MeasureString(Str, StrFont)
                End While

                For i As Integer = 0 To Math.Abs(Tiles(0).Y - Tiles(1).Y)
                    For j As Integer = 0 To Math.Abs(Tiles(0).X - Tiles(1).X) + 1
                        g.DrawString(String.Format("{0}: {1}. {2}: {3}.", "R", Tiles(0).Y + i, "C", Tiles(0).X + j), StrFont, New SolidBrush(TilePen.Color), j * CurrentZoomRow.Tilewidth, i * CurrentZoomRow.Tileheight)
                        g.DrawLine(TilePen, j * CurrentZoomRow.Tilewidth, 0, j * CurrentZoomRow.Tilewidth, Result.Height)
                    Next
                    g.DrawLine(TilePen, 0, i * CurrentZoomRow.Tileheight, Result.Width, i * CurrentZoomRow.Tileheight)
                Next
            End If
        End Using
        If SaveOption.SaveLayersSeparately AndAlso Not SaveOption.SaveRoutesSeparately Then
            Result.Save(Path.Combine(FBD_SaveLayersSeperately.SelectedPath, "Route.png"), Imaging.ImageFormat.Png)
        End If

        If SaveOption.Preview Then
            Me.Invoke(Sub()
                          PB_Preview.Image = Result
                          'GB_Preview.Text = "Vorschau (Doppelkick für Originalgröße (" & Result.Width & " x " & Result.Height & "))"
                          GUIEnabling(True)
                      End Sub)
        ElseIf Not SaveOption.Preview AndAlso Not SaveOption.SaveLayersSeparately Then
            Select Case Path.GetExtension(SFD_SaveImage.FileName).ToLower()
                Case ".jpg"
                    Result.Save(SFD_SaveImage.FileName, Imaging.ImageFormat.Jpeg)
                Case ".png"
                    Result.Save(SFD_SaveImage.FileName, Imaging.ImageFormat.Png)
                Case ".bmp"
                    Result.Save(SFD_SaveImage.FileName, Imaging.ImageFormat.Bmp)
                Case ".gif"
                    Result.Save(SFD_SaveImage.FileName, Imaging.ImageFormat.Gif)
                Case ".tif"
                    Result.Save(SFD_SaveImage.FileName, Imaging.ImageFormat.Tiff)
            End Select
        End If
        Me.Invoke(Sub()
                      GUIEnabling(True)
                  End Sub)

        WriteLog(Starttime, Log)

        If Not SaveOption.Preview AndAlso Not SaveOption.SaveLayersSeparately AndAlso Not SaveOption.SaveRoutesSeparately Then
            If MessageBox.Show(My.Resources.Main_OpenResultFile, My.Resources.Main_OpenResultFile_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Process.Start(SFD_SaveImage.FileName)
            End If
        ElseIf Not SaveOption.Preview Then
            If MessageBox.Show(My.Resources.Main_OpenResultDirectory, My.Resources.Main_OpenResultDirectory_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Process.Start(FBD_SaveLayersSeperately.SelectedPath)
            End If
        End If
    End Sub

    Private Sub WriteLog(Starttime As DateTime, LogSB As StringBuilder)
        If LogSB.ToString.Length <> 0 Then
            LogSB.Insert(0, String.Format(My.Resources.Main_LogHeader & Environment.NewLine & Environment.NewLine, Starttime.ToShortDateString, Starttime.ToLongTimeString))
            Using sw As StreamWriter = File.CreateText(Path.Combine(Application.StartupPath, "Log.txt"))
                sw.Write(LogSB.ToString)
            End Using
            If MessageBox.Show(String.Format(My.Resources.Main_OpenLog, Path.Combine(Application.StartupPath, "Log.txt"), Environment.NewLine), My.Resources.Main_OpenLog_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Process.Start(Path.Combine(Application.StartupPath, "Log.txt"))
            End If
        End If
    End Sub

    Public Function ReadCoordinatesFromGPX(RR As RoutefileRow) As List(Of Coordinate)
        Dim ser As New XmlSerializer(GetType(gpx.gpxType))
        Dim Result As New List(Of Coordinate)
        Using FS As New FileStream(RR.Path, FileMode.Open)
            Dim info As New gpx.gpxType
            info = CType(ser.Deserialize(FS), gpx.gpxType)
            Dim tracks() As gpx.trkType = info.trk
            For Each track As gpx.trkType In tracks
                For Each seg As gpx.trksegType In track.trkseg
                    For Each wpt As gpx.wptType In seg.trkpt
                        Result.Add(New Coordinate(wpt.lat, wpt.lon))
                    Next
                Next
            Next
        End Using
        Return Result
    End Function

    Public Function ImportCoordinatesFromFile(RR As RoutefileRow) As List(Of Coordinate)
        If RR.IsPathNull Then
            Throw New ArgumentNullException("RoutefileRow.Path", "The path is nothing in Route with ID " & RR.ID)
        End If
        If Not File.Exists(RR.Path) Then
            Throw New FileNotFoundException("File not found during import of coordinates: ", RR.Path)
        End If
        Dim Result As New List(Of Coordinate)
        Try
            Select Case Path.GetExtension(RR.Path).ToLower
                Case ".kml"
                    Result = ReadCoordinatesFromKML(RR)
                Case ".gpx"
                    Result = ReadCoordinatesFromGPX(RR)
            End Select
        Catch ex As Exception
            Throw ex
        End Try
        Return Result
    End Function

    Public Function ReadCoordinatesFromKML(RR As RoutefileRow) As List(Of Coordinate)
        Dim Result As New List(Of Coordinate)
        Dim enUS As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
        Using r As StreamReader = File.OpenText(RR.Path)
            Dim Z As String
            Dim CRaw() As String
            Dim Found As Integer = -1
            Do While Not r.EndOfStream 'AndAlso Found <> 1
                Z = r.ReadLine.Trim
                If Z.Contains("<coordinates>") AndAlso Z.Contains("</coordinates>") Then
                    Z = Z.Substring("<coordinates>".Length, Z.Length - "</coordinates>".Length - "<coordinates>".Length)
                    CRaw = Z.Split(CType(", ", Char()))
                    If CRaw.Count >= 2 Then
                        Result.Add(New Coordinate(Double.Parse(CRaw(1), enUS), Double.Parse(CRaw(0), enUS)))
                    End If
                    Continue Do
                End If
                If Z.Contains("<coordinates>") Then
                    Found = 0
                    If Z.Length > "<coordinates>".Length Then
                        Z = Z.Substring("<coordinates>".Length).Trim()
                        CRaw = Z.Split(CType(", ", Char()))
                        If CRaw.Count >= 2 Then
                            Result.Add(New Coordinate(Double.Parse(CRaw(1), enUS), Double.Parse(CRaw(0), enUS)))
                        End If
                    End If
                    Continue Do
                End If
                If Z.Contains("</coordinates>") Then
                    Found = 1
                End If
                If Found = 0 Then
                    CRaw = Z.Split(CType(", ", Char()))
                    If CRaw.Count >= 2 Then
                        Result.Add(New Coordinate(Double.Parse(CRaw(1), enUS), Double.Parse(CRaw(0), enUS)))
                    End If
                End If
            Loop
        End Using

        Return Result
    End Function

    Private Sub NUD_AdditionalTilesNorth_ValueChanged(sender As Object, e As EventArgs) Handles NUD_AdditionalTilesNorth.ValueChanged, NUD_AdditionalTilesWest.ValueChanged, NUD_AdditionalTilesEast.ValueChanged, NUD_AdditionalTilesSouth.ValueChanged, CMB_Zoom.SelectedIndexChanged
        UpdateBackground = True
    End Sub

    Private Sub CLB_Layers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CLB_Layers.SelectedIndexChanged
        Dim OldSelectedValue As Integer = CInt(CMB_Zoom.SelectedItem)
        Dim PossibleZoomValues As New List(Of Integer)
        For i As Integer = 0 To CLB_Layers.Items.Count - 1
            If CLB_Layers.GetItemChecked(i) Then
                Dim DRV As DataRowView = CType(CLB_Layers.Items(i), DataRowView)
                Dim LR As LayerRow = CType(DRV.Row, LayerRow)
                For Each ZR As ZoomRow In LR.GetChildRows("Layer_Zoom")
                    PossibleZoomValues.Add(ZR.Zoomvalue)
                Next
            End If
        Next
        PossibleZoomValues = PossibleZoomValues.Distinct.ToList()
        PossibleZoomValues.Sort()
        CMB_Zoom.DataSource = PossibleZoomValues
        If PossibleZoomValues.Contains(OldSelectedValue) Then
            CMB_Zoom.SelectedItem = OldSelectedValue
        End If
    End Sub

    Private Sub frm_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If TH.IsAlive() Then
            If MessageBox.Show(My.Resources.Main_CancelMapCreation, My.Resources.Main_CancelMapCreation_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            Else
                TH.Abort()
            End If
        End If
        Data.WriteXml(Path.Combine(Application.StartupPath, "Data.xml"))
        If File.Exists(Path.Combine(Application.StartupPath, "TempBackground.png")) Then
            Try
                File.Delete(Path.Combine(Application.StartupPath, "TempBackground.png"))
            Catch ex As Exception
                MessageBox.Show(String.Format(My.Resources.Main_CouldntDeleteTemp, Path.Combine(Application.StartupPath, "TempBackground.png")))
            End Try
        End If
    End Sub

    Private Sub NUD_Enter(sender As Object, e As EventArgs) Handles NUD_AdditionalTilesEast.Enter, NUD_AdditionalTilesNorth.Enter, NUD_AdditionalTilesSouth.Enter, NUD_AdditionalTilesWest.Enter
        Dim NUD As NumericUpDown = CType(sender, NumericUpDown)
        NUD.Select(0, NUD.Value.ToString.Length)
    End Sub

    Private Sub Btn_ResetAdditionalTiles_Click(sender As Object, e As EventArgs) Handles Btn_ResetAdditionalTiles.Click
        NUD_AdditionalTilesEast.Value = 0
        NUD_AdditionalTilesNorth.Value = 0
        NUD_AdditionalTilesSouth.Value = 0
        NUD_AdditionalTilesWest.Value = 0
    End Sub

    Private Sub ZoomDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles ZoomDataGridView.DataError
        If TypeOf (e.Exception) Is NoNullAllowedException Then
            If MessageBox.Show(My.Resources.Main_AllColumnsHaveToBeFilled, My.Resources.Main_AllColumnsHaveToBeFilled_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                e.Cancel = True
            End If
        ElseIf TypeOf (e.Exception) Is FormatException Then
            If MessageBox.Show(My.Resources.Main_WrongInputFormat, My.Resources.Main_WrongInputFormat_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub DGV_Route_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DGV_Route.CellBeginEdit
        If DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnPath" Then
            e.Cancel = True
            If e.RowIndex = DGV_Route.RowCount - 1 Then 'new row(s) added
                OFD_ImportRoute.Multiselect = True
                If OFD_ImportRoute.ShowDialog() = DialogResult.OK Then
                    If OFD_ImportRoute.Multiselect Then
                        For Each F As String In OFD_ImportRoute.FileNames
                            Dim RR As RoutefileRow = Data.Routefile.NewRoutefileRow()
                            RR.Path = F
                            Data.Routefile.AddRoutefileRow(RR)
                        Next
                    End If
                    DGV_Route.Rows.RemoveAt(e.RowIndex + OFD_ImportRoute.FileNames.Length)
                End If
            Else 'row gets edited
                OFD_ImportRoute.Multiselect = False
                Dim DRV As DataRowView = CType(RoutefileBindingSource.Current, DataRowView)
                Dim RR As RoutefileRow = CType(DRV.Row, RoutefileRow)

                If OFD_ImportRoute.ShowDialog() = DialogResult.OK Then
                    RR.Path = OFD_ImportRoute.FileName
                End If
            End If
            UpdateBackground = True
        ElseIf DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnRouteColor" OrElse DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnSymbolColor" Then
            If ValidateColorObject(DGV_Route.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                Dim ColStr() As String = DGV_Route.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Replace(" ", "").Split(CType(", ", Char()))
                CD_Main.Color = Color.FromArgb(CInt(ColStr(0)), CInt(ColStr(1)), CInt(ColStr(2)))
            End If
            If CD_Main.ShowDialog() = DialogResult.OK Then
                For Each C As DataGridViewCell In DGV_Route.SelectedCells
                    If C.ColumnIndex <> e.ColumnIndex Then
                        Continue For
                    End If
                    C.Value = CD_Main.Color.R & ", " & CD_Main.Color.G & ", " & CD_Main.Color.B
                Next
            End If
            e.Cancel = True
        End If
    End Sub

    Private Sub SaveAsImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsImageToolStripMenuItem.Click
        SaveOption = New SaveOptions(False, False, False)
        If TH.IsAlive() Then
            Exit Sub
        End If
        If TH.ThreadState = Threading.ThreadState.Stopped OrElse TH.ThreadState = Threading.ThreadState.Aborted Then
            TH = New Threading.Thread(AddressOf UpdatePreviewNew)
        End If
        TH.Start()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub UpdatePreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePreviewToolStripMenuItem.Click
        If TH.IsAlive() Then
            Exit Sub
        End If
        If TH.ThreadState = Threading.ThreadState.Stopped OrElse TH.ThreadState = Threading.ThreadState.Aborted Then
            TH = New Threading.Thread(AddressOf UpdatePreviewNew)
        End If
        SaveOption = New SaveOptions(True, False, False)
        TH.Start()
    End Sub

    Private Sub PB_Preview_DoubleClick(sender As Object, e As EventArgs) Handles PB_Preview.DoubleClick
        Dim PB As PictureBox = CType(sender, PictureBox)
        If PB.Image Is Nothing Then
            Exit Sub
        End If
        Dim PreviewForm As New frm_Preview(PB.Image)
        PreviewForm.ShowDialog()
    End Sub

    Private Sub frm_Main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape AndAlso TH.ThreadState = Threading.ThreadState.Running Then
            TH.Abort()
            GUIEnabling(True)
        End If
    End Sub

    Private Sub SpeichernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernToolStripMenuItem.Click
        Data.WriteXml(Path.Combine(Application.StartupPath, "Data.xml"))
    End Sub

    Private Sub DGV_Route_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DGV_Route.CellValidating
        If DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnRouteAlpha" OrElse DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnSymbolAlpha" Then
            Dim Nr As Integer
            If e.FormattedValue Is Nothing OrElse e.FormattedValue.ToString = "" Then
                MessageBox.Show(String.Format(My.Resources.Main_ValueBetween, 0, 255))
                e.Cancel = True
                Exit Sub
            End If
            If Not Integer.TryParse(e.FormattedValue.ToString, Nr) Then
                MessageBox.Show("Bitte eine Zahl eingeben.")
                e.Cancel = True
            Else
                If CInt(e.FormattedValue.ToString) > 255 OrElse CInt(e.FormattedValue.ToString) < 0 Then
                    MessageBox.Show(String.Format(My.Resources.Main_ValueBetween, 0, 255))
                    e.Cancel = True
                End If
            End If
        ElseIf DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnRouteColor" OrElse DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnSymbolColor" Then
            If e.FormattedValue Is Nothing OrElse e.FormattedValue.ToString = "" Then
                Exit Sub
            End If
            Dim StrSpl() As String = e.FormattedValue.ToString.Replace(" ", "").Split(CType(",", Char()))
            If StrSpl.Length <> 3 Then
                MessageBox.Show(My.Resources.Main_EnteredColorValue)
                e.Cancel = True
                Exit Sub
            End If
            Dim R As Integer
            Dim G As Integer
            Dim B As Integer
            If Not Integer.TryParse(StrSpl(0), R) OrElse Not Integer.TryParse(StrSpl(1), G) OrElse Not Integer.TryParse(StrSpl(2), B) Then
                MessageBox.Show(My.Resources.Main_EnterNumbers)
                e.Cancel = True
                Exit Sub
            End If
            If R < 0 OrElse R > 255 OrElse G < 0 OrElse G > 255 OrElse B < 0 OrElse B > 255 Then
                MessageBox.Show(String.Format(My.Resources.Main_NumbersBetween, 0, 255))
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Function ValidateColorObject(ByVal O As Object) As Boolean
        If O Is Nothing OrElse O.ToString = "" Then
            Return False
        End If
        Dim StrSpl() As String = O.ToString.Replace(" ", "").Split(CType(",", Char()))
        If StrSpl.Length <> 3 Then
            Return False
        End If
        Dim R As Integer
        Dim G As Integer
        Dim B As Integer
        If Not Integer.TryParse(StrSpl(0), R) OrElse Not Integer.TryParse(StrSpl(1), G) OrElse Not Integer.TryParse(StrSpl(2), B) Then
            Return False
        End If
        If R < 0 OrElse R > 255 OrElse G < 0 OrElse G > 255 OrElse B < 0 OrElse B > 255 Then
            Return False
        End If
        Return True
    End Function

    Private Sub DGV_Route_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_Route.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            If My.Computer.Clipboard.GetText() Is Nothing Then
                Exit Sub
            End If
            For Each C As DataGridViewCell In DGV_Route.SelectedCells()
                If DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewTextBoxColumnPath" _
                    OrElse DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewComboBoxColumnSymbol" _
                    OrElse DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewTextBoxColumnVisibility" Then
                    Continue For
                End If
                If DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewTextBoxColumnRouteColor" OrElse DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewTextBoxColumnSymbolColor" Then
                    If ValidateColorObject(My.Computer.Clipboard.GetText()) Then
                        C.Value = My.Computer.Clipboard.GetText()
                    End If
                Else
                    C.Value = My.Computer.Clipboard.GetText()
                End If
            Next
        End If
    End Sub

    Private Sub DGV_Route_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Route.CellEndEdit
        If DGV_Route.SelectedCells.Count > 1 Then
            For Each C As DataGridViewCell In DGV_Route.SelectedCells
                If DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewTextBoxColumnPath" _
                    OrElse DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewComboBoxColumnSymbol" _
                    OrElse DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewTextBoxColumnVisibility" Then
                    Continue For
                End If
                If DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewTextBoxColumnRouteColor" OrElse DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewTextBoxColumnSymbolColor" Then
                    If ValidateColorObject(DGV_Route.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                        C.Value = DGV_Route.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    End If
                Else
                    C.Value = DGV_Route.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                End If
            Next
        End If
    End Sub

    Private Sub HilfeAnzeigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HilfeAnzeigenToolStripMenuItem.Click
        Process.Start("https://github.com/DAccord/Route-Visualizer/wiki")
    End Sub

    Public Function CalcMinMaxTiles(Coords As List(Of Coordinate), ZR As ZoomRow) As Point()
        Dim Result(1) As Point

        Dim MinLat As Double = 1000
        Dim MaxLat As Double = -1000
        Dim MinLong As Double = 1000
        Dim MaxLong As Double = -1000
        For Each C As Coordinate In Coords
            If C.Latitude < MinLat Then
                MinLat = C.Latitude
            End If
            If C.Latitude > MaxLat Then
                MaxLat = C.Latitude
            End If
            If C.Longitude < MinLong Then
                MinLong = C.Longitude
            End If
            If C.Longitude > MaxLong Then
                MaxLong = C.Longitude
            End If
        Next

        Dim MinTile_x As Integer
        Dim MaxTile_x As Integer
        Dim MinTile_y As Integer
        Dim MaxTile_Y As Integer

        MinTile_x = New Coordinate(MaxLat, MinLong).TileCoordinate(ZR).X
        MaxTile_x = New Coordinate(MinLat, MaxLong).TileCoordinate(ZR).X
        MinTile_y = New Coordinate(MaxLat, MinLong).TileCoordinate(ZR).Y
        MaxTile_Y = New Coordinate(MinLat, MaxLong).TileCoordinate(ZR).Y

        If MaxTile_x < MinTile_x Then
            Dim W As Integer = MaxTile_x
            MaxTile_x = MinTile_x
            MinTile_x = W
        End If

        If MaxTile_Y < MinTile_y Then
            Dim W As Integer = MaxTile_Y
            MaxTile_Y = MinTile_y
            MinTile_y = W
        End If

        MinTile_x = CInt(MinTile_x - NUD_AdditionalTilesWest.Value)
        MaxTile_x = CInt(MaxTile_x + NUD_AdditionalTilesEast.Value)
        MinTile_y = CInt(MinTile_y - NUD_AdditionalTilesNorth.Value)
        MaxTile_Y = CInt(MaxTile_Y + NUD_AdditionalTilesSouth.Value)

        If MaxTile_x > 2 ^ ZR.Zoomvalue - 1 Then
            MaxTile_x = CInt(2 ^ ZR.Zoomvalue - 1)
        End If
        If MinTile_x <= 0 Then
            MinTile_x = 0
        ElseIf MinTile_x > 2 ^ ZR.Zoomvalue - 1 Then
            MinTile_x = MaxTile_x - 1
        End If
        If MaxTile_Y > 2 ^ ZR.Zoomvalue - 1 Then
            MaxTile_Y = CInt(2 ^ ZR.Zoomvalue - 1)
        End If
        If MinTile_y <= 0 Then
            MinTile_y = 0
        ElseIf MinTile_y > 2 ^ ZR.Zoomvalue - 1 Then
            MinTile_y = MaxTile_Y - 1
        End If

        Result(0).X = MinTile_x
        Result(0).Y = MinTile_y
        Result(1).X = MaxTile_x
        Result(1).Y = MaxTile_Y

        Return Result
    End Function

    Private Sub LayerDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles LayerDataGridView.DataError
        If TypeOf (e.Exception) Is NoNullAllowedException Then
            If MessageBox.Show(My.Resources.Main_AllColumnsHaveToBeFilled, My.Resources.Main_AllColumnsHaveToBeFilled_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                e.Cancel = True
            End If
        ElseIf TypeOf (e.Exception) Is FormatException Then
            If MessageBox.Show(My.Resources.Main_WrongInputFormat_2, My.Resources.Main_WrongInputFormat_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub AlleAuswählenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlleAuswählenToolStripMenuItem.Click
        For i As Integer = 0 To RoutefileBindingSource.Count - 1
            Dim DV As DataRowView = CType(RoutefileBindingSource.Item(i), DataRowView)
            Dim DR As RoutefileRow = CType(DV.Row, RoutefileRow)
            DR.Visibility = True
        Next
    End Sub

    Private Sub AlleAbwählenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlleAbwählenToolStripMenuItem.Click
        For i As Integer = 0 To RoutefileBindingSource.Count - 1
            Dim DV As DataRowView = CType(RoutefileBindingSource.Item(i), DataRowView)
            Dim DR As RoutefileRow = CType(DV.Row, RoutefileRow)
            DR.Visibility = False
        Next
    End Sub

    Private Sub AuswahlUmkehrenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuswahlUmkehrenToolStripMenuItem.Click
        For i As Integer = 0 To RoutefileBindingSource.Count - 1
            Dim DV As DataRowView = CType(RoutefileBindingSource.Item(i), DataRowView)
            Dim DR As RoutefileRow = CType(DV.Row, RoutefileRow)
            DR.Visibility = Not DR.Visibility
        Next
    End Sub

    Private Sub RoutenZusammenfassenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoutenZusammenfassenToolStripMenuItem.Click
        SaveOption = New SaveOptions(False, True, False)
        If TH.IsAlive() Then
            Exit Sub
        End If
        If TH.ThreadState = Threading.ThreadState.Stopped OrElse TH.ThreadState = Threading.ThreadState.Aborted Then
            TH = New Threading.Thread(AddressOf UpdatePreviewNew)
        End If
        TH.Start()
    End Sub

    Private Sub RoutenSeparatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoutenSeparatToolStripMenuItem.Click
        SaveOption = New SaveOptions(False, True, True)
        If TH.IsAlive() Then
            Exit Sub
        End If
        If TH.ThreadState = Threading.ThreadState.Stopped OrElse TH.ThreadState = Threading.ThreadState.Aborted Then
            TH = New Threading.Thread(AddressOf UpdatePreviewNew)
        End If
        TH.Start()
    End Sub

    Private Sub SpeicherortÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeicherortÖffnenToolStripMenuItem.Click
        Dim drv As DataRowView = CType(RoutefileBindingSource.Current, DataRowView)
        Dim DR As RoutefileRow = CType(drv.Row, RoutefileRow)
        Process.Start("explorer.exe", "/select,""" & DR.Path & """")
    End Sub

    Private Sub DGV_Route_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Route.CellValueChanged
        If DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnVisibility" Then
            UpdateBackground = True
        End If
    End Sub

    Private Sub ÜberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÜberToolStripMenuItem.Click
        Dim About_Box As New About_RouteVisualize
        About_Box.ShowDialog()
    End Sub

    Private Sub ZoomDataGridView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles ZoomDataGridView.CellValueChanged
        If ZoomDataGridView.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumn4" OrElse ZoomDataGridView.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumn5" Then
            Dim OldSelectedValue As Integer = CInt(CMB_Zoom.SelectedItem)
            Dim PossibleZoomValues As New List(Of Integer)
            For i As Integer = 0 To CLB_Layers.Items.Count - 1
                If CLB_Layers.GetItemChecked(i) Then
                    Dim DRV As DataRowView = CType(CLB_Layers.Items(i), DataRowView)
                    Dim LR As LayerRow = CType(DRV.Row, LayerRow)
                    For Each ZR As ZoomRow In LR.GetChildRows("Layer_Zoom")
                        PossibleZoomValues.Add(ZR.Zoomvalue)
                    Next
                End If
            Next
            PossibleZoomValues = PossibleZoomValues.Distinct.ToList()
            PossibleZoomValues.Sort()
            CMB_Zoom.DataSource = PossibleZoomValues
            If PossibleZoomValues.Contains(OldSelectedValue) Then
                CMB_Zoom.SelectedItem = OldSelectedValue
            End If
        End If
    End Sub
End Class

Class SaveOptions
    Private Property _Preview As Boolean
    Private Property _SaveLayersSeparately As Boolean
    Private Property _SaveRoutesSeparately As Boolean

    Public Property Preview As Boolean
        Get
            Return _Preview
        End Get
        Set(value As Boolean)
            _Preview = value
        End Set
    End Property

    Public Property SaveLayersSeparately As Boolean
        Get
            Return _SaveLayersSeparately
        End Get
        Set(value As Boolean)
            _SaveLayersSeparately = value
        End Set
    End Property

    Public Property SaveRoutesSeparately As Boolean
        Get
            Return _SaveRoutesSeparately
        End Get
        Set(value As Boolean)
            _SaveRoutesSeparately = value
        End Set
    End Property

    Public Sub New(Preview As Boolean, SaveLayersSeparately As Boolean, SaveRoutesSeparately As Boolean)
        _Preview = Preview
        _SaveLayersSeparately = SaveLayersSeparately
        _SaveRoutesSeparately = SaveRoutesSeparately
    End Sub

    Public Sub New()

    End Sub
End Class
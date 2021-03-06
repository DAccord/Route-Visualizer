﻿Imports System.IO
Imports System.Net
Imports System.Resources
Imports System.Text
Imports System.Xml.Serialization
Imports ImageMagick
Imports Route_Visualizer
Imports Route_Visualizer.Data
Imports Route_Visualizer.WebTiles

Public Class frm_Main
    Dim Coordinates As New List(Of Coordinate)
    Dim LayerDataView As DataView
    Dim TH_UpdatePreview As New Threading.Thread(AddressOf UpdatePreviewNew)
    Dim TH_AnimationSingleFiles As New Threading.Thread(AddressOf Animation)
    Dim SaveOption As New SaveOption
    Dim UpdateBackground As Boolean = True
    Dim CancelThread As Boolean = False

    Dim RVS As New RouteVisualizerSettings

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(Path.Combine(Application.StartupPath, "Data.xml")) Then
            Data.ReadXml(Path.Combine(Application.StartupPath, "Data.xml"))
        End If
        If File.Exists(Path.Combine(Application.StartupPath, "WebTiles.xml")) Then
            WebTiles.ReadXml(Path.Combine(Application.StartupPath, "WebTiles.xml"))
        End If
        RVS.ReadSettings(Path.Combine(Application.StartupPath, "RouteVisualizerSettings.resx"))
        Me.WindowState = RVS.MainFormWindowState
        Me.Location = RVS.MainFormWindowLocation
        Me.Size = RVS.MainFormWindowSize
        If RVS.PreviewFormWindowOpen Then
            'UpdatePreviewPB(Nothing)
        End If

        LayerDataView = New DataView(Data.Layer)
        LayerDataView.Sort = "Sortindex ASC"
        ZoomBindingSource.Sort = "Zoomvalue ASC"
        ZoomBindingSource1.Sort = "Zoomvalue ASC"
        CLB_Layers.DataSource = LayerDataView
        CLB_Layers.DisplayMember = "Name"
        CLB_OnlineLayers.DataSource = WebTileProviderBindingSource1
        CLB_OnlineLayers.DisplayMember = "Name"

        If Not RVS.CheckedLocalLayers Is Nothing Then
            For i As Integer = 0 To Math.Min(CLB_Layers.Items.Count - 1, RVS.CheckedLocalLayers.Count - 1)
                CLB_Layers.SetItemChecked(i, RVS.CheckedLocalLayers(i))
            Next
        End If
        If Not RVS.CheckedOnlineLayers Is Nothing Then
            For i As Integer = 0 To Math.Min(CLB_OnlineLayers.Items.Count - 1, RVS.CheckedOnlineLayers.Count - 1)
                CLB_OnlineLayers.SetItemChecked(i, RVS.CheckedOnlineLayers(i))
            Next
        End If

        'Setting numeric up downs' maximum values to 2^(2n), where n is the maximum zoom level
        NUD_AdditionalTilesNorth.Maximum = CDec(2 ^ (2 * 20))
        NUD_AdditionalTilesSouth.Maximum = CDec(2 ^ (2 * 20))
        NUD_AdditionalTilesWest.Maximum = CDec(2 ^ (2 * 20))
        NUD_AdditionalTilesEast.Maximum = CDec(2 ^ (2 * 20))

        Btn_Switch.Tag = RVS.Switch
        If RVS.Switch = "AbsoluteNumbers" Then
            Btn_ResetAdditionalTiles.Visible = False
        End If
        NUD_AdditionalTilesNorth.Value = RVS.North
        NUD_AdditionalTilesWest.Value = RVS.West
        NUD_AdditionalTilesSouth.Value = RVS.South
        NUD_AdditionalTilesEast.Value = RVS.East

        TB_Zoom.Value = RVS.Zoom

        If My.Application.Info.Version.Major = 0 Then
            Me.Text = "Route Visualizer v" & String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.Minor, My.Application.Info.Version.Build) & " beta"
        Else
            Me.Text = "Route Visualizer v" & String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
        End If

        OFD_ImportRoute.Filter = My.Resources.OFD_ImportRouteFilter
        OFD_ImportRoute.Title = My.Resources.OFD_ImportRouteTitle
        OFD_ImportRoute.InitialDirectory = Path.GetDirectoryName(RVS.ImportRoutePath)
        SaveOption.FilePath = RVS.SaveImagePath
        SaveOption.DirectoryPath = RVS.SaveLayersSeparatelyPath
        SaveOption.DirectoryPath = RVS.SaveLayersSeparatelyPath
        OFD_LayerWizard.Filter = My.Resources.OFD_LayerWizardFilter

        L_WebTileProvider_Restrictions.DataBindings.Add(New Binding("Text", WebTileProviderBindingSource, "LocalRestriction"))
        LL_WebTileProvider_Website.DataBindings.Add(New Binding("Text", WebTileProviderBindingSource, "Website"))
        If CMB_WebTileProvider_Name.Items.Count > 0 Then
            CMB_WebTileProvider_Name.SelectedIndex = 0
        Else
            LL_WebTileProvider_Website.Text = ""
            L_WebTileProvider_Restrictions.Text = ""
        End If
    End Sub

    Sub GUIEnabling(EnabledState As Boolean)
        UpdatePreviewToolStripMenuItem.Enabled = EnabledState
        SaveAsImageToolStripMenuItem.Enabled = EnabledState
        SaveLayersSeparatelyToolStripMenuItem.Enabled = EnabledState
        AnimationSingleFilesToolStripMenuItem.Enabled = EnabledState

        GB_Route.Enabled = EnabledState
        GB_AdditionalTiles.Enabled = EnabledState
        GB_Layers.Enabled = EnabledState

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
                    Dim CurrentPath As String = RowColumnZoomReplace(ZR.Path, i, j, ZR.Zoomvalue)
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

    Public Function RowColumnZoomReplace(ByVal Str As String, ByVal RowIndex As Integer, ByVal ColumnIndex As Integer, ByVal Zoom As Integer) As String
        Dim RowStrings() As String = {"{R}", "{Y}", "{r}", "{y}"}
        Dim ColumnStrings() As String = {"{C}", "{X}", "{c}", "{x}"}
        Dim ZoomStrings() As String = {"{Z}", "{z}"}

        For Each SearchStr As String In RowStrings
            Str = Str.Replace(SearchStr, RowIndex.ToString)
        Next
        For Each SearchStr As String In ColumnStrings
            Str = Str.Replace(SearchStr, ColumnIndex.ToString)
        Next
        For Each SearchStr As String In ZoomStrings
            Str = Str.Replace(SearchStr, Zoom.ToString)
        Next

        Return Str
    End Function

    Function ResizeImage(ByVal Img As Image, ByVal DesiredSize_Fct As Size) As Image
        Dim Res As Bitmap = New Bitmap(DesiredSize_Fct.Width, DesiredSize_Fct.Height)
        Using g_Res As Graphics = Graphics.FromImage(Res)
            g_Res.DrawImage(Img, 0, 0, DesiredSize_Fct.Width, DesiredSize_Fct.Height)
        End Using
        Return Res
    End Function

    Private Function CheckImagePrerequisites() As Boolean
        Dim RRs() As RoutefileRow = CType(Data.Routefile.Select("Visibility = " & True & " And RouteLineWidth > 0"), RoutefileRow())
        If RRs.Length = 0 Then
            MessageBox.Show(Me, My.Resources.Main_NoRoutesToPlot, My.Resources.Main_NoRoutesToPlot_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return false
        End If
        If CLB_Layers.CheckedItems.Count = 0 AndAlso CLB_OnlineLayers.CheckedItems.Count = 0 Then
            MessageBox.Show(Me, My.Resources.Main_SelectLayer, My.Resources.Main_SelectLayer_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Data.Routefile.Rows.Count = 0 Then
            MessageBox.Show(Me, My.Resources.Main_ImportFile, My.Resources.Main_ImportFile_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Btn_Switch.Tag.ToString = "AbsoluteNumbers" Then
            If NUD_AdditionalTilesNorth.Value > NUD_AdditionalTilesSouth.Value Then
                MessageBox.Show(Me, String.Format(My.Resources.Main_SmallerOrEqual, My.Resources.Main_L_MinRow, My.Resources.Main_L_MaxRow), My.Resources.Main_WrongInputFormat_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            If NUD_AdditionalTilesWest.Value > NUD_AdditionalTilesEast.Value Then
                MessageBox.Show(Me, String.Format(My.Resources.Main_SmallerOrEqual, My.Resources.Main_L_MinCol, My.Resources.Main_L_MaxCol), My.Resources.Main_WrongInputFormat_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        Return True
    End Function

    Public Sub UpdatePreviewNew()
        Dim Starttime As DateTime = DateTime.Now
        Dim TilePen As New Pen(New SolidBrush(Color.Blue), 5)
        Dim CurrentZoomRow As ZoomRow
        Dim Cancel As Boolean = False
        Dim Log As New StringBuilder
        Dim TryCached As Boolean = False

        If SaveOption.SaveType <> SaveType.Preview Then
            UpdateBackground = True
        End If

        Me.Invoke(Sub()
                      GUIEnabling(False)
                  End Sub)

        Dim Zoom As Integer
        Me.Invoke(Sub()
                      Zoom = TB_Zoom.Value
                  End Sub)

        Me.Invoke(Sub()
                      TSPB_Progress.Value = 0
                      TSPB_Progress.Maximum = CLB_Layers.CheckedIndices.Count + Data.Routefile.Select("Visibility = " & True & " And RouteLineWidth > 0").Length + 1
                      TSPB_Progress.Visible = True
                      TSSL_Progress.Visible = True
                      TSSL_EscToAbort.Visible = True
                  End Sub)

        Dim Result As Image = Nothing
        Dim MyCoordinates As New List(Of Coordinate)
        Dim RRs() As RoutefileRow = CType(Data.Routefile.Select("Visibility = " & True & " And RouteLineWidth > 0"), RoutefileRow())
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
                If Not ex.Message Is Nothing AndAlso Not ex.InnerException Is Nothing AndAlso Not ex.InnerException.StackTrace Is Nothing Then
                    Log.AppendLine(String.Format(My.Resources.Main_ErrorWhileImporting, RR.Path) & Environment.NewLine & ex.Message & Environment.NewLine & ex.InnerException.ToString & Environment.NewLine & ex.InnerException.StackTrace)
                ElseIf Not ex.Message Is Nothing Then
                    Log.AppendLine(String.Format(My.Resources.Main_ErrorWhileImporting, RR.Path) & Environment.NewLine & ex.Message)
                Else
                    Log.AppendLine(String.Format(My.Resources.Main_ErrorWhileImporting, RR.Path))
                End If
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

        Dim OnlineLayersCheckedCount As Integer
        Me.Invoke(Sub()
                      OnlineLayersCheckedCount = CLB_OnlineLayers.CheckedItems.Count
                  End Sub)
        Dim OnlineZoomRow As ZoomRow = Data.Zoom.NewZoomRow
        If OnlineLayersCheckedCount > 0 Then
            OnlineZoomRow = Data.Zoom.NewZoomRow
            OnlineZoomRow.Tileheight = 256
            OnlineZoomRow.Tilewidth = 256
            OnlineZoomRow.Zoomvalue = Zoom
            Dim MaxAllowedZoom As Integer = MaxZoom(MyCoordinates, OnlineZoomRow)
            If Zoom > MaxAllowedZoom Then
                Me.Invoke(Sub()
                              If MessageBox.Show(Me, String.Format(My.Resources.Main_ZoomTooLarge, MaxAllowedZoom), My.Resources.Main_ZoomTooLarge_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.Yes Then
                                  TryCached = True
                              Else
                                  GUIEnabling(True)
                                  Cancel = True
                              End If
                          End Sub)
            End If
        End If

        If Cancel Then
            Me.Invoke(Sub()
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If

        Me.Invoke(Sub()
                      TSPB_Progress.Value += 1
                  End Sub)

        Dim DesiredSize As Size
        Dim OrigSize As Size
        Dim Tiles() As Point 'array for minimum and maximum tiles
        For k As Integer = 0 To CLB_OnlineLayers.Items.Count - 1
            If Not CLB_OnlineLayers.GetItemChecked(k) Then
                Continue For
            End If

            If Btn_Switch.Tag.ToString = "AdditionalTiles" Then
                Tiles = CalcMinMaxTiles(MyCoordinates, OnlineZoomRow)
            Else
                Tiles = {New Point(CInt(NUD_AdditionalTilesWest.Value), CInt(NUD_AdditionalTilesNorth.Value)), New Point(CInt(NUD_AdditionalTilesEast.Value), CInt(NUD_AdditionalTilesSouth.Value))}
            End If

            OrigSize = New Size((Tiles(1).X - Tiles(0).X + 1) * OnlineZoomRow.Tilewidth, (Tiles(1).Y - Tiles(0).Y + 1) * OnlineZoomRow.Tileheight)
            If SaveOption.SaveType = SaveType.Preview Then
                DesiredSize = OrigSize
            ElseIf SaveOption.Height = 0 AndAlso SaveOption.Width = 0 Then
                DesiredSize = OrigSize
            ElseIf SaveOption.Height = 0 AndAlso SaveOption.Width > 0 Then
                DesiredSize = New Size(SaveOption.Width, CInt(OrigSize.Height / OrigSize.Width * SaveOption.Width))
            ElseIf SaveOption.Height > 0 AndAlso SaveOption.Width = 0 Then
                DesiredSize = New Size(CInt(OrigSize.Width / OrigSize.Height * SaveOption.Height), SaveOption.Height)
            End If

            If Result Is Nothing OrElse SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                Result = New Bitmap(DesiredSize.Width, DesiredSize.Height)
            End If
            Using g As Graphics = Graphics.FromImage(Result)
                Using Img As Image = CreateWebTileLayer(CType(CType(CLB_OnlineLayers.Items(k), DataRowView).Row, WebTileProviderRow), OnlineZoomRow, Tiles, Log, TryCached)
                    g.DrawImage(Img, 0, 0, DesiredSize.Width, DesiredSize.Height)
                End Using
            End Using
            If SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                If SaveOption.OutputFormat.ToLower = ".png" Then
                    Result.Save(Path.Combine(SaveOption.DirectoryPath, "OnlineLayer" & k & ".png"), Imaging.ImageFormat.Png)
                ElseIf SaveOption.OutputFormat.ToLower = ".tif" Then
                    Result.Save(Path.Combine(SaveOption.DirectoryPath, "OnlineLayer" & k & ".tif"), Imaging.ImageFormat.Tiff)
                End If
            End If
        Next
        CurrentZoomRow = OnlineZoomRow

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

            If Btn_Switch.Tag.ToString = "AdditionalTiles" Then
                Tiles = CalcMinMaxTiles(MyCoordinates, CurrentZoomRow)
            Else
                Tiles = {New Point(CInt(NUD_AdditionalTilesWest.Value), CInt(NUD_AdditionalTilesNorth.Value)), New Point(CInt(NUD_AdditionalTilesEast.Value), CInt(NUD_AdditionalTilesSouth.Value))}
            End If

            OrigSize = New Size((Tiles(1).X - Tiles(0).X + 1) * CurrentZoomRow.Tilewidth, (Tiles(1).Y - Tiles(0).Y + 1) * CurrentZoomRow.Tileheight)
            If SaveOption.SaveType = SaveType.Preview Then
                DesiredSize = OrigSize
            ElseIf SaveOption.Height = 0 AndAlso SaveOption.Width = 0 Then
                DesiredSize = OrigSize
            ElseIf SaveOption.Height = 0 AndAlso SaveOption.Width > 0 Then
                DesiredSize = New Size(SaveOption.Width, CInt(OrigSize.Height / OrigSize.Width * SaveOption.Width))
            ElseIf SaveOption.Height > 0 AndAlso SaveOption.Width = 0 Then
                DesiredSize = New Size(CInt(OrigSize.Width / OrigSize.Height * SaveOption.Height), SaveOption.Height)
            End If

            If Not UpdateBackground AndAlso File.Exists(Path.Combine(Application.StartupPath, "TempBackground.png")) Then
                Using TempResult As Image = Image.FromFile(Path.Combine(Application.StartupPath, "TempBackground.png"))
                    Result = ResizeImage(Image.FromFile(Path.Combine(Application.StartupPath, "TempBackground.png")), DesiredSize)
                End Using
                Exit For
            End If

            If Result Is Nothing OrElse SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                Result = New Bitmap(DesiredSize.Width, DesiredSize.Height)
            End If

            Using g As Graphics = Graphics.FromImage(Result)
                Using Img As Image = CreateLayerImage(CurrentZoomRow, Tiles, Log)
                    g.DrawImage(Img, 0, 0, DesiredSize.Width, DesiredSize.Height)
                End Using
            End Using
            If SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                If SaveOption.OutputFormat.ToLower = ".png" Then
                    Result.Save(Path.Combine(SaveOption.DirectoryPath, "LocalLayer" & k & ".png"), Imaging.ImageFormat.Png)
                ElseIf SaveOption.OutputFormat.ToLower = ".tif" Then
                    Result.Save(Path.Combine(SaveOption.DirectoryPath, "LocalLayer" & k & ".tif"), Imaging.ImageFormat.Tiff)
                End If
            End If
                Me.Invoke(Sub()
                          TSPB_Progress.Value += 1
                      End Sub)
        Next

        If UpdateBackground AndAlso SaveOption.SaveType <> SaveType.LayersSeparately_MergeRoutes AndAlso SaveOption.SaveType <> SaveType.LayersSeparately_RoutesSeparately Then
            Try
                Result.Save(Path.Combine(Application.StartupPath, "TempBackground.png"))
                UpdateBackground = False
            Catch ex As Exception
                UpdateBackground = True
            End Try
        End If

        If Result Is Nothing OrElse SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
            If DesiredSize.Width = 0 AndAlso DesiredSize.Height = 0 Then
                WriteLog(Starttime, Log)
                Me.Invoke(Sub()
                              GUIEnabling(True)
                          End Sub)
                Exit Sub
            Else
                Result = New Bitmap(DesiredSize.Width, DesiredSize.Height)
            End If
        End If
        cnt = 0

        Dim FinalPoints(ReadCoordinates.Length - 1) As List(Of Point)
        For i As Integer = 0 To ReadCoordinates.Length - 1
            FinalPoints(i) = New List(Of Point)
            FinalPoints(i).Add(New Point(
                CInt((ReadCoordinates(i).Item(0).PixelCoordinate(CurrentZoomRow).X - Tiles(0).X * CurrentZoomRow.Tilewidth) * DesiredSize.Width / OrigSize.Width),
                CInt((ReadCoordinates(i).Item(0).PixelCoordinate(CurrentZoomRow).Y - Tiles(0).Y * CurrentZoomRow.Tileheight) * DesiredSize.Width / OrigSize.Width)))
            For j As Integer = 1 To ReadCoordinates(i).Count - 1
                If FinalPoints(i).Item(FinalPoints(i).Count - 1) = New Point(
                CInt((ReadCoordinates(i).Item(j).PixelCoordinate(CurrentZoomRow).X - Tiles(0).X * CurrentZoomRow.Tilewidth) * DesiredSize.Width / OrigSize.Width),
                CInt((ReadCoordinates(i).Item(j).PixelCoordinate(CurrentZoomRow).Y - Tiles(0).Y * CurrentZoomRow.Tileheight) * DesiredSize.Width / OrigSize.Width)) Then
                    Continue For
                End If
                FinalPoints(i).Add(New Point(
                CInt((ReadCoordinates(i).Item(j).PixelCoordinate(CurrentZoomRow).X - Tiles(0).X * CurrentZoomRow.Tilewidth) * DesiredSize.Width / OrigSize.Width),
                CInt((ReadCoordinates(i).Item(j).PixelCoordinate(CurrentZoomRow).Y - Tiles(0).Y * CurrentZoomRow.Tileheight) * DesiredSize.Width / OrigSize.Width)))
            Next
        Next

        Using g As Graphics = Graphics.FromImage(Result)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim RR As RoutefileRow
            For j As Integer = 0 To ReadCoordinates.Length - 1
                RR = RRs(j)
                Dim RoutePen As New Pen(Color.FromArgb(RR.RouteAlpha, CInt(RR.RouteColor.Replace(" ", "").Split(CType(", ", Char()))(0)), CInt(RR.RouteColor.Replace(" ", "").Split(CType(", ", Char()))(1)), CInt(RR.RouteColor.Replace(" ", "").Split(CType(", ", Char()))(2))), CSng(RR.RouteLineWidth * DesiredSize.Width / OrigSize.Width))
                RoutePen.EndCap = Drawing2D.LineCap.Round
                RoutePen.StartCap = Drawing2D.LineCap.Round
                RoutePen.LineJoin = Drawing2D.LineJoin.Round
                g.DrawLines(RoutePen, FinalPoints(j).ToArray())
                Me.Invoke(Sub()
                              TSPB_Progress.Value += 1
                          End Sub)
                If SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                    If SaveOption.OutputFormat.ToLower = ".png" Then
                        Result.Save(Path.Combine(SaveOption.DirectoryPath, "Route" & cnt & ".png"), Imaging.ImageFormat.Png)
                    ElseIf SaveOption.OutputFormat.ToLower = ".tif" Then
                        Result.Save(Path.Combine(SaveOption.DirectoryPath, "Route" & cnt & ".tif"), Imaging.ImageFormat.Tiff)
                    End If
                    g.Clear(Color.Transparent)
                    cnt += 1
                End If
            Next

            If SaveOption.SaveType = SaveType.Preview Then 'Draw tile lines
                Dim Str As String = String.Format("{0}:   {1}. {2}: {3}.", "R", 2 ^ CurrentZoomRow.Zoomvalue, "C", 2 ^ CurrentZoomRow.Zoomvalue)
                Dim FS As Integer = 50
                Dim StrFont As New Font("Arial", FS)
                Dim StrSize As SizeF = g.MeasureString(Str, StrFont)
                While (StrSize.Width > CurrentZoomRow.Tilewidth * DesiredSize.Width / OrigSize.Width) OrElse (StrSize.Height > CurrentZoomRow.Tileheight * DesiredSize.Width / OrigSize.Width)
                    StrFont = New Font("Arial", StrFont.Size - 1)
                    StrSize = g.MeasureString(Str, StrFont)
                End While

                For i As Integer = 0 To Math.Abs(Tiles(0).Y - Tiles(1).Y) + 1
                    For j As Integer = 0 To Math.Abs(Tiles(0).X - Tiles(1).X) + 1
                        g.DrawString(String.Format("{0}: {1}. {2}: {3}.", "R", Tiles(0).Y + i, "C", Tiles(0).X + j), StrFont, New SolidBrush(TilePen.Color), CSng(j * CurrentZoomRow.Tilewidth * DesiredSize.Width / OrigSize.Width), CSng(i * CurrentZoomRow.Tileheight * DesiredSize.Width / OrigSize.Width))
                        g.DrawLine(TilePen, CInt(j * CurrentZoomRow.Tilewidth * DesiredSize.Width / OrigSize.Width), 0, CInt(j * CurrentZoomRow.Tilewidth * DesiredSize.Width / OrigSize.Width), CInt(Result.Height * DesiredSize.Width / OrigSize.Width))
                    Next
                    g.DrawLine(TilePen, 0, CInt(i * CurrentZoomRow.Tileheight * DesiredSize.Width / OrigSize.Width), CInt(Result.Width * DesiredSize.Width / OrigSize.Width), CInt(i * CurrentZoomRow.Tileheight * DesiredSize.Width / OrigSize.Width))
                Next
            End If
        End Using
        If SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes Then
            If SaveOption.OutputFormat.ToLower = ".png" Then
                Result.Save(Path.Combine(SaveOption.DirectoryPath, "Route.png"), Imaging.ImageFormat.Png)
            ElseIf SaveOption.OutputFormat.ToLower = ".tif" Then
                Result.Save(Path.Combine(SaveOption.DirectoryPath, "Route.gif"), Imaging.ImageFormat.Tiff)
            End If
        End If

        If SaveOption.SaveType = SaveType.Preview Then
            Me.Invoke(Sub()
                          UpdatePreviewPB(Result)
                          GUIEnabling(True)
                      End Sub)
        ElseIf SaveOption.SaveType = SaveType.SimpleImage Then
            RVS.SaveImagePath = SaveOption.FilePath
            Select Case SaveOption.OutputFormat.ToLower()
                Case ".jpg"
                    Result.Save(SaveOption.FilePath, Imaging.ImageFormat.Jpeg)
                Case ".png"
                    Result.Save(SaveOption.FilePath, Imaging.ImageFormat.Png)
                Case ".bmp"
                    Result.Save(SaveOption.FilePath, Imaging.ImageFormat.Bmp)
                Case ".gif"
                    Result.Save(SaveOption.FilePath, Imaging.ImageFormat.Gif)
                Case ".tif"
                    Result.Save(SaveOption.FilePath, Imaging.ImageFormat.Tiff)
            End Select
        End If

        Me.Invoke(Sub()
                      GUIEnabling(True)
                  End Sub)

        WriteLog(Starttime, Log)

        If SaveOption.SaveType = SaveType.SimpleImage Then
            Me.Invoke(Sub()
                          If MessageBox.Show(Me, My.Resources.Main_OpenResultFile, My.Resources.Main_OpenResultFile_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                              Process.Start(SaveOption.FilePath)
                          End If
                      End Sub)
        ElseIf SaveOption.SaveType <> SaveType.Preview Then
            Me.Invoke(Sub()
                          If MessageBox.Show(Me, My.Resources.Main_OpenResultDirectory, My.Resources.Main_OpenResultDirectory_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                              Process.Start(SaveOption.DirectoryPath)
                          End If
                      End Sub)
        End If
    End Sub

    Private Sub WriteLog(Starttime As DateTime, LogSB As StringBuilder)
        If LogSB.ToString.Length <> 0 Then
            LogSB.Insert(0, String.Format(My.Resources.Main_LogHeader & Environment.NewLine & Environment.NewLine, Starttime.ToShortDateString, Starttime.ToLongTimeString))
            Using sw As StreamWriter = File.CreateText(Path.Combine(Application.StartupPath, "Log.txt"))
                sw.Write(LogSB.ToString)
            End Using
            Me.Invoke(Sub()
                          If MessageBox.Show(Me, String.Format(My.Resources.Main_OpenLog, Path.Combine(Application.StartupPath, "Log.txt"), Environment.NewLine), My.Resources.Main_OpenLog_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                              Process.Start(Path.Combine(Application.StartupPath, "Log.txt"))
                          End If
                      End Sub)
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

    Private Sub NUD_AdditionalTilesNorth_ValueChanged(sender As Object, e As EventArgs) Handles NUD_AdditionalTilesNorth.ValueChanged, NUD_AdditionalTilesWest.ValueChanged, NUD_AdditionalTilesEast.ValueChanged, NUD_AdditionalTilesSouth.ValueChanged
        UpdateBackground = True
    End Sub

    Private Sub CLB_Layers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CLB_Layers.SelectedIndexChanged

    End Sub

    Private Sub frm_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If TH_UpdatePreview.IsAlive() Then
            If MessageBox.Show(My.Resources.Main_CancelMapCreation, My.Resources.Main_CancelMapCreation_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            Else
                TH_UpdatePreview.Abort()
            End If
        End If
        If TH_AnimationSingleFiles.IsAlive() Then
            If MessageBox.Show(My.Resources.Main_CancelMapCreation, My.Resources.Main_CancelMapCreation_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            Else
                CancelThread = True
                'TH_AnimationSingleFiles.Abort()
            End If
        End If

        RVS.MainFormWindowLocation = Me.Location
        RVS.MainFormWindowSize = Me.Size
        RVS.MainFormWindowState = Me.WindowState
        Dim List_CLB_Layers As New List(Of Boolean)
        For i As Integer = 0 To CLB_Layers.Items.Count - 1
            List_CLB_Layers.Add(CLB_Layers.GetItemChecked(i))
        Next
        RVS.CheckedLocalLayers = List_CLB_Layers
        Dim List_CLB_OLayers As New List(Of Boolean)
        For i As Integer = 0 To CLB_OnlineLayers.Items.Count - 1
            List_CLB_OLayers.Add(CLB_OnlineLayers.GetItemChecked(i))
        Next
        RVS.CheckedOnlineLayers = List_CLB_OLayers
        If PreviewForm Is Nothing OrElse PreviewForm.IsDisposed Then
            RVS.PreviewFormWindowOpen = False
        Else
            RVS.PreviewFormWindowOpen = True
            RVS.PreviewFormWindowLocation = PreviewForm.Location
            RVS.PreviewFormWindowSize = PreviewForm.Size
            RVS.PreviewFormWindowState = PreviewForm.WindowState
        End If
        RVS.Switch = Btn_Switch.Tag.ToString
        RVS.North = CInt(NUD_AdditionalTilesNorth.Value)
        RVS.West = CInt(NUD_AdditionalTilesWest.Value)
        RVS.East = CInt(NUD_AdditionalTilesEast.Value)
        RVS.South = CInt(NUD_AdditionalTilesSouth.Value)
        RVS.Zoom = TB_Zoom.Value
        RVS.SaveSettings(Path.Combine(Application.StartupPath, "RouteVisualizerSettings.resx"))

        Data.WriteXml(Path.Combine(Application.StartupPath, "Data.xml"))
        WebTiles.WriteXml(Path.Combine(Application.StartupPath, "WebTiles.xml"))
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
        If DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnPath" OrElse DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnRouteColor" Then
            Dim Routefilerows(DGV_Route.SelectedRows.Count - 1) As RoutefileRow
            For i As Integer = 0 To DGV_Route.SelectedRows.Count - 1
                Dim DGVR As DataGridViewRow = DGV_Route.SelectedRows(i)
                Dim DRV As DataRowView = CType(DGVR.DataBoundItem, DataRowView)
                Dim RR As RoutefileRow = CType(DRV.Row, RoutefileRow)
                Routefilerows(i) = RR
            Next

            Using AERF As New frm_AddEditRoutefile(Routefilerows)
                If AERF.ShowDialog() = DialogResult.OK Then
                    UpdateBackground = True
                End If
                e.Cancel = True
            End Using
        End If
    End Sub

    Private Sub SaveAsImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsImageToolStripMenuItem.Click
        If Not CheckImagePrerequisites() Then
            Exit Sub
        End If
        SaveOption.SaveType = SaveType.SimpleImage

        AnimationSaveDialogSetSettings(SaveOption)
        Dim frm_Save As New frm_AnimationSaveDialog(SaveOption)
        If frm_Save.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        AnimationSaveDialogGetSettings(frm_Save, SaveOption)

        If TH_UpdatePreview.IsAlive() Then
            Exit Sub
        End If
        If TH_UpdatePreview.ThreadState = Threading.ThreadState.Stopped OrElse TH_UpdatePreview.ThreadState = Threading.ThreadState.Aborted Then
            TH_UpdatePreview = New Threading.Thread(AddressOf UpdatePreviewNew)
        End If
        TH_UpdatePreview.Start()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub UpdatePreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePreviewToolStripMenuItem.Click
        If Not CheckImagePrerequisites() Then
            Exit Sub
        End If
        If TH_UpdatePreview.IsAlive() Then
            Exit Sub
        End If
        If TH_UpdatePreview.ThreadState = Threading.ThreadState.Stopped OrElse TH_UpdatePreview.ThreadState = Threading.ThreadState.Aborted Then
            TH_UpdatePreview = New Threading.Thread(AddressOf UpdatePreviewNew)
        End If
        SaveOption.SaveType = SaveType.Preview
        TH_UpdatePreview.Start()
    End Sub

    Private Sub frm_PreviewClosing(sender As Object, e As FormClosingEventArgs)
        ImagePreviewToolStripMenuItem.Checked = False

        Dim frm As frm_Preview = CType(sender, frm_Preview)
        RVS.PreviewFormWindowLocation = frm.Location
        RVS.PreviewFormWindowSize = frm.Size
        RVS.PreviewFormWindowState = frm.WindowState
    End Sub

    Private Sub UpdatePreviewPB(Img As Image)
        If PreviewForm Is Nothing OrElse PreviewForm.IsDisposed() Then
            PreviewForm = New frm_Preview()
            AddHandler PreviewForm.FormClosing, AddressOf frm_PreviewClosing
            PreviewForm.Size = RVS.PreviewFormWindowSize
            PreviewForm.Location = RVS.PreviewFormWindowLocation
            PreviewForm.WindowState = RVS.PreviewFormWindowState
            PreviewForm.SetImage(Img)
            PreviewForm.Show()
        Else
            PreviewForm.SetImage(Img)
            PreviewForm.BringToFront()
        End If
    End Sub

    Dim PreviewForm As frm_Preview

    Private Sub frm_Main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape AndAlso TH_UpdatePreview.ThreadState = Threading.ThreadState.Running Then
            TH_UpdatePreview.Abort()
            GUIEnabling(True)
        ElseIf e.KeyCode = Keys.Escape AndAlso TH_AnimationSingleFiles.ThreadState = Threading.ThreadState.Running Then
            CancelThread = True
            'TH_AnimationSingleFiles.Abort()
            GUIEnabling(True)
        End If
    End Sub

    Private Sub SpeichernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernToolStripMenuItem.Click
        Data.WriteXml(Path.Combine(Application.StartupPath, "Data.xml"))
        RVS.SaveSettings(Path.Combine(Application.StartupPath, "RouteVisualizerSettings.resx"))
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
        If DGV_Route.SelectedRows.Count > 1 AndAlso DGV_Route.Columns(e.ColumnIndex).Name <> "DataGridViewTextBoxColumnPath" AndAlso DGV_Route.Columns(e.ColumnIndex).Name <> "DataGridViewTextBoxColumnVisibility" Then
            For Each C As DataGridViewCell In DGV_Route.SelectedCells
                If C.ColumnIndex <> e.ColumnIndex Then
                    Continue For
                End If
                If DGV_Route.Columns(C.ColumnIndex).Name = "DataGridViewTextBoxColumnRouteColor" Then
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
        Dim GI As Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentUICulture
        If TC_Main.SelectedTab Is TP_RouteVisualizer Then
            If GI.TwoLetterISOLanguageName = "de" Then
                Process.Start("https://github.com/DAccord/Route-Visualizer/wiki/Der-Route-Visualizer%E2%80%90Tab")
            Else
                Process.Start("https://github.com/DAccord/Route-Visualizer/wiki/The-Route-Visualizer-Tab")
            End If
        ElseIf TC_Main.SelectedTab Is TP_LocalLayers Then
            If GI.TwoLetterISOLanguageName = "de" Then
                Process.Start("https://github.com/DAccord/Route-Visualizer/wiki/Der-Ebenen%E2%80%90Tab")
            Else
                Process.Start("https://github.com/DAccord/Route-Visualizer/wiki/The-Layers-Tab")
            End If
        Else
            Process.Start("https://github.com/DAccord/Route-Visualizer/wiki/")
        End If
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

    Private Sub RoutenZusammenfassenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoutenZusammenfassenToolStripMenuItem.Click
        If Not CheckImagePrerequisites() Then
            Exit Sub
        End If
        UpdateBackground = True
        SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes
        AnimationSaveDialogSetSettings(SaveOption)
        Dim frm_Save As New frm_AnimationSaveDialog(SaveOption)
        If frm_Save.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        AnimationSaveDialogGetSettings(frm_Save, SaveOption)

        If TH_UpdatePreview.IsAlive() Then
            Exit Sub
        End If
        If TH_UpdatePreview.ThreadState = Threading.ThreadState.Stopped OrElse TH_UpdatePreview.ThreadState = Threading.ThreadState.Aborted Then
            TH_UpdatePreview = New Threading.Thread(AddressOf UpdatePreviewNew)
        End If
        TH_UpdatePreview.Start()
    End Sub

    Private Sub RoutenSeparatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoutenSeparatToolStripMenuItem.Click
        If Not CheckImagePrerequisites() Then
            Exit Sub
        End If
        UpdateBackground = True
        SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately
        AnimationSaveDialogSetSettings(SaveOption)
        Dim frm_Save As New frm_AnimationSaveDialog(SaveOption)
        If frm_Save.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        AnimationSaveDialogGetSettings(frm_Save, SaveOption)

        If TH_UpdatePreview.IsAlive() Then
            Exit Sub
        End If
        If TH_UpdatePreview.ThreadState = Threading.ThreadState.Stopped OrElse TH_UpdatePreview.ThreadState = Threading.ThreadState.Aborted Then
            TH_UpdatePreview = New Threading.Thread(AddressOf UpdatePreviewNew)
        End If
        TH_UpdatePreview.Start()
    End Sub

    Private Sub DGV_Route_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Route.CellValueChanged
        If DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnVisibility" Then
            UpdateBackground = True
        End If
    End Sub

    Private Sub ÜberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÜberToolStripMenuItem.Click
        Dim About_Box As New About_RouteVisualizer
        About_Box.ShowDialog()
    End Sub

    Private Sub CMB_Zoom_SelectedIndexChanged(sender As Object, e As EventArgs)
        UpdateBackground = True
    End Sub

    Private Sub DGV_Route_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_Route.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub DGV_Route_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_Route.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each F As String In MyFiles
                If Path.GetExtension(F) = ".kml" OrElse Path.GetExtension(F) = ".gpx" Then
                    Dim RR As RoutefileRow = Data.Routefile.NewRoutefileRow()
                    RR.Path = F.Replace(Application.StartupPath() & Path.DirectorySeparatorChar, "")
                    Data.Routefile.AddRoutefileRow(RR)
                End If
            Next
            DGV_Route.EndEdit()
            For i As Integer = Data.Routefile.Count - 1 To 0 Step -1
                If Data.Routefile.Item(i).IsPathNull OrElse Data.Routefile.Item(i).Path = "" Then
                    Data.Routefile.Item(i).Delete()
                End If
            Next
        End If
        UpdateBackground = True
    End Sub

    Private Sub TC_Main_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TC_Main.SelectedIndexChanged
        ZoomWizardEnabling()
    End Sub

    Private Sub ZoomWizardEnabling()
        If TC_Main.SelectedTab Is Nothing Then
            Exit Sub
        End If
        If Not LayerBindingSource.Current Is Nothing Then
            Dim DRV As DataRowView = CType(LayerBindingSource.Current, DataRowView)
        End If
        If TC_Main.SelectedTab.Name = "TP_LocalLayers" AndAlso Not LayerBindingSource.Current Is Nothing AndAlso Not CType(LayerBindingSource.Current, DataRowView).IsNew Then
            TilesWizardToolStripMenuItem.Enabled = True
        Else
            TilesWizardToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub TilesWizardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TilesWizardToolStripMenuItem.Click
        If MessageBox.Show(My.Resources.Main_ZoomWizardIntro) = DialogResult.OK Then
            If OFD_LayerWizard.ShowDialog() = DialogResult.OK Then
                Dim ZR As ZoomRow = Data.Zoom.NewZoomRow()
                ZR.Path = OFD_LayerWizard.FileName.Replace(Application.StartupPath() & Path.DirectorySeparatorChar, "")
                Using bmp As New Bitmap(OFD_LayerWizard.FileName)
                    ZR.Tileheight = bmp.Height
                    ZR.Tilewidth = bmp.Width
                End Using
                Dim Zoom As Integer
                While Not Integer.TryParse(Microsoft.VisualBasic.InputBox(My.Resources.Main_EnterZoomValue), Zoom) OrElse Not Zoom >= 0
                    MessageBox.Show(My.Resources.Main_ZoomInteger)
                End While
                ZR.Zoomvalue = Zoom
                Dim CurLayerDRV As DataRowView = CType(LayerBindingSource.Current, DataRowView)
                Dim CurLayer As LayerRow = CType(CurLayerDRV.Row, LayerRow)
                ZR.LayerID = CurLayer.ID
                Data.Zoom.AddZoomRow(ZR)

                MessageBox.Show(My.Resources.Main_RowAddedReplace)
            End If
        End If
    End Sub

    Private Sub Btn_Switch_Click(sender As Object, e As EventArgs) Handles Btn_Switch.Click
        If Btn_Switch.Tag.ToString = "AdditionalTiles" Then 'Change to relative column and row index
            L_North.Text = My.Resources.Main_L_MinRow
            L_West.Text = My.Resources.Main_L_MinCol
            L_East.Text = My.Resources.Main_L_MaxCol
            L_South.Text = My.Resources.Main_L_MaxRow

            Btn_ResetAdditionalTiles.Visible = False
            GB_AdditionalTiles.Text = My.Resources.Main_GB_RelativeIndices
            Btn_Switch.Tag = "AbsoluteNumbers"
        Else 'change to additional tiles
            L_North.Text = My.Resources.Main_L_North
            L_West.Text = My.Resources.Main_L_West
            L_South.Text = My.Resources.Main_L_South
            L_East.Text = My.Resources.Main_L_East

            Btn_ResetAdditionalTiles.Visible = True
            GB_AdditionalTiles.Text = My.Resources.Main_GB_AdditionalTiles
            Btn_Switch.Tag = "AdditionalTiles"
        End If

        'Restore old values
        Dim Temp_North As Decimal = NUD_AdditionalTilesNorth.Value
        Dim Temp_South As Decimal = NUD_AdditionalTilesSouth.Value
        Dim Temp_East As Decimal = NUD_AdditionalTilesEast.Value
        Dim Temp_West As Decimal = NUD_AdditionalTilesWest.Value
        NUD_AdditionalTilesNorth.Value = CDec(NUD_AdditionalTilesNorth.Tag)
        NUD_AdditionalTilesSouth.Value = CDec(NUD_AdditionalTilesSouth.Tag)
        NUD_AdditionalTilesEast.Value = CDec(NUD_AdditionalTilesEast.Tag)
        NUD_AdditionalTilesWest.Value = CDec(NUD_AdditionalTilesWest.Tag)
        NUD_AdditionalTilesNorth.Tag = Temp_North
        NUD_AdditionalTilesSouth.Tag = Temp_South
        NUD_AdditionalTilesEast.Tag = Temp_East
        NUD_AdditionalTilesWest.Tag = Temp_West
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For i As Integer = 0 To RoutefileBindingSource.Count - 1
            Dim DV As DataRowView = CType(RoutefileBindingSource.Item(i), DataRowView)
            Dim DR As RoutefileRow = CType(DV.Row, RoutefileRow)
            DR.Visibility = True
        Next
    End Sub

    Private Sub DeselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeselectAllToolStripMenuItem.Click
        For i As Integer = 0 To RoutefileBindingSource.Count - 1
            Dim DV As DataRowView = CType(RoutefileBindingSource.Item(i), DataRowView)
            Dim DR As RoutefileRow = CType(DV.Row, RoutefileRow)
            DR.Visibility = False
        Next
    End Sub

    Private Sub InvertSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InvertSelectionToolStripMenuItem.Click
        For i As Integer = 0 To RoutefileBindingSource.Count - 1
            Dim DV As DataRowView = CType(RoutefileBindingSource.Item(i), DataRowView)
            Dim DR As RoutefileRow = CType(DV.Row, RoutefileRow)
            DR.Visibility = Not DR.Visibility
        Next
    End Sub

    Private Sub OpenPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenPathToolStripMenuItem.Click
        Dim drv As DataRowView = CType(RoutefileBindingSource.Current, DataRowView)
        Dim DR As RoutefileRow = CType(drv.Row, RoutefileRow)
        Process.Start("explorer.exe", "/select,""" & DR.Path & """")
    End Sub

    Private Sub LayerDataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles LayerDataGridView.RowsAdded
        ZoomWizardEnabling()
    End Sub

    Private Sub LayerDataGridView_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles LayerDataGridView.RowsRemoved
        ZoomWizardEnabling()
    End Sub

    Private Sub LayerDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles LayerDataGridView.SelectionChanged
        ZoomWizardEnabling()
    End Sub

    Private Sub DuplicateRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateRowToolStripMenuItem.Click
        Dim DRV As DataRowView = CType(ZoomBindingSource1.Current, DataRowView)
        If DRV.IsNew Then
            Media.SystemSounds.Asterisk.Play()
            Exit Sub
        End If
        Dim ZR As ZoomRow = CType(DRV.Row, ZoomRow)
        Dim ZR_New As ZoomRow = Data.Zoom.NewZoomRow()
        ZR_New.Path = ZR.Path
        ZR_New.Tileheight = ZR.Tileheight
        ZR_New.Tilewidth = ZR.Tilewidth
        ZR_New.LayerID = ZR.LayerID
        ZR_New.Zoomvalue = ZR.Zoomvalue
        Data.Zoom.AddZoomRow(ZR_New)
        ZoomBindingSource1.EndEdit()
    End Sub

    Sub Animation()
        Dim Starttime As DateTime = DateTime.Now
        Dim TilePen As New Pen(New SolidBrush(Color.Blue), 5)
        Dim CurrentZoomRow As ZoomRow
        Dim Cancel As Boolean = False
        Dim Log As New StringBuilder
        Dim TryCached As Boolean = False

        If SaveOption.SaveType <> SaveType.Preview Then
            UpdateBackground = True
        End If

        Me.Invoke(Sub()
                      GUIEnabling(False)
                  End Sub)

        Dim Zoom As Integer
        Me.Invoke(Sub()
                      Zoom = TB_Zoom.Value
                  End Sub)

        If Cancel Then
            Me.Invoke(Sub()
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If

        Me.Invoke(Sub()
                      TSPB_Progress.Value = 0
                      TSPB_Progress.Maximum = CLB_Layers.CheckedIndices.Count + Data.Routefile.Select("Visibility = " & True & " And RouteLineWidth > 0").Length + 1
                      TSPB_Progress.Visible = True
                      TSSL_Progress.Visible = True
                      TSSL_EscToAbort.Visible = True
                  End Sub)

        If CancelThread Then
            Me.Invoke(Sub()
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If

        Dim Result As Image = Nothing
        Dim MyCoordinates As New List(Of Coordinate)
        Dim RRs() As RoutefileRow = CType(Data.Routefile.Select("Visibility = " & True & " And RouteLineWidth > 0"), RoutefileRow())
        If RRs.Length = 0 Then
            Me.Invoke(Sub()
                          MessageBox.Show(Me, My.Resources.Main_NoRoutesToPlot, My.Resources.Main_NoRoutesToPlot_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If
        Dim ReadCoordinates(RRs.Length - 1) As List(Of Coordinate)
        Dim cnt As Integer = -1
        For Each RR As RoutefileRow In RRs
            If CancelThread Then
                Me.Invoke(Sub()
                              GUIEnabling(True)
                          End Sub)
                Exit Sub
            End If
            cnt += 1
            Dim Res As New List(Of Coordinate)
            Try
                Res = ImportCoordinatesFromFile(RR)
            Catch ArgNullEx As ArgumentNullException
                Log.AppendLine(String.Format(My.Resources.Main_PathNull, RR.ID))
            Catch FNFEx As FileNotFoundException
                Log.AppendLine(String.Format(My.Resources.Main_FileNotFound, RR.Path))
            Catch ex As Exception
                If Not ex.Message Is Nothing AndAlso Not ex.InnerException Is Nothing AndAlso Not ex.InnerException.StackTrace Is Nothing Then
                    Log.AppendLine(String.Format(My.Resources.Main_ErrorWhileImporting, RR.Path) & Environment.NewLine & ex.Message & Environment.NewLine & ex.InnerException.ToString & Environment.NewLine & ex.InnerException.StackTrace)
                ElseIf Not ex.Message Is Nothing Then
                    Log.AppendLine(String.Format(My.Resources.Main_ErrorWhileImporting, RR.Path) & Environment.NewLine & ex.Message)
                Else
                    Log.AppendLine(String.Format(My.Resources.Main_ErrorWhileImporting, RR.Path))
                End If
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

        Dim OnlineLayersCheckedCount As Integer
        Me.Invoke(Sub()
                      OnlineLayersCheckedCount = CLB_OnlineLayers.CheckedItems.Count
                  End Sub)
        Dim OnlineZoomRow As ZoomRow = Data.Zoom.NewZoomRow
        If OnlineLayersCheckedCount > 0 Then
            OnlineZoomRow = Data.Zoom.NewZoomRow
            OnlineZoomRow.Tileheight = 256
            OnlineZoomRow.Tilewidth = 256
            OnlineZoomRow.Zoomvalue = Zoom
            Dim MaxAllowedZoom As Integer = MaxZoom(MyCoordinates, OnlineZoomRow)
            If Zoom > MaxAllowedZoom Then
                Me.Invoke(Sub()
                              If MessageBox.Show(Me, String.Format(My.Resources.Main_ZoomTooLarge, MaxAllowedZoom), My.Resources.Main_ZoomTooLarge_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.Yes Then
                                  TryCached = True
                              Else
                                  GUIEnabling(True)
                                  Cancel = True
                              End If
                          End Sub)
            End If
        End If

        If Cancel Then
            Me.Invoke(Sub()
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If

        Me.Invoke(Sub()
                      TSPB_Progress.Value += 1
                  End Sub)

        Dim DesiredSize As Size
        Dim OrigSize As Size
        Dim Tiles() As Point 'array for minimum and maximum tiles
        For k As Integer = 0 To CLB_OnlineLayers.Items.Count - 1
            If CancelThread Then
                Me.Invoke(Sub()
                              GUIEnabling(True)
                          End Sub)
                Exit Sub
            End If
            If Not CLB_OnlineLayers.GetItemChecked(k) Then
                Continue For
            End If

            If Btn_Switch.Tag.ToString = "AdditionalTiles" Then
                Tiles = CalcMinMaxTiles(MyCoordinates, OnlineZoomRow)
            Else
                Tiles = {New Point(CInt(NUD_AdditionalTilesWest.Value), CInt(NUD_AdditionalTilesNorth.Value)), New Point(CInt(NUD_AdditionalTilesEast.Value), CInt(NUD_AdditionalTilesSouth.Value))}
            End If

            OrigSize = New Size((Tiles(1).X - Tiles(0).X + 1) * OnlineZoomRow.Tilewidth, (Tiles(1).Y - Tiles(0).Y + 1) * OnlineZoomRow.Tileheight)
            If SaveOption.SaveType = SaveType.Preview Then
                DesiredSize = OrigSize
            ElseIf SaveOption.Height = 0 AndAlso SaveOption.Width = 0 Then
                DesiredSize = OrigSize
            ElseIf SaveOption.Height = 0 AndAlso SaveOption.Width > 0 Then
                DesiredSize = New Size(SaveOption.Width, CInt(OrigSize.Height / OrigSize.Width * SaveOption.Width))
            ElseIf SaveOption.Height > 0 AndAlso SaveOption.Width = 0 Then
                DesiredSize = New Size(CInt(OrigSize.Width / OrigSize.Height * SaveOption.Height), SaveOption.Height)
            End If

            If Result Is Nothing OrElse SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                Result = New Bitmap(DesiredSize.Width, DesiredSize.Height)
            End If
            Using g As Graphics = Graphics.FromImage(Result)
                Using Img As Image = CreateWebTileLayer(CType(CType(CLB_OnlineLayers.Items(k), DataRowView).Row, WebTileProviderRow), OnlineZoomRow, Tiles, Log, TryCached)
                    g.DrawImage(Img, 0, 0, DesiredSize.Width, DesiredSize.Height)
                End Using
            End Using
            If SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                If SaveOption.OutputFormat.ToLower = ".png" Then
                    Result.Save(Path.Combine(SaveOption.DirectoryPath, "OnlineLayer" & k & ".png"), Imaging.ImageFormat.Png)
                ElseIf SaveOption.OutputFormat.ToLower = ".tif" Then
                    Result.Save(Path.Combine(SaveOption.DirectoryPath, "OnlineLayer" & k & ".tif"), Imaging.ImageFormat.Tiff)
                End If
            End If
        Next
        CurrentZoomRow = OnlineZoomRow

        For k As Integer = 0 To CLB_Layers.Items.Count - 1
            If CancelThread Then
                Me.Invoke(Sub()
                              GUIEnabling(True)
                          End Sub)
                Exit Sub
            End If
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

            If Btn_Switch.Tag.ToString = "AdditionalTiles" Then
                Tiles = CalcMinMaxTiles(MyCoordinates, CurrentZoomRow)
            Else
                Tiles = {New Point(CInt(NUD_AdditionalTilesWest.Value), CInt(NUD_AdditionalTilesNorth.Value)), New Point(CInt(NUD_AdditionalTilesEast.Value), CInt(NUD_AdditionalTilesSouth.Value))}
            End If

            OrigSize = New Size((Tiles(1).X - Tiles(0).X + 1) * CurrentZoomRow.Tilewidth, (Tiles(1).Y - Tiles(0).Y + 1) * CurrentZoomRow.Tileheight)
            If SaveOption.SaveType = SaveType.Preview Then
                DesiredSize = OrigSize
            ElseIf SaveOption.Height = 0 AndAlso SaveOption.Width = 0 Then
                DesiredSize = OrigSize
            ElseIf SaveOption.Height = 0 AndAlso SaveOption.Width > 0 Then
                DesiredSize = New Size(SaveOption.Width, CInt(OrigSize.Height / OrigSize.Width * SaveOption.Width))
            ElseIf SaveOption.Height > 0 AndAlso SaveOption.Width = 0 Then
                DesiredSize = New Size(CInt(OrigSize.Width / OrigSize.Height * SaveOption.Height), SaveOption.Height)
            End If

            If Not UpdateBackground AndAlso File.Exists(Path.Combine(Application.StartupPath, "TempBackground.png")) Then
                Using TempResult As Image = Image.FromFile(Path.Combine(Application.StartupPath, "TempBackground.png"))
                    Result = ResizeImage(Image.FromFile(Path.Combine(Application.StartupPath, "TempBackground.png")), DesiredSize)
                End Using
                Exit For
            End If

            If Result Is Nothing OrElse SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                Result = New Bitmap(DesiredSize.Width, DesiredSize.Height)
            End If

            Using g As Graphics = Graphics.FromImage(Result)
                Using Img As Image = CreateLayerImage(CurrentZoomRow, Tiles, Log)
                    g.DrawImage(Img, 0, 0, DesiredSize.Width, DesiredSize.Height)
                End Using
            End Using
            If SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
                If SaveOption.OutputFormat.ToLower = ".png" Then
                    Result.Save(Path.Combine(SaveOption.DirectoryPath, "LocalLayer" & k & ".png"), Imaging.ImageFormat.Png)
                ElseIf SaveOption.OutputFormat.ToLower = ".tif" Then
                    Result.Save(Path.Combine(SaveOption.DirectoryPath, "LocalLayer" & k & ".tif"), Imaging.ImageFormat.Tiff)
                End If
            End If
            Me.Invoke(Sub()
                          TSPB_Progress.Value += 1
                      End Sub)
        Next

        If UpdateBackground AndAlso SaveOption.SaveType <> SaveType.LayersSeparately_MergeRoutes AndAlso SaveOption.SaveType <> SaveType.LayersSeparately_RoutesSeparately Then
            Try
                Result.Save(Path.Combine(Application.StartupPath, "TempBackground.png"))
                UpdateBackground = False
            Catch ex As Exception
                UpdateBackground = True
            End Try
        End If

        If Result Is Nothing OrElse SaveOption.SaveType = SaveType.LayersSeparately_MergeRoutes OrElse SaveOption.SaveType = SaveType.LayersSeparately_RoutesSeparately Then
            Result = New Bitmap(DesiredSize.Width, DesiredSize.Height)
        End If
        cnt = 0


        '--------------------------------------------------

        Dim FinalPoints(RRs.Length - 1) As List(Of Point)
        Dim CoordCounter As Integer = 0
        For j As Integer = 0 To FinalPoints.Length - 1
            For i As Integer = 1 To ReadCoordinates(j).Count - 1
                If CancelThread Then
                    Me.Invoke(Sub()
                                  GUIEnabling(True)
                              End Sub)
                    Exit Sub
                End If
                Dim LP As New List(Of Point)
                Dim P1 As Point = New Point(ReadCoordinates(j).Item(i - 1).PixelCoordinate(CurrentZoomRow).X - Tiles(0).X * CurrentZoomRow.Tilewidth, ReadCoordinates(j).Item(i - 1).PixelCoordinate(CurrentZoomRow).Y - Tiles(0).Y * CurrentZoomRow.Tileheight)
                Dim P2 As Point = New Point(ReadCoordinates(j).Item(i).PixelCoordinate(CurrentZoomRow).X - Tiles(0).X * CurrentZoomRow.Tilewidth, ReadCoordinates(j).Item(i).PixelCoordinate(CurrentZoomRow).Y - Tiles(0).Y * CurrentZoomRow.Tileheight)
                LP.Add(P1)

                Dim Length As Double = (P1.X - P2.X) ^ 2 + (P1.Y - P2.Y) ^ 2
                Dim Steps As Integer = CInt(Math.Ceiling(Length) / 20)
                Dim DeltaX As Double = (P2.X - P1.X) / Steps
                Dim DeltaY As Double = (P2.Y - P1.Y) / Steps

                For k As Integer = 1 To Steps
                    Dim NewPoint As Point = New Point(CInt(LP.Item(0).X + k * DeltaX), CInt(LP.Item(0).Y + k * DeltaY))
                    If LP(LP.Count - 1) <> NewPoint Then
                        LP.Add(NewPoint)
                    End If
                Next

                CoordCounter += LP.Count

                If FinalPoints(j) Is Nothing Then
                    FinalPoints(j) = LP
                Else
                    FinalPoints(j).AddRange(LP)
                End If
            Next

            For i As Integer = FinalPoints(j).Count - 2 To 0 Step -1
                If CancelThread Then
                    Me.Invoke(Sub()
                                  GUIEnabling(True)
                              End Sub)
                    Exit Sub
                End If
                If FinalPoints(j).Item(i) = FinalPoints(j).Item(i + 1) Then
                    FinalPoints(j).RemoveAt(i + 1)
                    CoordCounter -= 1
                End If
            Next
        Next

        If CoordCounter = 0 Then
            Log.AppendLine(My.Resources.Main_NoCoordinates)
            WriteLog(Starttime, Log)
            Me.Invoke(Sub()
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If

        Me.Invoke(Sub()
                      TSPB_Progress.Maximum = CLB_Layers.CheckedIndices.Count + Data.Routefile.Select("Visibility = " & True & " AND RouteLineWidth > 0").Length + 1 + CInt(Math.Ceiling(CoordCounter / SaveOption.StepSize))
                      If SaveOption.SaveType = SaveType.Animation_GIF Then
                          TSPB_Progress.Maximum += CInt(Math.Ceiling(CoordCounter / SaveOption.StepSize)) + 6
                      End If
                  End Sub)

        '------------------------------------------------------

        Dim newBMP As Bitmap
        Dim StepSize As Integer = SaveOption.StepSize
        Dim RoutePen1 As New Pen(New SolidBrush(Color.Blue), 10)
        RoutePen1.EndCap = Drawing2D.LineCap.Round
        RoutePen1.StartCap = Drawing2D.LineCap.Round
        RoutePen1.LineJoin = Drawing2D.LineJoin.Round
        Dim Brush2 As New SolidBrush(SaveOption.SymbolColor)
        Dim ImgFormat As Imaging.ImageFormat
        Select Case SaveOption.OutputFormat.ToString.ToLower()
            Case ".bmp"
                ImgFormat = Imaging.ImageFormat.Bmp
            Case ".jpg"
                ImgFormat = Imaging.ImageFormat.Jpeg
            Case ".png"
                ImgFormat = Imaging.ImageFormat.Png
            Case ".gif"
                ImgFormat = Imaging.ImageFormat.Gif
            Case ".tif"
                ImgFormat = Imaging.ImageFormat.Tiff
            Case Else
                ImgFormat = Imaging.ImageFormat.Png
        End Select

        If Not SaveOption.BackgroundAlways Then
            Using newBMP_Res As Bitmap = New Bitmap(DesiredSize.Width, DesiredSize.Height)
                Using g_Res As Graphics = Graphics.FromImage(newBMP_Res)
                    g_Res.DrawImage(Result, 0, 0, newBMP_Res.Width + 1, newBMP_Res.Height + 1)
                End Using
                newBMP_Res.Save(Path.Combine(SaveOption.DirectoryPath, "_Background" & ".png"), Imaging.ImageFormat.Png)
            End Using
        End If

        Dim SavedImagesFileNames As New List(Of String)
        Dim cnt2 As Integer = 0
        If SaveOption.AnimSaveType = AnimationSaveType.InRow_Hold OrElse SaveOption.AnimSaveType = AnimationSaveType.InRow_NoHold Then
            Dim RoutePen2 As New Pen(New SolidBrush(Color.Blue), 10)
            RoutePen2.EndCap = Drawing2D.LineCap.Round
            RoutePen2.StartCap = Drawing2D.LineCap.Round
            RoutePen2.LineJoin = Drawing2D.LineJoin.Round
            For j As Integer = 0 To FinalPoints.Length - 1
                If CancelThread Then
                    For Each F As String In SavedImagesFileNames
                        If File.Exists(F) Then
                            File.Delete(F)
                        End If
                    Next
                    Me.Invoke(Sub()
                                  GUIEnabling(True)
                              End Sub)
                    Exit Sub
                End If
                RoutePen1.Color = Color.FromArgb(RRs(j).RouteAlpha, CInt(RRs(j).RouteColor.Split(CType(",", Char()), StringSplitOptions.RemoveEmptyEntries)(0)), CInt(RRs(j).RouteColor.Split(CType(",", Char()), StringSplitOptions.RemoveEmptyEntries)(1)), CInt(RRs(j).RouteColor.Split(CType(",", Char()), StringSplitOptions.RemoveEmptyEntries)(2)))
                RoutePen1.Width = RRs(j).RouteLineWidth
                Dim PointsToDraw As New List(Of Point)
                For i As Integer = 0 To FinalPoints(j).Count - 1
                    If PointsToDraw.Count = 0 Then
                        PointsToDraw.Add(FinalPoints(j).Item(i))
                    ElseIf FinalPoints(j).Item(i) = PointsToDraw(PointsToDraw.Count - 1) Then
                        Continue For
                    Else
                        PointsToDraw.Add(FinalPoints(j).Item(i))
                    End If
                    If i Mod StepSize <> 0 Then
                        Continue For
                    End If
                    newBMP = New Bitmap(OrigSize.Width, OrigSize.Height)
                    Using g As Graphics = System.Drawing.Graphics.FromImage(newBMP)
                        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        If SaveOption.BackgroundAlways Then
                            g.DrawImage(Result, 0, 0, newBMP.Width, newBMP.Height)
                        Else
                            g.Clear(Color.Transparent)
                        End If
                        If SaveOption.AnimSaveType = AnimationSaveType.InRow_Hold Then
                            For k As Integer = 0 To j - 1
                                If CancelThread Then
                                    For Each F As String In SavedImagesFileNames
                                        If File.Exists(F) Then
                                            File.Delete(F)
                                        End If
                                    Next
                                    Me.Invoke(Sub()
                                                  GUIEnabling(True)
                                              End Sub)
                                    Exit Sub
                                End If
                                RoutePen2.Color = Color.FromArgb(RRs(k).RouteAlpha, CInt(RRs(k).RouteColor.Split(CType(",", Char()), StringSplitOptions.RemoveEmptyEntries)(0)), CInt(RRs(k).RouteColor.Split(CType(",", Char()), StringSplitOptions.RemoveEmptyEntries)(1)), CInt(RRs(k).RouteColor.Split(CType(",", Char()), StringSplitOptions.RemoveEmptyEntries)(2)))
                                RoutePen2.Width = RRs(k).RouteLineWidth
                                g.DrawLines(RoutePen2, FinalPoints(k).ToArray())
                            Next
                        End If
                        If PointsToDraw.Count > 1 Then
                            g.DrawLines(RoutePen1, PointsToDraw.ToArray())
                        End If

                        If SaveOption.SymbolWidth > 0 Then
                            g.FillEllipse(Brush2, CInt(PointsToDraw.Item(PointsToDraw.Count - 1).X - SaveOption.SymbolWidth / 2), CInt(PointsToDraw.Item(PointsToDraw.Count - 1).Y - SaveOption.SymbolWidth / 2), SaveOption.SymbolWidth, SaveOption.SymbolWidth)
                        End If
                    End Using

                    Using newBMP_Res As Bitmap = New Bitmap(DesiredSize.Width, DesiredSize.Height)
                        Using g_Res As Graphics = Graphics.FromImage(newBMP_Res)
                            g_Res.DrawImage(newBMP, 0, 0, newBMP_Res.Width + 1, newBMP_Res.Height + 1)
                        End Using
                        If SaveOption.SaveType = SaveType.Animation_GIF Then
                            newBMP_Res.Save(Path.Combine(SaveOption.DirectoryPath, cnt2.ToString("D6") & ".png"), Imaging.ImageFormat.Png)
                            SavedImagesFileNames.Add(Path.Combine(SaveOption.DirectoryPath, cnt2.ToString("D6") & ".png"))
                        Else
                            newBMP_Res.Save(Path.Combine(SaveOption.DirectoryPath, cnt2.ToString("D6") & SaveOption.OutputFormat), ImgFormat)
                            SavedImagesFileNames.Add(Path.Combine(SaveOption.DirectoryPath, cnt2.ToString("D6") & SaveOption.OutputFormat))
                        End If
                    End Using
                    newBMP.Dispose()
                    Me.Invoke(Sub()
                                  TSPB_Progress.Value += 1
                              End Sub)
                    cnt2 += 1
                Next
            Next
        ElseIf SaveOption.AnimSaveType = AnimationSaveType.Together Then
            Dim PointsToDraw(FinalPoints.Length - 1) As List(Of Point)
            Dim MaxCount As Integer = 0
            For k As Integer = 0 To FinalPoints.Length - 1
                MaxCount = Math.Max(MaxCount, FinalPoints(k).Count)
            Next
            For i As Integer = 1 To MaxCount - 1
                If CancelThread Then
                    For Each F As String In SavedImagesFileNames
                        If File.Exists(F) Then
                            File.Delete(F)
                        End If
                    Next
                    Me.Invoke(Sub()
                                  GUIEnabling(True)
                              End Sub)
                    Exit Sub
                End If
                If i <> 1 AndAlso i Mod StepSize <> 0 Then
                    Continue For
                End If
                For k As Integer = 0 To FinalPoints.Length - 1
                    PointsToDraw(k) = New List(Of Point)
                    For j As Integer = 0 To Math.Min(FinalPoints(k).Count, i) - 1
                        If CancelThread Then
                            For Each F As String In SavedImagesFileNames
                                If File.Exists(F) Then
                                    File.Delete(F)
                                End If
                            Next
                            Me.Invoke(Sub()
                                          GUIEnabling(True)
                                      End Sub)
                            Exit Sub
                        End If
                        PointsToDraw(k).Add(FinalPoints(k).Item(j))
                    Next
                Next

                Using newBMP2 As New Bitmap(OrigSize.Width, OrigSize.Height)
                    Using g As Graphics = Graphics.FromImage(newBMP2)
                        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        If SaveOption.BackgroundAlways Then
                            g.DrawImage(Result, 0, 0, newBMP2.Width, newBMP2.Height)
                        Else
                            g.Clear(Color.Transparent)
                        End If
                        For k As Integer = 0 To PointsToDraw.Length - 1
                            If CancelThread Then
                                For Each F As String In SavedImagesFileNames
                                    If File.Exists(F) Then
                                        File.Delete(F)
                                    End If
                                Next
                                Me.Invoke(Sub()
                                              GUIEnabling(True)
                                          End Sub)
                                Exit Sub
                            End If
                            RoutePen1.Color = Color.FromArgb(RRs(k).RouteAlpha, CInt(RRs(k).RouteColor.Split(CType(",", Char()), StringSplitOptions.RemoveEmptyEntries)(0)), CInt(RRs(k).RouteColor.Split(CType(",", Char()), StringSplitOptions.RemoveEmptyEntries)(1)), CInt(RRs(k).RouteColor.Split(CType(",", Char()), StringSplitOptions.RemoveEmptyEntries)(2)))
                            RoutePen1.Width = RRs(k).RouteLineWidth
                            If PointsToDraw(k).Count > 1 Then
                                g.DrawLines(RoutePen1, PointsToDraw(k).ToArray())
                            End If

                            If SaveOption.SymbolWidth > 0 Then
                                g.FillEllipse(Brush2, CInt(PointsToDraw(k).Item(PointsToDraw(k).Count - 1).X - SaveOption.SymbolWidth / 2), CInt(PointsToDraw(k).Item(PointsToDraw(k).Count - 1).Y - SaveOption.SymbolWidth / 2), SaveOption.SymbolWidth, SaveOption.SymbolWidth)
                            End If
                        Next
                    End Using
                    Using newBMP_Res As Bitmap = New Bitmap(DesiredSize.Width, DesiredSize.Height)
                        Using g_Res As Graphics = Graphics.FromImage(newBMP_Res)
                            g_Res.DrawImage(newBMP2, 0, 0, newBMP_Res.Width + 1, newBMP_Res.Height + 1)
                        End Using
                        If SaveOption.SaveType = SaveType.Animation_GIF Then
                            newBMP_Res.Save(Path.Combine(SaveOption.DirectoryPath, cnt2.ToString("D6") & ".png"), Imaging.ImageFormat.Png)
                            SavedImagesFileNames.Add(Path.Combine(SaveOption.DirectoryPath, cnt2.ToString("D6") & ".png"))
                        Else
                            newBMP_Res.Save(Path.Combine(SaveOption.DirectoryPath, cnt2.ToString("D6") & SaveOption.OutputFormat), ImgFormat)
                            SavedImagesFileNames.Add(Path.Combine(SaveOption.DirectoryPath, cnt2.ToString("D6") & SaveOption.OutputFormat))
                        End If
                    End Using
                End Using
                Me.Invoke(Sub()
                              TSPB_Progress.Value += 1
                          End Sub)
                cnt2 += 1
            Next
        End If

        'GIF
        If SaveOption.SaveType = SaveType.Animation_GIF Then
            If File.Exists(SaveOption.FilePath) Then
                File.Delete(SaveOption.FilePath)
            End If

            Using background As New MagickImage(Path.Combine(SaveOption.DirectoryPath, "_Background.png"))
                Using collection As New MagickImageCollection
                    For Each F As String In SavedImagesFileNames
                        If CancelThread Then
                            For Each F2 As String In SavedImagesFileNames
                                If File.Exists(F2) Then
                                    File.Delete(F2)
                                End If
                            Next
                            Me.Invoke(Sub()
                                          GUIEnabling(True)
                                      End Sub)
                            Exit Sub
                        End If
                        If F.Contains("_") Then
                            Continue For
                        End If
                        collection.Add(F)
                        collection(collection.Count - 1).AnimationDelay = CInt(SaveOption.DelayTime / 10)
                        collection(collection.Count - 1).AnimationIterations = SaveOption.LoopCount
                        collection(collection.Count - 1).GifDisposeMethod = GifDisposeMethod.Previous
                        collection(collection.Count - 1).Composite(background, Gravity.Center, CompositeOperator.DstOver)

                        Me.Invoke(Sub()
                                      TSPB_Progress.Value += 1
                                  End Sub)
                    Next
                    collection.OptimizeTransparency()
                    collection.Optimize()

                    If File.Exists(SaveOption.FilePath) Then
                        File.Delete(SaveOption.FilePath)
                    End If
                    collection.Write(SaveOption.FilePath)
                End Using
            End Using

            Me.Invoke(Sub()
                          TSPB_Progress.Value += 1
                      End Sub)

            File.Delete(Path.Combine(SaveOption.DirectoryPath, "_Background.png"))
            Me.Invoke(Sub()
                          TSPB_Progress.Value += 1
                      End Sub)

            For Each F As String In SavedImagesFileNames
                File.Delete(F)
            Next
            Me.Invoke(Sub()
                          TSPB_Progress.Value += 1
                      End Sub)
        End If

        If CancelThread Then
            For Each F As String In SavedImagesFileNames
                If File.Exists(F) Then
                    File.Delete(F)
                End If
            Next
            Me.Invoke(Sub()
                          GUIEnabling(True)
                      End Sub)
            Exit Sub
        End If

        Me.Invoke(Sub()
                      GUIEnabling(True)
                  End Sub)

        If SaveOption.SaveType = SaveType.Animation_SingleFiles Then
            Me.Invoke(Sub()
                          If MessageBox.Show(Me, My.Resources.Main_OpenResultDirectory, My.Resources.Main_OpenResultDirectory_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                              Process.Start(SaveOption.DirectoryPath)
                          End If
                      End Sub)
        ElseIf SaveOption.SaveType = SaveType.Animation_GIF Then
            Me.Invoke(Sub()
                          If MessageBox.Show(Me, My.Resources.Main_OpenResultFile, My.Resources.Main_OpenResultFile_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                              Process.Start(SaveOption.FilePath)
                          End If
                      End Sub)
        End If
    End Sub

    Private Sub AnimationSaveDialogGetSettings(frm As frm_AnimationSaveDialog, SO As SaveOption)
        RVS.AnimationImageSizeWidth = frm.RB_Width.Checked
        RVS.AnimationImageSizeHeight = frm.RB_Height.Checked
        RVS.AnimationImageSize = CInt(frm.Nud_Size.Value)
        RVS.AnimationStepSize = CInt(frm.NUD_StepSize.Value)
        RVS.AnimationCurrentPositionColor = frm.L_SymbolColor.BackColor
        RVS.AnimationCurrentPositionWidth = CInt(frm.NUD_SymbolWidth.Value)
        RVS.AnimationOutputFormat = SO.OutputFormat
        If SO.SaveType = SaveType.Animation_GIF OrElse SO.SaveType = SaveType.SimpleImage Then
            RVS.SaveImagePath = frm.L_Path.Text
            RVS.AnimationOutputPath = Path.GetDirectoryName(frm.L_Path.Text)
        Else
            RVS.AnimationOutputPath = frm.L_Path.Text
        End If
        RVS.AnimationAlwaysBackground = frm.RB_AlwaysBackground.Checked
        RVS.AnimationBackgroundOnce = frm.RB_SingleBackground.Checked
        RVS.AnimationDelayTime = CInt(frm.NUD_DelayTime.Value)
        RVS.AnimationLoopCount = CInt(frm.NUD_LoopCount.Value)
        RVS.AniSaveType = SO.AnimSaveType
    End Sub

    Private Sub AnimationSaveDialogSetSettings(ASO As SaveOption)
        If RVS.AnimationImageSizeWidth Then
            ASO.Width = RVS.AnimationImageSize
            ASO.Height = 0
        Else
            ASO.Width = 0
            ASO.Height = RVS.AnimationImageSize
        End If
        ASO.StepSize = RVS.AnimationStepSize
        ASO.SymbolColor = RVS.AnimationCurrentPositionColor
        ASO.SymbolWidth = RVS.AnimationCurrentPositionWidth
        ASO.OutputFormat = RVS.AnimationOutputFormat
        ASO.DirectoryPath = RVS.AnimationOutputPath
        ASO.FilePath = RVS.SaveImagePath
        ASO.BackgroundAlways = RVS.AnimationAlwaysBackground
        ASO.DelayTime = RVS.AnimationDelayTime
        ASO.LoopCount = RVS.AnimationLoopCount
        ASO.AnimSaveType = RVS.AniSaveType
    End Sub

    Private Sub SingleFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SingleFilesToolStripMenuItem.Click
        If Not CheckImagePrerequisites() Then
            Exit Sub
        End If
        CancelThread = False
        SaveOption.SaveType = SaveType.Animation_SingleFiles
        AnimationSaveDialogSetSettings(SaveOption)
        Dim frm_Save As New frm_AnimationSaveDialog(SaveOption)
        If frm_Save.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        AnimationSaveDialogGetSettings(frm_Save, SaveOption)

        If TH_AnimationSingleFiles.IsAlive() Then
            Exit Sub
        End If
        If TH_AnimationSingleFiles.ThreadState = Threading.ThreadState.Stopped OrElse TH_AnimationSingleFiles.ThreadState = Threading.ThreadState.Aborted Then
            TH_AnimationSingleFiles = New Threading.Thread(AddressOf Animation)
        End If
        TH_AnimationSingleFiles.Start()
    End Sub

    Private Sub GIFToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GIFToolStripMenuItem1.Click
        If Not CheckImagePrerequisites() Then
            Exit Sub
        End If
        CancelThread = False
        SaveOption.SaveType = SaveType.Animation_GIF
        AnimationSaveDialogSetSettings(SaveOption)
        Dim frm_Save As New frm_AnimationSaveDialog(SaveOption)
        If frm_Save.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        AnimationSaveDialogGetSettings(frm_Save, SaveOption)

        If TH_AnimationSingleFiles.IsAlive() Then
            TH_AnimationSingleFiles.Abort()
        End If
        If TH_AnimationSingleFiles.ThreadState = Threading.ThreadState.Stopped OrElse TH_AnimationSingleFiles.ThreadState = Threading.ThreadState.Aborted Then
            TH_AnimationSingleFiles = New Threading.Thread(AddressOf Animation)
        End If
        TH_AnimationSingleFiles.Start()
    End Sub

    Function CreateWebTileLayer(ByVal WTP As WebTileProviderRow, ByVal ZR As ZoomRow, MinMaxTiles() As Point, LogSB As StringBuilder, OnlyCached As Boolean) As Image
        Dim Result As Image = New Bitmap((MinMaxTiles(1).X - MinMaxTiles(0).X + 1) * ZR.Tilewidth, (MinMaxTiles(1).Y - MinMaxTiles(0).Y + 1) * ZR.Tileheight)

        Using g As Graphics = Graphics.FromImage(Result)
            For i As Integer = MinMaxTiles(0).Y To MinMaxTiles(1).Y
                For j As Integer = MinMaxTiles(0).X To MinMaxTiles(1).X
                    If Not OnlyCached Then
                        Dim WTRows() As TileRow = CType(WebTiles.Tile.Select("ProviderID = " & WTP.ID & " AND x = " & j & " AND y = " & i & " AND z = " & ZR.Zoomvalue), TileRow())
                        Dim Downloaded As String = "Downloaded"
                        If WTRows.Length = 0 Then 'Tile not available
                            'Download tile
                            Downloaded = DownloadWebTileAndSave(j, i, ZR.Zoomvalue, WTP)
                            If Downloaded = "Downloaded" Then
                                'add tile to dataset
                                WebTiles.Tile.AddTileRow(j, i, ZR.Zoomvalue, Date.Now.AddMonths(1), WTP)
                            End If
                        ElseIf WTRows(0).Expires < Date.Now Then 'Tile expired
                            'Download tile
                            Downloaded = DownloadWebTileAndSave(j, i, ZR.Zoomvalue, WTP)

                            If Downloaded = "Downloaded" Then
                                'update table
                                WTRows(0).Expires = Date.Now.AddMonths(1)
                            Else
                                WTRows(0).Expires = Date.Now
                            End If
                        ElseIf Not File.Exists(CreateLocalPathForWebTile(WTP, j, i, ZR.Zoomvalue)) Then 'tile not saved anymore
                            'Download tile
                            Downloaded = DownloadWebTileAndSave(j, i, ZR.Zoomvalue, WTP)

                            If Downloaded = "Downloaded" Then
                                'update table
                                WTRows(0).Expires = Date.Now.AddMonths(1)
                            Else
                                WTRows(0).Expires = Date.Now
                            End If
                        End If

                        If Downloaded <> "Downloaded" Then
                            LogSB.AppendLine(String.Format(My.Resources.WebTile_DownloadError, WTP.Name, i, j, ZR.Zoomvalue, Downloaded))
                            Continue For
                        End If
                    End If

                    Dim CurrentPath As String = CreateLocalPathForWebTile(WTP, j, i, ZR.Zoomvalue)
                    If OnlyCached AndAlso Not File.Exists(CurrentPath) Then
                        LogSB.AppendLine(String.Format(My.Resources.WebTile_NotCached, WTP.Name, i, j, ZR.Zoomvalue))
                        Continue For
                    End If
                    Using img As Image = New Bitmap(CurrentPath)
                        g.DrawImage(img, (j - MinMaxTiles(0).X) * ZR.Tilewidth, (i - MinMaxTiles(0).Y) * ZR.Tileheight, ZR.Tilewidth, ZR.Tileheight)
                    End Using
                Next
            Next
            Dim LRs() As LicenseRow = CType(WTP.GetChildRows("WebTileProvider_License"), LicenseRow())
            Dim License_SB As New StringBuilder
            For Each LR As LicenseRow In LRs
                License_SB.Append(LR.Text & " ")
            Next
            Dim AttributionString As String = License_SB.ToString
            Dim font As New Font("Arial", 14)
            Dim StringSize As SizeF = g.MeasureString(AttributionString, font)
            While StringSize.Width > Result.Width
                font = New Font("Arial", font.Size - 1)
                StringSize = g.MeasureString(AttributionString, font)
            End While
            g.FillRectangle(New SolidBrush(Color.FromArgb(160, Color.White)), Result.Width - StringSize.Width, Result.Height - StringSize.Height, StringSize.Width, StringSize.Height)
            g.DrawString(AttributionString, font, New SolidBrush(Color.Black), Result.Width - StringSize.Width, Result.Height - StringSize.Height)
        End Using
        Return Result
    End Function

    Public Function CreateLocalPathForWebTile(WTP_CL As WebTileProviderRow, x As Integer, y As Integer, z As Integer) As String
        Return Path.Combine(Application.StartupPath, "Tiles", WTP_CL.Path, z.ToString, x.ToString, y.ToString & Path.GetExtension(WTP_CL.Link))
    End Function

    Function DownloadWebTileAndSave(x As Integer, y As Integer, z As Integer, WTP_DL As WebTileProviderRow) As String
        Dim Link As New Uri(RowColumnZoomReplace(WTP_DL.Link, y, x, z))
        Dim LocalPath As String = CreateLocalPathForWebTile(WTP_DL, x, y, z)

        If Not Directory.Exists(Path.GetDirectoryName(LocalPath)) Then
            Directory.CreateDirectory(Path.GetDirectoryName(LocalPath))
        End If

        Try
            Using Client As New WebClient
                Dim VersStr As String
                If My.Application.Info.Version.Major = 0 Then
                    VersStr = String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.Minor, My.Application.Info.Version.Build) & " beta"
                Else
                    VersStr = String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
                End If
                Client.Headers.Add(HttpRequestHeader.UserAgent, "Route Visualizer/" & VersStr & " (https://github.com/DAccord/Route-Visualizer)")
                Client.DownloadFile(Link, LocalPath)
            End Using
            Return "Downloaded"
        Catch ex As Exception
            MessageBox.Show(ex.GetType.ToString)
            Return ex.Message & " (" & Link.ToString & ")"
        End Try
    End Function

    Function MaxZoom(ByVal Coords As List(Of Coordinate), ByVal ZR As ZoomRow) As Integer
        Dim Z As Integer
        Dim Temp_ZR As ZoomRow = Data.Zoom.NewZoomRow()
        Temp_ZR.Tileheight = ZR.Tileheight
        Temp_ZR.Tilewidth = ZR.Tilewidth
        Temp_ZR.Zoomvalue = ZR.Zoomvalue

        For Z = 0 To 19
            Temp_ZR.Zoomvalue = Z
            Dim Tiles() As Point
            If Btn_Switch.Tag.ToString = "AdditionalTiles" Then
                Tiles = CalcMinMaxTiles(Coords, Temp_ZR)
            Else
                Tiles = {New Point(CInt(NUD_AdditionalTilesWest.Value), CInt(NUD_AdditionalTilesNorth.Value)), New Point(CInt(NUD_AdditionalTilesEast.Value), CInt(NUD_AdditionalTilesSouth.Value))}
            End If
            If (Math.Abs(Tiles(0).X - Tiles(1).X) + 1) * (Math.Abs(Tiles(0).Y - Tiles(1).Y) + 1) > 9 Then
                Exit For
            End If
        Next

        Return Z - 1
    End Function

    Private Sub WebTileProvider_LinkLabel_Click(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs)
        Dim LL As LinkLabel = CType(sender, LinkLabel)
        Process.Start(LL.Text)
    End Sub

    Private Sub CMB_WebTileProvider_Name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_WebTileProvider_Name.SelectedIndexChanged
        If WebTileProviderBindingSource.Current Is Nothing Then
            Exit Sub
        End If
        Dim DRV As DataRowView = CType(CMB_WebTileProvider_Name.SelectedItem, DataRowView)
        Dim WTPR As WebTileProviderRow = CType(DRV.Row, WebTileProviderRow)
        'Dim WTPR As WebTileProviderRow = CType((CType(WebTileProviderBindingSource.Current, DataRowView).Row), WebTileProviderRow)
        Dim LRs() As LicenseRow = CType(WebTiles.License.Select("ProviderID = " & WTPR.ID), LicenseRow())

        TLP_WebTileProvider_License.Controls.Clear()

        Dim cnt As Integer = 0
        For Each LR As LicenseRow In LRs
            If TLP_WebTileProvider_License.RowStyles.Count < cnt Then
                TLP_WebTileProvider_License.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            End If
            Dim LL As New LinkLabel
            LL.AutoSize = True
            LL.Text = LR.Link
            AddHandler LL.LinkClicked, AddressOf WebTileProvider_LinkLabel_Click
            TLP_WebTileProvider_License.Controls.Add(LL, 1, cnt)

            Dim L As New Label
            L.Text = LR.Text
            L.AutoSize = True
            TLP_WebTileProvider_License.Controls.Add(L, 0, cnt)

            cnt += 1
        Next
    End Sub

    Private Sub CLB_OnlineLayers_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CLB_OnlineLayers.ItemCheck
        If e.NewValue = CheckState.Checked Then
            For i As Integer = 0 To CLB_OnlineLayers.Items.Count - 1
                If i <> e.Index Then
                    CLB_OnlineLayers.SetItemChecked(i, False)
                End If
            Next i
        End If
        UpdateBackground = True
    End Sub

    Private Sub ImagePreviewToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles ImagePreviewToolStripMenuItem.CheckedChanged
        If Not ImagePreviewToolStripMenuItem.Checked Then 'Close preview window
            If Not PreviewForm Is Nothing AndAlso Not PreviewForm.IsDisposed Then
                PreviewForm.Close()
            End If
        Else 'open preview window
            UpdatePreviewPB(Nothing)
        End If
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click
        OFD_ImportRoute.Multiselect = True
        If OFD_ImportRoute.ShowDialog() = DialogResult.OK Then
            RVS.ImportRoutePath = OFD_ImportRoute.FileNames(0)
            For Each F As String In OFD_ImportRoute.FileNames
                Dim RR As RoutefileRow = Data.Routefile.NewRoutefileRow()
                RR.Path = F.Replace(Application.StartupPath() & Path.DirectorySeparatorChar, "")
                Data.Routefile.AddRoutefileRow(RR)
            Next
            UpdateBackground = True
        End If
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
        For k As Integer = DGV_Route.SelectedRows.Count - 1 To 0 Step -1
            Dim DGVR As DataGridViewRow = DGV_Route.SelectedRows(k)
            Dim DRV As DataRowView = CType(DGVR.DataBoundItem, DataRowView)
            Dim RF As RoutefileRow = CType(DRV.Row, RoutefileRow)
            Data.Routefile.RemoveRoutefileRow(RF)
        Next
        UpdateBackground = True
    End Sub

    Private Sub DGV_Route_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGV_Route.DataError

    End Sub

    Private Sub BindingNavigatorEditItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorEditItem.Click
        Dim Routefilerows(DGV_Route.SelectedRows.Count - 1) As RoutefileRow
        For i As Integer = 0 To DGV_Route.SelectedRows.Count - 1
            Dim DGVR As DataGridViewRow = DGV_Route.SelectedRows(i)
            Dim DRV As DataRowView = CType(DGVR.DataBoundItem, DataRowView)
            Dim RR As RoutefileRow = CType(DRV.Row, RoutefileRow)
            Routefilerows(i) = RR
        Next

        Using AERF As New frm_AddEditRoutefile(Routefilerows)
            If AERF.ShowDialog() = DialogResult.OK Then
                UpdateBackground = True
            End If
        End Using
    End Sub

    Private Sub DGV_Route_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_Route.CellFormatting
        If DGV_Route.Columns(e.ColumnIndex).Name = "DataGridViewTextBoxColumnRouteColor" Then
            Dim DRV As DataRowView = CType(DGV_Route.Rows(e.RowIndex).DataBoundItem, DataRowView)
            Dim RR As RoutefileRow = CType(DRV.Row, RoutefileRow)
            Dim ColStr() As String = RR.RouteColor.Split(CType(", ", Char()), StringSplitOptions.RemoveEmptyEntries)
            Dim NewColor As Color = Color.FromArgb(CInt(ColStr(0)), CInt(ColStr(1)), CInt(ColStr(2)))
            DGV_Route.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = NewColor
            DGV_Route.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = NewColor
            DGV_Route.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionBackColor = NewColor
            DGV_Route.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionForeColor = NewColor
        End If
    End Sub

    Private Sub DGV_Route_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Route.CellDoubleClick
        Dim Routefilerows(DGV_Route.SelectedRows.Count - 1) As RoutefileRow
        For i As Integer = 0 To DGV_Route.SelectedRows.Count - 1
            Dim DGVR As DataGridViewRow = DGV_Route.SelectedRows(i)
            Dim DRV As DataRowView = CType(DGVR.DataBoundItem, DataRowView)
            Dim RR As RoutefileRow = CType(DRV.Row, RoutefileRow)
            Routefilerows(i) = RR
        Next

        Using AERF As New frm_AddEditRoutefile(Routefilerows)
            If AERF.ShowDialog() = DialogResult.OK Then
                UpdateBackground = True
            End If
        End Using
    End Sub

    Private Sub LL_WebTileProvider_Website_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LL_WebTileProvider_Website.LinkClicked
        Process.Start(LL_WebTileProvider_Website.Text)
    End Sub

    Private Sub TB_Zoom_ValueChanged(sender As Object, e As EventArgs) Handles TB_Zoom.ValueChanged
        L_ZoomValue.Text = TB_Zoom.Value.ToString
        UpdateBackground = True
    End Sub

    Private Sub CLB_Layers_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CLB_Layers.ItemCheck
        UpdateBackground = True
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

Option Strict On

Imports System.Drawing
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Route_Visualizer
Imports Route_Visualizer.Data

<TestClass()> Public Class RouteVisualizerTests

    <TestMethod()>
    <DeploymentItem("01_Placemark.kml")>
    <DeploymentItem("02_Paths.kml")>
    <DeploymentItem("03_Polygons.kml")>
    <DeploymentItem("04_Linestring.kml")>
    <DeploymentItem("05_MultiGeometry.kml")>
    Public Sub ImportKML()
        Dim RV As New Route_Visualizer.frm_Main
        Dim RF As New Route_Visualizer.Data.RoutefileDataTable

        Dim Expected(4) As List(Of Coordinate)
        Expected(0) = New List(Of Coordinate)
        Expected(1) = New List(Of Coordinate)
        Expected(2) = New List(Of Coordinate)
        Expected(3) = New List(Of Coordinate)
        Expected(4) = New List(Of Coordinate)

        Expected(0).Add(New Coordinate(37.422289901402507, -122.08220354256829))

        Expected(1).Add(New Coordinate(36.079549521456471, -112.2550785337791))
        Expected(1).Add(New Coordinate(36.081170834921217, -112.25492770397381))
        Expected(1).Add(New Coordinate(36.082607613072788, -112.25525050690629))
        Expected(1).Add(New Coordinate(36.083956605885056, -112.25645401583761))
        Expected(1).Add(New Coordinate(36.08511401044813, -112.2580238976449))
        Expected(1).Add(New Coordinate(36.085843552393939, -112.2595218489022))
        Expected(1).Add(New Coordinate(36.086126345485887, -112.2608216347552))
        Expected(1).Add(New Coordinate(36.086260190851469, -112.262073428656))
        Expected(1).Add(New Coordinate(36.086215198600911, -112.2633204928495))
        Expected(1).Add(New Coordinate(36.086278979452743, -112.2644963846444))
        Expected(1).Add(New Coordinate(36.086495990906442, -112.26569695545891))

        Expected(2).Add(New Coordinate(38.872532598928238, -77.057884576609666))
        Expected(2).Add(New Coordinate(38.872910162817028, -77.054659737567022))
        Expected(2).Add(New Coordinate(38.870532677943856, -77.0531553685479))
        Expected(2).Add(New Coordinate(38.868757801256, -77.055526224935164))
        Expected(2).Add(New Coordinate(38.86996206506943, -77.058440562903925))
        Expected(2).Add(New Coordinate(38.872532598928238, -77.057884576609666))

        Expected(2).Add(New Coordinate(38.871542397984562, -77.05668055019126))
        Expected(2).Add(New Coordinate(38.871678903440767, -77.055426259608183))
        Expected(2).Add(New Coordinate(38.870765353977923, -77.054851259010235))
        Expected(2).Add(New Coordinate(38.870086865814457, -77.05577677433152))
        Expected(2).Add(New Coordinate(38.870544469633508, -77.056911620175427))
        Expected(2).Add(New Coordinate(38.871542397984562, -77.05668055019126))

        Expected(3).Add(New Coordinate(12.233, 146.825))
        Expected(3).Add(New Coordinate(12.222, 146.82))
        Expected(3).Add(New Coordinate(12.212, 146.812))
        Expected(3).Add(New Coordinate(12.209, 146.796))
        Expected(3).Add(New Coordinate(12.205, 146.788))

        Expected(4).Add(New Coordinate(37.806664186073228, -122.4425587930444))
        Expected(4).Add(New Coordinate(37.806635783230931, -122.44283795947681))
        Expected(4).Add(New Coordinate(37.806625880612053, -122.4425509770566))
        Expected(4).Add(New Coordinate(37.8065999493009, -122.4428340530617))

        Dim Files() As String = {"01_Placemark.kml", "02_Paths.kml", "03_Polygons.kml", "04_Linestring.kml", "05_MultiGeometry.kml"}
        For i As Integer = 0 To Files.Length - 1
            Dim RR As RoutefileRow = RF.NewRoutefileRow()
            RR.Path = Files(i)

            Dim Res As List(Of Coordinate) = RV.ReadCoordinatesFromKML(RR)

            Dim ExpectedResult = Expected(i)

            If Res.Count <> ExpectedResult.Count Then
                Assert.Fail("Number of Coordinates differs when importing " & Files(i))
            Else
                For j As Integer = 0 To Res.Count - 1
                    If Not (Res(j).Latitude = ExpectedResult(j).Latitude) OrElse Not (Res(j).Longitude = ExpectedResult(j).Longitude) Then
                        Assert.Fail("Coordinate " & j & " has not the expected value when importing " & Files(i))
                    End If
                Next
            End If
        Next
    End Sub

    <TestMethod()>
    <DeploymentItem("01.gpx")>
    <DeploymentItem("02.gpx")>
    Public Sub ImportGPX()
        Dim RV As New Route_Visualizer.frm_Main
        Dim RF As New Route_Visualizer.Data.RoutefileDataTable

        Dim Expected(1) As List(Of Coordinate)
        Expected(0) = New List(Of Coordinate)
        Expected(1) = New List(Of Coordinate)

        Expected(0).Add(New Coordinate(52.52, 13.38))
        Expected(0).Add(New Coordinate(48.2, 16.26))
        Expected(0).Add(New Coordinate(46.95, 7.4))
        Expected(0).Add(New Coordinate(47.2, 7.41))
        Expected(0).Add(New Coordinate(52.53, 13.0))

        Expected(1).Add(New Coordinate(47.644548, -122.326897))
        Expected(1).Add(New Coordinate(47.644548, -122.326897))
        Expected(1).Add(New Coordinate(47.644548, -122.326897))

        Dim Files() As String = {"01.gpx"}
        For i As Integer = 0 To Files.Length - 1
            Dim RR As RoutefileRow = RF.NewRoutefileRow()
            RR.Path = Files(i)

            Dim Res As List(Of Coordinate) = RV.ReadCoordinatesFromGPX(RR)

            Dim ExpectedResult = Expected(i)

            If Res.Count <> ExpectedResult.Count Then
                Assert.Fail("Number of Coordinates differs when importing " & Files(i))
            Else
                For j As Integer = 0 To Res.Count - 1
                    If Not (Res(j).Latitude = ExpectedResult(j).Latitude) OrElse Not (Res(j).Longitude = ExpectedResult(j).Longitude) Then
                        Assert.Fail("Coordinate " & j & " has not the expected value when importing " & Files(i))
                    End If
                Next
            End If
        Next
    End Sub

    <TestMethod()>
    Public Sub CreateLayerImage()
        Dim RV As New Route_Visualizer.frm_Main
        Dim RF As New Route_Visualizer.Data.RoutefileDataTable
        Dim ZDT As New Route_Visualizer.Data.ZoomDataTable
        Dim ZR As ZoomRow = ZDT.NewZoomRow()

        ZR.Path = "{Z}_{C}-{R}.jpg"
        ZR.Tileheight = 256
        ZR.Tilewidth = 256
        ZR.Zoomvalue = 9

        Dim MinMax() As Point = {New Point(1, 128), New Point(3, 129)}

        Dim bmp = RV.CreateLayerImage(ZR, MinMax)
        bmp.Save("Result.jpg", Imaging.ImageFormat.Jpeg)
        Dim MD As New MD5CryptoServiceProvider
        Using FS As New FileStream("Result.jpg", FileMode.Open)
            MD.ComputeHash(FS)
        End Using
        Dim Result As String = Strings.Replace(BitConverter.ToString(MD.Hash), "-", "")
        Assert.AreEqual("EEA457D893A130F8AC00834B75B0B00F", Result)
    End Sub

    <TestMethod()>
    <DeploymentItem("01.gpx")>
    <DeploymentItem("02.gpx")>
    <DeploymentItem("01_Placemark.kml")>
    <DeploymentItem("02_Paths.kml")>
    <DeploymentItem("03_Polygons.kml")>
    <DeploymentItem("04_Linestring.kml")>
    <DeploymentItem("05_MultiGeometry.kml")>
    Public Sub CalcMinMaxTiles()
        Dim RV As New Route_Visualizer.frm_Main
        Dim RF As New Route_Visualizer.Data.RoutefileDataTable
        Dim ZDT As New Route_Visualizer.Data.ZoomDataTable
        Dim ZR As ZoomRow = ZDT.NewZoomRow()
        ZR.Path = "{Z}_{C}-{R}.jpg"
        ZR.Tileheight = 256
        ZR.Tilewidth = 256
        ZR.Zoomvalue = 9

        Dim Files() As String = {"01_Placemark.kml", "02_Paths.kml", "03_Polygons.kml", "04_Linestring.kml", "05_MultiGeometry.kml", "01.gpx", "02.gpx"}
        Dim Res As New List(Of Coordinate)
        For i As Integer = 0 To Files.Length - 1
            Dim RR As RoutefileRow = RF.NewRoutefileRow()
            RR.Path = Files(i)
            Res.AddRange(RV.ImportCoordinatesFromFile(RR))
        Next

        Dim MinMax() As Point = RV.CalcMinMaxTiles(Res, ZR)
        Assert.IsTrue(MinMax(0).X = 81 AndAlso MinMax(0).Y = 167 AndAlso MinMax(1).X = 464 AndAlso MinMax(1).Y = 238)
    End Sub
End Class
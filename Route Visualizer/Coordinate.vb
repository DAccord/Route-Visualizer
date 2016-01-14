Imports Route_Visualizer.Data

Public Class Coordinate
    Implements IComparable 'to compare to coordinates

    Dim _Latitude As Double
    Dim _Longitude As Double

    Public Property Latitude As Double
        Get
            Return _Latitude
        End Get
        Set(value As Double)
            _Latitude = value
        End Set
    End Property

    Public Property Longitude As Double
        Get
            Return _Longitude
        End Get
        Set(value As Double)
            _Longitude = value
        End Set
    End Property

    Public Sub New(Latitude As Double, Longitude As Double)
        _Latitude = Latitude
        _Longitude = Longitude
    End Sub

    Function WorldCoordinate(ZR As ZoomRow) As PointF
        Dim Result As New PointF
        Result.X = CSng(ZR.Tilewidth * (0.5 + Longitude / 360))
        Result.Y = CSng(ZR.Tileheight * (0.5 - Math.Log((1 + Math.Min(Math.Max(Math.Sin(Latitude * Math.PI / 180), -0.9999), 0.9999)) / (1 - Math.Min(Math.Max(Math.Sin(Latitude * Math.PI / 180), -0.9999), 0.9999))) / (4 * Math.PI)))
        Return Result
    End Function

    Function PixelCoordinate(ZR As ZoomRow) As Point
        Dim Result As New Point
        Result.X = CInt(Math.Floor(WorldCoordinate(ZR).X * 2 ^ ZR.Zoomvalue))
        Result.Y = CInt(Math.Floor(WorldCoordinate(ZR).Y * 2 ^ ZR.Zoomvalue))
        Return Result
    End Function

    Function TileCoordinate(ZR As ZoomRow) As Point
        Dim Result As New Point
        Result.X = CInt(Math.Floor(WorldCoordinate(ZR).X * 2 ^ ZR.Zoomvalue / ZR.Tilewidth))
        Result.Y = CInt(Math.Floor(WorldCoordinate(ZR).Y * 2 ^ ZR.Zoomvalue / ZR.Tileheight))
        Return Result
    End Function

    Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        Dim Coord As Coordinate = CType(obj, Coordinate)
        If Me.Latitude = Coord.Latitude AndAlso Me.Longitude = Coord.Longitude Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        Dim C As Coordinate = TryCast(obj, Coordinate)
        If C Is Nothing Then
            Return False
        End If
        If Latitude.Equals(C.Latitude) AndAlso Longitude.Equals(C.Longitude) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Latitude.GetHashCode Xor Longitude.GetHashCode
    End Function
End Class
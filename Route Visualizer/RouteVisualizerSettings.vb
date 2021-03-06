﻿Imports System.IO
Imports System.Resources

Public Class RouteVisualizerSettings
    Private _MainFormWindowState As FormWindowState = FormWindowState.Normal
    Private _MainFormWindowSize As Size = New Size(912, 669)
    Private _MainFormWindowLocation As Point = New Point(100, 100)

    Private _SaveImagePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Output.jpg")
    Private _SaveLayersSeparatelyPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Private _ImportRoutePath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

    Private _AnimationCurrentPositionColor As Color = Color.Red
    Private _AnimationCurrentPositionWidth As Integer = 20
    Private _AnimationImageSizeWidth As Boolean = True
    Private _AnimationImageSizeHeight As Boolean = False
    Private _AnimationImageSize As Integer = 0
    Private _AnimationAlwaysBackground As Boolean = True
    Private _AnimationBackgroundOnce As Boolean = False
    Private _AnimationOutputFormat As String = ".jpg"
    Private _AnimationOutputPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Private _AnimationStepSize As Integer = 50
    Private _AnimationDelayTime As Integer = 60
    Private _AnimationLoopCount As Integer = 0

    Private _PreviewFormWindowState As FormWindowState = FormWindowState.Normal
    Private _PreviewFormWindowSize As Size = New Size(640, 412)
    Private _PreviewFormWindowLocation As Point = New Point(100, 100)
    Private _PreviewFormWindowOpen As Boolean = False

    Private _CheckedLocalLayers As List(Of Boolean)
    Private _CheckedOnlineLayers As List(Of Boolean)

    Private _Switch As String = "AdditionalTiles"
    Private _North As Integer = 0
    Private _West As Integer = 0
    Private _South As Integer = 0
    Private _East As Integer = 0

    Private _Zoom As Integer = 0

    Private _AST As AnimationSaveType

    Public Sub New()

    End Sub

    Public Property Zoom As Integer
        Get
            Return _Zoom
        End Get
        Set(value As Integer)
            _Zoom = value
        End Set
    End Property

    Public Property AniSaveType As AnimationSaveType
        Get
            Return _AST
        End Get
        Set(value As AnimationSaveType)
            _AST = value
        End Set
    End Property

    ''' <summary>
    ''' The value in the additional tiles North numeric up down.
    ''' </summary>
    ''' <returns></returns>
    Public Property North As Integer
        Get
            Return _North
        End Get
        Set(value As Integer)
            _North = value
        End Set
    End Property

    ''' <summary>
    ''' The value in the additional tiles West numeric up down.
    ''' </summary>
    ''' <returns></returns>
    Public Property West As Integer
        Get
            Return _West
        End Get
        Set(value As Integer)
            _West = value
        End Set
    End Property

    ''' <summary>
    ''' The value in the additional tiles South numeric up down.
    ''' </summary>
    ''' <returns></returns>
    Public Property South As Integer
        Get
            Return _South
        End Get
        Set(value As Integer)
            _South = value
        End Set
    End Property

    ''' <summary>
    ''' The value in the additional tiles East numeric up down.
    ''' </summary>
    ''' <returns></returns>
    Public Property East As Integer
        Get
            Return _East
        End Get
        Set(value As Integer)
            _East = value
        End Set
    End Property

    ''' <summary>
    ''' Determines if additional or absolute tiles are entered. Returns "AdditionalTiles" if additional tiles, "AbsoluteNumbers" otherwise.
    ''' </summary>
    ''' <returns></returns>
    Public Property Switch As String
        Get
            Return _Switch
        End Get
        Set(value As String)
            _Switch = value
        End Set
    End Property

    ''' <summary>
    ''' A list of booleans representing the check state of the online layers checked list box.
    ''' </summary>
    ''' <returns></returns>
    Public Property CheckedOnlineLayers As List(Of Boolean)
        Get
            Return _CheckedOnlineLayers
        End Get
        Set(value As List(Of Boolean))
            _CheckedOnlineLayers = value
        End Set
    End Property

    ''' <summary>
    ''' A list of booleans representing the check state of the local layers checked list box.
    ''' </summary>
    ''' <returns></returns>
    Public Property CheckedLocalLayers As List(Of Boolean)
        Get
            Return _CheckedLocalLayers
        End Get
        Set(value As List(Of Boolean))
            _CheckedLocalLayers = value
        End Set
    End Property

    ''' <summary>
    ''' The path last used for importing a route file, including file name.
    ''' </summary>
    ''' <returns></returns>
    Public Property ImportRoutePath As String
        Get
            Return _ImportRoutePath
        End Get
        Set(value As String)
            _ImportRoutePath = value
        End Set
    End Property

    ''' <summary>
    ''' If preview window is open when closing, true. False otherwise.
    ''' </summary>
    ''' <returns></returns>
    Public Property PreviewFormWindowOpen As Boolean
        Get
            Return _PreviewFormWindowOpen
        End Get
        Set(value As Boolean)
            _PreviewFormWindowOpen = value
        End Set
    End Property

    ''' <summary>
    ''' The color used to plot the current position in the animation (GIF or single files).
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationCurrentPositionColor As Color
        Get
            Return _AnimationCurrentPositionColor
        End Get
        Set(value As Color)
            _AnimationCurrentPositionColor = value
        End Set
    End Property

    ''' <summary>
    ''' The width of the circle used for the current position in the animation (GIF or single files).
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationCurrentPositionWidth As Integer
        Get
            Return _AnimationCurrentPositionWidth
        End Get
        Set(value As Integer)
            _AnimationCurrentPositionWidth = value
        End Set
    End Property

    ''' <summary>
    ''' The IsChecked property of the width check box in the animation save dialog (GIF or single files).
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationImageSizeWidth As Boolean
        Get
            Return _AnimationImageSizeWidth
        End Get
        Set(value As Boolean)
            _AnimationImageSizeWidth = value
        End Set
    End Property

    ''' <summary>
    ''' The IsChecked property of the height check box in the animation save dialog (GIF or single files).
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationImageSizeHeight As Boolean
        Get
            Return _AnimationImageSizeHeight
        End Get
        Set(value As Boolean)
            _AnimationImageSizeHeight = value
        End Set
    End Property

    ''' <summary>
    ''' The desired image size for the animation (GIF or single files).
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationImageSize As Integer
        Get
            Return _AnimationImageSize
        End Get
        Set(value As Integer)
            _AnimationImageSize = value
        End Set
    End Property

    ''' <summary>
    ''' The IsChecked property of the Always Background checkbox in the animation save dialog (GIF or single files).
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationAlwaysBackground As Boolean
        Get
            Return _AnimationAlwaysBackground
        End Get
        Set(value As Boolean)
            _AnimationAlwaysBackground = value
        End Set
    End Property

    ''' <summary>
    ''' The IsChecked property of the Background Once checkbox in the animation save dialog (GIF or single files).
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationBackgroundOnce As Boolean
        Get
            Return _AnimationBackgroundOnce
        End Get
        Set(value As Boolean)
            _AnimationBackgroundOnce = value
        End Set
    End Property

    ''' <summary>
    ''' The text selected in the combo box of the animation save dialog (GIF or single files).
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationOutputFormat As String
        Get
            Return _AnimationOutputFormat
        End Get
        Set(value As String)
            _AnimationOutputFormat = value
        End Set
    End Property

    ''' <summary>
    ''' The path to save the animation (GIF or single files) to.
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationOutputPath As String
        Get
            Return _AnimationOutputPath
        End Get
        Set(value As String)
            _AnimationOutputPath = value
        End Set
    End Property

    ''' <summary>
    ''' The step size used for the animation (GIF or single files).
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationStepSize As Integer
        Get
            Return _AnimationStepSize
        End Get
        Set(value As Integer)
            _AnimationStepSize = value
        End Set
    End Property

    ''' <summary>
    ''' The animation delay time (in 1/100s of a second) used for a GIF animation.
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationDelayTime As Integer
        Get
            Return _AnimationDelayTime
        End Get
        Set(value As Integer)
            _AnimationDelayTime = value
        End Set
    End Property

    ''' <summary>
    ''' The number of repeats for a GIF animation. 0 = infinite.
    ''' </summary>
    ''' <returns></returns>
    Public Property AnimationLoopCount As Integer
        Get
            Return _AnimationLoopCount
        End Get
        Set(value As Integer)
            _AnimationLoopCount = value
        End Set
    End Property

    ''' <summary>
    ''' 'Path for saving layers in separate files
    ''' </summary>
    ''' <returns></returns>
    Public Property SaveLayersSeparatelyPath As String
        Get
            Return _SaveLayersSeparatelyPath
        End Get
        Set(value As String)
            _SaveLayersSeparatelyPath = value
        End Set
    End Property

    ''' <summary>
    ''' Path for saving a single file
    ''' </summary>
    ''' <returns></returns>
    Public Property SaveImagePath As String
        Get
            Return _SaveImagePath
        End Get
        Set(value As String)
            _SaveImagePath = value
        End Set
    End Property

    Public Property PreviewFormWindowLocation As Point
        Get
            Return _PreviewFormWindowLocation
        End Get
        Set(value As Point)
            _PreviewFormWindowLocation = value
        End Set
    End Property

    Public Property PreviewFormWindowSize As Size
        Get
            Return _PreviewFormWindowSize
        End Get
        Set(value As Size)
            _PreviewFormWindowSize = value
        End Set
    End Property

    Public Property PreviewFormWindowState As FormWindowState
        Get
            Return _PreviewFormWindowState
        End Get
        Set(value As FormWindowState)
            _PreviewFormWindowState = value
        End Set
    End Property

    Public Sub SaveSettings(ByVal Path As String)
        Using RRW As New ResXResourceWriter(Path)
            For Each p As System.Reflection.PropertyInfo In Me.GetType().GetProperties()
                RRW.AddResource(p.Name, p.GetValue(Me, Nothing))
            Next
        End Using
    End Sub

    Public Sub ReadSettings(ByVal Path As String)
        If Not File.Exists(Path) Then
            Exit Sub
        End If
        Using resxSet As New ResXResourceSet(Path)
            Me.MainFormWindowState = CType(resxSet.GetObject("MainFormWindowState"), FormWindowState)
            Me.MainFormWindowSize = CType(resxSet.GetObject("MainFormWindowSize"), Size)
            Me.MainFormWindowLocation = CType(resxSet.GetObject("MainFormWindowLocation"), Point)

            Me.SaveImagePath = resxSet.GetString("SaveImagePath")
            Me.SaveLayersSeparatelyPath = resxSet.GetString("SaveLayersSeparatelyPath")
            Me.ImportRoutePath = resxSet.GetString("ImportRoutePath")

            Me.PreviewFormWindowOpen = CType(resxSet.GetObject("PreviewFormWindowOpen"), Boolean)
            Me.PreviewFormWindowState = CType(resxSet.GetObject("PreviewFormWindowState"), FormWindowState)
            Me.PreviewFormWindowSize = CType(resxSet.GetObject("PreviewFormWindowSize"), Size)
            Me.PreviewFormWindowLocation = CType(resxSet.GetObject("PreviewFormWindowLocation"), Point)

            Me.AnimationCurrentPositionColor = CType(resxSet.GetObject("AnimationCurrentPositionColor"), Color)
            Me.AnimationCurrentPositionWidth = CType(resxSet.GetObject("AnimationCurrentPositionWidth"), Integer)
            Me.AnimationImageSizeWidth = CType(resxSet.GetObject("AnimationImageSizeWidth"), Boolean)
            Me.AnimationImageSizeHeight = CType(resxSet.GetObject("AnimationImageSizeHeight"), Boolean)
            Me.AnimationImageSize = CType(resxSet.GetObject("AnimationImageSize"), Integer)
            Me.AnimationAlwaysBackground = CType(resxSet.GetObject("AnimationAlwaysBackground"), Boolean)
            Me.AnimationBackgroundOnce = CType(resxSet.GetObject("AnimationBackgroundOnce"), Boolean)
            Me.AnimationOutputFormat = CType(resxSet.GetObject("AnimationOutputFormat"), String)
            Me.AnimationOutputPath = CType(resxSet.GetObject("AnimationOutputPath"), String)
            Me.AnimationStepSize = CType(resxSet.GetObject("AnimationStepSize"), Integer)
            Me.AnimationDelayTime = CType(resxSet.GetObject("AnimationDelayTime"), Integer)
            Me.AnimationLoopCount = CType(resxSet.GetObject("AnimationLoopCount"), Integer)

            Me.CheckedLocalLayers = CType(resxSet.GetObject("CheckedLocalLayers"), List(Of Boolean))
            Me.CheckedOnlineLayers = CType(resxSet.GetObject("CheckedOnlineLayers"), List(Of Boolean))

            Me.Switch = resxSet.GetString("Switch")
            Me.North = CType(resxSet.GetObject("North"), Integer)
            Me.West = CType(resxSet.GetObject("West"), Integer)
            Me.East = CType(resxSet.GetObject("East"), Integer)
            Me.South = CType(resxSet.GetObject("South"), Integer)

            Me.AniSaveType = CType(resxSet.GetObject("AniSaveType"), AnimationSaveType)

            Me.Zoom = CType(resxSet.GetObject("Zoom"), Integer)
        End Using
    End Sub

    Public Property MainFormWindowState As FormWindowState
        Get
            Return _MainFormWindowState
        End Get
        Set(value As FormWindowState)
            _MainFormWindowState = value
        End Set
    End Property

    Public Property MainFormWindowSize As Size
        Get
            Return _MainFormWindowSize
        End Get
        Set(value As Size)
            _MainFormWindowSize = value
        End Set
    End Property

    Public Property MainFormWindowLocation As Point
        Get
            Return _MainFormWindowLocation
        End Get
        Set(value As Point)
            _MainFormWindowLocation = value
        End Set
    End Property
End Class
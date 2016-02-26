Imports System.IO

Public Enum SaveType
    Animation_GIF
    Animation_SingleFiles
    SimpleImage
    LayersSeparately_MergeRoutes
    LayersSeparately_RoutesSeparately
    Preview
End Enum

Public Enum AnimationSaveType
    InRow_Hold
    InRow_NoHold
    Together
End Enum

Public Class SaveOption
    Private _Width As Integer = 0
    Private _Height As Integer = 0
    Private _StepSize As Integer = 5
    Private _SymbolColor As Color = Color.Red
    Private _OutputFormat As String = ".jpg"
    Private _DirectoryPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Private _FilePath As String = Path.Combine(DirectoryPath, "Output.gif")
    Private _SymbolWidth As Integer = 20
    Private _BackGroundAlways As Boolean = True
    Private _DelayTime As Integer = 60 'in 1/100 of a second
    Private _SaveType As SaveType
    Private _LoopCount As Integer = 0
    Private _AnimSaveType As AnimationSaveType = AnimationSaveType.InRow_Hold

    Public Sub New()

    End Sub

    Public Property AnimSaveType As AnimationSaveType
        Get
            Return _AnimSaveType
        End Get
        Set(value As AnimationSaveType)
            _AnimSaveType = value
        End Set
    End Property

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
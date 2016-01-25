<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LayerDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sortindex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LayerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Data = New Route_Visualizer.Data()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ZoomDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.LayerBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZoomBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GB_Route = New System.Windows.Forms.GroupBox()
        Me.DGV_Route = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumnVisibility = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumnPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumnRouteLineWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumnRouteColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumnRouteAlpha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMS_DGV_Route = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvertSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenPathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoutefileBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TLP_Tiles = New System.Windows.Forms.TableLayoutPanel()
        Me.GB_AdditionalTiles = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.NUD_AdditionalTilesSouth = New System.Windows.Forms.NumericUpDown()
        Me.NUD_AdditionalTilesWest = New System.Windows.Forms.NumericUpDown()
        Me.NUD_AdditionalTilesEast = New System.Windows.Forms.NumericUpDown()
        Me.NUD_AdditionalTilesNorth = New System.Windows.Forms.NumericUpDown()
        Me.L_North = New System.Windows.Forms.Label()
        Me.L_East = New System.Windows.Forms.Label()
        Me.L_West = New System.Windows.Forms.Label()
        Me.L_South = New System.Windows.Forms.Label()
        Me.Btn_ResetAdditionalTiles = New System.Windows.Forms.Button()
        Me.Btn_Switch = New System.Windows.Forms.Button()
        Me.GB_Layers = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.CMB_Zoom = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CLB_Layers = New System.Windows.Forms.CheckedListBox()
        Me.GB_Preview = New System.Windows.Forms.GroupBox()
        Me.PB_Preview = New System.Windows.Forms.PictureBox()
        Me.OFD_ImportRoute = New System.Windows.Forms.OpenFileDialog()
        Me.SFD_SaveImage = New System.Windows.Forms.SaveFileDialog()
        Me.FBD_SaveLayersSeperately = New System.Windows.Forms.FolderBrowserDialog()
        Me.TP_Layers = New System.Windows.Forms.TabPage()
        Me.TP_RouteVisualizer = New System.Windows.Forms.TabPage()
        Me.TC_Main = New System.Windows.Forms.TabControl()
        Me.CD_Main = New System.Windows.Forms.ColorDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdatePreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveAsImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveLayersSeparatelyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoutenSeparatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoutenZusammenfassenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TilesWizardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HilfeAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÜberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSSL_EscToAbort = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSL_Progress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSPB_Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ZoomBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OFD_LayerWizard = New System.Windows.Forms.OpenFileDialog()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.LayerDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ZoomDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayerBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZoomBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GB_Route.SuspendLayout()
        CType(Me.DGV_Route, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_DGV_Route.SuspendLayout()
        CType(Me.RoutefileBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TLP_Tiles.SuspendLayout()
        Me.GB_AdditionalTiles.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.NUD_AdditionalTilesSouth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AdditionalTilesWest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AdditionalTilesEast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AdditionalTilesNorth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_Layers.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GB_Preview.SuspendLayout()
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP_Layers.SuspendLayout()
        Me.TP_RouteVisualizer.SuspendLayout()
        Me.TC_Main.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ZoomBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer3
        '
        resources.ApplyResources(Me.SplitContainer3, "SplitContainer3")
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.GroupBox2)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LayerDataGridView)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'LayerDataGridView
        '
        Me.LayerDataGridView.AutoGenerateColumns = False
        Me.LayerDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LayerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LayerDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.Sortindex})
        Me.LayerDataGridView.DataSource = Me.LayerBindingSource
        resources.ApplyResources(Me.LayerDataGridView, "LayerDataGridView")
        Me.LayerDataGridView.Name = "LayerDataGridView"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Name"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'Sortindex
        '
        Me.Sortindex.DataPropertyName = "Sortindex"
        resources.ApplyResources(Me.Sortindex, "Sortindex")
        Me.Sortindex.Name = "Sortindex"
        '
        'LayerBindingSource
        '
        Me.LayerBindingSource.DataMember = "Layer"
        Me.LayerBindingSource.DataSource = Me.Data
        '
        'Data
        '
        Me.Data.DataSetName = "Data"
        Me.Data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ZoomDataGridView)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'ZoomDataGridView
        '
        Me.ZoomDataGridView.AutoGenerateColumns = False
        Me.ZoomDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ZoomDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ZoomDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ZoomDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn10})
        Me.ZoomDataGridView.DataSource = Me.ZoomBindingSource1
        resources.ApplyResources(Me.ZoomDataGridView, "ZoomDataGridView")
        Me.ZoomDataGridView.Name = "ZoomDataGridView"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LayerID"
        Me.DataGridViewTextBoxColumn4.DataSource = Me.LayerBindingSource1
        Me.DataGridViewTextBoxColumn4.DisplayMember = "Name"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn4, "DataGridViewTextBoxColumn4")
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn4.ValueMember = "ID"
        '
        'LayerBindingSource1
        '
        Me.LayerBindingSource1.DataMember = "Layer"
        Me.LayerBindingSource1.DataSource = Me.Data
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Zoomvalue"
        Me.DataGridViewTextBoxColumn5.FillWeight = 101.0!
        resources.ApplyResources(Me.DataGridViewTextBoxColumn5, "DataGridViewTextBoxColumn5")
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Tilewidth"
        Me.DataGridViewTextBoxColumn6.FillWeight = 101.0!
        resources.ApplyResources(Me.DataGridViewTextBoxColumn6, "DataGridViewTextBoxColumn6")
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Tileheight"
        Me.DataGridViewTextBoxColumn7.FillWeight = 105.0!
        resources.ApplyResources(Me.DataGridViewTextBoxColumn7, "DataGridViewTextBoxColumn7")
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Path"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn10, "DataGridViewTextBoxColumn10")
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'ZoomBindingSource1
        '
        Me.ZoomBindingSource1.DataMember = "Layer_Zoom"
        Me.ZoomBindingSource1.DataSource = Me.LayerBindingSource
        '
        'SplitContainer2
        '
        resources.ApplyResources(Me.SplitContainer2, "SplitContainer2")
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GB_Route)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        '
        'GB_Route
        '
        Me.GB_Route.Controls.Add(Me.DGV_Route)
        resources.ApplyResources(Me.GB_Route, "GB_Route")
        Me.GB_Route.Name = "GB_Route"
        Me.GB_Route.TabStop = False
        '
        'DGV_Route
        '
        Me.DGV_Route.AllowDrop = True
        Me.DGV_Route.AutoGenerateColumns = False
        Me.DGV_Route.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGV_Route.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV_Route.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Route.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumnVisibility, Me.DataGridViewTextBoxColumnPath, Me.DataGridViewTextBoxColumnRouteLineWidth, Me.DataGridViewTextBoxColumnRouteColor, Me.DataGridViewTextBoxColumnRouteAlpha})
        Me.DGV_Route.ContextMenuStrip = Me.CMS_DGV_Route
        Me.DGV_Route.DataSource = Me.RoutefileBindingSource
        resources.ApplyResources(Me.DGV_Route, "DGV_Route")
        Me.DGV_Route.Name = "DGV_Route"
        '
        'DataGridViewTextBoxColumnVisibility
        '
        Me.DataGridViewTextBoxColumnVisibility.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumnVisibility.DataPropertyName = "Visibility"
        resources.ApplyResources(Me.DataGridViewTextBoxColumnVisibility, "DataGridViewTextBoxColumnVisibility")
        Me.DataGridViewTextBoxColumnVisibility.Name = "DataGridViewTextBoxColumnVisibility"
        '
        'DataGridViewTextBoxColumnPath
        '
        Me.DataGridViewTextBoxColumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumnPath.DataPropertyName = "Path"
        resources.ApplyResources(Me.DataGridViewTextBoxColumnPath, "DataGridViewTextBoxColumnPath")
        Me.DataGridViewTextBoxColumnPath.Name = "DataGridViewTextBoxColumnPath"
        '
        'DataGridViewTextBoxColumnRouteLineWidth
        '
        Me.DataGridViewTextBoxColumnRouteLineWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumnRouteLineWidth.DataPropertyName = "RouteLineWidth"
        resources.ApplyResources(Me.DataGridViewTextBoxColumnRouteLineWidth, "DataGridViewTextBoxColumnRouteLineWidth")
        Me.DataGridViewTextBoxColumnRouteLineWidth.Name = "DataGridViewTextBoxColumnRouteLineWidth"
        '
        'DataGridViewTextBoxColumnRouteColor
        '
        Me.DataGridViewTextBoxColumnRouteColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumnRouteColor.DataPropertyName = "RouteColor"
        resources.ApplyResources(Me.DataGridViewTextBoxColumnRouteColor, "DataGridViewTextBoxColumnRouteColor")
        Me.DataGridViewTextBoxColumnRouteColor.Name = "DataGridViewTextBoxColumnRouteColor"
        '
        'DataGridViewTextBoxColumnRouteAlpha
        '
        Me.DataGridViewTextBoxColumnRouteAlpha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumnRouteAlpha.DataPropertyName = "RouteAlpha"
        resources.ApplyResources(Me.DataGridViewTextBoxColumnRouteAlpha, "DataGridViewTextBoxColumnRouteAlpha")
        Me.DataGridViewTextBoxColumnRouteAlpha.Name = "DataGridViewTextBoxColumnRouteAlpha"
        '
        'CMS_DGV_Route
        '
        Me.CMS_DGV_Route.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.DeselectAllToolStripMenuItem, Me.InvertSelectionToolStripMenuItem, Me.ToolStripMenuItem4, Me.OpenPathToolStripMenuItem})
        Me.CMS_DGV_Route.Name = "CMS_DGV_Route"
        resources.ApplyResources(Me.CMS_DGV_Route, "CMS_DGV_Route")
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        resources.ApplyResources(Me.SelectAllToolStripMenuItem, "SelectAllToolStripMenuItem")
        '
        'DeselectAllToolStripMenuItem
        '
        Me.DeselectAllToolStripMenuItem.Name = "DeselectAllToolStripMenuItem"
        resources.ApplyResources(Me.DeselectAllToolStripMenuItem, "DeselectAllToolStripMenuItem")
        '
        'InvertSelectionToolStripMenuItem
        '
        Me.InvertSelectionToolStripMenuItem.Name = "InvertSelectionToolStripMenuItem"
        resources.ApplyResources(Me.InvertSelectionToolStripMenuItem, "InvertSelectionToolStripMenuItem")
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'OpenPathToolStripMenuItem
        '
        Me.OpenPathToolStripMenuItem.Name = "OpenPathToolStripMenuItem"
        resources.ApplyResources(Me.OpenPathToolStripMenuItem, "OpenPathToolStripMenuItem")
        '
        'RoutefileBindingSource
        '
        Me.RoutefileBindingSource.DataMember = "Routefile"
        Me.RoutefileBindingSource.DataSource = Me.Data
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GB_Preview)
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.TLP_Tiles, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GB_Layers, 0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'TLP_Tiles
        '
        resources.ApplyResources(Me.TLP_Tiles, "TLP_Tiles")
        Me.TLP_Tiles.Controls.Add(Me.GB_AdditionalTiles, 0, 0)
        Me.TLP_Tiles.Name = "TLP_Tiles"
        '
        'GB_AdditionalTiles
        '
        Me.GB_AdditionalTiles.Controls.Add(Me.TableLayoutPanel3)
        resources.ApplyResources(Me.GB_AdditionalTiles, "GB_AdditionalTiles")
        Me.GB_AdditionalTiles.Name = "GB_AdditionalTiles"
        Me.GB_AdditionalTiles.TabStop = False
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.NUD_AdditionalTilesSouth, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.NUD_AdditionalTilesWest, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.NUD_AdditionalTilesEast, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.NUD_AdditionalTilesNorth, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.L_North, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.L_East, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.L_West, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.L_South, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Btn_ResetAdditionalTiles, 0, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.Btn_Switch, 0, 7)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'NUD_AdditionalTilesSouth
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.NUD_AdditionalTilesSouth, 3)
        resources.ApplyResources(Me.NUD_AdditionalTilesSouth, "NUD_AdditionalTilesSouth")
        Me.NUD_AdditionalTilesSouth.Name = "NUD_AdditionalTilesSouth"
        '
        'NUD_AdditionalTilesWest
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.NUD_AdditionalTilesWest, 2)
        resources.ApplyResources(Me.NUD_AdditionalTilesWest, "NUD_AdditionalTilesWest")
        Me.NUD_AdditionalTilesWest.Name = "NUD_AdditionalTilesWest"
        '
        'NUD_AdditionalTilesEast
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.NUD_AdditionalTilesEast, 2)
        resources.ApplyResources(Me.NUD_AdditionalTilesEast, "NUD_AdditionalTilesEast")
        Me.NUD_AdditionalTilesEast.Name = "NUD_AdditionalTilesEast"
        '
        'NUD_AdditionalTilesNorth
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.NUD_AdditionalTilesNorth, 3)
        resources.ApplyResources(Me.NUD_AdditionalTilesNorth, "NUD_AdditionalTilesNorth")
        Me.NUD_AdditionalTilesNorth.Name = "NUD_AdditionalTilesNorth"
        '
        'L_North
        '
        resources.ApplyResources(Me.L_North, "L_North")
        Me.TableLayoutPanel3.SetColumnSpan(Me.L_North, 5)
        Me.L_North.Name = "L_North"
        '
        'L_East
        '
        resources.ApplyResources(Me.L_East, "L_East")
        Me.TableLayoutPanel3.SetColumnSpan(Me.L_East, 2)
        Me.L_East.Name = "L_East"
        '
        'L_West
        '
        resources.ApplyResources(Me.L_West, "L_West")
        Me.TableLayoutPanel3.SetColumnSpan(Me.L_West, 2)
        Me.L_West.Name = "L_West"
        '
        'L_South
        '
        resources.ApplyResources(Me.L_South, "L_South")
        Me.TableLayoutPanel3.SetColumnSpan(Me.L_South, 5)
        Me.L_South.Name = "L_South"
        '
        'Btn_ResetAdditionalTiles
        '
        resources.ApplyResources(Me.Btn_ResetAdditionalTiles, "Btn_ResetAdditionalTiles")
        Me.TableLayoutPanel3.SetColumnSpan(Me.Btn_ResetAdditionalTiles, 5)
        Me.Btn_ResetAdditionalTiles.Name = "Btn_ResetAdditionalTiles"
        Me.Btn_ResetAdditionalTiles.UseVisualStyleBackColor = True
        '
        'Btn_Switch
        '
        resources.ApplyResources(Me.Btn_Switch, "Btn_Switch")
        Me.TableLayoutPanel3.SetColumnSpan(Me.Btn_Switch, 5)
        Me.Btn_Switch.Name = "Btn_Switch"
        Me.Btn_Switch.Tag = "AdditionalTiles"
        Me.Btn_Switch.UseVisualStyleBackColor = True
        '
        'GB_Layers
        '
        Me.GB_Layers.Controls.Add(Me.TableLayoutPanel4)
        resources.ApplyResources(Me.GB_Layers, "GB_Layers")
        Me.GB_Layers.Name = "GB_Layers"
        Me.GB_Layers.TabStop = False
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.CMB_Zoom, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.CLB_Layers, 0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'CMB_Zoom
        '
        resources.ApplyResources(Me.CMB_Zoom, "CMB_Zoom")
        Me.CMB_Zoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_Zoom.FormattingEnabled = True
        Me.CMB_Zoom.Name = "CMB_Zoom"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'CLB_Layers
        '
        Me.CLB_Layers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CLB_Layers.CheckOnClick = True
        Me.TableLayoutPanel4.SetColumnSpan(Me.CLB_Layers, 2)
        resources.ApplyResources(Me.CLB_Layers, "CLB_Layers")
        Me.CLB_Layers.FormattingEnabled = True
        Me.CLB_Layers.Name = "CLB_Layers"
        '
        'GB_Preview
        '
        Me.GB_Preview.Controls.Add(Me.PB_Preview)
        resources.ApplyResources(Me.GB_Preview, "GB_Preview")
        Me.GB_Preview.Name = "GB_Preview"
        Me.GB_Preview.TabStop = False
        '
        'PB_Preview
        '
        resources.ApplyResources(Me.PB_Preview, "PB_Preview")
        Me.PB_Preview.Name = "PB_Preview"
        Me.PB_Preview.TabStop = False
        '
        'OFD_ImportRoute
        '
        resources.ApplyResources(Me.OFD_ImportRoute, "OFD_ImportRoute")
        Me.OFD_ImportRoute.Multiselect = True
        '
        'SFD_SaveImage
        '
        resources.ApplyResources(Me.SFD_SaveImage, "SFD_SaveImage")
        '
        'FBD_SaveLayersSeperately
        '
        resources.ApplyResources(Me.FBD_SaveLayersSeperately, "FBD_SaveLayersSeperately")
        '
        'TP_Layers
        '
        Me.TP_Layers.Controls.Add(Me.SplitContainer3)
        resources.ApplyResources(Me.TP_Layers, "TP_Layers")
        Me.TP_Layers.Name = "TP_Layers"
        Me.TP_Layers.UseVisualStyleBackColor = True
        '
        'TP_RouteVisualizer
        '
        Me.TP_RouteVisualizer.Controls.Add(Me.SplitContainer2)
        resources.ApplyResources(Me.TP_RouteVisualizer, "TP_RouteVisualizer")
        Me.TP_RouteVisualizer.Name = "TP_RouteVisualizer"
        Me.TP_RouteVisualizer.UseVisualStyleBackColor = True
        '
        'TC_Main
        '
        Me.TC_Main.Controls.Add(Me.TP_RouteVisualizer)
        Me.TC_Main.Controls.Add(Me.TP_Layers)
        resources.ApplyResources(Me.TC_Main, "TC_Main")
        Me.TC_Main.Name = "TC_Main"
        Me.TC_Main.SelectedIndex = 0
        '
        'CD_Main
        '
        Me.CD_Main.Color = System.Drawing.Color.Red
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.LayerToolStripMenuItem, Me.HelpToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdatePreviewToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveAsImageToolStripMenuItem, Me.SaveLayersSeparatelyToolStripMenuItem, Me.ToolStripMenuItem2, Me.SpeichernToolStripMenuItem, Me.ToolStripMenuItem3, Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        '
        'UpdatePreviewToolStripMenuItem
        '
        Me.UpdatePreviewToolStripMenuItem.Name = "UpdatePreviewToolStripMenuItem"
        resources.ApplyResources(Me.UpdatePreviewToolStripMenuItem, "UpdatePreviewToolStripMenuItem")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'SaveAsImageToolStripMenuItem
        '
        Me.SaveAsImageToolStripMenuItem.Name = "SaveAsImageToolStripMenuItem"
        resources.ApplyResources(Me.SaveAsImageToolStripMenuItem, "SaveAsImageToolStripMenuItem")
        '
        'SaveLayersSeparatelyToolStripMenuItem
        '
        Me.SaveLayersSeparatelyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RoutenSeparatToolStripMenuItem, Me.RoutenZusammenfassenToolStripMenuItem})
        Me.SaveLayersSeparatelyToolStripMenuItem.Name = "SaveLayersSeparatelyToolStripMenuItem"
        resources.ApplyResources(Me.SaveLayersSeparatelyToolStripMenuItem, "SaveLayersSeparatelyToolStripMenuItem")
        '
        'RoutenSeparatToolStripMenuItem
        '
        Me.RoutenSeparatToolStripMenuItem.Name = "RoutenSeparatToolStripMenuItem"
        resources.ApplyResources(Me.RoutenSeparatToolStripMenuItem, "RoutenSeparatToolStripMenuItem")
        '
        'RoutenZusammenfassenToolStripMenuItem
        '
        Me.RoutenZusammenfassenToolStripMenuItem.Name = "RoutenZusammenfassenToolStripMenuItem"
        resources.ApplyResources(Me.RoutenZusammenfassenToolStripMenuItem, "RoutenZusammenfassenToolStripMenuItem")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'SpeichernToolStripMenuItem
        '
        Me.SpeichernToolStripMenuItem.Name = "SpeichernToolStripMenuItem"
        resources.ApplyResources(Me.SpeichernToolStripMenuItem, "SpeichernToolStripMenuItem")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        resources.ApplyResources(Me.QuitToolStripMenuItem, "QuitToolStripMenuItem")
        '
        'LayerToolStripMenuItem
        '
        Me.LayerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TilesWizardToolStripMenuItem})
        Me.LayerToolStripMenuItem.Name = "LayerToolStripMenuItem"
        resources.ApplyResources(Me.LayerToolStripMenuItem, "LayerToolStripMenuItem")
        '
        'TilesWizardToolStripMenuItem
        '
        resources.ApplyResources(Me.TilesWizardToolStripMenuItem, "TilesWizardToolStripMenuItem")
        Me.TilesWizardToolStripMenuItem.Name = "TilesWizardToolStripMenuItem"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HilfeAnzeigenToolStripMenuItem, Me.ÜberToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        '
        'HilfeAnzeigenToolStripMenuItem
        '
        Me.HilfeAnzeigenToolStripMenuItem.Name = "HilfeAnzeigenToolStripMenuItem"
        resources.ApplyResources(Me.HilfeAnzeigenToolStripMenuItem, "HilfeAnzeigenToolStripMenuItem")
        '
        'ÜberToolStripMenuItem
        '
        Me.ÜberToolStripMenuItem.Name = "ÜberToolStripMenuItem"
        resources.ApplyResources(Me.ÜberToolStripMenuItem, "ÜberToolStripMenuItem")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSL_EscToAbort, Me.TSSL_Progress, Me.TSPB_Progress})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'TSSL_EscToAbort
        '
        Me.TSSL_EscToAbort.Name = "TSSL_EscToAbort"
        resources.ApplyResources(Me.TSSL_EscToAbort, "TSSL_EscToAbort")
        Me.TSSL_EscToAbort.Spring = True
        '
        'TSSL_Progress
        '
        Me.TSSL_Progress.Name = "TSSL_Progress"
        resources.ApplyResources(Me.TSSL_Progress, "TSSL_Progress")
        '
        'TSPB_Progress
        '
        Me.TSPB_Progress.Name = "TSPB_Progress"
        resources.ApplyResources(Me.TSPB_Progress, "TSPB_Progress")
        '
        'ZoomBindingSource
        '
        Me.ZoomBindingSource.DataMember = "Zoom"
        Me.ZoomBindingSource.DataSource = Me.Data
        '
        'OFD_LayerWizard
        '
        Me.OFD_LayerWizard.FileName = "OpenFileDialog1"
        resources.ApplyResources(Me.OFD_LayerWizard, "OFD_LayerWizard")
        '
        'frm_Main
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.TC_Main)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_Main"
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.LayerDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ZoomDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayerBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZoomBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GB_Route.ResumeLayout(False)
        CType(Me.DGV_Route, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_DGV_Route.ResumeLayout(False)
        CType(Me.RoutefileBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TLP_Tiles.ResumeLayout(False)
        Me.GB_AdditionalTiles.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.NUD_AdditionalTilesSouth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AdditionalTilesWest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AdditionalTilesEast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AdditionalTilesNorth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_Layers.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.GB_Preview.ResumeLayout(False)
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP_Layers.ResumeLayout(False)
        Me.TP_RouteVisualizer.ResumeLayout(False)
        Me.TC_Main.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ZoomBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OFD_ImportRoute As OpenFileDialog
    Friend WithEvents SFD_SaveImage As SaveFileDialog
    Friend WithEvents FBD_SaveLayersSeperately As FolderBrowserDialog
    Friend WithEvents ZoomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TilewidthDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TileheightDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RowcountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ColumncountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Data As Data
    Friend WithEvents TP_Layers As TabPage
    Friend WithEvents TP_RouteVisualizer As TabPage
    Friend WithEvents GB_Layers As GroupBox
    Friend WithEvents CLB_Layers As CheckedListBox
    Friend WithEvents GB_Route As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CMB_Zoom As ComboBox
    Friend WithEvents GB_AdditionalTiles As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents NUD_AdditionalTilesSouth As NumericUpDown
    Friend WithEvents NUD_AdditionalTilesWest As NumericUpDown
    Friend WithEvents NUD_AdditionalTilesEast As NumericUpDown
    Friend WithEvents NUD_AdditionalTilesNorth As NumericUpDown
    Friend WithEvents L_North As Label
    Friend WithEvents L_East As Label
    Friend WithEvents L_West As Label
    Friend WithEvents L_South As Label
    Friend WithEvents Btn_ResetAdditionalTiles As Button
    Friend WithEvents GB_Preview As GroupBox
    Friend WithEvents PB_Preview As PictureBox
    Friend WithEvents TC_Main As TabControl
    Friend WithEvents LayerBindingSource As BindingSource
    Friend WithEvents ZoomBindingSource As BindingSource
    Friend WithEvents ZoomDataGridView As DataGridView
    Friend WithEvents LayerDataGridView As DataGridView
    Friend WithEvents LayerBindingSource1 As BindingSource
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents RoutefileBindingSource As BindingSource
    Friend WithEvents DGV_Route As DataGridView
    Friend WithEvents CD_Main As ColorDialog
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TSPB_Progress As ToolStripProgressBar
    Friend WithEvents SaveAsImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveLayersSeparatelyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdatePreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TSSL_EscToAbort As ToolStripStatusLabel
    Friend WithEvents TSSL_Progress As ToolStripStatusLabel
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents SpeichernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents DataGridViewComboBoxColumnSymbol As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnSymbolWidth As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnSymbolHeight As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnSymbolColor As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents CMS_DGV_Route As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeselectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InvertSelectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RoutenSeparatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RoutenZusammenfassenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents OpenPathToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HilfeAnzeigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÜberToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomBindingSource1 As BindingSource
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Sortindex As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents TLP_Tiles As TableLayoutPanel
    Friend WithEvents DataGridViewTextBoxColumnVisibility As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnPath As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnRouteLineWidth As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnRouteColor As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnRouteAlpha As DataGridViewTextBoxColumn
    Friend WithEvents OFD_LayerWizard As OpenFileDialog
    Friend WithEvents LayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TilesWizardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Btn_Switch As Button
End Class

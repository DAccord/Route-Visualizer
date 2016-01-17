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
        Me.OFD_ImportRoute = New System.Windows.Forms.OpenFileDialog()
        Me.SFD_SaveImage = New System.Windows.Forms.SaveFileDialog()
        Me.FBD_SaveLayersSeperately = New System.Windows.Forms.FolderBrowserDialog()
        Me.OFD_OwnImage = New System.Windows.Forms.OpenFileDialog()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
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
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GB_Route = New System.Windows.Forms.GroupBox()
        Me.DGV_Route = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumnVisibility = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumnPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumnRouteLineWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumnRouteColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumnRouteAlpha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMS_DGV_Route = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlleAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlleAbwählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuswahlUmkehrenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SpeicherortÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoutefileBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GB_AdditionalTiles = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.NUD_AdditionalTilesSouth = New System.Windows.Forms.NumericUpDown()
        Me.NUD_AdditionalTilesWest = New System.Windows.Forms.NumericUpDown()
        Me.NUD_AdditionalTilesEast = New System.Windows.Forms.NumericUpDown()
        Me.NUD_AdditionalTilesNorth = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Btn_ResetAdditionalTiles = New System.Windows.Forms.Button()
        Me.GB_Layers = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.CMB_Zoom = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CLB_Layers = New System.Windows.Forms.CheckedListBox()
        Me.GB_Preview = New System.Windows.Forms.GroupBox()
        Me.PB_Preview = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.FBD_Layer = New System.Windows.Forms.FolderBrowserDialog()
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
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HilfeAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÜberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSSL_EscToAbort = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSL_Progress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSPB_Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ZoomBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage3.SuspendLayout()
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
        Me.TabPage1.SuspendLayout()
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
        Me.TabControl1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ZoomBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OFD_ImportRoute
        '
        Me.OFD_ImportRoute.Filter = "Unterstützte Formate|*.kml;*.gpx"
        Me.OFD_ImportRoute.Multiselect = True
        Me.OFD_ImportRoute.Title = "Bitte wähle die zu importierenden kml-Dateien"
        '
        'SFD_SaveImage
        '
        Me.SFD_SaveImage.Filter = "jpg-Datei|*.jpg|png-Datei|*.png|bmp-Datei|*.bmp|gif-Datei|*.gif|tif-Datei|*.tif"
        Me.SFD_SaveImage.Title = "Karte speichern"
        '
        'FBD_SaveLayersSeperately
        '
        Me.FBD_SaveLayersSeperately.Description = "Wähle den Ordner in welchem die einzelnen Dateien gespeichert werden sollen"
        '
        'OFD_OwnImage
        '
        Me.OFD_OwnImage.Filter = "Supported Graphics Types|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff"""
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(888, 560)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Ebenen"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer3.Size = New System.Drawing.Size(882, 554)
        Me.SplitContainer3.SplitterDistance = 276
        Me.SplitContainer3.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LayerDataGridView)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(882, 276)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ebenen"
        '
        'LayerDataGridView
        '
        Me.LayerDataGridView.AutoGenerateColumns = False
        Me.LayerDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LayerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LayerDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.Sortindex})
        Me.LayerDataGridView.DataSource = Me.LayerBindingSource
        Me.LayerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayerDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.LayerDataGridView.Location = New System.Drawing.Point(3, 23)
        Me.LayerDataGridView.Name = "LayerDataGridView"
        Me.LayerDataGridView.Size = New System.Drawing.Size(876, 250)
        Me.LayerDataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'Sortindex
        '
        Me.Sortindex.DataPropertyName = "Sortindex"
        Me.Sortindex.HeaderText = "Sortierindex"
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
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(882, 274)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Kacheln/Zoomstufen"
        '
        'ZoomDataGridView
        '
        Me.ZoomDataGridView.AutoGenerateColumns = False
        Me.ZoomDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ZoomDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ZoomDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ZoomDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn10})
        Me.ZoomDataGridView.DataSource = Me.ZoomBindingSource1
        Me.ZoomDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ZoomDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.ZoomDataGridView.Location = New System.Drawing.Point(3, 23)
        Me.ZoomDataGridView.Name = "ZoomDataGridView"
        Me.ZoomDataGridView.Size = New System.Drawing.Size(876, 248)
        Me.ZoomDataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LayerID"
        Me.DataGridViewTextBoxColumn4.DataSource = Me.LayerBindingSource1
        Me.DataGridViewTextBoxColumn4.DisplayMember = "Name"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ebene"
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
        Me.DataGridViewTextBoxColumn5.HeaderText = "Zoom"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Tilewidth"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Kachel-Breite"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Tileheight"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Kachel-Höhe"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Path"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Pfad"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'ZoomBindingSource1
        '
        Me.ZoomBindingSource1.DataMember = "Layer_Zoom"
        Me.ZoomBindingSource1.DataSource = Me.LayerBindingSource
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(888, 560)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Route Visualizer"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GB_Route)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(882, 554)
        Me.SplitContainer2.SplitterDistance = 282
        Me.SplitContainer2.TabIndex = 9
        '
        'GB_Route
        '
        Me.GB_Route.Controls.Add(Me.DGV_Route)
        Me.GB_Route.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_Route.Location = New System.Drawing.Point(0, 0)
        Me.GB_Route.Name = "GB_Route"
        Me.GB_Route.Size = New System.Drawing.Size(882, 282)
        Me.GB_Route.TabIndex = 1
        Me.GB_Route.TabStop = False
        Me.GB_Route.Text = "Route"
        '
        'DGV_Route
        '
        Me.DGV_Route.AutoGenerateColumns = False
        Me.DGV_Route.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGV_Route.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV_Route.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Route.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumnVisibility, Me.DataGridViewTextBoxColumnPath, Me.DataGridViewTextBoxColumnRouteLineWidth, Me.DataGridViewTextBoxColumnRouteColor, Me.DataGridViewTextBoxColumnRouteAlpha})
        Me.DGV_Route.ContextMenuStrip = Me.CMS_DGV_Route
        Me.DGV_Route.DataSource = Me.RoutefileBindingSource
        Me.DGV_Route.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_Route.Location = New System.Drawing.Point(3, 23)
        Me.DGV_Route.Name = "DGV_Route"
        Me.DGV_Route.Size = New System.Drawing.Size(876, 256)
        Me.DGV_Route.TabIndex = 0
        '
        'DataGridViewTextBoxColumnVisibility
        '
        Me.DataGridViewTextBoxColumnVisibility.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumnVisibility.DataPropertyName = "Visibility"
        Me.DataGridViewTextBoxColumnVisibility.HeaderText = "SB"
        Me.DataGridViewTextBoxColumnVisibility.Name = "DataGridViewTextBoxColumnVisibility"
        Me.DataGridViewTextBoxColumnVisibility.ToolTipText = "Sichtbarkeit"
        Me.DataGridViewTextBoxColumnVisibility.Width = 32
        '
        'DataGridViewTextBoxColumnPath
        '
        Me.DataGridViewTextBoxColumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumnPath.DataPropertyName = "Path"
        Me.DataGridViewTextBoxColumnPath.HeaderText = "Pfad"
        Me.DataGridViewTextBoxColumnPath.MinimumWidth = 100
        Me.DataGridViewTextBoxColumnPath.Name = "DataGridViewTextBoxColumnPath"
        '
        'DataGridViewTextBoxColumnRouteLineWidth
        '
        Me.DataGridViewTextBoxColumnRouteLineWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumnRouteLineWidth.DataPropertyName = "RouteLineWidth"
        Me.DataGridViewTextBoxColumnRouteLineWidth.HeaderText = "RLB"
        Me.DataGridViewTextBoxColumnRouteLineWidth.Name = "DataGridViewTextBoxColumnRouteLineWidth"
        Me.DataGridViewTextBoxColumnRouteLineWidth.ToolTipText = "Routenlinienbreite"
        Me.DataGridViewTextBoxColumnRouteLineWidth.Width = 59
        '
        'DataGridViewTextBoxColumnRouteColor
        '
        Me.DataGridViewTextBoxColumnRouteColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumnRouteColor.DataPropertyName = "RouteColor"
        Me.DataGridViewTextBoxColumnRouteColor.HeaderText = "RF"
        Me.DataGridViewTextBoxColumnRouteColor.Name = "DataGridViewTextBoxColumnRouteColor"
        Me.DataGridViewTextBoxColumnRouteColor.ToolTipText = "Routenfarbe"
        Me.DataGridViewTextBoxColumnRouteColor.Width = 50
        '
        'DataGridViewTextBoxColumnRouteAlpha
        '
        Me.DataGridViewTextBoxColumnRouteAlpha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumnRouteAlpha.DataPropertyName = "RouteAlpha"
        Me.DataGridViewTextBoxColumnRouteAlpha.HeaderText = "RA"
        Me.DataGridViewTextBoxColumnRouteAlpha.Name = "DataGridViewTextBoxColumnRouteAlpha"
        Me.DataGridViewTextBoxColumnRouteAlpha.ToolTipText = "Transparenz"
        Me.DataGridViewTextBoxColumnRouteAlpha.Width = 53
        '
        'CMS_DGV_Route
        '
        Me.CMS_DGV_Route.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlleAuswählenToolStripMenuItem, Me.AlleAbwählenToolStripMenuItem, Me.AuswahlUmkehrenToolStripMenuItem, Me.ToolStripMenuItem4, Me.SpeicherortÖffnenToolStripMenuItem})
        Me.CMS_DGV_Route.Name = "CMS_DGV_Route"
        Me.CMS_DGV_Route.Size = New System.Drawing.Size(177, 98)
        '
        'AlleAuswählenToolStripMenuItem
        '
        Me.AlleAuswählenToolStripMenuItem.Name = "AlleAuswählenToolStripMenuItem"
        Me.AlleAuswählenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AlleAuswählenToolStripMenuItem.Text = "Alle auswählen"
        '
        'AlleAbwählenToolStripMenuItem
        '
        Me.AlleAbwählenToolStripMenuItem.Name = "AlleAbwählenToolStripMenuItem"
        Me.AlleAbwählenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AlleAbwählenToolStripMenuItem.Text = "Alle abwählen"
        '
        'AuswahlUmkehrenToolStripMenuItem
        '
        Me.AuswahlUmkehrenToolStripMenuItem.Name = "AuswahlUmkehrenToolStripMenuItem"
        Me.AuswahlUmkehrenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AuswahlUmkehrenToolStripMenuItem.Text = "Auswahl umkehren"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(173, 6)
        '
        'SpeicherortÖffnenToolStripMenuItem
        '
        Me.SpeicherortÖffnenToolStripMenuItem.Name = "SpeicherortÖffnenToolStripMenuItem"
        Me.SpeicherortÖffnenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.SpeicherortÖffnenToolStripMenuItem.Text = "Speicherort öffnen"
        '
        'RoutefileBindingSource
        '
        Me.RoutefileBindingSource.DataMember = "Routefile"
        Me.RoutefileBindingSource.DataSource = Me.Data
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GB_Preview)
        Me.SplitContainer1.Size = New System.Drawing.Size(882, 268)
        Me.SplitContainer1.SplitterDistance = 386
        Me.SplitContainer1.TabIndex = 8
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GB_AdditionalTiles, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GB_Layers, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(386, 268)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GB_AdditionalTiles
        '
        Me.GB_AdditionalTiles.Controls.Add(Me.TableLayoutPanel3)
        Me.GB_AdditionalTiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_AdditionalTiles.Location = New System.Drawing.Point(195, 0)
        Me.GB_AdditionalTiles.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.GB_AdditionalTiles.Name = "GB_AdditionalTiles"
        Me.GB_AdditionalTiles.Size = New System.Drawing.Size(191, 268)
        Me.GB_AdditionalTiles.TabIndex = 3
        Me.GB_AdditionalTiles.TabStop = False
        Me.GB_AdditionalTiles.Text = "Zusätzliche Kacheln"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel3.Controls.Add(Me.NUD_AdditionalTilesSouth, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.NUD_AdditionalTilesWest, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.NUD_AdditionalTilesEast, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.NUD_AdditionalTilesNorth, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label5, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Btn_ResetAdditionalTiles, 0, 6)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 7
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(185, 242)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'NUD_AdditionalTilesSouth
        '
        Me.NUD_AdditionalTilesSouth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NUD_AdditionalTilesSouth.Location = New System.Drawing.Point(64, 129)
        Me.NUD_AdditionalTilesSouth.Name = "NUD_AdditionalTilesSouth"
        Me.NUD_AdditionalTilesSouth.Size = New System.Drawing.Size(55, 27)
        Me.NUD_AdditionalTilesSouth.TabIndex = 3
        '
        'NUD_AdditionalTilesWest
        '
        Me.NUD_AdditionalTilesWest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NUD_AdditionalTilesWest.Location = New System.Drawing.Point(3, 76)
        Me.NUD_AdditionalTilesWest.Name = "NUD_AdditionalTilesWest"
        Me.NUD_AdditionalTilesWest.Size = New System.Drawing.Size(55, 27)
        Me.NUD_AdditionalTilesWest.TabIndex = 1
        '
        'NUD_AdditionalTilesEast
        '
        Me.NUD_AdditionalTilesEast.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NUD_AdditionalTilesEast.Location = New System.Drawing.Point(125, 76)
        Me.NUD_AdditionalTilesEast.Name = "NUD_AdditionalTilesEast"
        Me.NUD_AdditionalTilesEast.Size = New System.Drawing.Size(57, 27)
        Me.NUD_AdditionalTilesEast.TabIndex = 2
        '
        'NUD_AdditionalTilesNorth
        '
        Me.NUD_AdditionalTilesNorth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NUD_AdditionalTilesNorth.Location = New System.Drawing.Point(64, 23)
        Me.NUD_AdditionalTilesNorth.Name = "NUD_AdditionalTilesNorth"
        Me.NUD_AdditionalTilesNorth.Size = New System.Drawing.Size(55, 27)
        Me.NUD_AdditionalTilesNorth.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nord"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(125, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ost"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "West"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(64, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Süd"
        '
        'Btn_ResetAdditionalTiles
        '
        Me.Btn_ResetAdditionalTiles.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Btn_ResetAdditionalTiles.AutoSize = True
        Me.TableLayoutPanel3.SetColumnSpan(Me.Btn_ResetAdditionalTiles, 3)
        Me.Btn_ResetAdditionalTiles.Location = New System.Drawing.Point(40, 162)
        Me.Btn_ResetAdditionalTiles.Name = "Btn_ResetAdditionalTiles"
        Me.Btn_ResetAdditionalTiles.Size = New System.Drawing.Size(105, 30)
        Me.Btn_ResetAdditionalTiles.TabIndex = 8
        Me.Btn_ResetAdditionalTiles.Text = "Zurücksetzen"
        Me.Btn_ResetAdditionalTiles.UseVisualStyleBackColor = True
        '
        'GB_Layers
        '
        Me.GB_Layers.Controls.Add(Me.TableLayoutPanel4)
        Me.GB_Layers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_Layers.Location = New System.Drawing.Point(0, 0)
        Me.GB_Layers.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.GB_Layers.Name = "GB_Layers"
        Me.GB_Layers.Size = New System.Drawing.Size(191, 268)
        Me.GB_Layers.TabIndex = 0
        Me.GB_Layers.TabStop = False
        Me.GB_Layers.Text = "Ebenen"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.CMB_Zoom, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.CLB_Layers, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(185, 242)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'CMB_Zoom
        '
        Me.CMB_Zoom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CMB_Zoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_Zoom.FormattingEnabled = True
        Me.CMB_Zoom.Location = New System.Drawing.Point(61, 211)
        Me.CMB_Zoom.Name = "CMB_Zoom"
        Me.CMB_Zoom.Size = New System.Drawing.Size(121, 28)
        Me.CMB_Zoom.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 215)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Zoom:"
        '
        'CLB_Layers
        '
        Me.CLB_Layers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CLB_Layers.CheckOnClick = True
        Me.TableLayoutPanel4.SetColumnSpan(Me.CLB_Layers, 2)
        Me.CLB_Layers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLB_Layers.FormattingEnabled = True
        Me.CLB_Layers.Location = New System.Drawing.Point(3, 3)
        Me.CLB_Layers.Name = "CLB_Layers"
        Me.CLB_Layers.Size = New System.Drawing.Size(179, 202)
        Me.CLB_Layers.TabIndex = 0
        '
        'GB_Preview
        '
        Me.GB_Preview.Controls.Add(Me.PB_Preview)
        Me.GB_Preview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_Preview.Location = New System.Drawing.Point(0, 0)
        Me.GB_Preview.Name = "GB_Preview"
        Me.GB_Preview.Size = New System.Drawing.Size(492, 268)
        Me.GB_Preview.TabIndex = 7
        Me.GB_Preview.TabStop = False
        Me.GB_Preview.Text = "Vorschau (Doppelkick für Originalgröße)"
        '
        'PB_Preview
        '
        Me.PB_Preview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB_Preview.Location = New System.Drawing.Point(3, 23)
        Me.PB_Preview.Name = "PB_Preview"
        Me.PB_Preview.Size = New System.Drawing.Size(486, 242)
        Me.PB_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_Preview.TabIndex = 6
        Me.PB_Preview.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(896, 593)
        Me.TabControl1.TabIndex = 1
        '
        'CD_Main
        '
        Me.CD_Main.Color = System.Drawing.Color.Red
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(896, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdatePreviewToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveAsImageToolStripMenuItem, Me.SaveLayersSeparatelyToolStripMenuItem, Me.ToolStripMenuItem2, Me.SpeichernToolStripMenuItem, Me.ToolStripMenuItem3, Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.FileToolStripMenuItem.Text = "&Karte"
        '
        'UpdatePreviewToolStripMenuItem
        '
        Me.UpdatePreviewToolStripMenuItem.Name = "UpdatePreviewToolStripMenuItem"
        Me.UpdatePreviewToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.UpdatePreviewToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.UpdatePreviewToolStripMenuItem.Text = "Vorscha&u aktualisieren"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(213, 6)
        '
        'SaveAsImageToolStripMenuItem
        '
        Me.SaveAsImageToolStripMenuItem.Name = "SaveAsImageToolStripMenuItem"
        Me.SaveAsImageToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsImageToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SaveAsImageToolStripMenuItem.Text = "Als &Bild speichern..."
        '
        'SaveLayersSeparatelyToolStripMenuItem
        '
        Me.SaveLayersSeparatelyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RoutenSeparatToolStripMenuItem, Me.RoutenZusammenfassenToolStripMenuItem})
        Me.SaveLayersSeparatelyToolStripMenuItem.Name = "SaveLayersSeparatelyToolStripMenuItem"
        Me.SaveLayersSeparatelyToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SaveLayersSeparatelyToolStripMenuItem.Text = "&Ebenen einzeln speichern"
        '
        'RoutenSeparatToolStripMenuItem
        '
        Me.RoutenSeparatToolStripMenuItem.Name = "RoutenSeparatToolStripMenuItem"
        Me.RoutenSeparatToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.RoutenSeparatToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.RoutenSeparatToolStripMenuItem.Text = "Routen separat..."
        '
        'RoutenZusammenfassenToolStripMenuItem
        '
        Me.RoutenZusammenfassenToolStripMenuItem.Name = "RoutenZusammenfassenToolStripMenuItem"
        Me.RoutenZusammenfassenToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.RoutenZusammenfassenToolStripMenuItem.Text = "Routen zusammenfassen..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(213, 6)
        '
        'SpeichernToolStripMenuItem
        '
        Me.SpeichernToolStripMenuItem.Name = "SpeichernToolStripMenuItem"
        Me.SpeichernToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SpeichernToolStripMenuItem.Text = "Daten &speichern"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(213, 6)
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.QuitToolStripMenuItem.Text = "B&eenden"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HilfeAnzeigenToolStripMenuItem, Me.ÜberToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Hilfe"
        '
        'HilfeAnzeigenToolStripMenuItem
        '
        Me.HilfeAnzeigenToolStripMenuItem.Name = "HilfeAnzeigenToolStripMenuItem"
        Me.HilfeAnzeigenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.HilfeAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.HilfeAnzeigenToolStripMenuItem.Text = "&Hilfe anzeigen (online)"
        '
        'ÜberToolStripMenuItem
        '
        Me.ÜberToolStripMenuItem.Name = "ÜberToolStripMenuItem"
        Me.ÜberToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.ÜberToolStripMenuItem.Text = "Über..."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSL_EscToAbort, Me.TSSL_Progress, Me.TSPB_Progress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 617)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(896, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TSSL_EscToAbort
        '
        Me.TSSL_EscToAbort.Name = "TSSL_EscToAbort"
        Me.TSSL_EscToAbort.Size = New System.Drawing.Size(718, 17)
        Me.TSSL_EscToAbort.Spring = True
        Me.TSSL_EscToAbort.Text = "Kartenerstellung läuft. Esc zum Abbrechen."
        Me.TSSL_EscToAbort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TSSL_EscToAbort.Visible = False
        '
        'TSSL_Progress
        '
        Me.TSSL_Progress.Name = "TSSL_Progress"
        Me.TSSL_Progress.Size = New System.Drawing.Size(61, 17)
        Me.TSSL_Progress.Text = "Fortschritt"
        Me.TSSL_Progress.Visible = False
        '
        'TSPB_Progress
        '
        Me.TSPB_Progress.Name = "TSPB_Progress"
        Me.TSPB_Progress.Size = New System.Drawing.Size(100, 16)
        Me.TSPB_Progress.Visible = False
        '
        'ZoomBindingSource
        '
        Me.ZoomBindingSource.DataMember = "Zoom"
        Me.ZoomBindingSource.DataSource = Me.Data
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(896, 639)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frm_Main"
        Me.Text = "Route Visualizer 0.1 beta"
        Me.TabPage3.ResumeLayout(False)
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
        Me.TabPage1.ResumeLayout(False)
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
        Me.TabControl1.ResumeLayout(False)
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
    Friend WithEvents OFD_OwnImage As OpenFileDialog
    Friend WithEvents ZoomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TilewidthDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TileheightDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RowcountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ColumncountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Data As Data
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage1 As TabPage
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
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Btn_ResetAdditionalTiles As Button
    Friend WithEvents GB_Preview As GroupBox
    Friend WithEvents PB_Preview As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents FBD_Layer As FolderBrowserDialog
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
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Sortindex As DataGridViewTextBoxColumn
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
    Friend WithEvents DataGridViewTextBoxColumnVisibility As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnPath As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnRouteLineWidth As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnRouteColor As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnRouteAlpha As DataGridViewTextBoxColumn
    Friend WithEvents CMS_DGV_Route As ContextMenuStrip
    Friend WithEvents AlleAuswählenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlleAbwählenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AuswahlUmkehrenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RoutenSeparatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RoutenZusammenfassenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents SpeicherortÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents HilfeAnzeigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÜberToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomBindingSource1 As BindingSource
End Class

﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Route_Visualizer.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to https://github.com/DAccord/Route-Visualizer/blob/master/README_EN.md.
        '''</summary>
        Friend ReadOnly Property About_GithubLinkToReadme() As String
            Get
                Return ResourceManager.GetString("About_GithubLinkToReadme", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Route Visualizer is a program to plot coordinates from kml or gpx files onto a map. This results in a highly resolved image file..
        '''</summary>
        Friend ReadOnly Property Assembly_Description() As String
            Get
                Return ResourceManager.GetString("Assembly_Description", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Select the directory where the single files should be saved.
        '''</summary>
        Friend ReadOnly Property FBD_SaveLayersSeperatelyDescription() As String
            Get
                Return ResourceManager.GetString("FBD_SaveLayersSeperatelyDescription", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to All columns have to be filled out..
        '''</summary>
        Friend ReadOnly Property Main_AllColumnsHaveToBeFilled() As String
            Get
                Return ResourceManager.GetString("Main_AllColumnsHaveToBeFilled", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Missing value.
        '''</summary>
        Friend ReadOnly Property Main_AllColumnsHaveToBeFilled_Title() As String
            Get
                Return ResourceManager.GetString("Main_AllColumnsHaveToBeFilled_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Creation of a map is still in progress. Do you really want to exit?.
        '''</summary>
        Friend ReadOnly Property Main_CancelMapCreation() As String
            Get
                Return ResourceManager.GetString("Main_CancelMapCreation", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Exit application?.
        '''</summary>
        Friend ReadOnly Property Main_CancelMapCreation_Title() As String
            Get
                Return ResourceManager.GetString("Main_CancelMapCreation_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Could not delete the temporary file {0}. If you want you can delete it manually..
        '''</summary>
        Friend ReadOnly Property Main_CouldntDeleteTemp() As String
            Get
                Return ResourceManager.GetString("Main_CouldntDeleteTemp", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Couldn&apos;t find tile {0}..
        '''</summary>
        Friend ReadOnly Property Main_CouldntFindTile_Path() As String
            Get
                Return ResourceManager.GetString("Main_CouldntFindTile_Path", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Could not import coordinates from file {0}..
        '''</summary>
        Friend ReadOnly Property Main_CouldntImportCoordinatesFromFile() As String
            Get
                Return ResourceManager.GetString("Main_CouldntImportCoordinatesFromFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The entered colour value must have the following format: R, G, B.
        '''</summary>
        Friend ReadOnly Property Main_EnteredColorValue() As String
            Get
                Return ResourceManager.GetString("Main_EnteredColorValue", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please enter numbers..
        '''</summary>
        Friend ReadOnly Property Main_EnterNumbers() As String
            Get
                Return ResourceManager.GetString("Main_EnterNumbers", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please enter the zoom value of the selected tile:.
        '''</summary>
        Friend ReadOnly Property Main_EnterZoomValue() As String
            Get
                Return ResourceManager.GetString("Main_EnterZoomValue", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The following error occured while trying to import coordinates from {0}:.
        '''</summary>
        Friend ReadOnly Property Main_ErrorWhileImporting() As String
            Get
                Return ResourceManager.GetString("Main_ErrorWhileImporting", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The following file could not be found: {0}..
        '''</summary>
        Friend ReadOnly Property Main_FileNotFound() As String
            Get
                Return ResourceManager.GetString("Main_FileNotFound", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Additional Tiles.
        '''</summary>
        Friend ReadOnly Property Main_GB_AdditionalTiles() As String
            Get
                Return ResourceManager.GetString("Main_GB_AdditionalTiles", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Absolute Indices.
        '''</summary>
        Friend ReadOnly Property Main_GB_RelativeIndices() As String
            Get
                Return ResourceManager.GetString("Main_GB_RelativeIndices", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to {0} during import of file {1}: {2}{3}{4}{5}{6}.
        '''</summary>
        Friend ReadOnly Property Main_GPXDeserError() As String
            Get
                Return ResourceManager.GetString("Main_GPXDeserError", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Import at least one route file before producing a map..
        '''</summary>
        Friend ReadOnly Property Main_ImportFile() As String
            Get
                Return ResourceManager.GetString("Main_ImportFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Import route file.
        '''</summary>
        Friend ReadOnly Property Main_ImportFile_Title() As String
            Get
                Return ResourceManager.GetString("Main_ImportFile_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to East.
        '''</summary>
        Friend ReadOnly Property Main_L_East() As String
            Get
                Return ResourceManager.GetString("Main_L_East", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Max. Col..
        '''</summary>
        Friend ReadOnly Property Main_L_MaxCol() As String
            Get
                Return ResourceManager.GetString("Main_L_MaxCol", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Max. Row.
        '''</summary>
        Friend ReadOnly Property Main_L_MaxRow() As String
            Get
                Return ResourceManager.GetString("Main_L_MaxRow", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Min. Col..
        '''</summary>
        Friend ReadOnly Property Main_L_MinCol() As String
            Get
                Return ResourceManager.GetString("Main_L_MinCol", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Min. Row.
        '''</summary>
        Friend ReadOnly Property Main_L_MinRow() As String
            Get
                Return ResourceManager.GetString("Main_L_MinRow", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to North.
        '''</summary>
        Friend ReadOnly Property Main_L_North() As String
            Get
                Return ResourceManager.GetString("Main_L_North", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to South.
        '''</summary>
        Friend ReadOnly Property Main_L_South() As String
            Get
                Return ResourceManager.GetString("Main_L_South", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to West.
        '''</summary>
        Friend ReadOnly Property Main_L_West() As String
            Get
                Return ResourceManager.GetString("Main_L_West", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Errors during image creation on {0} at {1}:.
        '''</summary>
        Friend ReadOnly Property Main_LogHeader() As String
            Get
                Return ResourceManager.GetString("Main_LogHeader", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to No coordinates could be imported from any of the selected files. Cancelled producing the map..
        '''</summary>
        Friend ReadOnly Property Main_NoCoordinates() As String
            Get
                Return ResourceManager.GetString("Main_NoCoordinates", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to There are no route files to plot. Possible reasons for that:{0}- The visibility of all route files is off.{0}- No route has a line width larger than zero..
        '''</summary>
        Friend ReadOnly Property Main_NoRoutesToPlot() As String
            Get
                Return ResourceManager.GetString("Main_NoRoutesToPlot", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to No route files to plot.
        '''</summary>
        Friend ReadOnly Property Main_NoRoutesToPlot_Title() As String
            Get
                Return ResourceManager.GetString("Main_NoRoutesToPlot_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to No tiles were found for layer {0} at zoom level {2}..
        '''</summary>
        Friend ReadOnly Property Main_NoTilesLayerZoom() As String
            Get
                Return ResourceManager.GetString("Main_NoTilesLayerZoom", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The numbers have to be within {0} and {1}..
        '''</summary>
        Friend ReadOnly Property Main_NumbersBetween() As String
            Get
                Return ResourceManager.GetString("Main_NumbersBetween", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Errors occured during image creation which were written to the log file {0}.{1}Do you want to open this file now?.
        '''</summary>
        Friend ReadOnly Property Main_OpenLog() As String
            Get
                Return ResourceManager.GetString("Main_OpenLog", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Errors during image creation.
        '''</summary>
        Friend ReadOnly Property Main_OpenLog_Title() As String
            Get
                Return ResourceManager.GetString("Main_OpenLog_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Finished image creation. Do you want to open the result directory?.
        '''</summary>
        Friend ReadOnly Property Main_OpenResultDirectory() As String
            Get
                Return ResourceManager.GetString("Main_OpenResultDirectory", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Open directory?.
        '''</summary>
        Friend ReadOnly Property Main_OpenResultDirectory_Title() As String
            Get
                Return ResourceManager.GetString("Main_OpenResultDirectory_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Finished image creation. Do you want to open the resulting file?.
        '''</summary>
        Friend ReadOnly Property Main_OpenResultFile() As String
            Get
                Return ResourceManager.GetString("Main_OpenResultFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Open file?.
        '''</summary>
        Friend ReadOnly Property Main_OpenResultFile_Title() As String
            Get
                Return ResourceManager.GetString("Main_OpenResultFile_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The path of the route with ID {0} is Nothing..
        '''</summary>
        Friend ReadOnly Property Main_PathNull() As String
            Get
                Return ResourceManager.GetString("Main_PathNull", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Row was added. Now you have to replace the column index in the path with {C}, the row index with {R} and the zoom value with {Z}..
        '''</summary>
        Friend ReadOnly Property Main_RowAddedReplace() As String
            Get
                Return ResourceManager.GetString("Main_RowAddedReplace", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Select at least one layer before producing a map..
        '''</summary>
        Friend ReadOnly Property Main_SelectLayer() As String
            Get
                Return ResourceManager.GetString("Main_SelectLayer", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Select layer.
        '''</summary>
        Friend ReadOnly Property Main_SelectLayer_Title() As String
            Get
                Return ResourceManager.GetString("Main_SelectLayer_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Select a zoom value before producing a map..
        '''</summary>
        Friend ReadOnly Property Main_SelectZoom() As String
            Get
                Return ResourceManager.GetString("Main_SelectZoom", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Select zoom value.
        '''</summary>
        Friend ReadOnly Property Main_SelectZoom_Title() As String
            Get
                Return ResourceManager.GetString("Main_SelectZoom_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The value in &quot;{0}&quot; has to be smaller than or equal the value in &quot;{1}&quot;..
        '''</summary>
        Friend ReadOnly Property Main_SmallerOrEqual() As String
            Get
                Return ResourceManager.GetString("Main_SmallerOrEqual", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The value has to be within {0} and {1}..
        '''</summary>
        Friend ReadOnly Property Main_ValueBetween() As String
            Get
                Return ResourceManager.GetString("Main_ValueBetween", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Values in the columns zoom, tile width and tile height have to be numeric..
        '''</summary>
        Friend ReadOnly Property Main_WrongInputFormat() As String
            Get
                Return ResourceManager.GetString("Main_WrongInputFormat", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The value in the sort index column has to be numeric..
        '''</summary>
        Friend ReadOnly Property Main_WrongInputFormat_2() As String
            Get
                Return ResourceManager.GetString("Main_WrongInputFormat_2", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Wrong input format.
        '''</summary>
        Friend ReadOnly Property Main_WrongInputFormat_Title() As String
            Get
                Return ResourceManager.GetString("Main_WrongInputFormat_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please enter an integer for the zoom value!.
        '''</summary>
        Friend ReadOnly Property Main_ZoomInteger() As String
            Get
                Return ResourceManager.GetString("Main_ZoomInteger", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to You did select an online layer, therefore it was tried to use tiles directly from the web. However, the selected zoom value exceeds the allowed value. Reduce the selected zoom value to {0} or less, reduce the additional tile numbers, the absolute tile indices or import your own local layers and select them. Or, try to continue using only cached tiles. Do you want to continue?.
        '''</summary>
        Friend ReadOnly Property Main_ZoomTooLarge() As String
            Get
                Return ResourceManager.GetString("Main_ZoomTooLarge", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Selected zoom too large.
        '''</summary>
        Friend ReadOnly Property Main_ZoomTooLarge_Title() As String
            Get
                Return ResourceManager.GetString("Main_ZoomTooLarge_Title", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please select a tile from the selected layer and with the desired zoom value and remember the zoom value and the row and column index..
        '''</summary>
        Friend ReadOnly Property Main_ZoomWizardIntro() As String
            Get
                Return ResourceManager.GetString("Main_ZoomWizardIntro", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Supported file types|*.gpx;*.kml|gpx files|*.gpx|kml files|*.kml.
        '''</summary>
        Friend ReadOnly Property OFD_ImportRouteFilter() As String
            Get
                Return ResourceManager.GetString("OFD_ImportRouteFilter", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please select the files you want to import.
        '''</summary>
        Friend ReadOnly Property OFD_ImportRouteTitle() As String
            Get
                Return ResourceManager.GetString("OFD_ImportRouteTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Supported file types|*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tif|bmp file|*.bmp|gif file|*.gif|jpg file|*.jpeg;*.jpg|png file|*.png|tif file|*.tif;*.tiff.
        '''</summary>
        Friend ReadOnly Property OFD_LayerWizardFilter() As String
            Get
                Return ResourceManager.GetString("OFD_LayerWizardFilter", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Image size (W x H): {0} px x {1} px.
        '''</summary>
        Friend ReadOnly Property Preview_ImageSize() As String
            Get
                Return ResourceManager.GetString("Preview_ImageSize", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Zoom: {0:p0}.
        '''</summary>
        Friend ReadOnly Property Preview_Zoom() As String
            Get
                Return ResourceManager.GetString("Preview_Zoom", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to jpg file|*.jpg|png file|*.png|bmp file|*.bmp|gif file|*.gif|tif file|*.tif.
        '''</summary>
        Friend ReadOnly Property SFD_SaveImageFilter() As String
            Get
                Return ResourceManager.GetString("SFD_SaveImageFilter", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Save Map.
        '''</summary>
        Friend ReadOnly Property SFD_SaveImageTitle() As String
            Get
                Return ResourceManager.GetString("SFD_SaveImageTitle", resourceCulture)
            End Get
        End Property
    End Module
End Namespace

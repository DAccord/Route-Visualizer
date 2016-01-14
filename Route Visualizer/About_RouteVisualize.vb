﻿Public NotInheritable Class About_RouteVisualize

    Private Sub About_RouteVisualize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Über {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        If My.Application.Info.Version.Major = 0 Then
            Me.LabelVersion.Text = "Route Visualizer v" & String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.Minor, My.Application.Info.Version.Build) & " beta"
        Else
            Me.LabelVersion.Text = "Route Visualizer v" & String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
        End If
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.L_Description.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LL_Github_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LL_Github.LinkClicked
        Process.Start("https://github.com/DAccord/Route-Visualizer")
    End Sub
End Class

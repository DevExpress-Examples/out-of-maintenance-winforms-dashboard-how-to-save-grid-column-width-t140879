Imports Microsoft.VisualBasic
Imports DevExpress.DashboardWin.Native
Imports DevExpress.XtraEditors
Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.Xml.Serialization

Namespace NewProject
	Partial Public Class Form1
		Inherits XtraForm
		Private Const LayoutFileName As String = "Grid_1_Layout.xml"
		Private xmlSerializer As New XmlSerializer(GetType(List(Of GridColumnLayoutWrapper)))

		Public Sub New()
			InitializeComponent()
			RestoreColumnWidths()
		End Sub

		Private Sub dashboardViewer1_DataLoading(ByVal sender As Object, ByVal e As DevExpress.DataAccess.DataLoadingEventArgs) Handles dashboardViewer1.DataLoading
			Dim list As List(Of [MyClass]) = CreateDataSource()
			e.Data = list
		End Sub
		Private Shared Function CreateDataSource() As List(Of [MyClass])
			Dim list As New List(Of [MyClass])(10)
			Dim _r As New Random()
			For i As Integer = 0 To list.Capacity - 1
				list.Add(New [MyClass]() With {.ID = i, .Name = "Name" & i, .Sales = CSng(_r.NextDouble()), .Date = DateTime.Now.AddDays(i)})
			Next i
			Return list
		End Function

		Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			SaveColumnWidths()
		End Sub

		Private Sub SaveColumnWidths()
			Dim grid As GridControl = CType((CType(dashboardViewer1, IUnderlyingControlProvider)).GetUnderlyingControl("gridDashboardItem1"), GridControl)
			Dim view As GridView = CType(grid.MainView, GridView)
			Using stream As Stream = New FileStream(LayoutFileName, FileMode.Create)
				xmlSerializer.Serialize(stream, view.VisibleColumns.OfType(Of GridColumn)().Select(Function(c) New GridColumnLayoutWrapper() With {.FieldName = c.FieldName, .Width = c.Width}).ToList())
			End Using
		End Sub
		Private Sub RestoreColumnWidths()
			Dim grid As GridControl = CType((CType(dashboardViewer1, IUnderlyingControlProvider)).GetUnderlyingControl("gridDashboardItem1"), GridControl)
			If File.Exists(LayoutFileName) Then
				Using stream As Stream = New FileStream(LayoutFileName, FileMode.Open)
					Dim columnWrappers As List(Of GridColumnLayoutWrapper) = CType(xmlSerializer.Deserialize(stream), List(Of GridColumnLayoutWrapper))
					For Each columnWrapper As GridColumnLayoutWrapper In columnWrappers
						CType(grid.MainView, GridView).Columns(columnWrapper.FieldName).Width = columnWrapper.Width
					Next columnWrapper
				End Using
			End If
		End Sub
	End Class
End Namespace
Imports Microsoft.VisualBasic
Imports System
Namespace NewProject
	Partial Public Class Dashboard1
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim measure1 As New DevExpress.DashboardCommon.Measure()
			Dim gridMeasureColumn1 As New DevExpress.DashboardCommon.GridMeasureColumn()
			Dim dimension1 As New DevExpress.DashboardCommon.Dimension()
			Dim gridDimensionColumn1 As New DevExpress.DashboardCommon.GridDimensionColumn()
			Dim dashboardLayoutGroup1 As New DevExpress.DashboardCommon.DashboardLayoutGroup()
			Dim dashboardLayoutItem1 As New DevExpress.DashboardCommon.DashboardLayoutItem()
			Me.gridDashboardItem1 = New DevExpress.DashboardCommon.GridDashboardItem()
			Me.dataSource1 = New DevExpress.DashboardCommon.DataSource()
			Me.bindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
			CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(measure1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' gridDashboardItem1
			' 
			measure1.DataMember = "ID"
			gridMeasureColumn1.AddDataItem("Measure", measure1)
			dimension1.DataMember = "Name"
			gridDimensionColumn1.AddDataItem("Dimension", dimension1)
			Me.gridDashboardItem1.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() { gridMeasureColumn1, gridDimensionColumn1})
			Me.gridDashboardItem1.ComponentName = "gridDashboardItem1"
			Me.gridDashboardItem1.DataItemRepository.Clear()
			Me.gridDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0")
			Me.gridDashboardItem1.DataItemRepository.Add(measure1, "DataItem1")
			Me.gridDashboardItem1.DataSource = Me.dataSource1
			Me.gridDashboardItem1.IgnoreMasterFilters = False
			Me.gridDashboardItem1.Name = "Grid 1"
			Me.gridDashboardItem1.ShowCaption = True
			' 
			' dataSource1
			' 
			Me.dataSource1.ComponentName = "dataSource1"
			Me.dataSource1.Data = Me.bindingSource1
			Me.dataSource1.DataProcessingMode = DevExpress.DashboardCommon.DataProcessingMode.Client
			Me.dataSource1.Name = "Data Source 1"
			' 
			' bindingSource1
			' 
			Me.bindingSource1.DataSource = GetType(NewProject.MyClass)
			' 
			' Dashboard1
			' 
			Me.DataSources.AddRange(New DevExpress.DashboardCommon.DataSource() { Me.dataSource1})
			Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() { Me.gridDashboardItem1})
			dashboardLayoutItem1.DashboardItem = Me.gridDashboardItem1
			dashboardLayoutItem1.Weight = 50R
			dashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() { dashboardLayoutItem1})
			Me.LayoutRoot = dashboardLayoutGroup1
			Me.Title.Text = "Dashboard"
			CType(measure1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(dimension1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

		#End Region

		Private dataSource1 As DevExpress.DashboardCommon.DataSource
		Private bindingSource1 As System.Windows.Forms.BindingSource
		Private gridDashboardItem1 As DevExpress.DashboardCommon.GridDashboardItem
	End Class
End Namespace

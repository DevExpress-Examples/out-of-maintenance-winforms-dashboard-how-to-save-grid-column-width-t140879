using DevExpress.DashboardWin.Native;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Xml.Serialization;

namespace NewProject
{
    public partial class Form1 : XtraForm
    {
        private const string LayoutFileName = "Grid_1_Layout.xml";
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<GridColumnLayoutWrapper>));

        public Form1()
        {
            InitializeComponent();
            RestoreColumnWidths();
        }

        private void dashboardViewer1_DataLoading(object sender, DevExpress.DataAccess.DataLoadingEventArgs e)
        {
            List<MyClass> list = CreateDataSource();
            e.Data = list;
        }
        private static List<MyClass> CreateDataSource()
        {
            List<MyClass> list = new List<MyClass>(10);
            Random _r = new Random();
            for (int i = 0; i < list.Capacity; i++)
                list.Add(new MyClass() { ID = i, Name = "Name" + i, Sales = (float)_r.NextDouble(), Date = DateTime.Now.AddDays(i) });
            return list;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveColumnWidths();
        }

        private void SaveColumnWidths()
        {
            GridControl grid = (GridControl)((IUnderlyingControlProvider)dashboardViewer1).GetUnderlyingControl("gridDashboardItem1");
            GridView view = (GridView)grid.MainView;
            using (Stream stream = new FileStream(LayoutFileName, FileMode.Create))
                xmlSerializer.Serialize(stream, view.VisibleColumns.OfType<GridColumn>().Select(c => new GridColumnLayoutWrapper() { FieldName = c.FieldName, Width = c.Width }).ToList());
        }
        private void RestoreColumnWidths()
        {
            GridControl grid = (GridControl)((IUnderlyingControlProvider)dashboardViewer1).GetUnderlyingControl("gridDashboardItem1");
            if (File.Exists(LayoutFileName))
                using (Stream stream = new FileStream(LayoutFileName, FileMode.Open))
                {
                    List<GridColumnLayoutWrapper> columnWrappers = (List<GridColumnLayoutWrapper>)xmlSerializer.Deserialize(stream);
                    foreach (GridColumnLayoutWrapper columnWrapper in columnWrappers)
                        ((GridView)grid.MainView).Columns[columnWrapper.FieldName].Width = columnWrapper.Width;
                }
        }
    }
}
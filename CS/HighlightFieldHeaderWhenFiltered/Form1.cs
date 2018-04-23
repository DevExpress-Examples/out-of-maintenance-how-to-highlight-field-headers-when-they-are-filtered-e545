using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using System.Reflection;

namespace HighlightFieldHeaderWhenFiltered {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            SetupPivot(pivotGridControl1);
        }

        private void SetupPivot(PivotGridControl grid) {
            DataTable Table = new DataTable();
            Table.Columns.Add("Category Name", typeof(string));
            Table.Columns.Add("Product Name", typeof(string));
            Table.Columns.Add("Year", typeof(int));
            Table.Columns.Add("Sale", typeof(float));
            Table.Columns.Add("Quantity", typeof(int));
            Table.Columns.Add("Employee Name", typeof(string));

            Table.Rows.Add(new object[] { "Beverages", "Chai", 1995, 5070.60, 319, null });
            Table.Rows.Add(new object[] { "Beverages", "Chai", 1996, 6295.50, 399, null });
            Table.Rows.Add(new object[] { "Beverages", "Ipoh Coffee", 1995, 10034.90, 228, null });
            Table.Rows.Add(new object[] { "Beverages", "Ipoh Coffee", 1996, 8560.60, 216, null });
            Table.Rows.Add(new object[] { "Confections", "Chocolade", 1995, 1282.01, 130, null });
            Table.Rows.Add(new object[] { "Confections", "Chocolade", 1996, 86.70, 8, null });
            Table.Rows.Add(new object[] { "Confections", "Scottish Longbreads", 1995, 3909.00, 380, null });
            Table.Rows.Add(new object[] { "Confections", "Scottish Longbreads", 1996, 4175.00, 354, null });

            grid.DataSource = new BindingSource(Table, "");

            grid.Fields.Add("Category Name", PivotArea.RowArea);
            grid.Fields.Add("Product Name", PivotArea.RowArea);
            grid.Fields.Add("Year", PivotArea.ColumnArea);
            grid.Fields.Add("Sale", PivotArea.DataArea);
            grid.Fields.Add("Employee Name", PivotArea.FilterArea);
            grid.Fields["Category Name"].Width = 120;
            grid.Fields["Product Name"].Width = 120;
            grid.Fields["Year"].Width = 70;
            grid.Fields["Sale"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grid.Fields["Sale"].CellFormat.FormatString = "c";

            grid.Fields["Category Name"].FilterValues.ValuesIncluded = new string[] { "Beverages" };
        }

        private void pivotGridControl1_CustomDrawFieldHeader(object sender, PivotCustomDrawFieldHeaderEventArgs e) {
            if(!e.Field.FilterValues.IsEmpty 
                && e.Info.State == DevExpress.Utils.Drawing.ObjectState.Normal)
                e.Info.State = DevExpress.Utils.Drawing.ObjectState.Hot;
        }
    }
}
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid
Imports System.Reflection

Namespace HighlightFieldHeaderWhenFiltered
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			SetupPivot(pivotGridControl1)
		End Sub

		Private Sub SetupPivot(ByVal grid As PivotGridControl)
			Dim Table As New DataTable()
			Table.Columns.Add("Category Name", GetType(String))
			Table.Columns.Add("Product Name", GetType(String))
			Table.Columns.Add("Year", GetType(Integer))
			Table.Columns.Add("Sale", GetType(Single))
			Table.Columns.Add("Quantity", GetType(Integer))
			Table.Columns.Add("Employee Name", GetType(String))

			Table.Rows.Add(New Object() { "Beverages", "Chai", 1995, 5070.60, 319, Nothing })
			Table.Rows.Add(New Object() { "Beverages", "Chai", 1996, 6295.50, 399, Nothing })
			Table.Rows.Add(New Object() { "Beverages", "Ipoh Coffee", 1995, 10034.90, 228, Nothing })
			Table.Rows.Add(New Object() { "Beverages", "Ipoh Coffee", 1996, 8560.60, 216, Nothing })
			Table.Rows.Add(New Object() { "Confections", "Chocolade", 1995, 1282.01, 130, Nothing })
			Table.Rows.Add(New Object() { "Confections", "Chocolade", 1996, 86.70, 8, Nothing })
			Table.Rows.Add(New Object() { "Confections", "Scottish Longbreads", 1995, 3909.00, 380, Nothing })
			Table.Rows.Add(New Object() { "Confections", "Scottish Longbreads", 1996, 4175.00, 354, Nothing })

			grid.DataSource = New BindingSource(Table, "")

			grid.Fields.Add("Category Name", PivotArea.RowArea)
			grid.Fields.Add("Product Name", PivotArea.RowArea)
			grid.Fields.Add("Year", PivotArea.ColumnArea)
			grid.Fields.Add("Sale", PivotArea.DataArea)
			grid.Fields.Add("Employee Name", PivotArea.FilterArea)
			grid.Fields("Category Name").Width = 120
			grid.Fields("Product Name").Width = 120
			grid.Fields("Year").Width = 70
			grid.Fields("Sale").CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			grid.Fields("Sale").CellFormat.FormatString = "c"

			grid.Fields("Category Name").FilterValues.ValuesIncluded = New String() { "Beverages" }
		End Sub

		Private Sub pivotGridControl1_CustomDrawFieldHeader(ByVal sender As Object, ByVal e As PivotCustomDrawFieldHeaderEventArgs) Handles pivotGridControl1.CustomDrawFieldHeader
			If (Not e.Field.FilterValues.IsEmpty) AndAlso e.Info.State = DevExpress.Utils.Drawing.ObjectState.Normal Then
				e.Info.State = DevExpress.Utils.Drawing.ObjectState.Hot
			End If
		End Sub
	End Class
End Namespace
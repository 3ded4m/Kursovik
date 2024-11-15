using System;
using System.Linq;
using System.Windows;
using System.Data;
using System.IO;
using OfficeOpenXml;
using System.ComponentModel;

namespace HRD
{
    public partial class TenureReportWindow : Window
    {
        public TenureReportWindow()
        {
            InitializeComponent();
            LoadTenureData();
        }

        private void LoadTenureData()
        {
            using (var context = new user96_dbEntities1())
            {
                var tenureData = context.KU_EmployeeProfessionalData
                    .Select(e => new
                    {
                        e.EmployeeID,
                        FullName = e.KU_Employees.FirstName + " " + e.KU_Employees.LastName,
                        e.HireDate,
                        TenureYears = e.HireDate.HasValue ? DateTime.Now.Year - e.HireDate.Value.Year : 0
                    })
                    .ToList();

                TenureDataGrid.ItemsSource = tenureData;
            }
        }


        private void ExportToExcelButton_Click(object sender, RoutedEventArgs e)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("ФИО");
            dataTable.Columns.Add("Дата поступления");
            dataTable.Columns.Add("Стаж (лет)");

            foreach (var item in TenureDataGrid.Items)
            {
                dynamic row = item;
                dataTable.Rows.Add(row.EmployeeID, row.FullName, row.HireDate.ToShortDateString(), row.TenureYears);
            }

            SaveToExcel(dataTable);
        }

        private void SaveToExcel(DataTable dataTable)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Установка лицензии

            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Стаж сотрудников");
                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = "Стаж сотрудников.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        package.SaveAs(stream);
                    }

                    MessageBox.Show("Данные успешно сохранены в Excel.");
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

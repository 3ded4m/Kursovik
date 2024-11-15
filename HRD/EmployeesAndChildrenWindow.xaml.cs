using System;
using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class EmployeesAndChildrenWindow : Window
    {
        public EmployeesAndChildrenWindow()
        {
            InitializeComponent();
            LoadEmployeesWithChildren();
        }

        private void LoadEmployeesWithChildren()
        {
            using (var context = new user96_dbEntities1())
            {
                var employeesWithChildren = context.KU_EmployeeChildren
                    .Where(c => DateTime.Now.Year - c.BirthYear < 14)
                    .Select(c => new
                    {
                        c.EmployeeID,
                        FullName = c.KU_Employees.FirstName + " " + c.KU_Employees.LastName,
                        c.ChildName,
                        ChildAge = DateTime.Now.Year - c.BirthYear
                    })
                    .ToList();

                EmployeesChildrenDataGrid.ItemsSource = employeesWithChildren;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

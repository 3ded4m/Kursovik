using System;
using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class AddChildWindow : Window
    {
        public AddChildWindow()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            using (var context = new user96_dbEntities1())
            {
                var employees = context.KU_Employees
                    .Select(e => new { e.EmployeeID, FullName = e.FirstName + " " + e.LastName })
                    .ToList();
                EmployeeComboBox.ItemsSource = employees;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите сотрудника.");
                return;
            }

            if (!int.TryParse(BirthYearTextBox.Text, out int birthYear))
            {
                MessageBox.Show("Введите корректный год рождения.");
                return;
            }

            using (var context = new user96_dbEntities1())
            {
                var newChild = new KU_EmployeeChildren
                {
                    EmployeeID = (int)EmployeeComboBox.SelectedValue,
                    ChildName = ChildNameTextBox.Text,
                    BirthYear = birthYear,
                    School = SchoolTextBox.Text
                };

                context.KU_EmployeeChildren.Add(newChild);
                context.SaveChanges();

                MessageBox.Show("Ребенок добавлен.");
                this.DialogResult = true;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

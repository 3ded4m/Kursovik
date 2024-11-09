using System.Windows;
using System.Windows.Controls;

namespace HRD
{
    public partial class EditEmployeeWindow : Window
    {
        private int employeeId;

        public EditEmployeeWindow(int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            using (var context = new user96_dbEntities1())
            {
                var employee = context.KU_Employees.Find(employeeId);
                if (employee != null)
                {
                    FirstNameTextBox.Text = employee.FirstName;
                    LastNameTextBox.Text = employee.LastName;
                    StatusComboBox.SelectedItem = employee.EmploymentStatus == "Уволен" ? "Уволен" : "Работает";
                }
                else
                {
                    MessageBox.Show("Сотрудник не найден.");
                    this.Close();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user96_dbEntities1())
            {
                var employee = context.KU_Employees.Find(employeeId);
                if (employee != null)
                {
                    employee.FirstName = FirstNameTextBox.Text;
                    employee.LastName = LastNameTextBox.Text;
                    employee.EmploymentStatus = ((ComboBoxItem)StatusComboBox.SelectedItem).Content.ToString();

                    context.SaveChanges();
                    MessageBox.Show("Изменения сохранены.");
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Сотрудник не найден.");
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

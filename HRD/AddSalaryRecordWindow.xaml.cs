using System;
using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class AddSalaryRecordWindow : Window
    {
        private KU_Users currentUser;

        public AddSalaryRecordWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            using (var context = new user96_dbEntities1())
            {
                var employees = context.KU_Employees
                    .Select(e => new { e.EmployeeID, Name = e.FirstName + " " + e.LastName })
                    .ToList();

                EmployeeComboBox.ItemsSource = employees;
                EmployeeComboBox.DisplayMemberPath = "Name";
                EmployeeComboBox.SelectedValuePath = "EmployeeID";
            }
        }

        private void AddSalaryRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedItem == null || string.IsNullOrEmpty(SalaryAmountTextBox.Text) || SalaryDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            using (var context = new user96_dbEntities1())
            {
                var salaryRecord = new KU_SalaryHistory
                {
                    EmployeeID = (int)EmployeeComboBox.SelectedValue,
                    SalaryAmount = decimal.Parse(SalaryAmountTextBox.Text),
                    SalaryDate = SalaryDatePicker.SelectedDate.Value,
                    Note = NoteTextBox.Text
                };

                context.KU_SalaryHistory.Add(salaryRecord);
                context.SaveChanges();
            }

            MessageBox.Show("Запись о зарплате добавлена.");
            this.Close();
        }
    }
}

using System;
using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class AddLeaveRequestWindow : Window
    {
        private KU_Users currentUser;

        public AddLeaveRequestWindow(KU_Users user)
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

        private void AddLeaveRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedItem == null || StartDatePicker.SelectedDate == null || EndDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            using (var context = new user96_dbEntities1())
            {
                var leaveRequest = new KU_LeaveRequests
                {
                    EmployeeID = (int)EmployeeComboBox.SelectedValue,
                    StartDate = StartDatePicker.SelectedDate.Value,
                    EndDate = EndDatePicker.SelectedDate.Value,
                    RequestDate = DateTime.Now // При необходимости добавить текущую дату заявки
                };

                context.KU_LeaveRequests.Add(leaveRequest);
                context.SaveChanges();
            }

            MessageBox.Show("Заявка добавлена.");
        }

    }
}

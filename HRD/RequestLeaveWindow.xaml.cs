using System;
using System.Windows;

namespace HRD
{
    public partial class RequestLeaveWindow : Window
    {
        private KU_Users currentUser;

        public RequestLeaveWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
        }

        // Обработчик для отправки запроса на отпуск
        private void SubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate == null || EndDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, выберите даты начала и окончания отпуска.");
                return;
            }

            if (EndDatePicker.SelectedDate <= StartDatePicker.SelectedDate)
            {
                MessageBox.Show("Дата окончания должна быть позже даты начала.");
                return;
            }

            using (var context = new user96_dbEntities1())
            {
                var leaveRequest = new KU_LeaveRequests
                {
                    EmployeeID = currentUser.EmployeeID,
                    StartDate = StartDatePicker.SelectedDate.Value,
                    EndDate = EndDatePicker.SelectedDate.Value,
                    Status = "В ожидании"
                };

                context.KU_LeaveRequests.Add(leaveRequest);
                context.SaveChanges();
            }

            MessageBox.Show("Запрос на отпуск отправлен.");
            this.Close();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрываем текущее окно и возвращаемся к предыдущему
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Закрываем приложение
        }

    }
}

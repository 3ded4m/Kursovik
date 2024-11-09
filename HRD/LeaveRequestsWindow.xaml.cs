using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace HRD
{
    public partial class LeaveRequestsWindow : Window
    {
        private KU_Users currentUser;

        public LeaveRequestsWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadLeaveRequests();
        }

        // Загрузка заявок на отпуск из базы данных
        private void LoadLeaveRequests()
        {
            using (var context = new user96_dbEntities1())
            {
                var leaveRequests = context.KU_LeaveRequests
                    .Include(l => l.KU_Employees)
                    .Select(l => new
                    {
                        l.RequestID,
                        l.KU_Employees.LastName,
                        l.KU_Employees.FirstName,
                        l.StartDate,
                        l.EndDate,
                        l.Status
                    })
                    .ToList();

                LeaveRequestsDataGrid.ItemsSource = leaveRequests;
            }
        }

        // Обработчик для кнопки "Редактировать"
        private void EditLeaveRequest_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = (dynamic)LeaveRequestsDataGrid.SelectedItem;
            if (selectedRequest == null) return;

            int requestId = selectedRequest.RequestID;

            // Открытие окна для редактирования заявки
            var editLeaveRequestWindow = new EditLeaveRequestWindow(requestId);
            editLeaveRequestWindow.ShowDialog();

            LoadLeaveRequests(); // Обновление данных после редактирования
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(currentUser);
            mainWindow.Show();
            this.Close();
        }



        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

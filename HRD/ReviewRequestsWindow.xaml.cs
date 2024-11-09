using System;
using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class ReviewRequestsWindow : Window
    {
        private user96_dbEntities1 context = new user96_dbEntities1();

        public ReviewRequestsWindow()
        {
            InitializeComponent();
            LoadRequests();
        }

        // Метод для загрузки обращений в DataGrid
        private void LoadRequests()
        {
            var requests = context.KU_HRRequests
                .Select(r => new RequestData
                {
                    RequestID = r.RequestID,
                    EmployeeName = r.KU_Employees.FirstName + " " + r.KU_Employees.LastName,
                    Subject = r.Subject,
                    Description = r.Description,
                    Status = r.Status,
                    RequestDate = r.RequestDate ?? DateTime.MinValue // Задаем значение по умолчанию для DateTime
                })
                .ToList();

            RequestsDataGrid.ItemsSource = requests;
        }


        // Обработчик кнопки "Рассмотреть"
        private void ReviewRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsDataGrid.SelectedItem is RequestData selectedRequest)
            {
                var request = context.KU_HRRequests.FirstOrDefault(r => r.RequestID == selectedRequest.RequestID);
                if (request != null)
                {
                    request.Status = "Рассмотрен";
                    context.SaveChanges();
                    LoadRequests();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите обращение для рассмотрения.");
            }
        }

        // Обработчик кнопки "Отклонить"
        private void RejectRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsDataGrid.SelectedItem is RequestData selectedRequest)
            {
                var request = context.KU_HRRequests.FirstOrDefault(r => r.RequestID == selectedRequest.RequestID);
                if (request != null)
                {
                    request.Status = "Отклонено";
                    context.SaveChanges();
                    LoadRequests();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите обращение для отклонения.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    // Вспомогательный класс для привязки данных в DataGrid
    public class RequestData
    {
        public int RequestID { get; set; }
        public string EmployeeName { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }
    }
}

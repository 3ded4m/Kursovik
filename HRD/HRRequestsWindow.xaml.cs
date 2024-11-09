using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HRD
{
    public partial class HRRequestsWindow : Window
    {
        private KU_Users currentUser;

        public HRRequestsWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadHRRequests();
        }

        // Метод для загрузки истории запросов
        private void LoadHRRequests()
        {
            using (var context = new user96_dbEntities1())
            {
                var requests = context.KU_HRRequests
                    .Where(r => r.EmployeeID == currentUser.EmployeeID)
                    .Select(r => new
                    {
                        r.RequestID,
                        r.Subject,
                        r.Description,
                        r.Status,
                        r.RequestDate
                    })
                    .ToList();

                RequestsListView.ItemsSource = requests;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                // Очистить текст при фокусе, если это начальный текст
                if (textBox.Text == "Тема" || textBox.Text == "Описание")
                {
                    textBox.Text = string.Empty;
                    textBox.Foreground = new SolidColorBrush(Colors.Black); // Устанавливаем цвет текста в стандартный
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                // Если поле пустое после потери фокуса, восстанавливаем начальный текст
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (textBox.Name == "SubjectTextBox")
                    {
                        textBox.Text = "Тема";
                    }
                    else if (textBox.Name == "DescriptionTextBox")
                    {
                        textBox.Text = "Описание";
                    }
                    textBox.Foreground = new SolidColorBrush(Colors.Gray); // Устанавливаем серый цвет для начального текста
                }
            }
        }


        // Метод для создания нового запроса
        private void CreateRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SubjectTextBox.Text) || string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            using (var context = new user96_dbEntities1())
            {
                var newRequest = new KU_HRRequests
                {
                    EmployeeID = currentUser.EmployeeID,
                    Subject = SubjectTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Status = "На рассмотрении",
                    RequestDate = DateTime.Now
                };

                context.KU_HRRequests.Add(newRequest);
                context.SaveChanges();
            }

            MessageBox.Show("Запрос создан.");
            LoadHRRequests(); // Обновить историю запросов
        }
    }
}

using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HRD
{
    public partial class EmployeeMainWindow : Window
    {
        private KU_Users currentUser;

        public EmployeeMainWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadEmployeeInformation();
            CheckLeaveNotifications();

            this.Loaded += EmployeeMainWindow_Loaded;
        }

        // Обработчик события Loaded
        private async void EmployeeMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await DisplayEmployeeOfTheMonthAsync();
        }


        // Загрузка информации о текущем сотруднике
        private void LoadEmployeeInformation()
        {
            if (currentUser?.KU_Employees != null)
            {
                EmployeeNameTextBlock.Text = $"{currentUser.KU_Employees.FirstName} {currentUser.KU_Employees.LastName}";
            }
            else
            {
                EmployeeNameTextBlock.Text = "Сотрудник не найден";
            }
        }

        // Метод для проверки уведомлений о подтверждении отпуска
        private void CheckLeaveNotifications()
        {
            using (var context = new user96_dbEntities1())
            {
                var approvedLeave = context.KU_LeaveRequests
                    .Where(l => l.EmployeeID == currentUser.EmployeeID && l.Status == "Принято" && (l.IsNotified ?? false) == false)
                    .ToList();


                if (approvedLeave.Any())
                {
                    NotificationTextBlock.Text = "Ваш отпуск был одобрен!";
                    NotificationTextBlock.Visibility = Visibility.Visible;

                    // Обновляем статус уведомления для этих заявок
                    foreach (var leave in approvedLeave)
                    {
                        leave.IsNotified = true;
                    }

                    context.SaveChanges();
                }
            }
        }

        // Метод для отображения "Работника месяца"
        private async Task DisplayEmployeeOfTheMonthAsync()
        {
            using (var context = new user96_dbEntities1())
            {
                // Получаем первый день и последний день предыдущего месяца
                var previousMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
                var previousMonthEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);

                // Находим работника месяца за предыдущий месяц независимо от точной даты
                var employeeOfTheMonth = await context.KU_EmployeeOfTheMonth
                    .Where(e => e.MonthAssigned >= previousMonthStart && e.MonthAssigned <= previousMonthEnd)
                    .Select(e => new
                    {
                        e.KU_Employees.FirstName,
                        e.KU_Employees.LastName,
                        Position = e.KU_Employees.KU_EmployeeProfessionalData.FirstOrDefault().Position
                    })
                    .FirstOrDefaultAsync();

                // Проверяем, нашли ли мы запись, и отображаем информацию
                if (employeeOfTheMonth != null)
                {
                    EmployeeOfTheMonthTextBlock.Text = $"{employeeOfTheMonth.FirstName} {employeeOfTheMonth.LastName}\n" +
                                                       $"Должность: {employeeOfTheMonth.Position ?? "Не указано"}";
                }
                else
                {
                    EmployeeOfTheMonthTextBlock.Text = "Нет данных о работнике месяца за предыдущий месяц";
                }
            }
        }




        // Обработчик для кнопки "Посмотреть историю зарплат"
        private void ViewSalaryHistory_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно с историей зарплат
            var salaryHistoryWindow = new SalaryHistoryWindow(currentUser);
            salaryHistoryWindow.Show();
        }

        // Обработчик для кнопки "Запрос на отпуск"
        private void RequestLeave_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно для запроса на отпуск
            var requestLeaveWindow = new RequestLeaveWindow(currentUser);
            requestLeaveWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Возвращение на окно авторизации
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ViewTasks_Click(object sender, RoutedEventArgs e)
        {
            var tasksViewWindow = new TasksViewWindow(currentUser); // Передаем текущего пользователя в окно задач
            tasksViewWindow.Show();
        }

        private void ViewLeaveBalance_Click(object sender, RoutedEventArgs e)
        {
            var leaveBalanceWindow = new LeaveBalanceWindow(currentUser);
            leaveBalanceWindow.ShowDialog();
        }

        private void ViewHRRequests_Click(object sender, RoutedEventArgs e)
        {
            var hrRequestsWindow = new HRRequestsWindow(currentUser);
            hrRequestsWindow.ShowDialog();
        }

    }
}

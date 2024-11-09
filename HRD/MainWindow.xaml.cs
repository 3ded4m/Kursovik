using System.Windows;
using System.Data.Entity;
using System.Linq;

namespace HRD
{
    public partial class MainWindow : Window
    {
        private KU_Users currentUser;

        private KU_Users GetUserInformation(int userId)
        {
            using (var context = new user96_dbEntities1())
            {
                return context.KU_Users
                              .Include(u => u.KU_Roles)
                              .Include(u => u.KU_Employees)
                              .FirstOrDefault(u => u.UserID == userId);
            }
        }

        public MainWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = GetUserInformation(user.UserID);

            using (var context = new user96_dbEntities1())
            {
                // Загружаем данные пользователя и связанные данные до завершения контекста
                currentUser = context.KU_Users
                                     .Include(u => u.KU_Roles)
                                     .Include(u => u.KU_Employees)
                                     .FirstOrDefault(u => u.UserID == user.UserID);

                // Присваиваем значение currentUser из контекста
                if (currentUser != null)
                {
                    // Передаем загруженные данные в пользовательские интерфейсы
                    DisplayUserInformation();
                }
            }
        }

        public MainWindow()
        {
        }

        private void DisplayUserInformation()
        {
            if (currentUser?.KU_Employees != null)
            {
                UserFullNameTextBlock.Text = $"{currentUser.KU_Employees.FirstName} {currentUser.KU_Employees.LastName}";
            }
            else
            {
                UserFullNameTextBlock.Text = "Пользователь не найден";
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            var employeesWindow = new EmployeesWindow(currentUser);
            employeesWindow.Show();
            this.Close();
        }

        private void ChildrenButton_Click(object sender, RoutedEventArgs e)
        {
            var childrenWindow = new ChildrenWindow(currentUser);
            childrenWindow.Show();
            this.Close();
        }

        private void EducationButton_Click(object sender, RoutedEventArgs e)
        {
            var educationWindow = new EducationWindow(currentUser);
            educationWindow.Show();
            this.Close();
        }

        private void ContactsButton_Click(object sender, RoutedEventArgs e)
        {
            var contactsWindow = new ContactsWindow(currentUser);
            contactsWindow.Show();
            this.Close();
        }

        private void ProfessionalDataButton_Click(object sender, RoutedEventArgs e)
        {
            var professionalDataWindow = new ProfessionalDataWindow(currentUser);
            professionalDataWindow.Show();
            this.Close();
        }


        // Обработчик для кнопки "Заявки на отпуск"
        private void LeaveRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            var leaveRequestsWindow = new LeaveRequestsWindow(currentUser);
            leaveRequestsWindow.Show();
            this.Close();
        }


        // Обработчик для кнопки "Отчеты и статистика"
        private void ReportsAndStatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            var reportsAndStatisticsWindow = new SalaryWindow(currentUser);
            reportsAndStatisticsWindow.Show();
            this.Close();
        }

        private void EmployeeOfTheMonthButton_Click(object sender, RoutedEventArgs e)
        {
            var employeeOfTheMonthWindow = new EmployeeOfTheMonthWindow(currentUser);
            employeeOfTheMonthWindow.Show();
            this.Close();
        }

        private void TasksButton_Click(object sender, RoutedEventArgs e)
        {
            var taskAdminWindow = new TaskAdminWindow(currentUser);
            taskAdminWindow.Show();
            this.Close();
        }

        private void ReviewRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            var reviewRequestsWindow = new ReviewRequestsWindow();
            reviewRequestsWindow.Show();
        }

    }
}

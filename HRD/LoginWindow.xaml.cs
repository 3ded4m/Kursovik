using System.Windows;
using System.Linq;
using System.Data.Entity;

namespace HRD
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "Войти"
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using (var context = new user96_dbEntities1()) // Используем контекст базы данных
            {
                var user = context.KU_Users
                    .Include(u => u.KU_Roles) // Загружаем роль пользователя
                    .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    // Перенаправление в зависимости от роли
                    if (user.KU_Roles != null && user.KU_Roles.RoleName == "Администратор")
                    {
                        // Открываем главное окно администратора
                        MainWindow mainWindow = new MainWindow(user);
                        mainWindow.Show();
                    }
                    else
                    {
                        // Открываем главное окно сотрудника
                        EmployeeMainWindow employeeMainWindow = new EmployeeMainWindow(user);
                        employeeMainWindow.Show();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Обработчик кнопки "Выход"
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

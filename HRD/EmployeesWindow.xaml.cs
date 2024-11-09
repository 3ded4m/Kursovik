using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;

namespace HRD
{
    public partial class EmployeesWindow : Window
    {
        private KU_Users currentUser;

        public EmployeesWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;

            // Проверка, если у пользователя роль "Администратор"
            if (currentUser.KU_Roles != null && currentUser.KU_Roles.RoleName == "Администратор")
            {
                AddButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
            }
            else
            {
                // Скрываем кнопку "Редактировать" для пользователя
                EmployeesListView.ItemTemplateSelector = null;
            }

            LoadEmployees();
        }

        // Загрузка сотрудников из базы данных
        private void LoadEmployees()
        {
            using (var context = new user96_dbEntities1())
            {
                var query = context.KU_Employees.Include(e => e.KU_EmployeeProfessionalData).AsQueryable();

                // Фильтрация по фамилии
                if (!string.IsNullOrEmpty(SearchTextBox.Text))
                {
                    string searchText = SearchTextBox.Text.ToLower();
                    query = query.Where(e => e.LastName.ToLower().Contains(searchText));
                }

                // Фильтрация по статусу
                if (StatusFilterComboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content.ToString() != "Все")
                {
                    string status = selectedItem.Content.ToString();
                    query = query.Where(e => e.EmploymentStatus == status);
                }

                var employees = query.ToList();

                // Настройка видимости полей в зависимости от роли
                if (currentUser.KU_Roles.RoleName != "Администратор")
                {
                    EmployeesListView.ItemsSource = employees.Select(e => new
                    {
                        e.EmployeeID,
                        e.LastName,
                        e.FirstName,
                        e.MiddleName,
                        e.DateOfBirth,
                        Position = e.KU_EmployeeProfessionalData.FirstOrDefault()?.Position ?? "Не указано",
                        e.EmploymentStatus
                    }).ToList();
                }
                else
                {
                    EmployeesListView.ItemsSource = employees.Select(e => new
                    {
                        e.EmployeeID,
                        e.LastName,
                        e.FirstName,
                        e.MiddleName,
                        e.DateOfBirth,
                        Position = e.KU_EmployeeProfessionalData.FirstOrDefault()?.Position ?? "Не указано",
                        e.PassportNumber,
                        e.PlaceOfResidence,
                        e.PlaceOfRegistration,
                        e.ChildrenCount,
                        e.EmploymentStatus
                    }).ToList();
                }
            }
        }


        // Обработчик кнопки "Добавить"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна для добавления сотрудника
            var addEmployeeWindow = new AddEmployeeWindow();
            if (addEmployeeWindow.ShowDialog() == true)
            {
                // После закрытия окна добавления обновляем список сотрудников
                LoadEmployees();
            }
        }

        // Обработчик кнопки "Удалить"
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeesListView.SelectedItem;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
                return;
            }

            int employeeId = (int)((dynamic)selectedEmployee).EmployeeID;

            using (var context = new user96_dbEntities1())
            {
                var employee = context.KU_Employees.Find(employeeId);
                if (employee != null)
                {
                    context.KU_Employees.Remove(employee);
                    context.SaveChanges();
                    MessageBox.Show("Сотрудник удален.");
                    LoadEmployees();
                }
                else
                {
                    MessageBox.Show("Сотрудник не найден.");
                }
            }
        }

        // Обработчик кнопки "Редактировать"
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int employeeId = (int)button.Tag;

            if (currentUser.KU_Roles != null && currentUser.KU_Roles.RoleName == "Администратор")
            {
                var editEmployeeWindow = new EditEmployeeWindow(employeeId);
                if (editEmployeeWindow.ShowDialog() == true)
                {
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("У вас нет прав для редактирования.");
            }
        }

        // Обработчик поиска по фамилии
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadEmployees();
        }

        // Обработчик фильтрации по статусу
        private void StatusFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadEmployees();
        }




        // Пагинация (Назад)
        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика для перехода на предыдущую страницу
            MessageBox.Show("Предыдущая страница"); // Заглушка для пагинации
        }

        // Пагинация (Вперед)
        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика для перехода на следующую страницу
            MessageBox.Show("Следующая страница"); // Заглушка для пагинации
        }

        // Обработчик кнопки "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Явная загрузка связанных данных перед созданием MainWindow
            using (var context = new user96_dbEntities1())
            {
                var user = context.KU_Users
                    .Include(u => u.KU_Employees) // Явная загрузка KU_Employees
                    .FirstOrDefault(u => u.UserID == currentUser.UserID);

                if (user != null)
                {
                    var mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.");
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


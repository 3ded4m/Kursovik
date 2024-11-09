using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;

namespace HRD
{
    public partial class ChildrenWindow : Window
    {
        private KU_Users currentUser;

        public ChildrenWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;

            using (var context = new user96_dbEntities1())
            {
                // Загрузка текущего пользователя и связанных данных, таких как роль
                currentUser = context.KU_Users
                                     .Include(u => u.KU_Roles)
                                     .FirstOrDefault(u => u.UserID == user.UserID);
            }
            if (currentUser.KU_Roles != null && currentUser.KU_Roles.RoleName == "Администратор")
            {
                AddButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
            }
            else
            {
                // Скрываем кнопку "Редактировать" для пользователя
                ChildrenListView.ItemTemplateSelector = null;
            }

            LoadChildren();
        }

        // Загрузка данных о детях сотрудников с учетом фильтрации и поиска
        private void LoadChildren()
        {
            using (var context = new user96_dbEntities1())
            {
                var query = context.KU_EmployeeChildren.Include(c => c.KU_Employees).AsQueryable();

                // Фильтрация по имени
                if (!string.IsNullOrEmpty(SearchTextBox.Text))
                {
                    string searchText = SearchTextBox.Text.ToLower();
                    query = query.Where(c => c.ChildName.ToLower().Contains(searchText));
                }

                // Фильтрация по году рождения
                if (YearFilterComboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content.ToString() != "Все")
                {
                    int minYear = 0, maxYear = 9999;
                    switch (selectedItem.Content.ToString())
                    {
                        case "2010-2015": minYear = 2010; maxYear = 2015; break;
                        case "2016-2020": minYear = 2016; maxYear = 2020; break;
                        case "2021-2025": minYear = 2021; maxYear = 2025; break;
                    }
                    query = query.Where(c => c.BirthYear >= minYear && c.BirthYear <= maxYear);
                }

                var children = query.ToList();

                // Настройка источника данных для отображения
                ChildrenListView.ItemsSource = children.Select(c => new
                {
                    ChildID = c.ChildID,
                    ChildName = c.ChildName,
                    BirthYear = c.BirthYear,
                    School = c.School,
                    ParentName = $"{c.KU_Employees.FirstName} {c.KU_Employees.LastName}"
                }).ToList();
            }
        }

        // Обработчик поиска
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadChildren();
        }

        // Обработчик фильтрации
        private void YearFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadChildren();
        }

        // Обработчик кнопки "Добавить"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addChildWindow = new AddChildWindow();
            if (addChildWindow.ShowDialog() == true)
            {
                LoadChildren();
            }
        }

        // Обработчик кнопки "Удалить"
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedChild = ChildrenListView.SelectedItem;
            if (selectedChild == null)
            {
                MessageBox.Show("Выберите ребенка для удаления.");
                return;
            }

            int childId = (int)((dynamic)selectedChild).ChildID;

            using (var context = new user96_dbEntities1())
            {
                var child = context.KU_EmployeeChildren.Find(childId);
                if (child != null)
                {
                    context.KU_EmployeeChildren.Remove(child);
                    context.SaveChanges();
                    MessageBox.Show("Запись о ребенке удалена.");
                    LoadChildren();
                }
                else
                {
                    MessageBox.Show("Ребенок не найден.");
                }
            }
        }

        // Обработчик кнопки "Редактировать"
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int childId = (int)button.Tag;

            if (currentUser.KU_Roles != null && currentUser.KU_Roles.RoleName == "Администратор")
            {
                var editChildWindow = new EditChildWindow(childId);
                if (editChildWindow.ShowDialog() == true)
                {
                    LoadChildren();
                }
            }
            else
            {
                MessageBox.Show("У вас нет прав для редактирования.");
            }
        }

        // Обработчик кнопки "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(currentUser);
            mainWindow.Show();
            this.Close();
        }

        // Обработчик кнопки "Выход"
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

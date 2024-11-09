using System;
using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class EmployeeOfTheMonthWindow : Window
    {
        private user96_dbEntities1 context = new user96_dbEntities1();
        private KU_Users currentUser;

        public EmployeeOfTheMonthWindow(KU_Users currentUser)
        {
            InitializeComponent();
            LoadEmployees();
            this.currentUser = currentUser;
        }

        // Метод для загрузки сотрудников в ComboBox
        private void LoadEmployees()
        {
            var employees = context.KU_Employees
                .Where(e => e.EmploymentStatus == "Работает")
                .Select(e => new
                {
                    e.EmployeeID,
                    e.FirstName,
                    e.LastName
                })
                .ToList()
                .Select(e => new
                {
                    e.EmployeeID,
                    Name = $"{e.FirstName} {e.LastName}"
                })
                .ToList();

            EmployeeComboBox.ItemsSource = employees;
            EmployeeComboBox.DisplayMemberPath = "Name";
            EmployeeComboBox.SelectedValuePath = "EmployeeID";
        }


        // Обработчик кнопки для назначения работника месяца
        private void AssignEmployeeOfTheMonth_Click(object sender, RoutedEventArgs args)
        {
            // Проверка, был ли уже назначен работник месяца за предыдущий месяц
            var lastMonth = DateTime.Now.AddMonths(-1);
            bool alreadyAssigned = context.KU_EmployeeOfTheMonth.Any(e =>
                e.MonthAssigned.Year == lastMonth.Year && e.MonthAssigned.Month == lastMonth.Month);

            if (alreadyAssigned)
            {
                MessageBox.Show("Работник месяца уже назначен за прошлый месяц.");
                return;
            }

            // Получение выбранного сотрудника из ComboBox
            if (EmployeeComboBox.SelectedValue is int selectedEmployeeId)
            {
                // Добавление записи о новом работнике месяца
                var employeeOfTheMonth = new KU_EmployeeOfTheMonth
                {
                    EmployeeID = selectedEmployeeId,
                    MonthAssigned = lastMonth
                };

                context.KU_EmployeeOfTheMonth.Add(employeeOfTheMonth);
                context.SaveChanges();

                MessageBox.Show("Работник месяца успешно назначен.");
            }
            else
            {
                MessageBox.Show("Выберите сотрудника.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs args)
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

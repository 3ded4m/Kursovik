using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class SalaryWindow : Window
    {
        private KU_Users currentUser;

        public SalaryWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadSalaryHistory();
        }

        // Загрузка данных истории зарплат
        private void LoadSalaryHistory()
        {
            using (var context = new user96_dbEntities1())
            {
                var salaryData = context.KU_SalaryHistory
                    .Select(s => new
                    {
                        s.SalaryID,
                        EmployeeName = s.KU_Employees.FirstName + " " + s.KU_Employees.LastName,
                        s.SalaryAmount,
                        s.SalaryDate,
                        s.Note
                    })
                    .ToList();

                SalaryHistoryDataGrid.ItemsSource = salaryData;
            }
        }

        // Обработчик для добавления записи о зарплате
        private void AddSalaryRecord_Click(object sender, RoutedEventArgs e)
        {
            var addSalaryWindow = new AddSalaryRecordWindow(currentUser);
            addSalaryWindow.ShowDialog();
            LoadSalaryHistory();
        }

        // Обработчик для редактирования записи о зарплате
        private void EditSalaryRecord_Click(object sender, RoutedEventArgs e)
        {
            var selectedSalary = (dynamic)SalaryHistoryDataGrid.SelectedItem;
            if (selectedSalary == null) return;

            var editSalaryWindow = new EditSalaryRecordWindow(selectedSalary.SalaryID);
            editSalaryWindow.ShowDialog();
            LoadSalaryHistory();
        }

        // Обработчик для удаления записи о зарплате
        private void DeleteSalaryRecord_Click(object sender, RoutedEventArgs e)
        {
            var selectedSalary = (dynamic)SalaryHistoryDataGrid.SelectedItem;
            if (selectedSalary == null) return;

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var context = new user96_dbEntities1())
                {
                    var salaryRecord = context.KU_SalaryHistory.Find(selectedSalary.SalaryID);
                    if (salaryRecord != null)
                    {
                        context.KU_SalaryHistory.Remove(salaryRecord);
                        context.SaveChanges();
                    }
                }
                LoadSalaryHistory();
            }
        }

        // Обработчик кнопки "Назад"
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

using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class SalaryHistoryWindow : Window
    {
        private KU_Users currentUser;

        public SalaryHistoryWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadSalaryHistory();
        }

        // Метод для загрузки истории зарплат
        private void LoadSalaryHistory()
        {
            using (var context = new user96_dbEntities1())
            {
                var salaryHistory = context.KU_SalaryHistory
                    .Where(s => s.EmployeeID == currentUser.EmployeeID)
                    .Select(s => new
                    {
                        s.SalaryDate,
                        s.SalaryAmount,
                        s.Note
                    })
                    .ToList();

                SalaryHistoryDataGrid.ItemsSource = salaryHistory;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрываем текущее окно и возвращаемся к предыдущему
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Закрываем приложение
        }
    }
}

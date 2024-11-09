using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class ProfessionalDataWindow : Window
    {
        private KU_Users currentUser;

        public ProfessionalDataWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadProfessionalData();
        }

        // Метод для загрузки профессиональных данных сотрудников
        private void LoadProfessionalData()
        {
            using (var context = new user96_dbEntities1())
            {
                var professionalData = context.KU_EmployeeProfessionalData
                    .Select(p => new
                    {
                        p.ProfessionalDataID,
                        EmployeeName = p.KU_Employees.FirstName + " " + p.KU_Employees.LastName,
                        p.Position,
                        p.Qualification,
                        p.Specialization,
                        p.HireDate,
                        p.TotalExperience
                    })
                    .ToList();

                ProfessionalDataDataGrid.ItemsSource = professionalData;
            }
        }

        // Обработчик для добавления новой записи
        private void AddProfessionalData_Click(object sender, RoutedEventArgs e)
        {
            var addProfessionalDataWindow = new AddProfessionalDataWindow(currentUser);
            addProfessionalDataWindow.ShowDialog();
            LoadProfessionalData();
        }

        // Обработчик для удаления записи
        private void DeleteProfessionalData_Click(object sender, RoutedEventArgs e)
        {
            var selectedData = (dynamic)ProfessionalDataDataGrid.SelectedItem;
            if (selectedData == null) return;

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var context = new user96_dbEntities1())
                {
                    var professionalData = context.KU_EmployeeProfessionalData.Find(selectedData.ProfessionalDataID);
                    if (professionalData != null)
                    {
                        context.KU_EmployeeProfessionalData.Remove(professionalData);
                        context.SaveChanges();
                    }
                }
                LoadProfessionalData();
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

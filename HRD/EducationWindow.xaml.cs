using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class EducationWindow : Window
    {
        private KU_Users currentUser;

        public EducationWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadEducation();
        }

        // Метод для загрузки данных об образовании из базы данных
        private void LoadEducation(string degreeFilter = "")
        {
            using (var context = new user96_dbEntities1())
            {
                var educationData = context.KU_Education
                    .Where(e => degreeFilter == "" || e.Degree == degreeFilter) // Фильтрация по степени
                    .Select(e => new
                    {
                        e.EducationID,
                        EmployeeName = e.KU_Employees.FirstName + " " + e.KU_Employees.LastName,
                        e.Degree,
                        e.Institution,
                        e.GraduationYear,
                        e.Specialization
                    })
                    .ToList();

                EducationDataGrid.ItemsSource = educationData;
            }
        }

        // Обработчик для фильтрации по степени
        public void DegreeFilterComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedDegree = (DegreeFilterComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();
            LoadEducation(selectedDegree == "Все" ? "" : selectedDegree);
        }



        // Обработчик для добавления нового образования
        private void AddEducation_Click(object sender, RoutedEventArgs e)
        {
            var addEducationWindow = new AddEducationWindow(currentUser);
            addEducationWindow.ShowDialog();
            LoadEducation();
        }

        // Обработчик для редактирования записи об образовании
        private void EditEducation_Click(object sender, RoutedEventArgs e)
        {
            var selectedEducation = (dynamic)EducationDataGrid.SelectedItem;
            if (selectedEducation == null) return;

            var editEducationWindow = new EditEducationWindow(selectedEducation.EducationID);
            editEducationWindow.ShowDialog();
            LoadEducation();
        }

        // Обработчик для удаления записи об образовании
        private void DeleteEducation_Click(object sender, RoutedEventArgs e)
        {
            var selectedEducation = (dynamic)EducationDataGrid.SelectedItem;
            if (selectedEducation == null)
            {
                MessageBox.Show("Выберите запись для удаления.", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var context = new user96_dbEntities1())
                {
                    var education = context.KU_Education.Find(selectedEducation.EducationID);
                    if (education != null)
                    {
                        context.KU_Education.Remove(education);
                        context.SaveChanges();
                    }
                }
                LoadEducation();
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

using System;
using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class AddProfessionalDataWindow : Window
    {
        private KU_Users currentUser;

        public AddProfessionalDataWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadEmployees();
        }

        // Метод для загрузки списка сотрудников в ComboBox
        private void LoadEmployees()
        {
            using (var context = new user96_dbEntities1())
            {
                var employees = context.KU_Employees
                    .Select(e => new
                    {
                        e.EmployeeID,
                        FullName = e.FirstName + " " + e.LastName
                    })
                    .ToList();

                EmployeeComboBox.ItemsSource = employees;
                EmployeeComboBox.DisplayMemberPath = "FullName";
                EmployeeComboBox.SelectedValuePath = "EmployeeID";
            }
        }

        // Обработчик кнопки "Сохранить"
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new user96_dbEntities1())
            {
                var newProfessionalData = new KU_EmployeeProfessionalData
                {
                    EmployeeID = (int)EmployeeComboBox.SelectedValue,
                    Position = PositionTextBox.Text,
                    Qualification = QualificationTextBox.Text,
                    Specialization = SpecializationTextBox.Text,
                    HireDate = HireDatePicker.SelectedDate ?? DateTime.Now,
                    TotalExperience = int.TryParse(TotalExperienceTextBox.Text, out int experience) ? experience : 0
                };

                context.KU_EmployeeProfessionalData.Add(newProfessionalData);
                context.SaveChanges();
            }

            MessageBox.Show("Профессиональные данные успешно добавлены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            this.Close();
        }

        // Обработчик кнопки "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

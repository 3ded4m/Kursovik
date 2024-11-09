using System;
using System.Windows;
using System.Windows.Controls;

namespace HRD
{
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка и преобразование данных
            if (!int.TryParse(ChildrenCountTextBox.Text, out int childrenCount))
            {
                MessageBox.Show("Введите корректное количество детей.");
                return;
            }

            if (DateOfBirthPicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату рождения.");
                return;
            }

            using (var context = new user96_dbEntities1())
            {
                var newEmployee = new KU_Employees
                {
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    MiddleName = MiddleNameTextBox.Text,
                    DateOfBirth = DateOfBirthPicker.SelectedDate.Value,
                    PassportNumber = PassportNumberTextBox.Text,
                    PlaceOfResidence = PlaceOfResidenceTextBox.Text,
                    PlaceOfRegistration = PlaceOfRegistrationTextBox.Text,
                    MaritalStatus = (MaritalStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    ChildrenCount = childrenCount,
                    EmploymentStatus = (EmploymentStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
                };

                context.KU_Employees.Add(newEmployee);
                context.SaveChanges();

                MessageBox.Show("Сотрудник добавлен.");
                this.DialogResult = true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

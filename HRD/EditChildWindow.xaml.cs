using System;
using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class EditChildWindow : Window
    {
        private int childId;

        public EditChildWindow(int childId)
        {
            InitializeComponent();
            this.childId = childId;
            LoadEmployees();
            LoadChildData();
        }

        private void LoadEmployees()
        {
            using (var context = new user96_dbEntities1())
            {
                var employees = context.KU_Employees
                    .Select(e => new { e.EmployeeID, FullName = e.FirstName + " " + e.LastName })
                    .ToList();
                EmployeeComboBox.ItemsSource = employees;
            }
        }

        private void LoadChildData()
        {
            using (var context = new user96_dbEntities1())
            {
                var child = context.KU_EmployeeChildren.Find(childId);
                if (child != null)
                {
                    ChildNameTextBox.Text = child.ChildName;
                    BirthYearTextBox.Text = child.BirthYear.ToString();
                    SchoolTextBox.Text = child.School;
                    EmployeeComboBox.SelectedValue = child.EmployeeID;
                }
                else
                {
                    MessageBox.Show("Запись о ребенке не найдена.");
                    this.Close();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите сотрудника.");
                return;
            }

            if (!int.TryParse(BirthYearTextBox.Text, out int birthYear))
            {
                MessageBox.Show("Введите корректный год рождения.");
                return;
            }

            using (var context = new user96_dbEntities1())
            {
                var child = context.KU_EmployeeChildren.Find(childId);
                if (child != null)
                {
                    child.EmployeeID = (int)EmployeeComboBox.SelectedValue;
                    child.ChildName = ChildNameTextBox.Text;
                    child.BirthYear = birthYear;
                    child.School = SchoolTextBox.Text;

                    context.SaveChanges();
                    MessageBox.Show("Изменения сохранены.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Запись о ребенке не найдена.");
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

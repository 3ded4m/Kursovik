using System;
using System.Windows;

namespace HRD
{
    public partial class EditSalaryRecordWindow : Window
    {
        private int salaryId;

        public EditSalaryRecordWindow(int id)
        {
            InitializeComponent();
            salaryId = id;
            LoadSalaryRecord();
        }

        private void LoadSalaryRecord()
        {
            using (var context = new user96_dbEntities1())
            {
                var salaryRecord = context.KU_SalaryHistory.Find(salaryId);
                if (salaryRecord != null)
                {
                    EmployeeTextBlock.Text = salaryRecord.KU_Employees.FirstName + " " + salaryRecord.KU_Employees.LastName;
                    SalaryAmountTextBox.Text = salaryRecord.SalaryAmount.ToString();
                    SalaryDatePicker.SelectedDate = salaryRecord.SalaryDate;
                    NoteTextBox.Text = salaryRecord.Note;
                }
            }
        }

        private void SaveSalaryRecordButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user96_dbEntities1())
            {
                var salaryRecord = context.KU_SalaryHistory.Find(salaryId);
                if (salaryRecord != null)
                {
                    salaryRecord.SalaryAmount = decimal.Parse(SalaryAmountTextBox.Text);
                    salaryRecord.SalaryDate = SalaryDatePicker.SelectedDate.Value;
                    salaryRecord.Note = NoteTextBox.Text;
                    context.SaveChanges();
                }
            }

            MessageBox.Show("Запись о зарплате обновлена.");
            this.Close();
        }
    }
}

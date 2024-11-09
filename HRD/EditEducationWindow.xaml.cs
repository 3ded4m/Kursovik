using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class EditEducationWindow : Window
    {
        private int _educationId;

        public EditEducationWindow(int educationId)
        {
            InitializeComponent();
            _educationId = educationId;
            LoadEducationData();
        }

        private void LoadEducationData()
        {
            using (var context = new user96_dbEntities1())
            {
                // Переименуйте переменную, чтобы избежать конфликта
                var educationRecord = context.KU_Education.FirstOrDefault(ed => ed.EducationID == _educationId);
                if (educationRecord != null)
                {
                    DegreeTextBox.Text = educationRecord.Degree;
                    InstitutionTextBox.Text = educationRecord.Institution;
                    GraduationYearTextBox.Text = educationRecord.GraduationYear.ToString();
                    SpecializationTextBox.Text = educationRecord.Specialization;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user96_dbEntities1())
            {
                // Переименуйте переменную, чтобы избежать конфликта
                var educationRecord = context.KU_Education.FirstOrDefault(ed => ed.EducationID == _educationId);
                if (educationRecord != null)
                {
                    educationRecord.Degree = DegreeTextBox.Text;
                    educationRecord.Institution = InstitutionTextBox.Text;
                    educationRecord.GraduationYear = int.Parse(GraduationYearTextBox.Text);
                    educationRecord.Specialization = SpecializationTextBox.Text;

                    context.SaveChanges();
                }
            }

            MessageBox.Show("Образование обновлено успешно.");
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

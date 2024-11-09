using System.Windows;

namespace HRD
{
    public partial class AddEducationWindow : Window
    {
        private int _employeeId;
        private KU_Users currentUser;

        public AddEducationWindow(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
        }

        public AddEducationWindow(KU_Users currentUser)
        {
            this.currentUser = currentUser;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user96_dbEntities1())
            {
                var newEducation = new KU_Education
                {
                    EmployeeID = _employeeId,
                    Degree = DegreeTextBox.Text,
                    Institution = InstitutionTextBox.Text,
                    GraduationYear = int.Parse(GraduationYearTextBox.Text),
                    Specialization = SpecializationTextBox.Text
                };

                context.KU_Education.Add(newEducation);
                context.SaveChanges();
            }

            MessageBox.Show("Образование добавлено успешно.");
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

using System.Windows;

namespace HRD
{
    public partial class ReportsWindow : Window
    {
        private KU_Users currentUser;

        public ReportsWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void TenureReportButton_Click(object sender, RoutedEventArgs e)
        {
            var tenureReportWindow = new TenureReportWindow();
            tenureReportWindow.Show();
        }

        private void EmployeesAndChildrenReportButton_Click(object sender, RoutedEventArgs e)
        {
            var employeesAndChildrenWindow = new EmployeesAndChildrenWindow();
            employeesAndChildrenWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(currentUser);
            mainWindow.Show();
            this.Close();
        }
    }
}

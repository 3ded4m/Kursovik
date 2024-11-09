using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HRD
{
    public partial class EditLeaveRequestWindow : Window
    {
        private int requestId;

        public EditLeaveRequestWindow(int leaveRequestId)
        {
            InitializeComponent();
            requestId = leaveRequestId;
            LoadLeaveRequestDetails();
        }

        private void LoadLeaveRequestDetails()
        {
            using (var context = new user96_dbEntities1())
            {
                var request = context.KU_LeaveRequests.Find(requestId);
                if (request != null)
                {
                    StartDatePicker.SelectedDate = request.StartDate;
                    EndDatePicker.SelectedDate = request.EndDate;
                    StatusComboBox.SelectedItem = StatusComboBox.Items
                        .Cast<ComboBoxItem>()
                        .FirstOrDefault(item => item.Content.ToString() == request.Status);
                }
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate == null || EndDatePicker.SelectedDate == null || StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля перед сохранением.");
                return;
            }

            using (var context = new user96_dbEntities1())
            {
                var request = context.KU_LeaveRequests.Find(requestId);
                if (request != null)
                {
                    request.StartDate = StartDatePicker.SelectedDate.Value;
                    request.EndDate = EndDatePicker.SelectedDate.Value;
                    request.Status = (StatusComboBox.SelectedItem as ComboBoxItem).Content.ToString();

                    context.SaveChanges();
                }
            }

            MessageBox.Show("Изменения сохранены.");
            this.Close();
        }
    }
}

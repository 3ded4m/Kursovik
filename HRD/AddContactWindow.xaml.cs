using System.Windows;

namespace HRD
{
    public partial class AddContactWindow : Window
    {
        private KU_Users currentUser;

        public AddContactWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user96_dbEntities1())
            {
                var newContact = new KU_Contacts
                {
                    EmployeeID = currentUser.EmployeeID,
                    PhoneNumber = PhoneTextBox.Text,
                    Email = EmailTextBox.Text,
                    Address = AddressTextBox.Text
                };

                context.KU_Contacts.Add(newContact);
                context.SaveChanges();
            }

            MessageBox.Show("Контакт добавлен успешно.");
            this.Close();
        }
    }
}

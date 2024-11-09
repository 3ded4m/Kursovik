using System.Windows;

namespace HRD
{
    public partial class EditContactWindow : Window
    {
        private int contactId;

        public EditContactWindow(int contactId)
        {
            InitializeComponent();
            this.contactId = contactId;
            LoadContactDetails();
        }

        private void LoadContactDetails()
        {
            using (var context = new user96_dbEntities1())
            {
                var contact = context.KU_Contacts.Find(contactId);
                if (contact != null)
                {
                    PhoneTextBox.Text = contact.PhoneNumber;
                    EmailTextBox.Text = contact.Email;
                    AddressTextBox.Text = contact.Address;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user96_dbEntities1())
            {
                var contact = context.KU_Contacts.Find(contactId);
                if (contact != null)
                {
                    contact.PhoneNumber = PhoneTextBox.Text;
                    contact.Email = EmailTextBox.Text;
                    contact.Address = AddressTextBox.Text;
                    context.SaveChanges();
                }
            }

            MessageBox.Show("Изменения сохранены.");
            this.Close();
        }
    }
}

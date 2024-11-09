using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class ContactsWindow : Window
    {
        private KU_Users currentUser;

        public ContactsWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadContacts();
        }

        // Метод для загрузки контактов из базы данных
        private void LoadContacts(string searchPhone = "")
        {
            using (var context = new user96_dbEntities1())
            {
                var contacts = context.KU_Contacts
                    .Where(c => c.PhoneNumber.Contains(searchPhone)) // Фильтрация по телефону
                    .Select(c => new
                    {
                        c.ContactID,
                        EmployeeName = c.KU_Employees.FirstName + " " + c.KU_Employees.LastName,
                        c.PhoneNumber,
                        c.Email,
                        c.Address
                    })
                    .ToList();

                ContactsDataGrid.ItemsSource = contacts;
            }
        }

        // Обработчик для добавления нового контакта
        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            var addContactWindow = new AddContactWindow(currentUser);
            addContactWindow.ShowDialog();
            LoadContacts();
        }

        // Обработчик для редактирования контакта
        private void EditContact_Click(object sender, RoutedEventArgs e)
        {
            var selectedContact = (dynamic)ContactsDataGrid.SelectedItem;
            if (selectedContact == null) return;

            var editContactWindow = new EditContactWindow(selectedContact.ContactID);
            editContactWindow.ShowDialog();
            LoadContacts();
        }

        // Обработчик для удаления выбранного контакта
        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            var selectedContact = (dynamic)ContactsDataGrid.SelectedItem;
            if (selectedContact == null)
            {
                MessageBox.Show("Выберите контакт для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить этот контакт?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var context = new user96_dbEntities1())
                {
                    var contact = context.KU_Contacts.Find(selectedContact.ContactID);
                    if (contact != null)
                    {
                        context.KU_Contacts.Remove(contact);
                        context.SaveChanges();
                    }
                }
                LoadContacts();
            }
        }

        // Обработчик для поиска по телефону
        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LoadContacts(SearchTextBox.Text);
        }

        // Обработчик кнопки "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(currentUser);
            mainWindow.Show();
            this.Close();
        }

        // Обработчик кнопки "Выход"
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

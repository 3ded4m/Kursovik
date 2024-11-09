using System.Windows;

namespace HRD
{
    public partial class AddEditTaskWindow : Window
    {
        private KU_Tasks _task;

        public AddEditTaskWindow(KU_Tasks task = null)
        {
            InitializeComponent();
            _task = task;

            if (_task != null)
            {
                TitleTextBox.Text = _task.Title;
                DescriptionTextBox.Text = _task.Description;
                DueDatePicker.SelectedDate = _task.DueDate;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user96_dbEntities1())
            {
                if (_task == null)
                {
                    _task = new KU_Tasks();
                    context.KU_Tasks.Add(_task);
                }
                else
                {
                    _task = context.KU_Tasks.Find(_task.TaskID);
                }

                _task.Title = TitleTextBox.Text;
                _task.Description = DescriptionTextBox.Text;
                _task.DueDate = DueDatePicker.SelectedDate;

                context.SaveChanges();
            }

            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

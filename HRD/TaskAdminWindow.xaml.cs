using System.Linq;
using System.Windows;

namespace HRD
{
    public partial class TaskAdminWindow : Window
    {
        private KU_Users currentUser;

        public TaskAdminWindow(KU_Users currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            LoadTasks();
        }

        // Загрузка списка задач
        private void LoadTasks()
        {
            using (var context = new user96_dbEntities1())
            {
                var tasks = context.KU_Tasks.ToList();
                TasksListView.ItemsSource = tasks;
            }
        }

        // Обработчик для кнопки "Добавить задачу"
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var addEditTaskWindow = new AddEditTaskWindow();
            addEditTaskWindow.ShowDialog();
            LoadTasks();
        }

        // Обработчик для кнопки "Редактировать"
        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListView.SelectedItem is KU_Tasks selectedTask)
            {
                var addEditTaskWindow = new AddEditTaskWindow(selectedTask);
                addEditTaskWindow.ShowDialog();
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Выберите задачу для редактирования.");
            }
        }

        // Обработчик для кнопки "Удалить"
        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListView.SelectedItem is KU_Tasks selectedTask)
            {
                using (var context = new user96_dbEntities1())
                {
                    var taskToDelete = context.KU_Tasks.Find(selectedTask.TaskID);
                    if (taskToDelete != null)
                    {
                        context.KU_Tasks.Remove(taskToDelete);
                        context.SaveChanges();
                        LoadTasks();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(currentUser);
            mainWindow.Show();
            this.Close();
        }
    }
}

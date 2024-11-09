using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HRD
{
    public partial class TasksViewWindow : Window
    {
        private KU_Users currentUser;
        private user96_dbEntities1 context = new user96_dbEntities1();

        public TasksViewWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasks = context.KU_Tasks.Select(t => new TaskViewModel
            {
                TaskID = t.TaskID,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                IsCompleted = t.IsCompleted
            }).ToList();

            TasksListView.ItemsSource = tasks;
        }


        private void TaskCompleted_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTaskCompletionStatus(sender as CheckBox, true);
        }

        private void TaskCompleted_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateTaskCompletionStatus(sender as CheckBox, false);
        }

        private void UpdateTaskCompletionStatus(CheckBox checkBox, bool isCompleted)
        {
            // Изменяем тип задачи на анонимный тип или используем TaskID напрямую
            if (checkBox.DataContext is KU_Tasks task)
            {
                using (var context = new user96_dbEntities1())
                {
                    var taskToUpdate = context.KU_Tasks.FirstOrDefault(t => t.TaskID == task.TaskID);
                    if (taskToUpdate != null)
                    {
                        taskToUpdate.IsCompleted = isCompleted;
                        taskToUpdate.UpdatedAt = DateTime.Now;
                        context.SaveChanges();
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user96_dbEntities1())
            {
                foreach (TaskViewModel task in TasksListView.ItemsSource)
                {
                    var taskToUpdate = context.KU_Tasks.FirstOrDefault(t => t.TaskID == task.TaskID);
                    if (taskToUpdate != null)
                    {
                        taskToUpdate.IsCompleted = task.IsCompleted;
                        taskToUpdate.UpdatedAt = DateTime.Now;
                    }
                }
                context.SaveChanges();
            }
            MessageBox.Show("Изменения сохранены.");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

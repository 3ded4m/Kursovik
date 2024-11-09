using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace HRD
{
    public partial class LeaveBalanceWindow : Window
    {
        private KU_Users currentUser;

        public LeaveBalanceWindow(KU_Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadLeaveData(); // Заменяем вызов на новый метод
        }

        // Новый метод для загрузки остатка отпускных дней
        private void LoadLeaveData()
        {
            using (var context = new user96_dbEntities1())
            {
                // Получаем все одобренные заявки на отпуск для текущего сотрудника
                var leaveRequests = context.KU_LeaveRequests
                    .Where(l => l.EmployeeID == currentUser.EmployeeID && l.Status == "Принято")
                    .ToList();

                if (leaveRequests.Any())
                {
                    int remainingDays = CalculateRemainingLeaveDays(leaveRequests);
                    RemainingLeaveDaysTextBlock.Text = $"Осталось дней: {remainingDays}";
                    RemainingLeaveDaysTextBlock.Foreground = Brushes.Black;
                }
                else
                {
                    RemainingLeaveDaysTextBlock.Text = "Нет данных о днях отпуска";
                    RemainingLeaveDaysTextBlock.Foreground = Brushes.Green;
                }
            }
        }

        // Метод для подсчета оставшихся отпускных дней
        private int CalculateRemainingLeaveDays(System.Collections.Generic.List<KU_LeaveRequests> leaveRequests)
        {
            int totalLeaveDaysPerYear = 28; // Допустимое количество дней отпуска в году
            int usedLeaveDays = leaveRequests.Sum(l => (l.EndDate - l.StartDate).Days + 1);
            return totalLeaveDaysPerYear - usedLeaveDays;
        }

        // Обработчик для кнопки "Запрос на отпуск"
        private void RequestLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            var requestLeaveWindow = new RequestLeaveWindow(currentUser);
            requestLeaveWindow.ShowDialog();
            LoadLeaveData(); // Обновляем данные после закрытия окна запроса
        }
    }
}

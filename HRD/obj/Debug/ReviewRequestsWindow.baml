   M S B A M L   `   `   `  ����  HRD    HRD.ReviewRequestsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$1  +Рассмотрение обращений��5   	   $	��800��6(   $	��600��64    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���#ffffff$��10q�6    .+�5   
   �� $1��+Рассмотрение обращений��6   $��20(�62   $
��Bold"�6@   $��Center=�6R   $��	0,10,0,10q�6o   &   System.Windows.Controls.DataGrid  5
   
   -   5          Name$ RequestsDataGrid��5
         AutoGenerateColumns .  $��	0,50,0,60q�6I      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID обращения��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	RequestID+6Y     5      $ Сотрудник��6%   $ * 6Y    68   �� *EmployeeName+6Y     5      $ Тема��6%   $ * 6O    63   �� *	Subject+6O     5      $ Описание��6%   $ 2* 6W    67   �� *Description+6W     5      $ Статус��6%   $ * 6P    65   �� *Status+6P     5      $ Дата запроса��6%   $ * 6[    6;   �� *RequestDate+6[   5      �� 5   
   -   5        $��
Назад��5      $��80��6!   $��30��6,   $��Bottom=�68   $
��Left=�6S   ���#2196F3
�������$��14(�6�   $��10q�6�   6�   �� 5   
   -   5        $��Рассмотреть��5      $	��100��6'   $��30��63   $��Bottom=�6?   $��Right=�6Z   ���#4CAF50
�������$��14(�6�   $��10q�6�   6�   �� 5   
   -   5        $��Отклонить��5      $	��100��6%   $��30��61   $��Bottom=�6=   $��Right=�6X   ���#f44336
�������$��14(�6�   $��
0,0,130,10q�6�   6�   5      5      
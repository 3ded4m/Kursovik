   M S B A M L   `   `   `  ����  HRD    HRD.LeaveRequestsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$$  Заявки на отпуск��5   	   $	��800��6"   $	��600��6.    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6   .+�5   
   �� $$��Заявки на отпуск��6   $��20(�6,   $
��Bold"�6:   $��Center=�6L   $��0,0,0,20q�6i   &   System.Windows.Controls.DataGrid  5
   
   -   5          Name$ LeaveRequestsDataGrid��5
         AutoGenerateColumns .  $��	0,40,0,70q�6N      
IsReadOnly .    SelectionMode$ Single=�6s      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *
LastName+6S     5      $ Имя��6%   $ * 6P   	 62   �� *	FirstName+6P     5      $ Дата начала��6%   $ * 6X   	 6:   �� *	StartDate+6X     5      $! Дата окончания��6%   $ * 6Y   	 6=   �� *	EndDate+6Y     5      $ Статус��6%   $ * 6P   	 65   �� *Status+6P   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Действия��6)   $	 150 6;   
   CellTemplate
 5      �� 5      .R�5      �� -   5        $ ��Редактировать��5   %   6=   5      5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��Bottom=�6I   $��	10,0,0,10q�6d   .+�5      �� -   5        $��
Назад��5      $��80��6%   $��30��60   ���#2196F3
�������$��14(�6d   $��0,0,10,0q�6r   6�   �� 5      -   5        $��
Выход��5      $��80��6%   $��30��60   ���#f44336
�������$��14(�6d   6r   5      5       5!      
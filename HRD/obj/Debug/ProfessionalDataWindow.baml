   M S B A M L   `   `   `  ����  HRD     HRD.ProfessionalDataWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$J  DПрофессиональные данные сотрудников��5   	   $	��900��65   $	��600��6A    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���#ffffff$��10q�6    .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��50��6F   ���#e3eaf5.+�5	      �� $J��DПрофессиональные данные сотрудников��6   $��20(�6C   $��10,0,0,0q�6Q   $��Center=�6c   5
      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ProfessionalDataDataGrid��5         AutoGenerateColumns .  $��	0,60,0,70q�6Q      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ProfessionalDataID+6X     5      $ Сотрудник��6%   $	 150 6Y    68   �� *EmployeeName+6Y     5      $ Должность��6%   $	 150 6U    68   �� *
Position+6U     5      $ Квалификация��6%   $	 150 6]    6;   �� *Qualification+6]     5      $  Специализация��6%   $	 150 6_    6<   �� *Specialization+6_     5      $ Дата найма��6%   $	 100 6V    69   �� *
HireDate+6V     5      $ Опыт работы��6%   $	 100 6^    6:   �� *TotalExperience+6^   5      �� 5   
   $ 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��	10,0,0,10q�6e   .+�5      �� -   5        $��Добавить��5      $	��100��6(   $��35��64   $��10,0,0,0q�6@   6R   �� 5      -   5        $��Удалить��5      $	��100��6'   $��35��63   6?   5      �� 5    
   $ 
Horizontal=�6   $
��Left=�6.   $��Bottom=�6I   $��	10,0,0,10q�6d   .+�5!      �� -   5        $��
Назад��5!      $��80��6%   $��30��60   ���#2196F3
�������$��14(�6d   $��0,0,10,0q�6r   6�   �� 5"      -   5        $��
Выход��5"      $��80��6%   $��30��60   ���#f44336
�������$��14(�6d   6r   5#      5$      5%      
   M S B A M L   `   `   `  ����  HRD    HRD.SalaryHistoryWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  История зарплат��5   	   $	��800��6!   $	��500��6-    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ SalaryHistoryDataGrid��5         AutoGenerateColumns .  $��0,0,0,10q�6N   $	��400��6`      Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *
SalaryDate+6R     5      $ 
Сумма��6%   $ * 6U    64   �� *SalaryAmount+6U     5      $ Примечание��6%   $ * 6R    69   �� *Note+6R   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��Bottom=�6I   $��	10,0,0,10q�6d   .+�5      �� -   5        $��
Назад��5      $��80��6%   $��30��60   ���#2196F3
�������$��14(�6d   $��0,0,10,0q�6r   6�   �� 5      -   5        $��
Выход��5      $��80��6%   $��30��60   ���#f44336
�������$��14(�6d   6r   5      5      5      
   M S B A M L   `   `   `  ����  HRD    HRD.TenureReportWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$5  /Отчет о стаже сотрудников��5   	   $	��600��6+   $	��400��67    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���#ffffff$��10q�6    .+�5   
   �� $%��Стаж сотрудников��6   $��24(�6,   $
��Bold"�6:   $��Center=�6L   $��	0,10,0,20q�6i   &   System.Windows.Controls.DataGrid  5
   
   -   5          Name$ TenureDataGrid��5
         AutoGenerateColumns .  $��	0,50,0,50q�6G      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
EmployeeID+6P     5      $ ФИО��6%   $	 200 6O    62   �� *
FullName+6O     5      $% Дата поступления��6%   $	 150 6\    6?   �� *
HireDate+6\     5      $ Стаж (лет)��6%   $	 100 6Y    69   �� *TenureYears+6Y   5      �� 5   
   -   5        $��Экспорт в Excel��5      $	��120��6+   $��30��67   $��Right=�6C   $��Bottom=�6_   $��10q�6z   6�   �� 5   
   -   5        $��
Назад��5      $��80��6!   $��30��6,   $
��Left=�68   $��Bottom=�6S   $��10q�6n   6z   5      5      
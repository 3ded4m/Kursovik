   M S B A M L   `   `   `  ����  HRD$    HRD.EmployeesAndChildrenWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$+  %Сотрудники и их дети��5   	   $	��649��6&   $	��400��62    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���#ffffff$��10q�6    .+�5   
   �� $<��6Сотрудники и их дети (до 14 лет)��6   $��24(�6<   $
��Bold"�6J   $��Center=�6\   $��	0,10,0,20q�6y   &   System.Windows.Controls.DataGrid  5
   
   -   5          Name$ EmployeesChildrenDataGrid��5
         AutoGenerateColumns .  $��	0,50,0,50q�6R      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID сотрудника��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
EmployeeID+6[     5      $! ФИО сотрудника��6%   $	 200 6Z    6=   �� *
FullName+6Z     5      $ ФИО ребенка��6%   $	 200 6X    6:   �� *	ChildName+6X     5      $# Возраст ребенка��6%   $	 120 6[    6>   �� *
ChildAge+6[   5      �� 5   
   -   5        $��
Назад��5      $��80��6!   $��30��6,   $
��Left=�68   $��Bottom=�6S   $��10q�6n   6z   5      5      
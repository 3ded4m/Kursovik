   M S B A M L   `   `   `  ����  HRD    HRD.ContactsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$-  'Контакты сотрудников��5   	   $	��800��6&   $	��600��62    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���#ffffff$��10q�6    .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��50��6F   ���#e3eaf5.+�5	      �� $-��'Контакты сотрудников��6   $��20(�64   $��10,0,0,0q�6B   $��Center=�6T   �� 5
      -   5         ��Name$ SearchTextBox��5
      $	��200��6-   $��30��69   $��20,0,0,0q�6E   $��Center=�6W   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ContactsDataGrid��5         AutoGenerateColumns .  $��	0,60,0,70q�6I      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6O   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *	ContactID+6O     5      $ Сотрудник��6%   $	 150 6Y   	 68   �� *EmployeeName+6Y     5      $ Телефон��6%   $	 100 6V   	 66   �� *PhoneNumber+6V     5      $ Email��6%   $	 150 6N   	 64   �� *Email+6N     5      $ 
Адрес��6%   $	 200 6P   	 64   �� *	Address+6P   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Действия��6)   $ 80 6;   
   CellTemplate
 5      �� 5      .R�5      �� -   5        $ ��Редактировать��5   %   $��80��6=   6H   5      5      5      �� 5!   
   $ 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��	10,0,0,10q�6e   .+�5"      �� -   5        $%��Добавить контакт��5"      $	��150��60   $��30��6<   $��10,0,0,0q�6H   6Z   �� 5#      -   5        $6��0Удалить выбранный контакт��5#      $	��150��69   $��30��6E   $��10,0,0,0q�6Q   6c   5$      �� 5'   
   $ 
Horizontal=�6   $
��Left=�6.   $��Bottom=�6I   $��	10,0,0,10q�6d   .+�5(      �� -   5        $��
Назад��5(      $��80��6%   $��30��60   ���#2196F3
�������$��14(�6d   $��0,0,10,0q�6r   6�   �� 5)      -   5        $��
Выход��5)      $��80��6%   $��30��60   ���#f44336
�������$��14(�6d   6r   5*      5+      5,      
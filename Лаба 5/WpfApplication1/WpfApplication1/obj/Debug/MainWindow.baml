   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lb_5Lb_5  5   	       Lb_5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lb_5     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��5q�6   $	��100��6"    �� SelectedItem 6.   �� *	OrderBy+.@�5      �� .��6   
First Name6'   �� 5      .��6   	Last Name6&   �� 5      .��6   	Subject6$   �� 5      .��6   Mark6!   5      �� 5      $��0��6   $��5q�6$   $	��100��6/    6;   �� *Order+.@�5      �� .��6   Asc6$   �� 5      .��6   Desc6%   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��students_perform��5       $��1��6      AutoGenerateColumns .     CanUserAddRows . ��6x   �� *student_performance+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6:   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6F   �� 
 �� Path$
 
first_name�  5"      $ 	Last Name��6%   $	 150 69   	 6E   �� $
 	last_name�  5#      $ Subject��6%   $	 150 67   	 6C   �� $
 subject�  5$      $
 Mark��6%   $	 150 65   	 6A   �� $

 mark�5&      5'      5(      
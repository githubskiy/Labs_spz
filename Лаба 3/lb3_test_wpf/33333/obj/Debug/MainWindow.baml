   M S B A M L   `   `   `  ����@  <33333, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:_33333_33333  5   	       _33333.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:_33333     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
MainWindow��5
   	   $	��450��6   $	��800��6)    � 
ResizeMode$ NoResize=�65   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��270 �6   �� 5      $��60 �6   �� 5      $��20 �6   .+�5   
   �� -   5         ��Name$ Comps��5   3   $��0��6   $��Компьютеры��6!   $��18(�6B   $
��Bold"�6P   $
��0 12q�6b   �� 5   
   -   5        $��Computer_list��5   h   $��0��6   $	��Top=�6~   $��130 12 365 0q�6�   ��6G   �� *
computer+��5      �� 5      .R�5      �� .+�5      �� ��6$   ��  �� Path$ 	comp_name�5      5      5      �� 5!   
   -   5        $��0��5!      $��Изменить��6?   $��440 0 240 0q�6R   �� 5"   
   -   5        $��0��5"   +   $��Добавить��68   $��560 0 120 0q�6K   �� 5#   
   -   5        $��0��5#      $��Удалить��6D   $��	680 0 0 0q�6V   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ tableProcess��5%   �   $��1��6      AutoGenerateColumns .     CanUserAddRows .  ��6�   �� *	process+	   Columns	 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn
   Header$

 name��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� $ 	proc_name�  5)      $

 user��6%    . $	 100 6E    6Q   �� $ 	proc_user�  5*      $	
 cpu��6%    . $	 100 6D    6P   �� $ proc_cpu�  5+      $
 memory��6%    . $	 100 6G    6S   �� $ proc_memory�  5,      $
 location��6%    . $	 100 6I    6U   �� $ proc_location�  5-      $
 description��6%    . $	 100 6L    6X   �� $ proc_description�  5.      $
 priority��6%    . $ * 6I    6S   �� $ proc_priority�50      �� 52   
   -   5        $��2��52      $%��Добавить процесс��6<   $��	0 0 630 0q�6W   �� 53   
   -   5        $��2��53      $#��Удалить процесс��6=   $��170 0 470 0q�6W   �� 54   
   -	   5        $��2��54      $%��Изменить процесс��6?   $��	625 0 0 0q�6Z   �� 56   
   $��3��6   $��	0,0,0,-15q�6!   .@�57      �� $.��(Количество процессов:��6   �� 58      -
   5        $��count_proc_bottom��58   !   $��0��6   6!   �� 59      $��Загрузка ЦП(%):��6   $��20 0 0 0q�60   �� 5:      -   5        $��load_cpu_bottom��5:   !   $��0��6   6!   �� 5;      $+��%Использование ОЗУ(%):��6   $��20 0 0 0q�65   �� 5<      -   5        $��using_ram_bottom��5<   !   $��0��6   6!   5=      5>      5?      
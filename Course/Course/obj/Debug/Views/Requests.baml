   M S B A M L   `   `   `  ����A  =Course, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CourseCourse  5   	       Course.Requests   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Course     5   	     � Title$  Requests��5   	   $	��450��6   $	��800��6'   ��5	      �� 6    �� ImageSource$4 .../Images/Space-red-galaxy-stars_2560x1600.jpg��6%   6d   .��5
      �  � RowDefinitions 5   
   �� 5      $	��31* �6   6+   �� 5      $	��42* �6   6+   �� 5      $	��44* �6   6+   �� 5      $
��302* �6   6,   .+�5   
   o� $��0��6   $	��Top=�6   $��33��65   �� 5   
   $��1��6   
�������$��193,0,252,0q�65   .+�5      �� $��45��6   $��30(�6    $��Center=�6.   $.��(Запросы К базе Данных:��6K   6o   5      �� 5   
   $��2��6   $��2��6"   $��0,0,0,-9q�63   .+�5      �� -   5        $
��tcl2��5      $��1��6%   $��2��65   $��3��6B   .@�5      �� -   5        $��DBmain��5      ��5      �� 5      Основной6/   .��5      &   System.Windows.Controls.DataGrid  -   5        $��	dgvDBmain��5   N   $��1��6   $��2��6/   $��3��6<      AutoGenerateColumns . "   VerticalScrollBarVisibility$
 Auto=�6{   $   HorizontalScrollBarVisibility$
 Auto=�5      ��6D   �� *PostalOfficeRequest+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *SelectedPostOffice+5       5!      �� 5"      -   5        $��	DBreques1��5"      ��5#      �� 5$      Запрос16.   .��5'        -   5        $��dgvrequest1��5'   R   $��1��6#   $��2��63   $��3��6@    . $
 Auto=�6�   $
 Auto=�5(      ��6D   �� *RequestFindPostman+$ TwoWay=�$ PropertyChanged=� 6�   �� *SelectedPostOffice+5)      5,      �� 5.      -   5        $��	DBreques2��5.      ��5/      �� 50      Запрос26.   .��52        -   5        $��dgvrequest2��52   N   $��1��6   $��2��6/   $��3��6<    . $
 Auto=�6}   $
 Auto=�53      ��6D   �� *RequestNumberOfSubEdition+$ TwoWay=�$ PropertyChanged=� 6�   �� *SelectedPostOffice+55      56      �� 58      -   5        $��	DBreques3��58      ��59      �� 5:      Запрос36.   .��5<        -	   5        $��dgvrequest3��5<   N   $��1��6   $��2��6/   $��3��6<    . $
 Auto=�6}   $
 Auto=�5=      ��6D   �� *RequestAVGDate+$ TwoWay=�$ PropertyChanged=� 6�   �� *SelectedPostOffice+5?      5@      �� 5C      -
   5        $��	DBreques4��5C      ��5D      �� 5E      Запрос46.   .��5G        -   5        $��dgvrequest4��5G   N   $��1��6   $��2��6/   $��3��6<    . $
 Auto=�6}   $
 Auto=�5H      ��6D   �� *RequestFindMagazine+$ TwoWay=�$ PropertyChanged=� 6�   �� *SelectedPostOffice+5J      5K      �� 5P      -   5        $��	DBreques5��5P      ��5Q      �� 5R      Запрос56.   .��5T        -   5        $��dgvrequest5��5T   N   $��1��6   $��2��6/   $��3��6<    . $
 Auto=�6}   $
 Auto=�5U      ��6D   �� *RequestMaxSub+$ TwoWay=�$ PropertyChanged=� 6�   �� *SelectedPostOffice+5W      5X      �� 5Z      -   5        $��	DBreques6��5Z      ��5[      �� 5\      Запрос66.   .��5^        -   5        $��dgvrequest6��5^   N   $��1��6   $��2��6/   $��3��6<    . $
 Auto=�6}   $
 Auto=�5_      ��6D   �� *RequestNumberOfPostmans+$ TwoWay=�$ PropertyChanged=� 6�   �� *SelectedPostOffice+5a      5b      5d      5f      5g      5h      
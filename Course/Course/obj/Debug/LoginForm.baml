   M S B A M L   `   `   `  ����A  =Course, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CourseCourse  5   	       Course.LogInForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Course     5   	     � 
ResizeMode$  CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � Title$ 	LogInForm��5      $	��546��6   $��466.4��6&   ��5      �� 5   
    �� ImageSource$! Images/compute-ea4c57a4.png��6   6A   .��5      �  � RowDefinitions 5   
   �� 5      $
��157* �6   �� 5      $	��26* �6   �� 5      $	��28* �6   �� 5      $	��54* �6   �� 5      $	��44* �6   �� 5      $	��25* �6   �� 5      $	��54* �6   �� 5      $	��26* �6   �� 5      $
��101* �6   �� 5      $��0* �6    � ColumnDefinitions 5   
   �� 5      �� 5       .+�5#   
   �� $��1��6   $��0,0,0,0q�6%   .+�5$      �� $��39��6   
���  ��$��Verdana)�62   
���   �$��
Выход��6Z   $��20(�6j   $��1��6x   $��	141,2,0,0q�6�   $	��Top=�6�   ��6�   �� *	ClosedAll+6�   5%      �� 5&   
   $��0��6   $��0��6%   $��2��62   $��121,22,130,0q�6H   .+�5'      �� $P��J/Images/275-2754806_photo-logo-email-resume-email-icon-png-transparent.png��6   $	��136��6h   $��Center=�6v   $��-60,0,-65,0q�6�   5)      �� 5-   
   $��0��6   $��Center=�6&   $��Center=�6C   $��2��6^   $��38��6r   $��192,151,192,22q�6~   $��3��6�   $��74��6�   .+�5.      �� $��Вход��6   $��Verdana)�6#   $��Center=�68   $��Center=�6U   $��23(�6p   
�������$��75��6�   6�   5/      �� 50   
   $��2��6   $��0��6"   $��Center=�63   $��Center=�6P   $��2��6k   $��28��6   $��201,0q�6�   $��56��6�   .+�51      �� $��
Логин��6   $��Verdana)�6$   $��Center=�69   $��Center=�6V   $��15(�6q   
����+��6�   52      �� 53   
   $��3��6   $��0��6"   $��Center=�63   $��Center=�6P   $��2��6k   $��28��6   $��84,13q�6�   $	��290��6�   .+�55      �� $��0,3,0,1q�6B   $	��290��6S   $��26��6_   $��Center=�6k   $��Center=�6�    �� TextAlignment$ Center=�6�   $��Verdana)�6�   ��6   �� *
UserName+ �� Mode$ TwoWay=�.��6�   	 J� Effect	 56      3  -System.Windows.Media.Effects.DropShadowEffect  57      
   ShadowDepth$
 0Q�6'      
BlurRadius$ 1Q�67      Color$ Black��6F   .��58   "   59      5;      �� 5<   
   $��4��6   $��0��6"   $��Center=�63   $��Center=�6P   $��2��6k   $��28��6   $��196,43,196,52q�6�   $��3��6�   $��66��6�   .+�5=      �� $��Пароль��6   $��Verdana)�6%   $��Center=�6:   $��Center=�6W   $��15(�6r   
��� ���6�   5>      �� 5@   
   $��6��6   $��0��6"   $��Center=�63   $��Center=�6P   $��2��6k   $��26��6   $��84,14q�6�   $	��290��6�   .+�5A      �� $��0,3,0,1q�6A   $	��290��6T   $��26��6`   $��Center=�6m   $��Center=�6�   $ Center=�6�   ��6   �� *
Password+$ TwoWay=�.��6�   	 5C        5D      $
 0Q�6'   $ 1Q�67   $ Black��6F   .��5E   "   5G      5I      �� 5J   
   $��7��6   $��0��6"   $��2��62   .+�5L      �� $��26��6   .��5M      �� $	��456��6   $��24��6(   
���  ��$��Verdana)�6i   $��20(�6~    �� TextAlignment$ Center=�6�   $��Center=�6�   $��Center=�6�   ��64   �� *Right+$ TwoWay=�6�   5N      5O      �� 5P   
   $��8��6   $��0��6#   $��Center=�64   $��Center=�6Q   $��42��6l   $��99,31,93,28q�6x   $	��266��6�   $��2��6�   .+�5R      �� $��43��6   
����� �$��Verdana)�63   
���   �$��Вход��6[   $��30(�6j   ��6x   �� *Login+6�   5T      5V      5W      
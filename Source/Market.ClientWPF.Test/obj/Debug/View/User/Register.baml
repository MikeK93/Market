   M S B A M L   `   `   `  ����P  LMarket.ClientWPF.Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Market.Model.EntitiesMarket.Model.Entities  5   	   )    #Market.ClientWPF.View.User.Register   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   =modelEntities#clr-namespace:Market.Model.Entities     5   	   -   5          � Title$  Register��5   	   $
��auto��6   $	��300��6(    � WindowStyle$ 
ToolWindow=�64    � 
ResizeMode$ NoResize=�5   	   .��5	      � $��Center=�6   $��Center=�6&    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   ��5      �� 5      $��Аккаунт��6   $��Italic$�6+   $��10(�6>   .��5      �  5      �� 5      $
��auto �6$   �� 5      $
��auto �6$    � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      �� 5      $��0* �6'   .+�5      �� $��0��6   $��0��6)   $��Логин:��5       $
��10,8q�6(   �� 5!      $��0��6   $��1��6'   $
��10,8q�5"      $��80��5#      ��5$      �� *PWord+ �� ValidatesOnDataErrors . .��6M    =� ErrorTemplate 5%      �� 5&      .R�5'      �� .+�5)   "   ��  ��Name$ textBox��6<   �� 5*   "   ��6/   �� ��5+   &   �� 5,   *   .R�5-   .   �� 
���  ��$��9(�5.   0   $��Italic$�6=   ��5-   8   �� *ErrorContent+5.   =   5/   +   51   #   52      53      .��54   0   55      �� 57      $��1��6   $��0��6)   $��Пароль:��58      $
��10,8q�6)   �� 59      $��1��6   $��1��6'   $
��10,8q�5:      $��80��5;      ��5<      �� *Login+ . .��6M    5=      �� 5>      .R�5?      �� .+�5A   "   �� $ textBox��6<   �� 5B   "   ��6/   �� ��5C   &   �� 5D   *   .R�5E   .   �� 
���  ��$��9(�5F   0   $��Italic$�6=   ��5E   8   �� *ErrorContent+5F   =   5G   +   5I   #   5J      5K      .��5L   0   5M      5P      5Q      �� 5S   
   $��1��6   ��5T      �� 5U      $3��-Персональная информация��6   $��Italic$�6;   $��10(�6N   .��5W      �  5X      �� 5Y      $
��auto �6$   �� 5Z      $
��auto �6$   �� 5[      $
��auto �6$   �� 5\      $
��auto �6$   �� 5]      $
��auto �6$   �� 5^      $
��auto �6$    5`      �� 5a      $
��auto �6'   �� 5b      $��* �6'   .+�5e      �� $��0��6   $��0��6)   $��Имя:��5f      $
��10,8q�6&   �� 5g      $��0��6   $��1��6'   $
��10,8q�5h      $��80��5i      ��5j      �� *FName+ . .��6M    5k      �� 5l      .R�5m      �� .+�5o   "   �� $ textBox��6<   �� 5p   "   ��6/   �� ��5q   &   �� 5r   *   .R�5s   .   �� 
���  ��$��9(�5t   0   $��Italic$�6=   ��5s   8   �� *ErrorContent+5t   =   5u   +   5w   #   5x      5y      .��5z   0   5{      �� 5}      $��1��6   $��0��6)   $��Отчество:��5~      $
��10,8q�6+   �� 5      $��1��6   $��1��6'   $
��10,8q�5�      $��80��5�      ��5�      �� *MName+ . .��6M    5�      �� 5�      .R�5�      �� .+�5�   "   �� $ textBox��6<   �� 5�   "   ��6/   �� ��5�   &   �� 5�   *   .R�5�   .   �� 
���  ��$��9(�5�   0   $��Italic$�6=   ��5�   8   �� *ErrorContent+5�   =   5�   +   5�   #   5�      5�      .��5�   0   5�      �� 5�      $��2��6   $��0��6)   $��Фамилия:��5�      $
��10,8q�6*   �� 5�      $��2��6   $��1��6'   $
��10,8q�5�      $��80��5�      ��5�      �� *LName+ . .��6M    5�      �� 5�      .R�5�      �� .+�5�   "   �� $ textBox��6<   �� 5�   "   ��6/   �� ��5�   &   �� 5�   *   .R�5�   .   �� 
���  ��$��9(�5�   0   $��Italic$�6=   ��5�   8   �� *ErrorContent+5�   =   5�   +   5�   #   5�      5�      .��5�   0   5�      �� 5�      $��3��6   $��0��6)   $��Email:��5�      $
��10,8q�6(   �� 5�      $��3��6   $��1��6'   $
��10,8q�5�      $��80��5�      ��5�      �� *Email+ . .��6M    5�      �� 5�      .R�5�      �� .+�5�   "   �� $ textBox��6<   �� 5�   "   ��6/   �� ��5�   &   �� 5�   *   .R�5�   .   �� 
���  ��$��9(�5�   0   $��Italic$�6=   ��5�   8   �� *ErrorContent+5�   =   5�   +   5�   #   5�      5�      .��5�   0   5�      �� 5�      $��4��6   $��0��6)   $��Пол:��5�      $
��10,8q�6&   �� 5�      $��4��6   $��1��6(   $
��10,8q�5�      $��80��5�      ��5�      �� *Gender+ �� SelectedItem 5�      �� *SelectedGender+�� 5�      $��5��6   $��0��6)   $��	Роль:��5�      $
��10,8q�6'   �� 5�      $��5��6   $��1��6(   $
��10,8q�5�      $��80��5�      ��5�      �� *Roles+ 5�      �� *SelectedRole+5�      5�      �� 5�   
   $��2��6   	 �� Orientation$	 
Horizontal=�5�      $��Center=�5�      .+�5�      �� -   5        $��btnQuit��5�      $��
Выйти��5�      $��	5,10,5,10q�5�      $
��10,2q�5�      
 �� IsCancel
 . 5�      �� 5�      $��Регистрация��6   $��	5,10,5,10q�5�      $
��10,2q�5�       �� 	IsDefault . ��5�      �� *RegisterCommand+5�      5�      5�      
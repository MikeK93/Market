   M S B A M L   `   `   `  ����  Market.ClientWPF.Test&     Market.ClientWPF.View.User.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Login��5   	   $	��167��6   $	��376��6$    � WindowStyle$ 
ToolWindow=�60    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6   .��5      � $��Center=�6   $��Center=�6&    � RowDefinitions 5   
   �� 5	      $
��auto �6   �� 5
      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6    $��2��6-   $��yD:\Files\Studying\Лабораторки\EXAMPLES\EpamClasses\Market\Market\Source\Market.ClientWPF.Test\Assets\login.png��5      $��40��5      �� 5   
   $��0��6   $��1��6!   $��4,8,10,8q�5      $��Логин:��5      �� 5   
   $��1��6   $��1��6!   $��4,8,10,8q�5      $��Пароль:��5      �� 5   
   -   5        $��txtLogin��5$      $��0��5      $��2��6   $��4,8,4,8q�5       $	��100��5!      $	��120��6$   ��5"      �� *Login+ �� ValidatesOnDataErrors . .��5$   %    =� ErrorTemplate 5%      �� 5&      .R�5'      �� .+�5)      ��  ��Name$ textBox��64   �� 5*      ��6'   �� ��5+      �� 5,   "   .R�5-   &   �� 
���  ��$��9(�5.   0   $��Italic$�6=   ��5-   0   �� *ErrorContent+5.   =   5/   #   51      52      53      .��54   (   55      G� 5M   
   -   5        $��pwdBox��5P      $��1��5M      $��2��6#   $��4,8,4,8q�5N      $	��100��5O      $	��120��6$   5P      �� 5R   
   $��2��6   $��1��6"   $��2��62   	 �� Orientation$	 
Horizontal=�5S      $��Center=�6.   .+�5T      �� -   5        $��btnLogin��5V      $��
Войти��5T      $��4,8,10,8q�5U      $	��4,2q�6'   5V   %   �� 5X      $��Регистация��6   $��4,8,10,8q�5Y      $	��4,2q�6'   ��5Z      �� *RegisterCommand+5[      5\      5]      
   M S B A M L   `   `   `  ����E  AOopProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OopProject.ViewsOopProject.Views  5      #    OopProject.Views.RegisterView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:OopProject.Views     5        � DataContext  5
      ��    Locator �� Source# [   �� Path$ Register�.��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Nickame��6   $��20(�6#   $��Center=�61   �� 5   
   $��Center=�6<   ��6   �� *NicknameStr+ �� Mode$ TwoWay=�6<   �� 5   
   $��Password��6   $��20(�6$   $��Center=�62   $��1��6M   �� 5   
   $��Center=�6<   $��1��6Y   ��6   �� *PasswordStr+$ TwoWay=�6Y   	� 5   
   $��Employee��6   $��2��6N   $��Right=�6[   $��Center=�6w   $	��100��6�    d� 	IsChecked 6)   �� *IsSelected[0]+6�   	� 5   
   $��Customer��6   $��2��6N   $��Center=�6[   $
��Left=�6w   $	��100��6�    6)   �� *IsSelected[1]+6�   �� 5   
   $��Register��6   $��3��6%   $��2��62   ��6F   �� *JoinClickCommand+5      5      
   M S B A M L   `   `   `  ����E  AOopProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OopProject.ViewsOopProject.Views  5      $    OopProject.Views.AddRecordView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:OopProject.Views     5        � DataContext  5	      ��    Locator �� Source# [   �� Path$ 	AddRecord�.��5
      �  � ColumnDefinitions 5   
   �� 5      $	��500 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Enter Record Name:��6   $��20(�6.   $��0��6=   �� 5   
   $��0��68   ��6   �� *	NameStr+ �� Mode$ TwoWay=�68   �� 5   
   $��Enter Band/Singer Name :��6   $��20(�64   $��Center=�6B   $��1��6]   �� 5   
   $��1��6:   ��6   �� *	AuthorStr+$ TwoWay=�6:   �� 5    
   $"��Enter Price Before Discount:��6   $��20(�68   $��Center=�6F   $��2��6a   �� 5!   
   -   5        $��2��5!   q   ��6   �� *PriceBeforeDiscountStr+$ TwoWay=�6q   �� 5#   
   $$��    Enter Discount Percentage:��6   $��20(�6;   $��Center=�6I   $��1��6d   �� 5$   
   -   5        $��1��5$   p   ��6   �� *DiscountPercentageStr+$ TwoWay=�6p   �� 5&   
   $��    Enter Publish Date:��6   $��20(�63   $��Center=�6A   $��1��6\   $��1��6l   (  "System.Windows.Controls.DatePicker  5'   
   $	��150��6n   $	��100��6z   $��2��6�   $��1��6�      DisplayDateEnd 6   �� *PublishDate+   SelectedDate 6<   �� *PublishDate+$ TwoWay=�6�   �� 5*   
   $(��"    Select Categories (Maximum 3):��6   $��20(�6>   $��Center=�6L   $��1��6g   $��3��6w   �� 5,   
    �� SelectionMode$ Multiple=�6   $��Center=�6,   $��Right=�6G   $	��250��6c   $	��150��6o   $��1��6|   $��3��6�   $��3��6�   .@�5-      �� $��HipHop��6   	 d� 	IsChecked	 6(   �� *CategoriesCollection[0]+$ TwoWay=��� 5.      $
��Rock��6   	 6&   �� *CategoriesCollection[1]+$ TwoWay=��� 5/      $��RhythmAndBlues��6   	 60   �� *CategoriesCollection[2]+$ TwoWay=��� 50      $
��Soul��6   	 6&   �� *CategoriesCollection[3]+$ TwoWay=��� 51      $��Reggae��6   	 6(   �� *CategoriesCollection[4]+$ TwoWay=��� 52      $��Country��6   	 6)   �� *CategoriesCollection[5]+$ TwoWay=��� 53      $
��Funk��6   	 6&   �� *CategoriesCollection[6]+$ TwoWay=�54      �� 55   
   $��
Add Record��6   $��5��6'   $��2��64   ��6H   �� *AddRecordClickCommand+56      57      
   M S B A M L   `   `   `  ����E  AOopProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OopProject.ViewsOopProject.Views  5      !    OopProject.Views.ReportView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:OopProject.Views     5        � DataContext  5	      ��    Locator �� Source# [   �� Path$ Report�.��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $	��150��5      $	��350��6   $��0��6,   $��7��6<    �� DisplayMemberPath$ ItemName��6o   ��6N   �� *
AllItems+ �� SelectedItem 6�   �� *CurrentItem+6�   �� 5   
   -   5        $	��150��5      $	��350��6   $��2��6,   $��7��6<   $ ItemName��6r   ��6N   �� *FiltersItem+ 6�   �� *CurrentItem+6�   �� 5   
   $�� Old Publish Date��6   $��1��6-   $��1��6=   (  "System.Windows.Controls.DatePicker  5   
   $	��150��6o   $	��100��6{   $��1��6�   $��1��6�      DisplayDateEnd 6   �� *PublishDate+   SelectedDate 6=   �� *PublishDate+	 �� Mode$	 TwoWay=�6�   �� 5   
   $��Author Name��6   $��1��6'   $��2��67   �� 5   
   $��2��6:   $��1��6G   ��6   �� *	AuthorStr+$	 TwoWay=�6G   �� 5    
   $��Discount��6   $��1��6$   $��3��64   �� 5!   
   $��3��6G   $��1��6T   ��6   �� *DiscountPercentageStr+$	 TwoWay=�6T   �� 5"   
   $��
Item Price��6   $��1��6&   $��4��66   �� 5#   
   $��4��6G   $��1��6T   ��6   �� *PriceBeforeDiscountStr+$	 TwoWay=�6T   	� 5$   
   $
��Book��6   $��1��6I   $��5��6Y   $
��Left=�6f   $	��100��6�   
 d� 	IsChecked
 6%   �� *IsSelected[0]+6�   	� 5%   
   $��Record��6   $��1��6K   $��5��6[   $��Right=�6h   $	��100��6�   
 6'   �� *IsSelected[1]+6�   	� 5&   
   $
��Both��6   $��1��6I   $��5��6Y   $��Center=�6f   $	��100��6�   
 6%   �� *IsSelected[2]+6�   �� 5'   
   $��	Show Item��6   $��1��6%   $��6��65   ��6B   �� *ShowItemClickCommand+�� 5(   
   $��
Get Report��6   $��2��6&   $��6��67   ��6D   �� *ShowReportClickCommand+5)      5*      
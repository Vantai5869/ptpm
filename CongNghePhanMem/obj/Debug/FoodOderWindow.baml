   M S B A M L   `   `   `  ����J  FCongNghePhanMem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CongNghePhanMemCongNghePhanMem  5      $    CongNghePhanMem.FoodOderWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CongNghePhanMem     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        � Title$  FoodOderWindow��5	      $
��1000��5
      $	��550��5       � WindowStartupLocation$ CenterScreen=�5         
FoodOderVM � DataContext# [  5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedWindowCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��5* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��1.6* �6    �� 5      $��8* �6    .+�5!      � $��0��6   ���#ff7f50.+�5"      �� $��Cooper)�6   
��� ���$��40(�6B   $��Center=�6P   $��Center=�6m   	FOOD ODER6�   5#      � 5$      $��1��6   .+�5%      �� $��1��5&      $��1��5'      $��Visible=�5(      $��Visible=�5)      .��5*      #  MaterialDesignThemes.Wpf.Card  $��1��6*   $��5q�67   .��5+      �� -   5        $��lvBill��5+   #   $	��365��6S   ��61   �� *	fBillList+	 �� View	 5,      �� 5-   "   .P�5.   &   �� $��	Tên Món��50   )   $��20(�51   )   $
��Bold"�52   )   
 �� DisplayMemberBinding
 5/   )   �� *name+52   )   �� 53   &   $
��Giá��55   )   $��20(�56   )   $
��Bold"�57   )   
 54   )   �� *price+57   )   �� 58   &   $��Số Lượng��5:   )   $��20(�5;   )   $
��Bold"�5<   )   
 59   )   �� *number+5=   '   �� 5>   &   $��Thành Tiền��5@   )   $��20(�5A   )   $
��Bold"�5B   )   
 5?   )   �� *pay+5B   )   5C   #   5E      5F      5G      5H      5I      � 5L   
   
����ح�$��1��6&   $��0.4,0,-0.4,-0.2q�67    5M      �� 5N      $��1* �6    �� 5O      $��4* �6    �� 5P      $��1* �6    .+�5R      ]� $��0��6   
�������.+�5S      �� $	��120��5T      $��35��6!   
�������)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Loại món ăn��5V      $
��Left=�5X      $
��50 5q�60    �� SelectedItem 5U      �� *SelectedItemFType+��5W      �� *	fTypeList+��5Y      �� 5Z      .R�5[      �� .+�5\   "   �� $y�	Collapsed=�6,   $��0��6C   ��6M   �� *id+�� 5]   "   ��6,   �� *name+6D   5^      5_      5a      �� 5b      -   5         ��Name$ 	txtSearch��5b      $  Nhập tên món ăn:��5d      $	��250��6M   $��35��6Y   
�������$��5q�5e   1   ��5c      ��  �� Path$ Filter� �� UpdateSourceTrigger$ PropertyChanged=�5e   1   5f      �� 5h      $��1��6    5i      �� *SelectedItem+ �� Mode$ OneWayToSource=�$ PropertyChanged=���5j      �� *
foodList+��5k      �� 5l      .R�5m      �� $��10q�6!   $	��105��6-   $	��160��69   ._�5n      ��  ��Name$ bdName��6)   .+�5o   "   �� $	��100��6)   $	��100��65    �� CornerRadius$ 5��6B   $��5q�6S    J� Effect 5p   &   3  -System.Windows.Media.Effects.DropShadowEffect  5q   *      ShadowDepth$ 1Q�6;   ��5s   &   �� 5t   *    �� ImageSource 65   �� *image+5v   #   �� 5w   "    ��Name$ tblName��6n   $
��Bold"�6,   $��Comic Sans MS)�6>   ���#a52a2a$��Center=�6   ��6�   �� *name+�� 5x   "   $��Center=�6Y   ��6,   �� *price+ �� StringFormat$ {0:C}��6Y   5z      5{      5|      ��5~      �� 5      .R�5�      � 5�      5�      � 5�      $��2��6   
������� 5�      �� 5�      $��1* �6'   �� 5�      $��1* �6'   �� 5�      $��1* �6'   �� 5�      $��1* �6'   �� 5�      $��1* �6'   �� 5�      $��1* �6'   �� 5�      $��1* �6'   .+�5�      �� $��0��6   
�������
���i����6*   �� *AddCommand1+.��6y   15�      �� 5�      $��1��6   
�������
���i��$
��Bold"�6x   ��6)   �� *AddCommand2+.��6�   25�      �� 5�      $��2��6   
�������
���i��$
��Bold"�6x   ��6)   �� *AddCommand3+.��6�   35�      �� 5�      $��3��6   
�������
���i��$
��Bold"�6x   ��6)   �� *AddCommand4+.��6�   45�      �� 5�      $��4��6   
�������
���i��$
��Bold"�6x   ��6)   �� *AddCommand5+.��6�   55�      �� 5�      $��5��6   
�������
���i��$
��Bold"�6}   ��6)   �� *EnterTextCommand+.��6�   =>5�      �� 5�      $��6��6   $��32��6*   
�������$  Số lượng...��6�   ��6N   �� $ 	EnterText�$ PropertyChanged=�6�   5�      5�      5�      5�      
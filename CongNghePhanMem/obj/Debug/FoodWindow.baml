   M S B A M L   `   `   `  ����J  FCongNghePhanMem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CongNghePhanMemCongNghePhanMem  5   	        CongNghePhanMem.FoodWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CongNghePhanMem     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   -   5          �Name$  window��5   	    
  FoodVM � DataContext# [  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Món ăn��5   	   $	��550��6   $
��1050��6%   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedWindowCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��199* �6   �� 5      $
��282* �6   .+�5   
   � $��0��6   
�������	 � RowDefinitions	 5      �� 5      $��4* �6    �� 5      $��1* �6    .+�5      � $��0��6   $��0 35 0 0q�6    .+�5      �� .+�5       �� $��Cambria)�6    $��5 0 0 0q�65   $��20(�6F   $��DemiBold"�6T   Name:6r   �� 5!      $��5q�6   
���������6)   �� *name+
 �� UpdateSourceTrigger$
 PropertyChanged=�6d   �� 5"      $��Cambria)�6    $��5 0 0 0q�65   $��20(�6F   $��DemiBold"�6T   Price:6t   �� 5#      -   5        $��tbPrice��5#   )   $��5q�6   
���������68   �� *price+$
 PropertyChanged=�6t   �� 5$      $��Cambria)�6    $��5 0 0 0q�65   $��20(�6F   $��DemiBold"�6T   Type of Food:5%      �� 5&      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Loại món:��5(      $
��Left=�5)      $��5q�5+      $	��120��6$   $��15(�60   $
��Bold"�6>    �� SelectedItem 5'      �� *SelectedItemFTypeOnPost+��5*      �� *	fTypeList+��5,      �� 5-      .R�5.   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5/   &   �� $��0��60   $y�	Collapsed=�6:   ��6Q   �� *id+6g   �� 50   &   ��60   �� *name+6H   51   #   52      54      �� 55      $��Cambria)�6    $��5 0 0 0q�65   $��20(�6F   $��DemiBold"�6T   Image6r   ]� 56      .+�57      �� $
��Left=�58      $��5q�59      
���P����5:      �� *OpenFileCommand+.��6A   Image5;      �� 5<      $��Right=�5=      $��90��64   ��5>      �� *image+$
 PropertyChanged=�5?      5A      5B      � 5C      
�������$��1��6/   .+�5D      ]� .+�5E      �� $��80��6   $��20q�6G   ��6(   �� *
AddCommand+.��6S   ADD6X   �� 5F      $��80��6   ��6(   �� *EditCommand+.��6H   Update6P   �� 5G      $��80��6   ��6(   �� *DeleteCommand+.��6J   Delete6R   5H      5I      5J      � 5K   
   
����ح�$��1��6&   	 5L      �� 5M      $��1* �6    �� 5N      $��4* �6    .+�5P      ]� 
�������.+�5Q      �� $	��120��5R      $��35��6!   
�������$ Loại món ăn��5T      $
��Left=�5V      $��30 0 5 0q�60    5S      �� *SelectedItemFType+��5U      �� *	fTypeList+��5W      �� 5X      .R�5Y      �� .+�5Z   "   �� $y�	Collapsed=�6,   $��0��6C   ��6M   �� *id+�� 5[   "   ��6,   �� *name+6D   5\      5]      5_      �� 5`      -   5         ��Name$ 	txtSearch��5`      $  Nhập tên món ăn:��5a      $	��250��6M   $��35��6Y   
�������$��30 0 5 0q�6|   ��5`   -   ��  �� Path$ Filter�$
 PropertyChanged=�5a   |   �� 5b      $��5q�6   
�����_�$��80��6;   $��35��6F   $��Right=�6R   .��5c      '  !MaterialDesignThemes.Wpf.PackIcon  $	��Top=�6.   $��20��6F   $��20��6Q      Kind$ Magnify=�6]   5d      5e      �� 5f      $��1��6    5g      �� *SelectedItem+ �� Mode$ OneWayToSource=�$
 PropertyChanged=���5h      �� *
foodList+��5i      �� 5j      .R�5k      �� $��10q�6!   $	��105��6-   $	��160��69   ._�5l      ��  ��Name$ bdName��6)   .+�5m   "   �� $	��100��6)   $	��100��65    �� CornerRadius$ 5��6B   $��5q�6S    J� Effect 5n   &   3  -System.Windows.Media.Effects.DropShadowEffect  5o   *      ShadowDepth$ 1Q�6;   ��5q   &   �� 5r   *    �� ImageSource 65   �� *image+5t   #   �� 5u   "    ��Name$ tblName��6n   $
��Bold"�6,   $��Comic Sans MS)�6>   ���#a52a2a$��Center=�6   ��6�   �� *name+�� 5v   "   $��Center=�6Y   ��6,   �� *price+ �� StringFormat$ {0:C}��6Y   5x      5y      5z      ��5|      �� 5}      .R�5~      � 5      5�      5�      5�      5�      
   M S B A M L   `   `   `  ����C  ?eggstore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:eggstore.src.Boxeseggstore.src.Boxes  5   	   !    eggstore.src.Boxes.Ingresar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:eggstore.src.Boxes     5   	     � WindowStyle$
  none=�5   	   
������ $��20(�5
   	    � AllowsTransparency .  � Title$ Ingresar��5   	   $	��184��6   $	��266��6'    � 	Resources 5         TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  TextBoxStyle1 �� 
TargetType �� Property �� Value-  'System.Windows.Input.KeyboardNavigation �� 
TargetType	 ��Name
 �� CornerRadius J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value  FocusVisual �� StrokeDashArray  Button.Static.Background1  Button.Static.Border1   Button.MouseOver.Background1  Button.MouseOver.Border1 	 Button.Pressed.Background1 
 Button.Pressed.Border1  Button.Disabled.Background1  Button.Disabled.Border1  Button.Disabled.Foreground1  BTNSTYLE ��Name��%�  &	        &	 #     &	 F     &	 i     7   7  7  &	 o    &	     &	 <    &	 _    &	 �    &		 �    &	
 �    &	 �    &	     &	 9    &	 \    �� 5   
   $ 	#FFABAdB3��68   �� 5   
   $ 	#FF7EB4EA��6;   �� 5   
   $ 	#FF569DE5��67   �� 5   
   " ��6&   .�5      ��  � ��# � ��6+   �� 5       � ��8   6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       �@ TabNavigation$
 None=�6A   �� 5       � ��$
 Left=�6;   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@J�	AllowDrop . 6*   �� 5       �@��PanningMode$ VerticalFirst=�69   �� 5       �@��IsFlicksEnabled .  67   �� 5       � �� 5      �� 5      " ��6&   .R�5       �� $	 border��63   $
 10��6!   #��z��6C   #��z��6m   #��z��6�    . ._�5!      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5"       5#      P� 5$       � {� .  . �5%   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5&      P� 5'       �@J�IsMouseOver . . �5(   "   �� $ border��6@   8   � ��6T   5)      P� 5*       �@J�IsKeyboardFocused . . �5+   "   �� $ border��6@   8   � ��6T   5,      5.      50       51      ]� 52       53      �� 54      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 55       �@��IsSelectionActive .  6A   ./�57      ��  �@��SelectionBrush# � /�67   58      5:      �� 5;   
   .�5<      ��  � �� 5=      �� 5>      .R�5?      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5@      5B      5C      �� 5F   
   $ 	#FFDDDDDD��6<   �� 5G   
   $ 	#FF707070��68   �� 5H   
   $ Transparent��6?   �� 5I   
   $ Transparent��6;   �� 5J   
   $ Transparent��6=   �� 5K   
   $ Transparent��69   �� 5L   
   $ 	#FFF4F4F4��6>   �� 5M   
   $ 	#FFADB2B5��6:   �� 5N   
   $ 	#FF838383��6>   �� 5O   
   " ��6!   .�5P      ��  � �� �#ff8c416+   �� 5Q       � �� �#FFF9C46,   �� 5R       � ��
 ���� 6+   �� 5S       � ��$ 1q�60   �� 5T       � ��$ Center=�6;   �� 5U       � ��$ Center=�69   �� 5V       � ��$ 1q�6(   �� 5W       � �� 5X      �� 5Y      " ��6&   .R�5Z      �� $	 border��6!   #��z��61   #��z��6[   #��z��6�    . ._�5[      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5\       5]      P� 5^       �@��IsDefaulted . . �5_   "   �� $ border��6@   # � ��6T    � ��5`      P� 5a       �@J�IsMouseOver . . �5b   "   �� $ border��6?    � �� �#ff8c006S   �� 5c   "   $ border��6@    � �� �#ff8c006T   5d      P� 5e       � �� . . �5f   "   �� $ border��6?    � �� �#ff8c006S   �� 5g   "   $ border��6@    � �� �#ff8c006T   5h      P� 5i       � {� .  . �5j   "   �� $ border��6?    � �� �#FFF9C46S   �� 5k   "   $ border��6@    � �� �#FFF9C46T   �� 5l   "   $ contentPresenter��6K    � ��
 ���� 6i   5m      5o      5q      5r      5s      .��5u      �� $
 10��6   ���#fff._�5w   
   � $��25q�6    � RowDefinitions 5x      �� 5y      $��* �6    �� 5z      $��10 �6    �� 5{      �� 5|      $��10 �6    �� 5}      $��* �6    .+�5      �� $��0��6   $��Cantidad��5�      $��Center=�5�      �� 5�      -   5         ��Name$ 
tbcantidad��5�      $��2��5�      $	��150��5�      #���  5�      $��Center=�5�      $��Center=�5�      �� 5�      -   5         ��Name$ BtnOk��5�      $��4��5�      
����� �#���  5�      $��	Confirmar��5�      $	��100��5�      ���#000 �� 	IsDefault .  � Cursor$
 Hand��5�      $
��Left=�5�      5�      �� 5�      -   5        $ BtnCancelar��5�      $��4��5�      #���  5�      $��Cancelar��5�      $	��100��5�      ���#000 . $
 Hand��5�      $��Right=�5�      5�      5�      5�      5�      
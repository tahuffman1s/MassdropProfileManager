   M S B A M L   `   `   `  ����Q  MMassDropProfileManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MassDropProfileManagerMassDropProfileManager  5   	   '    !MassDropProfileManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:MassDropProfileManager     5   	     � Icon$  drop.ico��5   	    � Title$ Drop Keyboard Flasher��5	   	   $	��450��6'   $	��800��64   
�������.��5
      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��35 �6   �� 5      $��1* �6   �� 5      $	��.5* �6   .+�5   
   o� $��0��6   .@�5      m� $
��File��6   .@�5      m� -   5        $��mnuSettings��5      $��Settings��6.   6@   5      m� 5      $��Tools��6   .@�5      m� -   5        $��mnuDumpFirmware��5      $��Dump Firmware��6P   5      5      �� 5   
   $��1��6   $��5,0,0,0q�6   .��6.   	Profiles:69   �� 5   
   -   5        $��
btnRefresh��5      $��Right=�6<   $��1��6X   $��25��6e   $��0,5,10,0q�6q   $	��100��6�   $��Refresh��6�   $	��Top=�6�   �� 5   
   -   5        $��
lbProfiles��5      $��2��6   $��25��61   $
��Auto��6@   $
��Auto��6N   $��
10,0,10,10q�6[   � 5   
   $��3��6    � ColumnDefinitions 5      �� 5      $	��.5* �6#   �� 5      $	��.5* �6#    5!      �� 5"      .+�5$      �� -   5        $��Scroller��5$   T   $��0��6   $
��Left=�6)   $��0��6D   
���   �$��	10,0,0,10q�6w   $��Hidden=�6�   $
��1000��6�   .��5%      �� .+�5&      �� ��6#   �� *ConsoleOutput+ �� Mode$ OneWay=���5'      �� 5(      .R�5)   "   �� 
���2�2�$��Consolas)�6[    J� IsManipulationEnabled .  ��6,   ��  �� Path$ .�6q   5*      5,      �� 5-      -   5        $��
InputBlock��5-   �   
���   �
�������{�.  $��Consolas)�6�    �� 
IsReadOnly . ��6   �� *ConsoleInput+$ TwoWay=���6�   Z�  �� SelectionBrush 6�   Z� 6�   5.      5/      �� 50      $��1��6   $��Right=�6(   $��	4,3,130,0q�6D   .,Use fn + b to put device into flashing mode,�� 52      after hitting flash button.6<   �� 53      -   5        $��btnFlash��53      $��1��6=   $��Right=�6M   $��0��6i   $��25��6v   $��0,0,10,0q�6�   $	��100��6�   $��Flash��6�   $	��Top=�6�   �� 54      -   5        $��btnConfigure��54      $��1��6D   $��Right=�6T   $��0��6p   $��25��6}   $��	0,35,10,0q�6�   $	��100��6�   $��	Configure��6�   $	��Top=�6�   55      5:      5;      
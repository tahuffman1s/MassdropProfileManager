   M S B A M L   `   `   `  ���� Q  MMassDropProfileManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MassDropProfileManagerMassDropProfileManager  '    !MassDropProfileManager.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:MassDropProfileManager       � Icon$  drop.ico�� � Title$ Drop Keyboard Flasher��$	��450��$	��800��
�������.���  � RowDefinitions �� $��25 ��� $��35 ��� $��1* ��� $	��.5* �.+�o� $��0��.@�m� $
��File��.@�m� -   $��mnuSettings��$��Settings��m� $��Tools��.@�m� -   $��mnuDumpFirmware��$��Dump Firmware���� $��1��$��5,0,0,0q�.��	Profiles:�� -   $��
btnRefresh��$��Right=�$��1��$��25��$��0,5,10,0q�$	��100��$��Refresh��$	��Top=��� -   $��
lbProfiles��$��2��$��25��$
��Auto��$
��Auto��$��
10,0,10,10q�� $��3�� � ColumnDefinitions �� $	��.5* ��� $	��.5* � �� .+��� -   $��Scroller��$��0��$
��Left=�$��0��
���   �$��	10,0,0,10q�$��Hidden=�$
��1000��.���� .+��� ���� *ConsoleOutput+ �� Mode$ OneWay=����� .R��� 
���2�2�$��Consolas)� J� IsManipulationEnabled .  ����  �� Path$ .��� -   $��
InputBlock��
���   �
�������{�.  $��Consolas)� �� 
IsReadOnly . ���� *ConsoleInput+$ TwoWay=���Z�  �� SelectionBrush Z� �� $��1��$��Right=�$��	4,3,130,0q�.,Use fn + b to put device into flashing mode,�� after hitting flash button.�� -   $��btnFlash��$��1��$��Right=�$��0��$��25��$��0,0,10,0q�$	��100��$��Flash��$	��Top=��� -   $��btnConfigure��$��1��$��Right=�$��0��$��25��$��	0,35,10,0q�$	��100��$��	Configure��$	��Top=�
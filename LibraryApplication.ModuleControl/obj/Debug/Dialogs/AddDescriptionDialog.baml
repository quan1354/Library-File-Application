   M S B A M L   `   `   `  ����[  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:LibraryApplication.ModuleControl.Dialogs(LibraryApplication.ModuleControl.Dialogs  5   	   C    =LibraryApplication.ModuleControl.Dialogs.AddDescriptionDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:LibraryApplication.ModuleControl.Dialogs     5   	     � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � Title$ AddDescriptionDialog��5   	   $	��450��6&   $	��800��63   .��5      ��  �� CornerRadius$ 20��6   ._�5   
   �  � RowDefinitions 5      �� 5      $��33 �6    �� 5      $��* �6    .+�5      � $��0��6   
�����_� � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� $��5q�5      $��18(�5      $
��Bold"�5      $��0��5      $��Center=�5      
�������$
��Left=�5!      Description Configuration5#      �� 5%      -   5         ��Name$ CloseWindowButton��5)      $��1��5%      $��30��5&      $��0q�5'       � Cursor$
 Hand��5(      $��Right=�5+      
�������
���  ��$��X��5.      5/      � 51      $��1��6   $��	0,15,10,0q�6     52      �� 53      $��50 �6$   �� 54      $��* �6$   �� 55      $��30 �6$   .+�58      �� -   5        	 ��Name$	 AvailableVideos��58      $
��10 8q�64   ��59      �� 5:      .R�5;      �� ��6(   �� *	VideoName+5<      5>      �� 5@      $��1��6   $��10q�6,   $
��Auto=�68   .��5A      �� -   5        
 ��Name$
 DescriptionBox��5A   U   $��12(�6    �� TextWrapping$
 Wrap=�6,    �� AcceptsReturn . 6U   5B      �� 5D      -   5        $��2��5D      $��10, 0q�6&   .��6N   Save5F      5G      5H      5I      5J      
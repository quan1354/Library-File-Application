   M S B A M L   `   `   `  ����[  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ModuleControl.DialogsModuleControl.Dialogs  5      )    #ModuleControl.Dialogs.GeneralDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ModuleControl.Dialogs     5        � 
ResizeMode$  NoResize=�5
       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      $	��450��5      $	��500��6   .��5      ��  �� CornerRadius$ 20��6   ._�5   
   �  � RowDefinitions 5      �� 5      $��33 �6    �� 5      $��* �6    .+�5      � 
�����_� � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� -   5         ��Name$ dialogTitle��5      $��5q�5      $��18(�5      $
��Bold"�5      $��0��5      $��Center=�5       
�������$
��Left=�5"      �� 5$      -   5         ��Name$ CloseWindowButton��5(      $��1��5$      $��30��5%      $��0q�5&       � Cursor$
 Hand��5'      $��Right=�5*      
�������
���  ��$��X��5-      5.      � 50      $��1��6   .+�51      ,� $
��Auto=�6+   .��52      /�  	 /� IsOptimalParagraphEnabled	 . 
 /� IsHyphenationEnabled
 . .T�53      J� $��18(�6$   $��Arial)�62    �� Margin$ 3q�6E   .*�6P   .*�54      �� -   5         ��Name$ dialogMessage��54   "   6;   55      56      57      58      5<      5=      5>      
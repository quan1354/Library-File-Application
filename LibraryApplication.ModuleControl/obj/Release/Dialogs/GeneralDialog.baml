   M S B A M L   `   `   `  ���� [  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ModuleControl.DialogsModuleControl.Dialogs  )    #ModuleControl.Dialogs.GeneralDialog   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:ModuleControl.Dialogs       � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�$	��450��$	��500��.����  �� CornerRadius$ 20��._��  � RowDefinitions �� $��33 ��� $��* �.+�� 
�����_� � ColumnDefinitions �� $��* ��� $��* �.+��� -    ��Name$ dialogTitle��$��5q�$��18(�$
��Bold"�$��0��$��Center=�
�������$
��Left=��� -    ��Name$ CloseWindowButton��$��1��$��30��$��0q� � Cursor$
 Hand��$��Right=�
�������
���  ��$��X��� $��1��.+�,� $
��Auto=�.��/�  	 /� IsOptimalParagraphEnabled	 . 
 /� IsHyphenationEnabled
 . .T�J� $��18(�$��Arial)� �� Margin$ 3q�.*�.*��� -    ��Name$ dialogMessage��
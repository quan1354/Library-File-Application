   M S B A M L   `   `   `  ���� [  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ModuleControl.DialogsModuleControl.Dialogs  ,    &ModuleControl.Dialogs.UpdateFormDialog   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:ModuleControl.Dialogs     T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�$	��450��$	��500��.����  �� CornerRadius$ 20��._��  � RowDefinitions �� $��33 ��� $��* �.+�� $��0��
�����_� � ColumnDefinitions �� $��* ��� $��* �.+��� -    ��Name$ dialogTitle��$��5q�$��18(�$
��Bold"�$��0��$��Center=�
�������$
��Left=��� -    ��Name$ CloseWindowButton��$��1��$��30��$��0q�	 � Cursor$
	 Hand��$��Right=�
�������
���  ��$��X��� $��1��$��	0,35,10,0q� �� $��2* ��� $��2* � �� �� �� �� �� $��80 �.+��� $��0��$��0��$��Center=�.��Name�� -   
 ��Name$

 Name��$��0��$��1���� $��1��$��0��$��Center=�.��Date(  "System.Windows.Controls.DatePicker  -     Name$
 Date��$��1��$��1���� $��2��$��0��$��Center=�.��Description�� -   $
 Description��$��2��$��1���� $��3��$��0��$��Center=�.��Path�� -   $

 Path��$��3��$��1���� -   $ Submit��$��4��$��2��$��5q�$��18(�$��Center=�$��Center=�.��SUBMIT
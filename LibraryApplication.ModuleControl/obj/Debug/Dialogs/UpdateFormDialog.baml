   M S B A M L   `   `   `  ����[  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ModuleControl.DialogsModuleControl.Dialogs  5      ,    &ModuleControl.Dialogs.UpdateFormDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ModuleControl.Dialogs     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      $	��450��5      $	��500��6   .��5      ��  �� CornerRadius$ 20��6   ._�5   
   �  � RowDefinitions 5      �� 5      $��33 �6    �� 5      $��* �6    .+�5      � $��0��6   
�����_� � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� -   5         ��Name$ dialogTitle��5      $��5q�5      $��18(�5      $
��Bold"�5       $��0��5!      $��Center=�5"      
�������$
��Left=�5$      �� 5&      -   5         ��Name$ CloseWindowButton��5*      $��1��5&      $��30��5'      $��0q�5(      	 � Cursor$
	 Hand��5)      $��Right=�5,      
�������
���  ��$��X��5/      50      � 52      $��1��6   $��	0,35,10,0q�6     53      �� 54      $��2* �6'   64   �� 55      $��2* �6'   64    58      �� 59      6'   �� 5:      6'   �� 5;      6'   �� 5<      6'   �� 5=      $��80 �6$   62   .+�5A      �� $��0��6   $��0��6%   $��Center=�65   .��6R   Name6X   �� 5B      -   5        
 ��Name$

 Name��5B   7   $��0��6   $��1��6'   6G   �� 5D      $��1��6   $��0��6%   $��Center=�65   .��6R   Date6X   (  "System.Windows.Controls.DatePicker  5E      -   5          Name$
 Date��5E   ;   $��1��6   $��1��6+   6K   �� 5G      $��2��6   $��0��6%   $��Center=�65   .��6R   Description6_   �� 5H      -   5        $
 Description��5H   7   $��2��6   $��1��6'   6N   �� 5J      $��3��6   $��0��6%   $��Center=�65   .��6R   Path6X   �� 5K      -   5        $

 Path��5K   7   $��3��6   $��1��6'   6G   �� 5M      -   5        $ Submit��5M   T   $��4��6   $��2��6&   $��5q�6:   $��18(�6F   $��Center=�6d   $��Center=�6�   .��6�   SUBMIT6�   5N      5O      5P      5Q      
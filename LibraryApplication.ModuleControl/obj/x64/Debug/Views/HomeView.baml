   M S B A M L   `   `   `  ����[  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ModuleControl.ViewsModuleControl.Views  5      "    ModuleControl.Views.HomeView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ModuleControl.Views     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5	      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   6*   �� 5      $��2* �6   6*   �� 5      $��3* �6   6*   .+�5   
   �� $��0��6   
����ح�
���   �$��0,0,0,1q�6I   ._�5      �  � ColumnDefinitions 5      �� 5      $	��600 �6'   65   �� 5      $��* �6'   63   �� 5      $��10 �6'   64   �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   .+�5       �� $��0��6    �� Orientation$ 
Horizontal=�6-   $
��15,0q�6F   .+�5!      �� $��80��6   $��30��6(   $��SemiBold"�6R   ��64   �� *	UpCommand+.��6h   UP6l   �� 5"      $��Center=�6    $��15(�6f   $
��10,0q�6t   ��6;   �� *SelectedFolder.FolderPath+6�   5#      �� 5%      $��4��6   $ 
Horizontal=�6-   $��30��6F   $��Right=�6R   $��0 0 15 0q�6n   .+�5.      �� $
��10 0q�6q   $��SemiBold"�6   $	��5,0q�6�   y�6   �� *DescriptBtnVisibility+��6J   �� *DescriptionCommand+.��6�   Add Description6�   �� 50      $	��250��6   $��0 0 10 0q�6*   $��Center=�6<   ��6^   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�    J� InputBindings 51      �� 52      
 �� Key$ Enter��6)    �� Command 65   �� *SearchCommand+.��53   1   54      �� 55      $��search��6   $��60��6.   $��SemiBold"�69   $��5q�6O   ��6[   �� *SearchCommand+56      57      58      �� 5;   
   $��1��6   
�������._�5<      � .+�5=      �� $��10q�6   $��14(�6'   ��65   �� *	Folders+ �� SelectedItem 6U   �� *SelectedFolder+��5>      �� 5?      	 �� 
TargetType"	 ��6    .�5@      �� 
 �� Property
 � �� �� Value$ Center=�6K   5A       �� View 5C      �� 5D      .P�5E      �� $��Folder Name��6-    �� Width 6B   �� *ActualWidth+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �� �� HeaderContainerStyle 5F   "   �� 5G   &   "	 ��6,   .�5H   *   �� 
 � ��$ Center=�6W   �� 5I   *   
 � ��$ semiBold"�6G   5J   '    �� CellTemplate 5L   "   �� 5M   &   .R�5N   *   �� $��Center=�6Q   $��Center=�6l   ��64   �� *
FolderName+6l   5O   '   5Q      5R      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5U      +  %Microsoft.Xaml.Behaviors.EventTrigger  5V         	EventName$ MouseDoubleClick��6)   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5W      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   �� *DataContext.ChangeFolder+ �� " >�   CommandParameter 6�   �� *SelectedItem.FolderPath+ �� " ��5X      5Z      5[      5\      �� 5`   
   $��2��6   
���/���
���   �$��0,1,0,0q�6K   ._�5a      � $��15q�6   .+�5g      &   System.Windows.Controls.DataGrid  $��14(�6      SelectionMode$ Single=�6H      
IsReadOnly .    AutoGenerateColumns .  ��6)   �� *Videos+ � 	Resources 5h         CenteredTextBlockStyle��%V   &	        �� 5i      "	 ��6?   .�5j      �� 
 � ��$ Center=�6D   5k      5l         ColumnHeaderStyle 5m      �� 5n      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  6    .�5o      �� 
 � ��$ Center=�6K   5p         Columns 5x      0  *System.Windows.Controls.DataGridTextColumn  5y      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 0.4*
 6-    	  Header$ 
Video Name��6:   1  +System.Windows.Controls.DataGridBoundColumn    Binding  6N   �� *	VideoName+  5z      $
 0.4*
 6-   $ Last Modified��6:     6Q   �� *LastModified+  5{      $
 0.4*
 6-   $ 	File Type��6:     6M   �� *
FileType+  5|      $
 0.4*
 6-   $ 	File Size��6:     6M   �� *
FileSize+5~        5      $
 0.4*
 6-   $ Video Length��6:     6P   �� *VideoLength+ 5�        5�      $ MouseDoubleClick��6)   . 5�         64   �� * DataContext.SendMessageCommand+ �� " >� 6�   �� *SelectedItem+ �� "  5�      5�      5�      5�      5�      5�      
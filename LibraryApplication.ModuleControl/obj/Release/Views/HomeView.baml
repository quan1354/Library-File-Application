   M S B A M L   `   `   `  ���� [  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ModuleControl.ViewsModuleControl.Views  "    ModuleControl.Views.HomeView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:ModuleControl.Views     T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�.���  � RowDefinitions �� $��60 ��� $��2* ��� $��3* �.+��� $��0��
����ح�
���   �$��0,0,0,1q�._��  � ColumnDefinitions �� $	��600 ��� $��* ��� $��10 ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$
��15,0q�.+��� $��80��$��30��$��SemiBold"����� *	UpCommand+.��UP�� $��Center=�$��15(�$
��10,0q����� *SelectedFolder.FolderPath+�� $��4��$ 
Horizontal=�$��30��$��Right=�$��0 0 15 0q�.+��� $
��10 0q�$��SemiBold"�$	��5,0q�y��� *DescriptBtnVisibility+���� *DescriptionCommand+.��Add Description�� $	��250��$��0 0 10 0q�$��Center=����� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�.�� J� InputBindings �� 
 �� Key$ Enter�� �� Command �� *SearchCommand+.���� $��search��$��60��$��SemiBold"�$��5q����� *SearchCommand+�� $��1��
�������._�� .+��� $��10q�$��14(����� *	Folders+ �� SelectedItem �� *SelectedFolder+���� 	 �� 
TargetType"	 ��.��� 
 �� Property
 � �� �� Value$ Center=� �� View �� .P��� $��Folder Name�� �� Width �� *ActualWidth+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �� �� HeaderContainerStyle �� "	 ��.��� 
 � ��$ Center=��� 
 � ��$ semiBold"� �� CellTemplate �� .R��� $��Center=�$��Center=����� *
FolderName+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseDoubleClick��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *DataContext.ChangeFolder+ �� " >�   CommandParameter �� *SelectedItem.FolderPath+ �� " ���� $��2��
���/���
���   �$��0,1,0,0q�._�� $��15q�.+�&   System.Windows.Controls.DataGrid  $��14(�   SelectionMode$ Single=�   
IsReadOnly .    AutoGenerateColumns .  ���� *Videos+ � 	Resources    CenteredTextBlockStyle��%1   &	        �� "	 ��.��� 
 � ��$ Center=�   ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  .��� 
 � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 0.4*
  	  Header$ 
Video Name��1  +System.Windows.Controls.DataGridBoundColumn    Binding  �� *	VideoName+  $
 0.4*
 $ Last Modified��  �� *LastModified+  $
 0.4*
 $ 	File Type��  �� *
FileType+  $
 0.4*
 $ 	File Size��  �� *
FileSize+  $
 0.4*
 $ Video Length��  �� *VideoLength+   $ MouseDoubleClick��.    �� * DataContext.SendMessageCommand+ �� " >� �� *SelectedItem+ �� "  
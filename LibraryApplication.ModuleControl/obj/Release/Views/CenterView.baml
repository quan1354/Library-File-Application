   M S B A M L   `   `   `  ���� [  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ModuleControl.ViewsModuleControl.Views  S OLibraryApplication.Vinyl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:LibraryApplication.Vinyl;assembly=LibraryApplication.VinylLibraryApplication.Vinyl $    ModuleControl.Views.CenterView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:ModuleControl.Views     bspinningvinylHclr-namespace:LibraryApplication.Vinyl;assembly=LibraryApplication.Vinyl     T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  
������ !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�.���� 
������� �� Orientation$ Vertical=�.+��� 
���iii� �� TextAlignment$ Center=�
�������$	��900��$��30(�$
��0,15q����� *
MovieTitle+�� $	��400��$	��900��$��0,0,0,10q�._��    DarkBackgroundBrush#��[  .+��� ���� *MediaPlayerElement+$  LibraryApplication.Vinyl.Vinyl     VinylStroke �#3545   	VinylFill �#eeey��� *VinylVisibility+� $	��900��$��30��$��0,0,0,12q�
���   � � ColumnDefinitions �� $��70 ��� $��* ��� $��70 �.+��� $��0��
�������$��Center=�$��Center=����� *TimeElasped+� $��1��.+���  �� CornerRadius$ 5��
�������$��10��$
��Left=����� *	BarLength+._��� $ 5,0,0,5��$
��Left=����#0DCCFE$��10������ *ProgressBarLength+A� $��20��$��1��$
��Left=�$��20�� � Cursor$
 Hand��
�������$��2�����#67AABBy��� *SliderVisibility+���� *SliderPosition+�� $��2��
�������$��Center=�$��Center=����� *TotalMediaTime+�� $	��900��._��� $ 
Horizontal=�$��Center=�.+��� $��SemiBold"�$��10q�$��80������ *RewindCommand+.��REWIND�� $��SemiBold"�$��10q�$��60��
���  ������ *StopCommand+.��RESET�� $��SemiBold"�$��10q�$��60��
��� � ����� *PlayCommand+.��PLAY�� $��SemiBold"�$��10q�$��60������ *ForwardCommand+.��SKIP�� $��10q�$��Center=�$��Center=�
����·�$	��900��
����  �$��2q�._��� .+��� $��Center=�$��24(��� .�B� .�Description,� $
��Auto=�.��/�   /� IsOptimalParagraphEnabled . 	 /� IsHyphenationEnabled	 . .T�J� $��24(�$��Arial)�.*�.*��� ��� *DescriptionContent+�� 
���`���
���**��$��3q�$��Center=�$��Center=�$	��900��._��� $ 
Horizontal=�$��Center=�.+��� $	��5,8q����� *TermCheckBoxClick+�� 
������ $��0q�
������ $��0q����� *TermAndConditionDialog+���� 
 �� 
TargetType"
 ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R���  �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �@�Cursor$
 Hand����  � ��
 ��  �.���� $��20(�$��DemiBold"�$��	Underline{�$
 Hand��Term and Condition�� 
���`���$��0,0,0,20q�
���**��$��3,0,3,3q�$��Center=�$��Center=�$	��900��._��� -   $��DownloadButton��$��22(�$��Download��{��� *DownloadIsClick+
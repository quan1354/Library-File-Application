   M S B A M L   `   `   `  ����[  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ModuleControl.ViewsModuleControl.Views  5      S OLibraryApplication.Vinyl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:LibraryApplication.Vinyl;assembly=LibraryApplication.VinylLibraryApplication.Vinyl 5      $    ModuleControl.Views.CenterView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ModuleControl.Views     5      bspinningvinylHclr-namespace:LibraryApplication.Vinyl;assembly=LibraryApplication.Vinyl     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5
      
������ !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5      .��5      �� 
������� �� Orientation$ Vertical=�6'   .+�5   
   �� 
���iii� �� TextAlignment$ Center=�6)   
�������$	��900��6T   $��30(�6|   $
��0,15q�6�   ��6`   �� *
MovieTitle+6�   �� 5   
   $	��400��6   $	��900��6   $��0,0,0,10q�6*   ._�5      �    DarkBackgroundBrush#��[  6   .+�5       �� ��6!   �� *MediaPlayerElement+$  LibraryApplication.Vinyl.Vinyl  5%         VinylStroke �#3545   	VinylFill �#eeey�5(      �� *VinylVisibility+53      54      � 57   
   $	��900��6   $��30��6   $��0,0,0,12q�6'   
���   � � ColumnDefinitions 58      �� 59      $��70 �6#   60   �� 5:      $��* �6#   6/   �� 5;      $��70 �6#   60   .+�5?      �� $��0��6   
�������$��Center=�6X   $��Center=�6u   ��6(   �� *TimeElasped+6u   � 5A      $��1��6   .+�5B      ��  �� CornerRadius$ 5��6   
�������$��10��5D   !   $
��Left=�5E   !   ��5F   !   �� *	BarLength+._�5G      �� $ 5,0,0,5��6   $
��Left=�5H   %   ���#0DCCFE$��10��5J   %   ��5K   %   �� *ProgressBarLength+5L      5M      5N      A� 5P      $��20��6   $��1��5Q      $
��Left=�5R      $��20��5S       � Cursor$
 Hand��5T      
�������$��2��5W      ���#67AABBy�5U      �� *SliderVisibility+��5X      �� *SliderPosition+5Z      �� 5\      $��2��6   
�������$��Center=�5]      $��Center=�5^      ��5\   (   �� *TotalMediaTime+5^      5_      �� 5c   
   $	��900��6   ._�5d      �� $ 
Horizontal=�6   $��Center=�62   .+�5e      �� $��SemiBold"�6   $��10q�6/   $��80��6<   ��6G   �� *RewindCommand+.��6i   REWIND6q   �� 5f      $��SemiBold"�6   $��10q�6/   $��60��6<   
���  ����6G   �� *StopCommand+.��6x   RESET6   �� 5g      $��SemiBold"�6   $��10q�6/   $��60��6<   
��� � ���6G   �� *PlayCommand+.��6z   PLAY6�   �� 5h      $��SemiBold"�6   $��10q�6/   $��60��6<   ��6G   �� *ForwardCommand+.��6j   SKIP6p   5i      5j      �� 5l   
   $��10q�6   $��Center=�6   $��Center=�6:   
����·�$	��900��6o   
����  �$��2q�6�   ._�5m      �� .+�5n      �� $��Center=�6   $��24(�69   �� 6H   .�6N   B� .�6X   Description6e   6q   6x   ,� 5o      $
��Auto=�6+   .��5p      /�   /� IsOptimalParagraphEnabled . 	 /� IsHyphenationEnabled	 . .T�5q      J� $��24(�6$   $��Arial)�62   .*�6E   .*�5r      �� �6"   �� *DescriptionContent+6H   5s      5t      5u      5v      5w      �� 5x   
   
���`���
���**��$��3q�6=   $��Center=�6Q   $��Center=�6n   $	��900��6�   ._�5y      �� $ 
Horizontal=�6   $��Center=�62   .+�5z      �� $	��5,8q�6   ��6(   �� *TermCheckBoxClick+6P   �� 5{      
������ $��0q�62   
������ $��0q�6W   ��6k   �� *TermAndConditionDialog+��5|      �� 5}      
 �� 
TargetType"
 ��6    .�5~      ��  �� Property � �� �� Value 5   "   �� 5�   &    �� 
TargetType" ��66   .R�5�   *   �� 5�   '   5�       �� Triggers 5�      P� 5�   "    P� Property �@J�IsMouseOver P� Value . . �5�   &   ��  �@�Cursor$
 Hand��6?   �� 5�   &    � ��
 ��  �6C   5�   #   5�      .��5�      �� $��20(�6    $��DemiBold"�6.   $��	Underline{�6D   $
 Hand��6`   Term and Condition6�   5�      5�      5�      �� 5�   
   
���`���$��0,0,0,20q�6)   
���**��$��3,0,3,3q�6O   $��Center=�6i   $��Center=�6�   $	��900��6�   ._�5�      �� -   5        $��DownloadButton��5�   I   $��22(�6   $��Download��6_   {�6#   �� *DownloadIsClick+6�   5�      5�      5�      
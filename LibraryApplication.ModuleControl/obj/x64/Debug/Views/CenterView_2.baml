   M S B A M L   `   `   `  ����[  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:LibraryApplication.ModuleControl.Views&LibraryApplication.ModuleControl.Views  5      f bO2S.Components.PDFView4NET.WPF, Version=11.1.4.0, Culture=neutral, PublicKeyToken=2f824cb48af66728wTclr-namespace:O2S.Components.PDFView4NET.WPF;assembly=O2S.Components.PDFView4NET.WPFO2S.Components.PDFView4NET.WPF 5	      9    3LibraryApplication.ModuleControl.Views.CenterView_2   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:LibraryApplication.ModuleControl.Views     5      dpdfTclr-namespace:O2S.Components.PDFView4NET.WPF;assembly=O2S.Components.PDFView4NET.WPF     5	      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5
      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5      .��5      �� 
������� �� Orientation$ Vertical=�6'   .+�5   
   �� 
���iii� �� TextAlignment$ Center=�6)   
�������$	��900��6T   $��30(�6   $
��0,15q�6�   ��6`   �� *DocumentTitle+6�   0  *O2S.Components.PDFView4NET.WPF.PDFPageView  5   
   -   5          Name$ 	pdfViewer��5   5   $
��Auto��6   $	��900��6)   $��0,0,0,20q�6�      Document 6I   �� *PdfDocument+y�6j   �� *PDFVisibility+6�   �� 5   
   $ 
Horizontal=�6:   $��Center=�6S   $��0,0,0,10q�6p   y�6   �� *PDFVisibility+.+�5      �� -   5        $��SemiBold"�5   1   $��20(�6G   $��10q�6U   $	��100��6b   $��0 0 30 0q�6n   .��6�   
Previous6�   �� 5      -   5        $	��100��5   ,   $��SemiBold"�68   $��20(�6N   $��10q�6\   .��6i   Next6o   5      � 5#   
   $	��900��6   y�6   �� *PPTXVisibility+.+�5$      �� $��0��6   $
��Auto=�6(   $
��Auto=�6K   $��Stretch=�6p   $��Stretch=�6�   .��5%      �� -   5         ��Name$ slidesContainer��5%      $
��Left=�68   $	��Top=�6Z   ��5&      �� 5'      .R�5(      �� $ 
Horizontal=�6)   5)      5+      5,      5-      �� 5/   
   $	��400��6   $	��900��6E   $��0,0,0,10q�6Q   y�6   �� *ImageVisibility+._�50      �� ��6   �� *
ImageUrl+51      �� 53   
   $��10q�6   $��Center=�6   $��Center=�6:   
����·�$	��900��6o   
����  �$��2q�6�   ._�54      �� .+�55      �� $��Center=�6   $��24(�69   �� 6H   .�6N   B� .�6X   Description6e   6q   6x   ,� 56      $
��Auto=�6+   .��57      /�   /� IsOptimalParagraphEnabled .  /� IsHyphenationEnabled . .T�58      J� $��24(�6$   $��Arial)�62   .*�6E   .*�59      �� �6"   �� *DescriptionContent+6H   5:      5;      5<      5=      5>      �� 5?   
   $	��900��6-   $��SemiBold"�6^   $��20(�6t   $��20q�6�   $��0,0,0,10q�6�   ��6   �� *	OpenPDF+y�69   �� *PDFVisibility+.��6�   CLICK TO OPEN PDF IN BROWSER6�   �� 5@   
   
���`���
���**��$��3q�6=   $��Center=�6Q   $��Center=�6n   $	��900��6�   ._�5A      �� $ 
Horizontal=�6   $��Center=�62   .+�5B      �� $	��5,8q�6   ��6(   �� *TermCheckBoxClick+6P   �� 5C      
������ $��0q�62   
������ $��0q�6W   ��6k   �� *TermAndConditionDialog+��5D      �� 5E       �� 
TargetType" ��6    .�5F      �� 	 �� Property	 � ��
 �� Value
 5G   "   �� 5H   &    �� 
TargetType" ��66   .R�5I   *   �� 5J   '   5L       �� Triggers 5M      P� 5N   "    P� Property �@J�IsMouseOver P� Value . . �5O   &   �� 	 �@�Cursor$

 Hand��6?   �� 5P   &   	 � ��

 ��  �6C   5Q   #   5S      .��5U      �� $��20(�6    $��DemiBold"�6.   $��	Underline{�6D    � Cursor$
 Hand��6`   Term and Condition6�   5V      5W      5X      �� 5Y   
   
���`���$��0,0,0,20q�6)   
���**��$��3,0,3,3q�6O   $��Center=�6i   $��Center=�6�   $	��900��6�   ._�5Z      �� $��22(�6   $��Download��6I   {�6#   �� *DownloadIsClick+��6\   �� *DownloadBtnClick+6�   5[      5\      5]      
   M S B A M L   `   `   `  ���� [  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:LibraryApplication.ModuleControl.Views&LibraryApplication.ModuleControl.Views  f bO2S.Components.PDFView4NET.WPF, Version=11.1.4.0, Culture=neutral, PublicKeyToken=2f824cb48af66728wTclr-namespace:O2S.Components.PDFView4NET.WPF;assembly=O2S.Components.PDFView4NET.WPFO2S.Components.PDFView4NET.WPF 9    3LibraryApplication.ModuleControl.Views.CenterView_2   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Flocal4clr-namespace:LibraryApplication.ModuleControl.Views     dpdfTclr-namespace:O2S.Components.PDFView4NET.WPF;assembly=O2S.Components.PDFView4NET.WPF     T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�.���� 
������� �� Orientation$ Vertical=�.+��� 
���iii� �� TextAlignment$ Center=�
�������$	��900��$��30(�$
��0,15q����� *DocumentTitle+0  *O2S.Components.PDFView4NET.WPF.PDFPageView  -     Name$ 	pdfViewer��$
��Auto��$	��900��$��0,0,0,20q�   Document �� *PdfDocument+y��� *PDFVisibility+�� $ 
Horizontal=�$��Center=�$��0,0,0,10q�y��� *PDFVisibility+.+��� -   $��SemiBold"�$��20(�$��10q�$	��100��$��0 0 30 0q�.��
Previous�� -   $	��100��$��SemiBold"�$��20(�$��10q�.��Next� $	��900��y��� *PPTXVisibility+.+��� $��0��$
��Auto=�$
��Auto=�$��Stretch=�$��Stretch=�.���� -    ��Name$ slidesContainer��$
��Left=�$	��Top=����� .R��� $ 
Horizontal=��� $	��400��$	��900��$��0,0,0,10q�y��� *ImageVisibility+._��� ���� *
ImageUrl+�� $��10q�$��Center=�$��Center=�
����·�$	��900��
����  �$��2q�._��� .+��� $��Center=�$��24(��� .�B� .�Description,� $
��Auto=�.��/�   /� IsOptimalParagraphEnabled .  /� IsHyphenationEnabled . .T�J� $��24(�$��Arial)�.*�.*��� ��� *DescriptionContent+�� $	��900��$��SemiBold"�$��20(�$��20q�$��0,0,0,10q����� *	OpenPDF+y��� *PDFVisibility+.��CLICK TO OPEN PDF IN BROWSER�� 
���`���
���**��$��3q�$��Center=�$��Center=�$	��900��._��� $ 
Horizontal=�$��Center=�.+��� $	��5,8q����� *TermCheckBoxClick+�� 
������ $��0q�
������ $��0q����� *TermAndConditionDialog+����  �� 
TargetType" ��.��� 	 �� Property	 � ��
 �� Value
 ��  �� 
TargetType" ��.R���  �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ��� 	 �@�Cursor$

 Hand���� 	 � ��

 ��  �.���� $��20(�$��DemiBold"�$��	Underline{� � Cursor$
 Hand��Term and Condition�� 
���`���$��0,0,0,20q�
���**��$��3,0,3,3q�$��Center=�$��Center=�$	��900��._��� $��22(�$��Download��{��� *DownloadIsClick+���� *DownloadBtnClick+
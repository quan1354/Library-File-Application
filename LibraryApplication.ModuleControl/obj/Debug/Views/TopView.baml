   M S B A M L   `   `   `  ����[  WLibraryApplication.ModuleControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ModuleControl.ViewsModuleControl.Views  5      !    ModuleControl.Views.TopView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ModuleControl.Views     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.3* �6   6.   �� 5      $
��3.2* �6   6.   �� 5      $
��1.5* �6   6.   .+�5   
   �� 
����  �$��0��6'   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $
��Left=�6M   .+�5      o� $��10q�6   $	��100��6$   $
��20,0q�60   .@�5      m� $��_Menu��6   $��25(�6.   .@�5      m� $��_Login��6#   $��20(�6T    m� Command 63   �� *LoginCommand+6T   5      5      �� 5      $
��Back��6   $��10q�6(   $	��100��65   $��HomeView��6�   $��25(�6�   ��6B   �� *NavigateCommand+y�6f   �� *BtnVisibility+6�   5      5      �� 5   
   $��1��6   
����  �._�5       �� $��Center=�6   $��Center=�64   $ 
Horizontal=�6Q    � Cursor$
 Hand��6j   .+�5#      �� -   5        $]��Wpack://application:,,,/LibraryApplication.ModuleControl;component/Views/src/DogLogo.jpg��5#   H   $��90��6�   $
��20,0q�6�   �� 5$      -   5        $��25(�5$   L   
����� �$��Center=�6l   Tiramisu Library   图书馆6�   5%      5&      �� 5(   
   $��2��6   
����  �._�5)      �� $��Center=�6   $��Center=�64   $ 
Horizontal=�6Q   $
 Hand��6j   .+�5*      �� -   5        $]��Wpack://application:,,,/LibraryApplication.ModuleControl;component/Views/src/Mp4Logo.png��5*   H   $��80��6�   $��50��6�   �� 5+      -   5        $��25(�5+   M   
����� �$��Center=�6m   $��Center=�6�   Videos 视频6�   5,      5-      5.      5/      
   M S B A M L   `   `   `  ����D  @MVVMAppv2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MVVMAppv2	MVVMAppv2  5   	   9!clr-namespace:MVVMAppv2.ViewModelMVVMAppv2.ViewModel  5   	       MVVMAppv2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MVVMAppv2     5   	   0vm!clr-namespace:MVVMAppv2.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � DataContext 5
      -   'MVVMAppv2.ViewModel.MainWindowViewModel  5   
   6#   .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��60 �6   �� 5      $
��169* �6   .+�5   
   o� $��
0,0,-0.4,4q�6   $��0��6#   .@�5      m� $	��Add��6    m� Command 6$   �� *
AddCommand+6E   m� 5      $
��Edit��6    6%   �� *EditCommand+6G   m� 5      $��Delete��6    6'   �� *DeleteCommand+6K   5      �� 5   
   -   5        $��2��5      $��Visible=�6    $��Stretch=�6�   $��0,8.6,-0.4,10q�6�   $��Stretch=�6�   ��6S   �� *Items+ �� Mode$ TwoWay=� �� SelectedItem 6~   �� *SelectedItem+$ TwoWay=� �� View 5      �� 5      .P�5      �� $��Id��6%    �� Width$	 100��61    �� DisplayMemberBinding 6=   �� *Id+�� 5      $
��Name��6%   $	 250��63    6?   �� *
ItemName+�� 5      $��Quantity��6%   $	 150��67    6C   �� *
Quantity+�� 5      $
��Unit��6%   $	 100��63    6?   �� *Unit+�� 5      $	��Min��6%   $	 100��62    6>   �� *Min+5       5"      �� 5#   
   $��1��6   $��25(�6   $=��7This application is used for managing items in storage.��6,   $
��Left=�6n   $��59��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��751��6�   $��2��6�   5$      5%      
   M S B A M L   `   `   `  ����D  @MVVMAppv2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVVMAppv2.ViewMVVMAppv2.View  5   	   9!clr-namespace:MVVMAppv2.ViewModelMVVMAppv2.ViewModel  64   %clr-namespace:MVVMAppv2	MVVMAppv2  6a       MVVMAppv2.View.AddItem   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MVVMAppv2.View     5   	   0vm!clr-namespace:MVVMAppv2.ViewModel     64   *local1clr-namespace:MVVMAppv2     6a     � Title$  AddItem��5   	   $	��450��6   $	��800��6&    � DataContext 5	      *  $MVVMAppv2.ViewModel.AddItemViewModel  5
   
   6     � 	Resources 5         MVVMAppv2.IntToString   IntToString��%   &	          5   
   6   5      .��5      � .+�5   
   �� $��15(�6   $��
Item name:��6   $
��Left=�63   $��	42,65,0,0q�6N   $	��Top=�6a   $��35��6y   $��88��6�   �� 5   
   $��15(�6   $
��Left=�6    $��35��6;   $��
176,65,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $	��Top=�6�   $	��219��6�   ��6o   ��  �� Path$ ItemName� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��15(�6   $��Quantity��6   $
��Left=�61   $��
42,116,0,0q�6L   $	��Top=�6`   $��35��6x   $��88��6�   �� 5   
   $��15(�6   $
��Left=�6    $��35��6;   $��176,116,0,0q�6G   $
 Wrap=�6\   $	��Top=�6�   $	��219��6�   ��6p   �� $ Quantity�$ PropertyChanged=� �� 	Converter# [  6�   �� 5   
   $��15(�6   $
��Unit��6   $
��Left=�6-   $��
42,177,0,0q�6H   $	��Top=�6\   $��35��6t   $��88��6�   �� 5   
   $��15(�6   $
��Left=�6    $��35��6;   $��176,177,0,0q�6G   $
 Wrap=�6\   $	��Top=�6�   $	��219��6�   ��6p   �� $
 Unit�$ PropertyChanged=�6�   �� 5   
   $��15(�6   $	��Min��6   $
��Left=�6,   $��
42,235,0,0q�6G   $	��Top=�6[   $��35��6s   $��88��6   �� 5   
   $��15(�6   $
��Left=�6    $��35��6;   $��176,235,0,0q�6G   $
 Wrap=�6\   $	��Top=�6�   $	��219��6�   ��6p   �� $	 Min�$ PropertyChanged=�# [  6�   �� 5   
   $	��Add��6-   $
��Left=�6;   $��42��6V   $��520,300,0,0q�6b   $	��Top=�6w   $��98��6�   ��6   �� *	AddItem+6�   5      5      
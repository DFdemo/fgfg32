   M S B A M L   `   `   `  ����J  FWpfApplication9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication9WpfApplication9  5   	        WpfApplication9.HotelTable   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication9     5   	     � Title$  
HotelTable��5   	   $	��300��6   $	��525��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Gridus��5
   /      AutoGenerateColumns .  $��0,0,0,48q�6?      
IsReadOnly . $��Visible=�6c      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6T     5      $
 Name��6>   $ * 6L    6%   �� *Name+6X     5      $ CountOfStats��6G   $ * 6]    6%   �� *CointOfStarts+6i     5      $ CountryName��6E   $ * 6Z    6%   �� *CountryName+6f   5      �� 5   
   $��	0,246,0,0q�6   $
��Left=�6(   $��Center=�6C    �� Orientation$ 
Horizontal=�6^   .+�5      �� -   5        	 ��Name$		 Add��5      $	��Add��6"   $	��104��60   $��22��6<   6\   �� 5      -   5        $
	 Edit��5      $
��Edit��6#   $	��104��62   $��22��6>   6_   �� 5      -   5        $	 Delete��5      $��Delete��6%   $	��104��66   $��22��6B   6e   �� 5      -   5        $	 Update��5      $��Update��6%   $	��104��66   $��22��6B   6e   �� 5      -   5        $
	 Back��5      $
��Back��6#   $	��104��62   $��22��6>   6_   5      5      5      
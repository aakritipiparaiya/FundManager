   M S B A M L   `   `   `  ����F  BFundManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FundManager.ViewsFundManager.Views  5   	   )clr-namespace:FundManagerFundManager  5   	   #    FundManager.Views.FundsScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FundManager.Views     5   	   /	converterclr-namespace:FundManager     5   	   #��[B�5	        � WindowState$  	Maximized=�5
   
    � WindowStyle$
 None=�6"    � Title$ FundsScreen��5   	   $	��800��6   $
��1000��6*    � 	Resources 5      -   'FundManager.StockNameHighlightConverter   StockNameHighlightConverter �� 
TargetType �� Property �� Value  NoFunds �� Triggers �� Binding	 �� Value��%�  &	        '��      &	 �       5   
   60   �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   �� 5       � ��$ 2q�60   �� 5       �@��CornerRadius$ 5��6-   5      �� 5   
   " ��6    .�5      ��  � y�$ 	Collapsed=�6+    5      �� 5       6   �� 	 62   Z� .a�5      ��  � y�$ Visible=�63   5      5      5      .��5      (� 
 (� Stretch$
 Uniform=�6   .��5   
   � -   5        $��backgroundGrid��5      $��10,10,10,10q�6%    � RowDefinitions 5      �� 5      $	��50* �6    �� 5       $	��50* �6    �� 5!      $
��600* �6     � ColumnDefinitions 5#      �� 5$      $	��70* �6#   �� 5%      $��* �6#   .+�5'      &   System.Windows.Controls.DataGrid  -   5          Name$ dgAllStocks��5'   �   ���#F5F5F5   CanUserSortColumns .  $��20,0,0,0q�6H      SelectionUnit$ FullRow=�6[      
IsReadOnly . $��2��6�   $	��580��6�   $	��850��6  $��Center=�6  $
��Left=�6.     AutoGenerateColumns .  ��6�   �� *	AllStocks+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   ColumnHeaderStyle 5(      �� 5)      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5*      ��  � ��
 ��  �67   �� 5+       � ��
 �����67   �� 5,       � ��$ 30��63   �� 5-       � ��$ Center=�6G   5.         RowStyle 50      �� 51      )  #System.Windows.Controls.DataGridRow"  6    52      P� 53       P� Property �@J�IsMouseOver P� Value . . �54   "   ��  � ��
 ��ح�6?   �� 55   "    � ��
 �����6?   �� 56   "    � ��$ Heavy"�6?   57      5:         Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Stock Type��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *	StockType+6[     5?      $ 
Stock Name��6)   $ * 6=    6G   �� *	StockName+   ElementStyle 5@      �� 5A      " ��6$   .�5B   "   ��  � �� 5C   &   `� 5D   *    `� 	Converter# [  67   .1�5E   .   ��  �� Path$ MarketValue�66   �� 5F   .   $ TransactionCost�66   �� 5G   .   $ 	StockType�66   5H   +   5J   #   5K      5N        5O      $ Price��6)   $ * 6R    68   �� *Price+6R     5P      $ Quantity��6)   $ * 6X    6;   �� *
Quantity+6X     5Q      $ Market Value��6)   $ * 6_    6?   �� *MarketValue+6_     5R      $ Transaction Cost��6)   $
 1.2* 6g    6C   �� *TransactionCost+6g     5S      $ Stock Weight��6)   $ * 6_    6?   �� *StockWeight+6_   5U      �� 5V      $��2��6   $��Center=�6)   $��Center=�6E   $��0��6b   $��40��6o   ._�5X      �� ���#F5F5F5 �� Orientation$ 
Horizontal=�63   .+�5Y      �� $��Add a New Stock��6    
���   �$��14(�6J   $��Medium"�6X   $	��120��6l   $��5,0,10,3q�6y   $��Center=�6�   �� 5Z      -   5          ��Name$  	chkEquity��5Z   y   $��Equity��6   $��14(�60   $��Medium"�6>   $��Center=�6�   $��Center=�6�   ! d� 	IsChecked! 6R   �� *IsEquitySelected+6�   �� 5[      $��50��6   �� 5\      -   5        $  chkBond��5\   u   $
��Bond��6   $��14(�6.   $��Medium"�6<   $��Center=�6�   $��Center=�6�   ! 6P   �� *IsBondSelected+6�   �� 5]      $��20��6   5_      5`      �� 5a      -   5        $��2��5a      $ 
Horizontal=�6W   $��Center=�6p   $��68��6�   $��1��6�   y�6-   �� *NewStockVisibility+.+�5b      �� $��Price��6   $��14(�6(   $��Medium"�66   $��Center=�6J   �� 5c      -   5        " ��Name$" txtPrice��5c      $��40,0,0,0q�6,   $	��175��6>   $��30��6J   ��6V   �� *NewStockPrice+$ PropertyChanged=�6�   �� 5d      $��Quantity��6   $��40,0,0,0q�6+   $��14(�6=   $��Medium"�6K   $��Center=�6_   �� 5e      -   5        $" txtQuantity��5e      $	��175��6/   $��30��6;   $��40,0,0,0q�6G   ��6Y   �� *NewStockQuantity+$ PropertyChanged=�6�   �� 5f      -   5        # ��Name$# 	btnSumbit��5f      $��32��6,   $��	Add Stock��68   $��Center=�6L   $��
40,18,0,18q�6i   $��Center=�6}   $��87��6�   ��6�   �� *AddNewStockCommand+5h      5j      �� 5k      $	��200��6   $��	20,0,20,0q�6"   $��Right=�65   $��Center=�6Q   $��2��6l   $��1��6y   $	��411��6�   ._�5l      � ���#F5F5F5$ � DataContext$ 6   �� *StocksValue+ 5n      �� 5o      $
��0.8* �6(   �� 5p      $��* �6(   �� 5q      $��* �6(   �� 5r      $��* �6(    5t      �� 5u      $��* �6+   �� 5v      $��2* �6+   �� 5w      $��2* �6+   �� 5x      $��2* �6+   .+�5{      �� $��No Funds Available��6    $��12(�6;   $
��Bold"�6I   $��1��6[   $��3��6h   $��1��6y   $��3��6�   $��Center=�6�   $��Center=�6�   #��[ 6�   �� 5�      -	   5        % ��Name$% 	lblEquity��5�      $��Equity��6/   $��1��6@   $��0��6M   
����  �
�������$��Center=�6�   �� 5�      -
   5        $% lblBond��5�      $
��Bond��6-   $��2��6<   $��0��6I   
����  �
�������$��Center=�6�   �� 5�      -   5        $% lblFunds��5�      $��
All Stocks��6.   $��3��6C   $��0��6P   
����  �
�������$��Center=�6�   �� 5�      
����  �$��0��62   $��0��6?   �� 5�      -   5        & ��Name$& 
lblTotalNo��5�   !   $�� Total Number��65   $��0��6J   $��1��6W   $
��Wrap=�6g   
����  �
�������' �� TextAlignment$' Center=�6�   ( �� Padding$( 5q�6�   �� 5�      -   5        $& lblTotalStockWeight��5�       $��Total Stock Weight��6=   $��0��6W   $��2��6d   $
��Wrap=�6t   
����  �
�������$' Center=�6�   $( 5q�6�   �� 5�      -   5        $& lblTotalMarketValue��5�       $��Total Market Value��6=   $��0��6W   $��3��6d   $
��Wrap=�6t   
����  �
�������$' Center=�6�   $( 5q�6�   �� 5�      -   5        $& lblTotalNoEquity��5�       $��1��6Y   $��1��6f     DisplayData#��[ 6w   ��6:   �� *TotalNoEquity+6w   �� 5�      -   5        $& lblTotalStockWeightEquity��5�       $��1��6k   $��2��6x   #��[ 6�   ��6C   �� *TotalStockWeightEquity+6�   �� 5�      -   5        $& lblTotalMarketValueEquity��5�       $��1��6k   $��3��6x   #��[ 6�   ��6C   �� *TotalMarketValueEquity+6�   �� 5�      -   5        $& lblTotalNoBond��5�       $��2��6U   $��1��6b   #��[ 6r   ��68   �� *TotalNoBond+6r   �� 5�      -   5        $& lblTotalStockWeightBond��5�       $��2��6g   $��2��6t   #��[ 6�   ��6A   �� *TotalStockWeightBond+6�   �� 5�      -   5        $& lblTotalMarketValueBond��5�       $��2��6g   $��3��6t   #��[ 6�   ��6A   �� *TotalMarketValueBond+6�   �� 5�      -   5        $& lblTotalNoAll��5�       $��3��6Y   $��1��6f   #��[ 6w   ��67   �� *TotalNoAllStocks+6w   �� 5�      -   5        $& lblTotalStockWeightAll��5�       $��3��6k   $��2��6x   #��[ 6�   ��6@   �� *TotalStockWeightAllStocks+6�   �� 5�      -   5        $& lblTotalMarketValueAll��5�       $��3��6k   $��3��6x   #��[ 6�   ��6@   �� *TotalMarketValueAllStocks+6�   5�      5�      5�      5�      5�      
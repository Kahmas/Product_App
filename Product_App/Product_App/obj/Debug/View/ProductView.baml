   M S B A M L   `   `   `  ????F  BProduct_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Product_App.ViewProduct_App.View  5   	   "    Product_App.View.ProductView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Product_App.View     5   	   $	??450??5      $	??800??6'     ? 
ResizeMode$  	CanResize=?5   	    ? WindowStartupLocation$ CenterScreen=?5	   	    ? WindowState$ Normal=?5
   	    ? WindowStyle$ SingleBorderWindow=?5   	    ? Title$ Product??5   	   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      $	??200 ?6    ? RowDefinitions 5   
   ?? 5      ?? 5      $??40 ?6   ?? 5      $	??76* ?6   ?? 5      $	??123 ?6   ?? 5      $??80 ?6   ?? 5      $
??Auto ?6   .+?5   
   ? $??5??6   $??2??6    .+?5      ?? $
??Wrap=?6   $??10,10,498,395q?6,   $??16(?6C   $
??Bold"?6Q   ?? 6d   $?DATA PRODUCT??6h   ?? 6~   ?? 6?   6?   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ TblData??5      $??0??6$   $??2??64   $??10,3,8,0q?6A      HeadersVisibility$ Column=?5       	   EnableRowVirtualization	 .  
   CanUserAddRows
 .     CanUserDeleteRows .     AutoGenerateColumns .     AlternatingRowBackground
 ???????5#      ?? *
Collection+ ?? SelectedItem 66   ?? *Model+   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$
 CODE??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ?? *Uid+6K     5&      $
 NAME??6%   $ * 6L    63   ?? *Name+6L     5'      $ STATUS??6%   $
 auto 6P    65   ?? *Status+6P   5)      ?? 5*   
   -   5         ??Name$ TxtUid??5*       ?? TextWrapping$
 Wrap=?6J   $??254,20,8,86q?6_   $??3??6t   ??6"   ?? *	Model.Uid+ ?? Mode$ TwoWay=?6t   ?? 5+   
   -   5        $ TxtName??5+      $
 Wrap=?6L   $??254,57,162,49q?6a   $??3??6x   ??6#   ?? *
Model.Name+$ TwoWay=?6x   ?? 5,   
   -   5         ??Name$ 	IsChecked??5,      $??Active??6S   $??254,91,266,16q?6d   $??3??6{    d? 	IsChecked 6&   ?? *	IsChecked+$ TwoWay=?6{   ?? 5-   
   $
??Code??6   $??188,15,351,80q?6   $??3??66   ?? 5.   
   $
??Name??6   $??188,52,351,43q?6   $??3??66   ?? 5/   
   $??Status??6   $??188,85,351,10q?6!   $??3??68   ?? 50   
   -   5        $
??EDIT??50      $??10,10,10,124q?6!   $??2??67   $??1??6D   6T   ?? 51   
   -   5        $??UPDATE??51      $??10,79,10,56q?6#   $??2??68   $??1??6E   6U   52      53      
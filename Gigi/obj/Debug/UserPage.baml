   M S B A M L   `   `   `  ?????  ;Gigi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GigiGigi  5          Gigi.UserPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Gigi     5        N? Title$  UserPage??5	      .??5      ? .+?5   
   ?? .@?5   
   ?? -   5        $??UserTab??5      $??Пользователи??6!   .??5      ? ???	#FFE5E5E5 ? ColumnDefinitions 5      ?? 5      $
??111* ?6'   ?? 5      $
??683* ?6+    ? RowDefinitions 5      ?? 5      $??40 ?6$   ?? 5      $??* ?6$   .+?5      ?? $??0??6%    ?? Orientation$ 
Horizontal=?62   $??2??6K   .+?5      ?? -   5        $??	BtnUpdate??5   %   $??Изменить??66   $??80??6I   $??30??6T   $
??Left=?5      $??Center=?6   $??	10,0,10,0q?6O   ?? 5      -   5        $??	BtnRemove??5   !   $??Удалить??62   $??80??6E   $??30??6P   $
??Left=?6\   $??Center=?6w   $??	10,0,10,0q?6?   5      &   System.Windows.Controls.DataGrid  5      -   5        $??ListUser??5   #      AutoGenerateColumns .     SelectionMode$ Single=?6O   
 ? Tag$ UserBindingSource??6f   $??1??6~   $??2??6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . 	   
Visibility$	 	Collapsed=?6C   
   Header$
 Id??6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6f   ?? *IdUser+  5        . $
 
Логин??6C    6R   ?? *Login+  5!   "    . $
 	Пapoль??6G    6W   ?? *
Password+  5"   &    . $
 Имя??6K    6X   ?? *Name+  5#   &    . $
 Poль??6K    6Y   ?? *
Rolel.Name+4  .System.Windows.Controls.DataGridTemplateColumn  5$         CellTemplate 5%   "   ?? 5&   &   .R?5'   *   ?? $??50??6I   ??60   ?? *Photo+6I   5(   '   5*      5,      5-      5.      ?? 5/      -   5        $??OrderTab??5/      $??3аявки??6&    ?? 
IsSelected . .??50      ? ???	#FFE5E5E5 51      ?? 52      $??40 ?6(   ?? 53      $??* ?6(   .+?55      ?? $??0??6!   $ 
Horizontal=?6.   .+?56      ?? -   5        $??BtnAddOrder??56   !   $??Добавить??64   $??80??6H   $??30??6S   $
??Left=?57      $??Center=?6   $??	10,0,10,0q?6Q   ?? 58      -   5        $??BtnUpdateOrder??58   !   $??Изменить??67   $??80??6K   $??30??6V   $
??Left=?59      $??Center=?6   $??	10,0,10,0q?6T   ?? 5:      -   5        $??BtnRemoveOrder??5:   !   $??Удaлитb??67   $??80??6I   $??30??6T   $
??Left=?5;      $??Center=?6   $??	10,0,10,0q?6T   ?? 5<      -	   5        $??ComboboxTypeSelect??5<   #   $	??120??6=   $??Right=?6I   $??Center=?5=       ?? SelectedIndex$ 0??6   $??	50,9,10,9q?6.   ?? 5>      -
   5        $??ComboboxStatusSelect??5>   #   $	??120??6?   $??Right=?6K   $??Center=?5?      $ 0??6   $??	10,0,10,0q?6.   ?? 5@      -   5        $??	BtnSearch??5@   !   $??noncK??62   $??80??6B   $??30??6M   $??Right=?6Y   $??Center=?5A      $??	10,0,10,0q?6   6/   5B        5C      -   5        $??	ListOrder??5C       .  $ Single=?6L   $ UserBindingSource??5D      $??2??6   $??1??6*    5E        5F       . $	 	Collapsed=?6C   $
 Id??6Z    5G      ?? *	IdOrder+  5H       . $
 Пpo6лeмa??6C    6U   ?? *Text+  5I       . $
 Тип??6C    6P   ?? *TypeOrder.NameOrder+  5J       . $
 Статус??6C    6S   ?? *Statusl.NameStatus+  5K      -   5        Customer?? . $
 Заказчик??5K   U   $	 	Collapsed=?5L       6   ?? *
Customer+  5M       5N   "   ?? 5O   &   .R?5P   *   ?? $??50??6I   ??60   ?? *Photo+6I   5Q   '   5S      5U      5V      5W      5X      5Y      5Z      
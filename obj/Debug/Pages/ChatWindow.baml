   M S B A M L   `   `   `  ����>  :ICT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ICT.Pages	ICT.Pages  5          ICT.Pages.ChatWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:ICT.Pages     5      -   5          N� Title$  
ChatWindow��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $��3* �6   .+�5   
   �� $��0��6   .+�5      �� -   5         ��Name$ 	LVMembers��5      ��5      �� 5      .R�5      �� .+�5      �� ��6(   �� *employee.Name+6I   5      5      5      �� 5      -   5         ��Name$ AddUser��5   =   $��Add User��6   6=   �� 5       -   5        $��Change Topic��5       6,   �� 5!      -   5        $��Leave Chatroom��5!      6.   �� 5"      -   5        $
��Back��5"      6>   5#      �� 5&      -   5        $ 	LVMessage��5&      $��1��6*   ��5'      �� 5(      .R�5)      ��  �� Orientation$ 
Horizontal=�6%   .+�5*      �� ��6(   �� *Date+ �� StringFormat$ [HH:MM]��6X   �� 5+      $��5 0 0 0q�6]   ��6(   �� *employee.Name+$  {0}:��6p   �� 5,      $��5 0 0 0q�6A   ��6(   �� *	Message+6T   5-      5.      50      � 53   
   $��1��6   $��2��6    54      �� 55      $��6* �6#   �� 56      .+�58      �� -   5         ��Name$ 
MessageBox��58      6,   �� 59      -	   5        $ 
SendButton��59   %   $��1��6   
����·�.��5:      �� $
��Send��6   $��20(�6(   $
��Bold"�66   6J   5;      5<      5>      5?      
   M S B A M L   `   `   `  ����   UVS Task    UVS_Task.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  UVS Task�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=�$	��500��$
��1000�� � Icon$. (Images/universalios-valdymo-sistemos.jpg��.���  � RowDefinitions �� $��60 ��� $	��120 ��� $	��300 �.+��� $��1��$	��700�� �� CornerRadius$ 10��$��5q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ 	#FF3A3A3A��	 � Offset$		 0.0Q�� $ 	#FFA4000A��$
	 0.50Q�._��� $��2������ $	 0,0&�$	 1,0&�.��� $ 	#FF3A3A3A��$		 0.0Q�� $ 	#FFA4000A��$
	 0.50Q��� $��0��$
��1000��$��50��
 �� Orientation$
 
Horizontal=�.+��� $��Thread's symbol generator��$
��1000��$��Center=�$��Center=�$��25(�� $��1�� � ColumnDefinitions �� $	��500 ��� $	��500 �.+��� $��0��$
��Auto��$
��Auto��$��	180 0 0 0q�$
��Left=�$��Center=�$
 Vertical=�.+��� $��40��$	��300��$%��Enter Amount of Thread's (2-15)��$
��Left=�
�������$��20(��� -   $��threadAmount��$	��200��$��30��$��5 0 0 0q� �� 	MaxLength$ 2��$��18(�$��Center=�$
��Left=��� $��1��$
��Auto��$
��Auto��$
��Left=�$��Center=�$
 
Horizontal=�.+��� -   $��Start��$��40��$	��150��$��Start��$��0 0 20 0q�
�������$��20(�   ButtonRound#��[  �� -   $
��Stop��$��40��$	��150��$
��Stop��
�������$��20(�#��[  �� -   $��	lvSymbols��
���   ����	#FF3A3A3A$��2��$��	0 20 0 20q�$	��240��$	��250������ *SymbolsCollection+ �� View �� P��� $��	Thread ID�� �� Width$ 80�� �� DisplayMemberBinding �� *
ThreadId+�� $��Generated Line's��$	 120�� �� *	Symbols+
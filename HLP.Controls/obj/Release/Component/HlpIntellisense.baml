   M S B A M L   `   `   `  ���� G  CHLP.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HLP.Controls.BaseHLP.Controls.Base  ,    &HLP.Controls.Component.HlpIntellisense   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3runtimeclr-namespace:HLP.Controls.Base       � 	Resources     Button_PESQUISA_Pesquisa �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources  Key �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime	 �� Value
 ��Name �� CornerRadius F�Name �� Stretch �� Triggers P� Property P� Value N� ExitActions ��Name  Storyboard2 N� EnterActions  Storyboard1  TextBox_PESQUISA-  'System.Windows.Input.KeyboardNavigation � ColumnDefinitions J� SnapsToDevicePixels ��Name ��Name �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   	Direction   Opacity   ShadowDepth   RenderingBias � ToolTip  �� ElementName! �� Path��%y
  &	        7  7  &	      �� " ��.���  � ��$ 1q���  �@�Cursor$
 Hand����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " �� ���� Storyboard1 .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ border��.g�  $ 0:0:0.3��$	 	#FF0072C6���� $* $(Shape.Fill).(SolidColorBrush.Color)�$
 path��.g�  $ 0:0:0.3��$	 White���� Storyboard2 .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ border��.g�  $ 0��$	 	#FF0072C6��  $ 0:0:0.3��$	 	#000072C6���� $* $(Shape.Fill).(SolidColorBrush.Color)�$
 path��.g�  $ 0��$	 White��  $ 0:0:0.3��$	 	#FF626262��.R�� .+��� $
 border��$	��0.7q�$ 0,4,4,0��
������ 
������ ._�� .+�F� $
 path��$��Center=�$��Center=�$��15��$��15��$
 Fill=����	#FF626262��������O������O�;Gp��;G�m��;G��w����)����)�Ӱkd�)���BL%� Q%�X�Ѵ���<�$����M8�l��M��Z�<�|�H/*|�H3��Z�R��l/��q�����>T�����2����mӀ��p�p(��O����O������ �@����� �����mӀ� V �@� ���� �� !�� ��2
 V�2
�m��2
 �� !��������� P�  �@J�IsMouseOver .  �� $! Storyboard2_BeginStoryboard��8��   �� 8�� �� " ��.���  � ��$ 1q���  � ��$ 20����  � �� �	#FF626262��  �@ TabNavigation$
 None=���  � ��$
 Left=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R�� |�.   �� �� $
��Auto �.+��� $
 border��$��3��
������ $ 4��$	��0.7q�
������� . �� $
 border2��$��3�����	#FF9C9C9C$ 4��$	��0.7q�
������� . �� $ PART_ContentHost��|�. $��Hidden=�$��Hidden=����	#FF626262$��Segoe Ui Light)�$��Center=�$
��Left=��� $	 btn��$y�Visible=�$��20��$��1��|�.  #���    P�  �@J�	IsFocused . . ��� $ border2�� � �� �	#FF1C669C�� $ border�� �@J�Effect   $ 	#FF6BB5F0��$ 7Q�$ 0Q�$ 1Q�$ 0Q�$ Performance=�P�  �@��
IsReadOnly . . ��� $	 btn�� � y�$ 	Collapsed=�P�  �@=�HasError . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� ���	#FFC82F2F$��Right=�$��5,0,0,0q�$��12��$��12��$ 7�� �� $  customAdorner��$8! 2AdornedElement.(Validation.Errors)[0].ErrorContent�._��� $��!��$��center=�$��center=�$
��Bold"�
��������� $��customAdorner��$��Center=�.v��� 
������ $��1q�.��� " � Orientation" �� # �� RelativeSource# �� $ �� Mode$$ FindAncestor=�% �� AncestorType"% >�$! Orientation�.+��� -   & ��Name$& 	compBlock��$
��Wrap=�$
��Left=����� # �� $$ FindAncestor=�"% >�$! 	TextLabel����� # �� $$ FindAncestor=�"% >�$! 
WidthComp1��� -   ' ��Name$	' txt��#��[ $��20��$��Center=�$
��Left=�( �� 
IsReadOnly( �� # �� $$ FindAncestor=�"% >�$! 
IsReadOnly����� # �� $$ FindAncestor=�$% UserControlL�$!! customViewModel.xTextSearch�) �� Mode$) TwoWay=�* �� UpdateSourceTrigger$* PropertyChanged=����� # �� $$ FindAncestor=�"% >�$! 
WidthComp2�.��� -   $��popUp��$	��200��$��Bottom=�+ � PlacementTarget+ �� $	  txt��.��&   System.Windows.Controls.DataGrid  ,   GridLinesVisibility$
, None=�-   
IsReadOnly- . ��Z� . �� SelectedItem. �� # �� $$ FindAncestor=�$% UserControlL�$"! customViewModel.selectedItem����� # �� $$ FindAncestor=�$% UserControlL�$! customViewModel.cvs�
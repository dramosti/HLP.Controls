   M S B A M L   `   `   `  ���� G  CHLP.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HLP.Controls.BaseHLP.Controls.Base  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   TextBox.Static.Background  �� Color  ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color � Offset ! ComboBox.MouseOver.Background 1 -ComboBox.MouseOver.Editable.Button.Background  ComboBox.Pressed.Background / +ComboBox.Pressed.Editable.Button.Background  ComboBox.Static.Border ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border .	 *ComboBox.Static.Editable.Button.Background *
 &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph  ComboBox.MouseOver.Border * &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBox.Static.Glyph  Button_HLP_Search �� 
TargetType �� Property �� Value �� 
TargetType	 � 	Resources  Key
 �� TargetProperty �� 
TargetName8   2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name �� CornerRadius F�Name �� Stretch �� Triggers P� Property P� Value N� ExitActions ��Name  Storyboard2 N� EnterActions   Storyboard1 ! HLP_Search_TextBox-  'System.Windows.Input.KeyboardNavigation � ColumnDefinitions J� SnapsToDevicePixels ��Name ��Name �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   	Direction    Opacity!   ShadowDepth"   RenderingBias# � ToolTip$ �� ElementName% �� Path " HLP_TextBox # Button_Search_TextBox& �� RelativeSource' �� Mode( �� AncestorType) �� Triggers* ]� 
Conditions+ �� Property, �� Value- ��Name. � UseLayoutRounding $ ComboBoxToggleButton/ ^� 
Conditions0 �� Binding % ComboBoxTemplate1 �Name2 �Name3 � AllowsTransparency4 �� Mode5 �� ClearTypeHint6 ��Name7 ��Name8 ��Name9   DirectionalNavigation: d�Name; d� 	IsChecked< �� SelectionBoxItemTemplate= �� SelectionBoxItem#> �� SelectionBoxItemStringFormat? �� ContentStringFormat@ J� IsHitTestVisibleA P� 
SourceName & ComboBoxEditableTextBox ' ComboBoxEditableTemplateB ��NameC �� 
IsReadOnly ( HLP_ComboBoxItemD �� Padding ) HLP_ComboBox * HLP_CheckBox9  3System.Windows.Media.Animation.EasingDoubleKeyFrameE O� KeyTimeF O� ValueG A�NameH J� RenderTransformOrigin + TextBoxPesquisaStyle , CheckBox_QuickSearchI J� Opacity - TextBox_QuickSearchJ ��Name�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     (baseclr-namespace:HLP.Controls.Base  ;ed4http://schemas.microsoft.com/expression/2010/drawing  %,L  &	        &	      &	 o     &	 �     &	 #    &	 }    &	 �    &	 �    &	     &		     &	
 -    &	 D    &	 Y    &	 n    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	     &	 +    &	 @    &	 U    &	 j    &	     &	 �    &	 �    &	 �    7  7   &	! �
    7  &	"     &	# �    7  7   &	$ �    7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	% 1%    7 $ &	& S-    &	' �.    7 $ 7   7 & &	( 84    &	) �6    7  7  7 ( 7 % 7 ' &	* �8    7  7   &	+ :A    &	, �D    7  7   &	- �G    �� $  	#FFFFFFFF���� $	 0,1&�$	 0,0&�.��� $ 	#FFF0F0F0��$	 0.0Q�� $ 	#FFE5E5E5��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $ 	#FFECF4FC��$	 0.0Q�� $ 	#FFDCECFC��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $ 	#FFEBF4FC��$	 0.0Q�� $ 	#FFDCECFC��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $ 	#FFDAECFC��$	 0.0Q�� $ 	#FFC4E0FC��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $ 	#FFDAEBFC��$	 0.0Q�� $ 	#FFC4E0FC��$	 1.0Q��� $  	#FFABADB3���� $  	#FFFFFFFF���� $  	#FFABADB3���� $  Transparent���� $  Transparent���� $  	#FF000000���� $  	#FF4774B5���� $  	#FFFFFFFF���� $  	#FF7EB4EA���� $  	#FF7EB4EA���� $  	#FF000000���� $  	#FF569DE5���� $  	#FFFFFFFF���� $  	#FF569DE5���� $  	#FF569DE5���� $  	#FFBFBFBF���� $  	#FFF0F0F0���� $  	#FFD9D9D9���� $  	#FFFFFFFF���� $  	#FFBFBFBF���� $  Transparent���� $  Transparent���� $  	#FF606060���� " ��.���  � ��$ 1q���  �@�Cursor$
 Hand����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��	 ���� Storyboard1 .���� $0
 *(Panel.Background).(SolidColorBrush.Color)�$ border��.g�   $ 0:0:0.3��$ 	#FF0072C6���� $*
 $(Shape.Fill).(SolidColorBrush.Color)�$
 path��.g�   $ 0:0:0.3��$ White���� Storyboard2 .���� $0
 *(Panel.Background).(SolidColorBrush.Color)�$ border��.g�   $ 0��$ 	#FF0072C6��   $ 0:0:0.3��$ 	#000072C6���� $*
 $(Shape.Fill).(SolidColorBrush.Color)�$
 path��.g�   $ 0��$ White��   $ 0:0:0.3��$ 	#FF626262��.R�� .+��� $ border��$	��0.7q�$ 0,4,4,0��
������ 
������ ._�F� $
 path��$��Center=�$��Center=�$��15��$��15��$ Uniform=����	#FF626262������`>���0&��h��(��h�� /��h��`�Z0&XG9�`>XG9Ө�gXG9@�`�Z@� /��@�(����g���`>���������I���pښ(��pښ /��pښ`�ZI�XG9���XG9�h�XG9 -0`�Z -0 /�� -0(��h�������������`X�l
`�iE�[H��,���7X� i ��
0���� �(�@{�Ƞ4@{� �\�@{��bhӠ��hc L��`�e�@`��0��`0uv�*cui��h�ui �\�uiȠ4h�F(�PJ"��Ӏ��
��X�����,ӈ���iE٤X�l���Ӱ�W��6��a����a��� �a��� �d ���`� ���� ��@X. ��&i@>��&i /���&iȖ�HBi tHBiH�d��urH`Xb��IP�e��IP�h���IP���(�X����cӰ���s@��(��@�� /��@��@>�(�� ��`> �Ӡ�� �P`� ��H���������������P���6���� P�  �@J�IsMouseOver .  �� $! Storyboard2_BeginStoryboard��8��   �� 8�� �� " ��.���  � ��$ 1q���  � ��$ 20����  � ��$ 3,0,0,0q���  � �� �	#FF626262��  �@ TabNavigation$
 None=���  � ��$
 Left=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R�� |�.   �� �� $
��Auto �.+��� $ border��$��3��
������ $ 4��$	��0.7q�
������� . �� $ border2��$��3�����	#FF9C9C9C$ 4��$	��0.7q�
������� . �� $ PART_ContentHost��|�. $��Hidden=�$��Hidden=����	#FF626262$��Segoe Ui Light)�$��Center=�$
��Left=��� $	 btn��$y�Visible=�$��20��$��1��|�.  8��   P�  �@J�	IsFocused . . ��� $ border2�� � �� �	#FF1C669C�� $ border�� �@J�Effect   $ 	#FF6BB5F0��$ 7Q�$ 0Q�$  1Q�$! 0Q�$" Performance=�P�  �@��
IsReadOnly . . ��� $	 btn�� � y�$ 	Collapsed=�P�  �@=�HasError . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� ���	#FFC82F2F$��Right=�$��5,0,0,0q�$��12��$��12��$ 7��# �� $$ customAdorner��$8% 2AdornedElement.(Validation.Errors)[0].ErrorContent�._��� $��!��$��center=�$��center=�$
��Bold"�
��������� $��customAdorner��$��Center=�.v��� 
������ $��1q��� " ��.���  � ��$ 1q���  � ��$ 20����  � ��$ 0,0,0,3q���  � �� �	#FF626262��  �@ TabNavigation$
 None=���  � ��$
 Left=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R�� .+��� $ border��
������ $ 4��$	��0.7q�
������� . �� $ border2�����	#FF9C9C9C$ 4��$	��0.7q�
������� . �  �� �� $
��Auto �$��20��.+��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=��� $��1��$��20��$��20��|�.  
���   �#��� # ���� & �� $' FindAncestor=�"( >�$#% CustomViewModel.searchCommand����� & �� $' FindAncestor=�"( >� P�  �@J�	IsFocused . . ��� $ border2�� � �� �	#FF1C669C�� $ border�� �@J�Effect   $ 	#FF6BB5F0��$ 7Q�$ 0Q�$  1Q�$! 0Q�$" Performance=�P�  �@J�IsMouseOver . . ��� $ border2�� � �� �	#FF1C669C�� $ border�� �@J�Effect   $ 	#FF6BB5F0��$ 7Q�$ 0Q�$  1Q�$! 0Q�$" Performance=�P�  �@=�HasError . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� ���	#FFC82F2F$��Right=�$��5,0,0,0q�$��12��$��12��$ 7��# �� $$ customAdorner��$8% 2AdornedElement.(Validation.Errors)[0].ErrorContent�._��� $��!��$��center=�$��center=�$
��Bold"�
��������� $��customAdorner��$��Center=�.v��� 
������ $��1q�) ]� * �� ++ �@��#IsInactiveSelectionHighlightEnabled, . �� + �@��IsSelectionActive, .  ./���  �@��SelectionBrush# � /��� " ��.���  �@�FocusVisualStyle Z� ��  �@�Cursor$
 Hand����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��	 ���� Storyboard1 .���� $0
 *(Panel.Background).(SolidColorBrush.Color)�$ border��.g�   $ 0:0:0.4��$ 	#FF0072C6���� $2
 ,(Border.BorderBrush).(SolidColorBrush.Color)�$ border��.g�   $ 0:0:0.4��$ 	#FF0072C6���� $*
 $(Shape.Fill).(SolidColorBrush.Color)�$
 path��.g�   $ 0:0:0.4��$ White���� Storyboard2 .���� $*
 $(Shape.Fill).(SolidColorBrush.Color)�$
 path��.g�   $ 0��$ White��   $ 0:0:0.4��$ 	#FF626262���� $0
 *(Panel.Background).(SolidColorBrush.Color)�$ border��.g�   $ 0��$ 	#FF0072C6��   $ 0:0:0.4��$ 	#000072C6���� $2
 ,(Border.BorderBrush).(SolidColorBrush.Color)�$ border��.g�   $ 0��$ 	#000072C6��.R�� .+��� $ border��$ 0,4,4,0��
������ $	��0.7q�
������  . ._��� $- contentPresenter��|�.  #��z��#��z����. # z #��z��F� $
 path��$ Uniform=����	#FF626262��������O������O�;Gp��;G�m��;G��w����)����)�Ӱkd�)���BL%� Q%�X�Ѵ���<�$����M8�l��M��Z�<�|�H/*|�H3��Z�R��l/��q�����>T�����2����mӀ��p�p(��O����O������ �@����� �����mӀ� V �@� ���� �� !�� ��2
 V�2
�m��2
 �� !���������. .  $��10��$��10�� P�  �@J�IsMouseOver .  �� $! Storyboard2_BeginStoryboard��8��   �� 8�� �� " d�.���  �@�OverridesDefaultStyle . ��  � �� . ��  �@�FocusVisualStyle Z� ��  � |� . ��  �@��	ClickMode$ Press=���  � �� �� " d�.R�� |�.  .+��� $ border��
������ $ 4��$	��0.7q�
������� . �� $ border2��
������ $ 4��$��1q�
������� . �� $ splitBorder��
������ 
������ $ 0,3,3,0��#��� r� . $��0q�$��Right=�$	��0.7q�._�F� $ arrow��$��Center=�$��4.833,6.912,4.834,8.21q�$��Center=�8��  i���p    ��^o0��?Q��( �/�؀@Q�aQ ��^o0��?Q�aQ E]�`UU�?Q̰( ���B�}�?Q    TV�QUU>Q    ��^o0��?$��3.438��$��5.333�� P�  � {� .  . ��� $ border2�� � �� �	#FFF1F1F1�� $ border�� � �� �	#FFF1F1F1�� $ border2�� � �� �	#FFC3C3C3�� $ border�� � �� �	#FFC3C3C3��  �@�Cursor$ Arrow��P�  �@J�IsMouseOver . . ��� $ arrow�� � �� �	#FF0072C6P�  �@J�	IsFocused . . ��� $ border2�� � �� �	#FF1C669C�� $ border�� �@J�Effect   $ 	#FF6BB5F0��$ 7Q�$ 0Q�$  1Q�$! 0Q�$" Performance=�P�  � �� . . ��� $ arrow��8   � ��^� / �� 0 �� *	IsPressed+& �� *Self+, true�� 0 �� *
IsEditable+& �� "( ��	, false.0��� $ border2��8   � ���� $ border2��8   � ��^� / �� 0 �� *	IsPressed+& �� *Self+, true�� 0 �� *
IsEditable+& �� "( ��, true.0��� $ border2��8   � ���� $ border2��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � {� .  . ��� $ arrow��8   � ��^� / �� 0 �� *	IsEnabled+& �� *Self+	, false�� 0 �� *
IsEditable+& �� "( ��	, false.0��� $ border2��8 	  � ���� $ border2��8 
  � ��^� / �� 0 �� *	IsEnabled+& �� *Self+	, false�� 0 �� *
IsEditable+& �� "( ��, true.0��� $ border2��8   � ���� $ border2��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ���� " ��.R�� $1 templateRoot�� . |�.   �� $��* ��� #��� r�$��0 �.+��� $ border��$��2��
������ $ 4��$	��0.7q�
������� . � $2 
PART_Popup��|�.  3 . $��2��$��1q�#��� .�$��Bottom=����� *IsDropDownOpen+$4 TwoWay=�& �� *TemplatedParent+.���� $ dropDownBorder��$ 0,0,4,4�����	#FF9C9C9C$��0.7,0,0.7,0.7q�#��� ��._��� $ DropDownScrollViewer��$��1q�
������ 
������ .��� $
1 grid��
������ $5 Enabled=�.+��� $6 canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $7 
opaqueRect������ *
Background+$$ dropDownBorder������ *ActualHeight+$$ dropDownBorder������ *ActualWidth+$$ dropDownBorder���� $8 ItemsPresenter��$9 	Contained=�# z �� $ border2��$��2�����	#FF9C9C9C$ 4��$	��0.8q�
������� . ._�d� $: toggleButton��|�.  $��2��8��  ; �� *IsDropDownOpen+$4 TwoWay=�& �� *TemplatedParent+�� $- contentPresenter�����	#FF626262|�.  $��Segoe Ui Light)�#��z< #��z��#��z= #? z> #��z��@ .  #��z��# z #��z�� P�  �@J�	IsFocused . . ��� $ border2�� � �� �	#FF1C669C�� $ border�� �@J�Effect   $ 	#FF6BB5F0��$ 7Q�$ 0Q�$  1Q�$! 0Q�$" Performance=�P�  � {� .  . ��� $ border2�� � �� �	#FFF1F1F1�� $ border2�� � �� �	#FFC3C3C3�� $ border�� � �� �	#FFC3C3C3P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand���� $ border2�� � �� �	#FF1C669C�� $ border�� �@J�Effect   $ 	#FF6BB5F0��$ 7Q�$ 0Q�$  1Q�$! 0Q�$" Performance=�P�  �@��HasItems .  . ��� $ dropDownBorder�� � ��$ 95��]� * �� + �@��
IsGrouping, . �� "+ �@%�IsVirtualizingWhenGrouping, .  ./���  � �� .  P� $A DropDownScrollViewer�� � �� .  . ��� $ 
opaqueRect�� �� *VerticalOffset+$$ DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$$ DropDownScrollViewer�� �@��Left�� " ��.���  �@�OverridesDefaultStyle . ��  �@J�	AllowDrop . ��  � ��$ 0����  � ��$ 0����  �@�FocusVisualStyle Z� ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R��� $ PART_ContentHost��
������ |�. $��Hidden=�$��Hidden=��� " ��.R�� $1 templateRoot�� .  �� $��* ��� #��� r�$��0 �.+�� $2 
PART_Popup��3 . $��2��#��� .�$��Bottom=����� *IsDropDownOpen+& �� *TemplatedParent+.���� $ dropDownBorder��#��� ��$��1q�#��� ��._��� $ DropDownScrollViewer��.��� $
1 grid��$5 Enabled=�.+��� $6 canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $7 
opaqueRect������ *
Background+$$ dropDownBorder������ *ActualHeight+$$ dropDownBorder������ *ActualWidth+$$ dropDownBorder���� $8 ItemsPresenter��$9 	Contained=�# z d� $: toggleButton��#��z��#��z��#��z��$��2��8��  ; �� *IsDropDownOpen+$4 TwoWay=�& �� *TemplatedParent+�� $ border��8�� #��z��._��� $B PART_EditableTextBox��#��z��#��z��8�� #��z��C �� *
IsReadOnly+& �� *TemplatedParent+ P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsKeyboardFocusWithin . . ���  � ��
 �   �P�  �@��HasItems .  . ��� $ dropDownBorder�� � ��$ 95��]� * �� + �@��
IsGrouping, . �� "+ �@%�IsVirtualizingWhenGrouping, .  ./���  � �� .  P� $A DropDownScrollViewer�� � �� .  . ��� $ 
opaqueRect�� �� *VerticalOffset+$$ DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$$ DropDownScrollViewer�� �@��Left�� " ��.���  �@J�SnapsToDevicePixels . ��  � ��$	 4,1q���  �@�Cursor$
 Hand����  � �� �� *HorizontalContentAlignment+& �� "( ����  � �� �� *VerticalContentAlignment+& �� "( ����  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  �@�FocusVisualStyle Z� ��  � �� �� " ��.R��� $ Bd��
������ 
������ #��z��#D z�� . ._��� ���	#FF626262$��Segoe UI Light)�#��z��# z #��z�� P�  �@��IsHighlighted . . ��� $ Bd�� � �� �	#FFE7E7E7�� $ Bd�� � �� �	#FFE7E7E7�� " ��.���  � ��8   ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ 22����  � ��$ 0,0,0,1q���  � ��$ 6,3,5,3q���  � ��$
 Auto=���  � ��$
 Auto=���  � ��8  ��  �@�FocusVisualStyle Z� ��  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��8  ) P�  �@��
IsEditable . . ���  � �� .  ��  � ��$ 2q���  � ��8  �� " ��.���  � �� �� " ��	 ���� Storyboard1 .��U� $U
 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ ellipse��.\�  $E 0:0:0.4��$F 18.002Q��� $,
 &(Shape.Stroke).(SolidColorBrush.Color)�$ ellipse��.g�   $ 0:0:0.4��$ 	#FF0CFF00���� $N
 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�$ border��.g�   $ 0:0:0.4��$ 	#FF0CFF00���� $2
 ,(Border.BorderBrush).(SolidColorBrush.Color)�$ border��.g�   $ 0:0:0.4��$ 	#FF0CFF00���� $*
 $(Shape.Fill).(SolidColorBrush.Color)�$ ellipse��.g�   $ 0:0:0.4��$ White���� $N
 H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�$ border��.g�   $ 0:0:0.4��$ 	#FF0CFF00��U� $O
 I(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Offset)�$ border��.\�  $E 0:0:0.4��$F 0.465Q��� Storyboard2 .��U� $U
 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ ellipse��.\�  $E 0��$F 18.002Q�  $E 0:0:0.4��$F -0.01Q��� $,
 &(Shape.Stroke).(SolidColorBrush.Color)�$ ellipse��.g�   $ 0��$ 	#FF0CFF00��   $ 0:0:0.4��$ 	#FF626262���� $N
 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�$ border��.g�   $ 0��$ 	#FF0CFF00��   $ 0:0:0.4��$ White���� $N
 H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�$ border��.g�   $ 0��$ 	#FF0CFF00��   $ 0:0:0.4��$ White���� $2
 ,(Border.BorderBrush).(SolidColorBrush.Color)�$ border��.g�   $ 0��$ 	#FF0CFF00��   $ 0:0:0.4��$ 	#FF626262���� $*
 $(Shape.Fill).(SolidColorBrush.Color)�$ ellipse��.g�   $ 0��$ 
WhiteSmoke��   $ 0:0:0.4��$ 
WhiteSmoke��.R�� 
������  . .+��� $ border��$	��0.7q�$
 10.7�����	#FF626262��
� .��� $ White��$ 0Q�� $ White��$ 1Q�._�A� $G ellipse��$��22��$��22�����	#FF626262$	��0.7��$!��-0.703,-0.689,17.302,-0.712q�$H 0.5,0.5&�
�������z�V� .~��� �� �� T�  P�  �@d�	IsChecked$
 TrueY� �� $! Storyboard2_BeginStoryboard��8��   �� 8�� �� " ��.���  � ��# � ����  � ��$ 1q���  �@ TabNavigation$
 None=���  � ��$
 Left=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R�� .+��� $ border��$	��0.7q�
���   �._��  �� �� $
��Auto �$��20��.+��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=��� $��1��$��19��$��19��|�.  
������ ���� & �� $' FindAncestor=�"( >�$#% CustomViewModel.searchCommand����� & �� $' FindAncestor=�"( >� P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver . . ��� $ border�� � ��
 �   �P�  �@J�IsKeyboardFocused . . ��� $ border�� � ��
 �   �) ]� * �� ++ �@��#IsInactiveSelectionHighlightEnabled, . �� + �@��IsSelectionActive, .  �� " 	�.���  �@�FocusVisualStyle Z� ��  � ��$ 1q���  � �� �� " 	�	 ���� Storyboard1 .��U� $
 (UIElement.Opacity)�$ ellipse��.\�  $E 0:0:0.4��$F 1Q��� Storyboard2 .��U� $
 (UIElement.Opacity)�$ ellipse��.\�  $E 0��$F 1Q�  $E 0:0:0.4��$F 0Q�.R��  �� $��16 ��� .+��� $��0��$	��0.8q�$ 10�����	#FF626262._�A� $G ellipse��$��8��$��8�����	#FF0072C6$I 0Q��� $- contentPresenter��$��1��$��Segoe Ui Symbol)�$��Center=����	#FF545454|�.  $
��Left=�$��3.998,-2.674,0,-0.335q� P�  �@d�	IsChecked$
 TrueY� �� $! Storyboard2_BeginStoryboard��8��   �� 8�� �� " ��.���  � ��$ 25����  � ��$ 0,0,0,3q���  � �� �� " ��.R�� .+��� $ border��
����������	#FF626262$ 0��$	��1.3q��� $ PART_ContentHost��$��Center=�$��15�����	#FF626262$��2,0,0,0q��� $J WaterMarkLabel��$��Insira um valor��$y�	Collapsed=����	#FF626262$��Segoe UI Light)� P�  �@J�IsMouseOver . . ��� $ border�� � �� �	#FF0072C6P�  �@J�	IsFocused . . ��� $ border�� � �� �	#FF0072C6]� * �� + � ��$,  ��./��� $ WaterMarkLabel�� � y�$ Visible=�
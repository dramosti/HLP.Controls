   M S B A M L   `   `   `  ���� G  CHLP.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:HLP.Controls.Converters.Component!HLP.Controls.Converters.Component  +    %HLP.Controls.ViewWindow.wdQuickSearch   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     E	converter/clr-namespace:HLP.Controls.Converters.Component     -     �Name$
  wdQs�� � Title$ wdQuickSearch��$	��150��$	��250�� � WindowStyle$
 None=� J� SnapsToDevicePixels .  � AllowsTransparency .  � 	Resources  �� MergedDictionaries �� SourceT   NHLP.Controls.Converters.Component.RadioButtonCheckedButtonQuickSearchConverter   radioBtnCheckedButtonQSConv  Button_Search_QuickSearch �� 
TargetType	 �� Property
 �� Value �� 
TargetType � 	Resources  Key ��Name �� CornerRadius �� Left
 �� Top �� Stretch �� Triggers P� Property P� Value N� EnterActions  Storyboard1  Button_Close_QuickSearch��  �� $[ Upack://application:,,,/HLP.Controls;component/Resources/Styles/UserControlStyles.xaml?�%�  &	        &	      7  &	 �    7    �� " ��.��� 	 �@�FocusVisualStyle
 Z� �� 	 � ��$
 Center=��� 	 � ��$
 Center=��� 	 � ��$
 1q��� 	 � ��
 �� " �� ���� Storyboard1 .R��� $ border�����	#FF626262$	��0.9q�
�������$ 19�� . ._�F� $��16��$��16��$ 21.8536��$ 22��$
 Fill=����	#FF626262��������O������O�;Gp��;G�m��;G��w����)����)�Ӱkd�)���BL%� Q%�X�Ѵ���<�$����M8�l��M��Z�<�|�H/*|�H3��Z�R��l/��q�����>T�����2����mӀ��p�p(��O����O������ �@����� �����mӀ� V �@� ���� �� !�� ��2
 V�2
�m��2
 �� !��������� P�  �@J�IsMouseOver .  �� 8��  �� " ��.��� 	 �@�FocusVisualStyle
 Z� �� 	 � ��$
 Center=��� 	 � ��$
 Center=��� 	 � ��$
 1q��� 	 � ��
 �� " �� ���� Storyboard1 .R��� $ border�����	#FF626262$	��0.9q�
�������$ 19�� . ._�F� $��10��$��Center=�$��Center=�$��10��$ 21.8536��$ 22��$
 Fill=����	#FF626262�����ܵV@�e�8�@�e��wSt����Od����K��h�G��ь�E��Ӝ�C���<s?�z��I8P��ѨL�@�e�d4@�e� �~�:@@@��C�h�D��!������!Ѵ:̼��8�@,��,�F��Q�.@@��K� �lbM� ��P�[��V<��L�_$/�ѼM���!�(mN��!фݠ�_A�ܵV@�e P�  �@J�IsMouseOver .  �� 8��  .���� $	��1.5q����	#FF0072C6._��  � ColumnDefinitions �� $��10 ��� �� $��10 � � RowDefinitions �� $��10 ��� $��25 ��� $��5 ��� �� $��40 �.+��� -   $��1��$��1��  TextBox_QuickSearch#��[ $��0q����� *xValue+ �� UpdateSourceTrigger$ PropertyChanged=�� $��1��$��3�� �� $��20 ��� �� $��16 ��� $��15 �.+��� $��0��$��Tipo do Filtro��$��Center=�$��Segoe Ui Light)�$��16(����	#FF626262� $��2�� �� $��55 ��� �� $��70 �.+�	� $��0��$��Igual��  CheckBox_QuickSearch#��[ ���� *ChangeToEqualCommand+ d� 	IsChecked �� *
stFilterQs+ �� 	Converter# [   �� ConverterParameter$ eq��	� $��1��$��Começa com��#��[ ���� *ChangeToStartWithCommand+ �� *
stFilterQs+# [  $ start��	� $��2��$��Contém��#��[ ���� *ChangeToContainsCommand+ �� *
stFilterQs+# [  $ contains���� $��4��$��4��._��  �� �� $��35 ��� $��10 ��� $��35 ��� $��10 � �� �� $��5 �.+��� $��1��#��[ ���� *searchCommad+����  �� ElementName$
 wdQs���� $��3��#��[ ���� *closeCommand+���� $
 wdQs��
   M S B A M L   `   `   `  ����H  DLearningWords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LearningWordsLearningWords  5   	       LearningWords.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:LearningWords     5   	     � Title$%  Профиль Студента��5   	   $	��450��6"   $	��800��6/    � 
ResizeMode$ CanMinimize=�6;    � Icon$ self-study_250.ico��6T    � WindowStartupLocation$ CenterScreen=�6n   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��301* �6   �� 5      $
��493* �6   ��5   
   �� 5       �� ImageSource$O Idepositphotos_160392568-stock-photo-icons-graduation-cap-illustration.jpg��6   .+�5   
   �� -   5        $
��List��5      $��374.4,0,-0.4,0q�6   $��1��66   5      �� 5   
   -   5         ��Name$ 
Scroll_Bar��5      
�������$
��Left=�65   $	��420��6P   
�������$	��Top=�6l   $	��287��6�   �� 5   
   -   5         ��Name$ Sername��5      $-��'Имя, Фамилия студента��6!   $
��Left=�6A   $��	10,10,0,0q�6\   $	��Top=�6o   $	��245��6�   $��Tempus Sans ITC)�6�   $��15(�6�   $
��Bold"�6�   �� 5   
   -   5        $ Point��5      $��
Балы: ��6   $
��Left=�60   $��0,45,0,0q�6K   $	��Top=�6]   $	��255��6u   
����������	#FF1CA8006�   �� 5   
   -   5        $ amount_wrong_words��5      $5��/Кол-во неправильных слов: ��6,   $
��Left=�6Q   $��0,71,0,0q�6l   $	��Top=�6~   ���	#FFF01919$	��277��6�   �� 5   
   -   5        $ amount_theme��5      $/��)Кол-во пройденных тем: ��6&   $
��Left=�6H   $��	0,123,0,0q�6c   $	��Top=�6v   $	��255��6�   ���	#FF17C4E56�   �� 5   
   -   5         ��Name$ 
arrow_left��5      $�� ��6%   $
��Left=�60   $��	255,0,0,0q�6K   $	��Top=�6^   $��32��6v   $��40��6�   
���   �
���������5       �� 5!      $# Стрелка влево.jpg��6   5#      �� 5$   
   -   5        $ arrow_Right��5$      $�� ��6&   $
��Left=�61   $	��Top=�6L   $��32��6d   $��40��6o   
���������5%      �� 5&      $% Стрелка вправо.jpg��6   5(      �� 5)   
   -	   5        $ amount_right_words��5)      $0��*Кол-во правильных слов:��6,   $
��Left=�6N   $��0,97,0,0q�6i   $	��Top=�6{   ���	#FFCAD11C$	��255��6�   �� 5*   
   -
   5        $ Last_complete_theme��5*      $7��1Последняя пройденная тема:��6-   $
��Left=�6R   $��	0,149,0,0q�6m   $	��Top=�6�   ���	#FFB020E2$	��255��6�   �� 5+   
   -   5        $�� ��5+      $��1��6   $
��Left=�6,   $��294.2,374,0,0q�6G   $	��Top=�6^   $��75��6v   $��36��6�   
���������5,      �� 5-      $+ %Lessons/Anonymous_arrow_next_Left.jpg��6   5/      50      51      
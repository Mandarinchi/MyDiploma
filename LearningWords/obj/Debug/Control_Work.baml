   M S B A M L   `   `   `  ����H  DLearningWords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LearningWordsLearningWords  5   	        LearningWords.Control_Work   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:LearningWords     5   	   -   5          �Name$  Control_work��5   	    � Title$ Control_Work��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�67    � Icon$ self-study_250.ico��6\    � 
ResizeMode$ CanMinimize=�6v   .��5	      � .+�5
   
   �� -   5         ��Name$ TabControler��5
      $��
0,0,-0.4,0q�6+   .@�5      �� $��Задание №1��6   .��5      �� .+�5      �� -   5        $��RUS\ENG��5       �� Left$	 518��6m   
 �� Top$ 15��6   �� 5      -   5         ��Name$ Label_Word_1��5       $��18��66   $
��Wrap=�6B   $��
TextBlock:��6V   $	��100��6h   $	 231��6t   $	 103��6�   $��14(�6�   �� 5      -   5        $ Label_Word_2��5       $��18��66   $
��Wrap=�6B   $��
TextBlock:��6V   $	��100��6h   $	 231��6t   $	 126��6�   $��14(�6�   �� 5      -   5        $ Label_Word_3��5       $��18��66   $
��Wrap=�6B   $��
TextBlock:��6V   $	��100��6h   $	 231��6t   $	 149��6�   $��14(�6�   �� 5      -   5        $ Label_Word_4��5       $��18��66   $
��Wrap=�6B   $��
TextBlock:��6V   $	��100��6h   $	 231��6t   $	 172��6�   $��14(�6�   �� 5      -   5        $ Label_Word_5��5       $��18��66   $
��Wrap=�6B   $��
TextBlock:��6V   $	��100��6h   $	 231��6t   $	 195��6�   $��14(�6�   �� 5      -	   5        	 ��Name$	 Word_1��5      $��23��6.   
 �� TextWrapping$

 Wrap=�6:   $	��235��6N   $	 366��6Z   $	 102��6l   $��14(�6}   �� 5      -
   5        $	 Word_2��5      $��23��6.   $

 Wrap=�6:   $	��235��6N   $	 366��6Z   $	 125��6l   $��14(�6}   �� 5      -   5        $	 Word_3��5      $��23��6.   $

 Wrap=�6:   $	��235��6N   $	 366��6Z   $	 148��6l   $��14(�6}   �� 5      -   5        $	 Word_4��5      $��23��6.   $

 Wrap=�6:   $	��235��6N   $	 366��6Z   $	 171��6l   $��14(�6}   �� 5      -   5        $	 Word_5��5      $��23��6.   $

 Wrap=�6:   $	��235��6N   $	 366��6Z   $	 194��6l   $��14(�6}   �� 5      -   5        $ Label_russian_words��5       $��25��6=   $
��Wrap=�6I   $	��225��6]   $	 270��6i   $ 8��6{   $��16(�6�   $6��0Вставьте английские слова��6�   $
��Bold"�6�   �� 5      -   5        $ Label_english_words��5       $��25��6=   $
��Wrap=�6I   $	��162��6]   $	 295��6i   $ 10��6{   $��16(�6�   $��Insert english words��6�   $
��Bold"�6�   �� 5      -   5        $��Проверить��5      $��23��61   $��75��6=   $	 703��6H   $	 359��6Z   6k   �� 5      -   5         ��Name$
 VARa��5      $��Вариант:��6*   $ 10��6=   $ 10��6N   $��16(�6^   $
��Bold"�6l   5      5       �� 5!      $��Задание №2��6   .��5"      �� .+�5#      �� -   5        $��RUS\ENG��5#      $	 358��6k   $ 15��6}   �� 5%      -   5        $
	 Text��5%       �� 
IsReadOnly . $	��345��6>   $ 10��6K   $

 Wrap=�6\   $ 35��6p   $	��428��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   �� 5&      -   5        $ Label_rus_zad_2��5&       $��25��69   $
��Wrap=�6E   $	��347��6Y   $	 431��6e   $ 10��6w   $��16(�6�   $N��HПрочтите и выберите верные утверждения��6�   $
��Bold"�6�   �� 5'      -   5        $ Label_eng_zad_2��5'       $��25��69   $
��Wrap=�6E   $	��347��6Y   $	 431��6e   $ 10��6w   $��16(�6�   $
��Bold"�6�   �� 6�   $�Read and choose��6�   �� 6�   $� ��6�   �� 6�   $�the right statement��6�   6�   �� 5(      -   5        $ 
Question_1��5(      $��Label��60   $	 455��6@   $ 40��6R   $	��323��6b   �� 5*      -   5        $ 
Question_2��5*      $��Label��60   $	 455��6@   $ 90��6R   $	��323��6b   �� 5+      -   5        $ 
Question_3��5+      $��Label��60   $	 455��6@   $	 134��6R   $	��323��6c   �� 5,      -   5        $ 
Question_4��5,      $��Label��60   $	 455��6@   $	 179��6R   $	��323��6c   �� 5/      -   5        $ 
Question_5��5/      $��Label��60   $	 451��6@   $	 221��6R   $	��323��6c   �� 52      -   5        $ Name_of_text��52      $��Label��62   $��35��6B   $	��296��6N   $ 10��6Z   $��16(�6k   $
��Bold"�6y   �� 53      -   5         ��Name$ Question_1_Yes��53      $	��Yes��65   $	 462��6C   $ 66��6U   $��76��6e   $��24��6p   6|   �� 54      -   5        $ Question_1_No��54      $��No��64   $	 572��6A   $ 66��6S   $��75��6c   $��24��6n   6z   �� 55      -   5        $ Question_2_Yes��55      $	��Yes��65   $	 463��6C   $	 115��6U   $��75��6f   6q   �� 56      -   5        $ Question_2_No��56      $��No��64   $	 572��6A   $	 115��6S   $��75��6d   6o   �� 57      -    5        $ Question_3_Yes��57      $	��Yes��65   $	 463��6C   $	 160��6U   $��75��6f   6q   �� 58      -!   5        $ Question_3_No��58      $��No��64   $	 572��6A   $	 160��6S   $��75��6d   6o   �� 59      -"   5        $ Question_4_Yes��59      $	��Yes��65   $	 463��6C   $	 202��6U   $��75��6f   6q   �� 5:      -#   5        $ Question_4_No��5:      $��No��64   $	 572��6A   $	 202��6S   $��75��6d   6o   �� 5;      -$   5        $ Question_5_Yes��5;      $	��Yes��65   $	 462��6C   $	 246��6U   $��75��6f   6q   �� 5<      -%   5        $ Question_5_No��5<      $��No��64   $	 572��6A   $	 246��6S   $��75��6d   6o   5?      5@      �� 5B      $��Задание №3��6   $��23��6*   $��-2.4,0,-1.8,0q�66   $	��Top=�6M   .��5C      �� .+�5D      �� -&   5        $��RUS\ENG��5D      $	 710��6k   $ 15��6}   �� 5F      -'   5        $��Text_First_Part_1��5F      $��20��67   $

 Wrap=�6C   $	��302��6W   $ 10��6c   $	 120��6t    . 6�   �� 5G      -(   5        $��Text_Second_Part_1��5G      $��20��68   $

 Wrap=�6D   $	��302��6X   $ 10��6d   $	 144��6u    . 6�   �� 5H      -)   5        $��Text_Third_Part_1��5H      $��20��67   $

 Wrap=�6C   $	��302��6W   $ 10��6c   $	 170��6t    . 6�   �� 5I      -*   5        $��Text_Fourth_Part_1��5I      $��20��68   $

 Wrap=�6D   $	��302��6X   $ 10��6d   $	 194��6u    . 6�   �� 5J      -+   5        $��Text_First_Part_2��5J      $��20��67   $

 Wrap=�6C   $	��323��6W   $	 455��6c   $	 120��6u    . 6�   �� 5K      -,   5        $��Text_Second_Part_2��5K      $��20��68   $

 Wrap=�6D   $	��323��6X   $	 455��6d   $	 145��6v    . 6�   �� 5L      --   5        $��Text_Third_Part_2��5L      $��20��67   $

 Wrap=�6C   $	��323��6W   $	 455��6c   $	 170��6u    . 6�   �� 5M      -.   5        $��Text_Fourth_Part_2��5M      $��20��68   $

 Wrap=�6D   $	��323��6X   $	 455��6d   $	 194��6v    . 6�   �� 5O      -/   5        $��First_Part_1��5O      $�� ��63   $	 312��6>   $	 122��6P   $��14��6a   6�   �� 5P      -0   5        $��Second_Part_1��5P      $�� ��64   $	 312��6?   $	 147��6Q   $��14��6b   6�   �� 5Q      -1   5        $��Third_Part_1��5Q      $�� ��63   $	 312��6>   $	 174��6P   $��14��6a   6�   �� 5R      -2   5        $��Fourth_Part_1��5R      $�� ��64   $	 312��6?   $	 198��6Q   $��14��6b   6�   �� 5S      -3   5        $��First_Part_2��5S      $�� ��63   $	 441��6>   $	 122��6P   $��14��6a   6�   �� 5T      -4   5        $��Second_Part_2��5T      $�� ��64   $	 441��6?   $	 147��6Q   $��14��6b   6�   �� 5U      -5   5        $��Third_Part_2��5U      $�� ��63   $	 441��6>   $	 174��6P   $��14��6a   6�   �� 5V      -6   5        $��Fourth_Part_2��5V      $�� ��64   $	 441��6?   $	 198��6Q   $��14��6b   6�   �� 5X      -7   5        $��First_to_First��5X       ���	#FF000006$��4��6G   
���   �$��95��6a   $	 336��6l   $	 126��6~   $y�Hidden=�6�   �� 5Y      -8   5        $��Second_to_Second��5Y       ���	#FF000006$��4��6I   
���   �$��95��6c   $	 336��6n   $	 152��6�   $y�Hidden=�6�   �� 5Z      -9   5        $��Third_to_Third��5Z       ���	#FF000006$��4��6G   
���   �$��95��6a   $	 336��6l   $	 179��6~   $y�Hidden=�6�   �� 5[      -:   5        $��Fourth_to_Fourth��5[       ���	#FF000006$��4��6I   
���   �$��95��6c   $	 336��6n   $	 203��6�   $y�Hidden=�6�   �� 5]      -;   5        $��Second_to_First��5]       ���	#FF000006$��4��6H   
���   �$��98��6b   $	 334��6m   $	 140��6    J� RenderTransformOrigin$ 0.5,0.5&�6�   $y�Hidden=�6�   z�5^      V� 5_      .~�5`   "   �� �� 5a   "   �� 5b   "    �� Angle$ -12.704Q�62   T� 5c   "   5d      5f      �� 5h      -<   5        $��Third_to_First��5h       ���	#FF000006$��4��6G   
���   �$	��106��6a   $	 330��6m   $	 153��6   $ 0.5,0.5&�6�   $y�Hidden=�6�   z�5i      V� 5j      .~�5k   "   �� �� 5l   "   �� 5m   "   $ -27.629Q�62   T� 5n   "   5o      5q      �� 5t      -=   5        $��Fourth_to_First��5t       ���	#FF000006$��4��6H   
���   �$	��115��6b   $	 326��6n   $	 162��6�   $ 0.5,0.5&�6�   $y�Hidden=�6�   z�5u      V� 5v      .~�5w   "   �� �� 5x   "   �� 5y   "   $ -37.413Q�62   T� 5z   "   5{      5}      �� 5      ->   5        $��First_to_Second��5       ���	#FF000006$��4��6H   
���   �$��95��6b   $	 337��6m   $	 138��6   $ 0.5,0.5&�6�   $y�Hidden=�6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   $ 13.848Q�62   T� 5�   "   5�      5�      �� 5�      -?   5        $��First_to_Third��5�       ���	#FF000006$��4��6G   
���   �$	��104��6a   $	 332��6m   $	 153��6   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   $ 28.726Q�62   T� 5�   "   5�      5�      �� 5�      -@   5        $��First_to_Fourth��5�       ���	#FF000006$��4��6H   
���   �$	��123��6b   $	 322��6n   $	 164��6�   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   $ 37.154Q�62   T� 5�   "   5�      5�      �� 5�      -A   5        $��Second_to_Third��5�       ���	#FF000006$��4��6H   
���   �$��95��6b   $	 337��6m   $	 164��6   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   $ 14.543Q�62   T� 5�   "   5�      5�      �� 5�      -B   5        $��Second_to_Forth��5�       ���	#FF000006$��4��6H   
���   �$	��106��6b   $	 331��6n   $	 176��6�   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   $ 28.586Q�62   T� 5�   "   5�      5�      �� 5�      -C   5        $��Third_to_Second��5�       ���	#FF000006$��4��6H   
���   �$��95��6b   $	 336��6m   $	 165��6   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   $ -15.752Q�62   T� 5�   "   5�      5�      �� 5�      -D   5        $��Third_to_Forth��5�       ���	#FF000006$��4��6G   
���   �$��99��6a   $	 334��6l   $	 191��6~   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   $ 14.521Q�62   T� 5�   "   5�      5�      �� 5�      -E   5        $��Fourth_to_Second��5�       ���	#FF000006$��4��6I   
���   �$	��106��6c   $	 331��6o   $	 176��6�   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   $ -26.127Q�62   T� 5�   "   5�      5�      �� 5�      -F   5        $��Fourth_to_Third��5�       ���	#FF000006$��4��6H   
���   �$��95��6b   $	 336��6m   $	 191��6   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   $ -13.532Q�62   T� 5�   "   5�      5�      �� 5�      -G   5        $ Label_rus_zad_3��5�       $��25��69   $
��Wrap=�6E   $	��255��6Y   $	 245��6e   $ 20��6w   $��16(�6�   $
��Bold"�6�   $:��4Соедините части предложений��6�   �� 5�      -H   5        $ Label_eng_zad_3��5�       $��25��69   $
��Wrap=�6E   $	��255��6Y   $	 245��6e   $ 20��6w   $��16(�6�   $
��Bold"�6�   $$��Connect parts of the sentences��6�   5�      5�      �� 5�      $��Задание №4��6   .��5�      �� .+�5�      �� -I   5        $��RUS\ENG��5�      $	 552��6k   $ 30��6}   �� 5�      -J   5        $ 	Questions��5�       $
��Wrap=�63   $	��Top=�6G   $��41��6`   $	��355��6l   $	 213��6x   $ 90��6�   �� 5�      -K   5        $ 
First_word��5�      $��Button��61   $	 245��6B   $	 136��6T   $	��104��6e   6q   �� 5�      -L   5        $ Second_word��5�      $��Button��62   $	 245��6C   $	 160��6U   $	��104��6f   6r   �� 5�      -M   5        $ 
Third_word��5�      $��Button��61   $	 245��6B   $	 184��6T   $	��104��6e   6q   �� 5�      $��A)��6   $��26��6)   $��24��65   $	 221��6@   $	 131��6R   �� 5�      $��B)��6   $��24��6)   $��24��65   $	 221��6@   $	 155��6R   �� 5�      $��C)��6   $��24��6)   $��24��65   $	 221��6@   $	 179��6R   �� 5�      -N   5        $
 Next��5�      $�� ��6+   $��47��66   $��75��6B   $	 493��6M   
�������$	 145��6�   ��5�      �� 5�       �� ImageSource$$ Anonymous_arrow_next_Right.jpg��6)   5�      �� 5�      -O   5        $ Label_rus_zad_4��5�       $��25��69   $
��Wrap=�6E   $	��232��6Y   $	 285��6e   $ 20��6w   $��16(�6�   $6��0Выберите правильный ответ��6�   $
��Bold"�6�   �� 5�      -P   5        $ Label_eng_zad_4��5�       $��45��69   $
��Wrap=�6E   $	��232��6Y   $	 285��6e   $��16(�6w   $
��Bold"�6�   �� 6�   �� 6�   �� 6�   $ �Choose the correct answer ��6�   6�   �� 5�      -Q   5        $��Результат��5�      $	 703��61   $	 360��6C   $��75��6T   6_   �� 5�      -R   5        $�� ��5�      $��47��6(   $��75��64   $ 10��6?   $	 332��6P   
���������5�      �� 5�      $+ %Lessons/Anonymous_arrow_next_Left.jpg��6)   5      5     5     5     5     5     
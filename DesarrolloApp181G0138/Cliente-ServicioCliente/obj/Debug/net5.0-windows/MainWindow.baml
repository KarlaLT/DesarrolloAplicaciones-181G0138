   M S B A M L   `   `   `  ����R  NCliente-ServicioCliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Cliente_ServicioClienteCliente_ServicioCliente  5   	   (    "Cliente_ServicioCliente.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Cliente_ServicioCliente     5   	   ���#E9967A  � Title$  Encuesta de satisfacción��5   	   $	��400��6*   $	��650��67    � DataContext 5	      %   Cliente_ServicioCliente.Cliente  5
   
   6    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%H  '��       '�� s     '��     �� 5   
   " ��6   .�5      ��  � ��$ 90��6'   �� 5       � ��$ 	0,15,0,10q�6'   5      �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�6.   �� 5       � ��$ 15(�6)   �� 5       � ��$ DemiBold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 0q�60    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#FFE4E163   �� 5       �@�Cursor$
 Hand��6/   5      5      5!      .��5"      � .+�5#   
   ]� .+�5$      �� ���#A52A2A$	��Top=�6-   	 �� Padding$	 10q�6B   
 �� TextAlignment$
 Center=�5%      $
��Bold"�6+   
�������$��30(�5&   '   Libreria "El sótano"5(      �� 5)      $	��Top=�6   $
 Center=�6-   $	 10q�6D   $��DemiBold"�6Q   ���#A52A2A$��25(�5*   )   )'¿Qué te ha parecido nuestro servicio?5,      �� 5-      $	��Top=�6   $
��50,5q�6-   
�������$��5q�6O   6e   � 5.      $	��Top=�6   $��50,10q�6-   .+�5/      �� .+�50      �� -   5        $��	Excelente��51      ��50   2   �� *EnviarCommand+.��52      �� $��/Assets/excelente.png��6   54      �� 55      
��� � �	Excelente6>   56      �� 57      .+�58      �� -   5        $��Bueno��59      ��58   2   �� *EnviarCommand+.��5:      �� $��/Assets/bueno.png��6   5<      �� 5=      
��� ���Bueno6;   5>      �� 5?      .+�5@      �� -   5        $��Regular��5A      ��5@   2   �� *EnviarCommand+.��5B      �� $��/Assets/neutral.png��6    5D      �� 5E      
���iii�	Regular6>   5F      �� 5G      .+�5H      �� -   5        $
��Malo��5I      ��5H   2   �� *EnviarCommand+.��5J      �� $��/Assets/malo.png��6   5L      �� 5M      
����  �Malo68   5N      �� 5O      .+�5P      �� -   5        $��Pésimo��5Q      ��5P   2   �� *EnviarCommand+.��5R      �� $��/Assets/pesimo.png��6   5T      �� 5U      
���  ��	Pésimo69   5V      5W      �� 5Z      $	��Top=�6   $
 Center=�6-   ���#800000$��20(�5[      $��DemiBold"�6"   $	 10q�68   )'¡Gracias por tu visita, vuelve pronto!5]      �� 5^      $��35��6   ���#4000$	��Top=�64   $��0q�6I   $��0q�5_      ��6!   �� *ConectarCommand+.��5`      �� $��	540,0,0,0q�6   $��30��6+   $��/Assets/encender.png��67   5a      5b      � 5c   
   -   5         �Name$ enviandoRes��5c      ���#9100$y�Hidden=�67   .+�5d      �� $��/Assets/cargando.png��6   5f      5g      5h      
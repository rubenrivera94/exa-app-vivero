   M S B A M L   `   `   `  ����D  @ViveroGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ViveroGUI	ViveroGUI  5   	   H DViveroNegocio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:ViveroNegocio;assembly=ViveroNegocioViveroNegocio 5   	   &     ViveroGUI.ActualizarPlantaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ViveroGUI     5   	   Dmodel2clr-namespace:ViveroNegocio;assembly=ViveroNegocio     5   	     � Title$  ActualizarPlantaWindow��5	   	   $	��800��6(   $	��800��65    � WindowStartupLocation$ CenterOwner=�5
   	    � DataContext 5        ViveroNegocio.Planta  5   
   .��5      � .+�5   
   ��  �� Padding$ 20q�6   $��10q�6   
�������$��1q�6=   ._�5      �� .+�5      �� $��22(�6   $��DemiBold"�6*   $��Actualizar Planta��6@   $��0,0,0,20q�6Y   $
��Left=�6k   �� 5      $ ��Nombre Común de la Planta��6   �� 5      -   5         ��Name$ txtNombreComun��5      $	��300��62   $
��Left=�6>   $
��0, 5q�6Y    �� 	MaxLength$ 50��5         TextBoxErrorTemplate =� ErrorTemplate# [  5      ��5      �� *NombreComun+ �� ValidatesOnExceptions .  �� UpdateSourceTrigger$ PropertyChanged=�.��5   S   5      �� 5      $%��Nombre Científico de la Planta��6   �� 5      -   5        $ txtNombreCientifico��5      $	��300��67   $
��Left=�6C   $
��0, 5q�6^   $ 50��5       # [  5!      ��5      �� *NombreCientifico+ . $ PropertyChanged=�.��5!   S   5"      �� 5%      $��Tipo de Planta��6   �� 5&      -   5        	 ��Name$	 cmbTipoPlanta��5&      $	��300��62   $
��Left=�6>   $
��0, 5q�6Y   
 �� SelectedValue
 5'      �� *
TipoPlanta+$ PropertyChanged=�.@�5(      �� $��Herbacea��6#   �� 5)      $��Matorral��6#   �� 5*      $��Arbusto��6#   �� 5+      $��Arbol��6#   5,      �� 50      $��Descripción de la Planta��6   �� 51      -   5        $ txtDescripcion��51      $	��300��62   $
��Left=�6>   $
��0, 5q�6Y   $	 200��53      # [  54      ��52      �� *Descripcion+ . $ PropertyChanged=�.��54   S   55      �� 58      $��Tiempo de Riego (días)��6   �� 59      -   5        $ txtTiempoRiego��59      $	��300��62   $
��Left=�6>   $
��0, 5q�6Y   # [  5;      ��5:      �� *TiempoRiego+ . $ PropertyChanged=�.��5;   S   5<      �� 5?      $��Cantidad de Agua (litros)��6   �� 5@      -   5        $ txtCantidadAgua��5@      $	��300��63   $
��Left=�6?   $
��0, 5q�6Z   # [  5B      ��5A      �� *CantidadAgua+ . $ PropertyChanged=�.��5B   S   5C      �� 5F      $��Época de Crecimiento��6   �� 5G      -   5        $	 cmbEpoca��5G      $	��300��6-   $
��Left=�69   $	��0,5q�6T   
 5H      �� *Epoca+$ PropertyChanged=�.@�5I      �� $��Verano��6#   �� 5J      $��Invierno��6#   �� 5K      $��Otoño��6#   �� 5L      $��	Primavera��6#   5M      �� 5P      $��¿Es venenosa?��6   �� 5Q      -   5         ��Name$ chkEsVenenosa��5Q      $	��400��62   $
��Left=�6>   $
��0, 5q�6Y    d� 	IsChecked 5R      �� *
EsVenenosa+$ PropertyChanged=��� 5U      $��¿Es autóctona?��6   �� 5V      -	   5        $ chkEsAutoctona��5V      $	��400��63   $
��Left=�6?   $
��0, 5q�6Z    5W      �� *EsAutoctona+$ PropertyChanged=��� 5Z      -
   5         ��Name$ btnActualizar��5Z      $��
Actualizar��60   $	��400��6E   $
��Left=�6Q   $��0, 10q�6l   ��5\      �� 5]       �� 
TargetType" ��6    .�5^      ��  �� Property � {� �� Value .  6:    �� Triggers 5_      ^� 5`   "    ^� 
Conditions 5a   &   �� 5b   *    �� Binding 5c   )   ��  �� ElementName$ txtNombreComun�� �� Path$ (Validation.HasError)� �� Value	 False5d   )   �� 5e   *    5f   )   �� $ txtNombreCientifico��$ (Validation.HasError)�	 False5g   )   �� 5h   *    5i   )   �� $ cmbTipoPlanta��$ (Validation.HasError)�	 False5j   )   �� 5k   *    5l   )   �� $ txtTiempoRiego��$ (Validation.HasError)�	 False5m   )   �� 5n   *    5o   )   �� $ txtCantidadAgua��$ (Validation.HasError)�	 False5p   )   �� 5q   *    5r   )   �� $ cmbEpoca��$ (Validation.HasError)�	 False5s   )   .0�5u   &   ��  � {� . 6B   5v   #   5x      5z      �� 5{      -   5        $ btnCancelar��5{      $��Cancelar��6.   $	��400��6[   $
��Left=�6g   $��0, 10q�6�   5|      5}      5~      5�      
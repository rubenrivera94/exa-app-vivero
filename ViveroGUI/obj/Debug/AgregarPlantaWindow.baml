   M S B A M L   `   `   `  ����D  @ViveroGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ViveroGUI	ViveroGUI  5   	   H DViveroNegocio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:ViveroNegocio;assembly=ViveroNegocioViveroNegocio 5   	   #    ViveroGUI.AgregarPlantaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ViveroGUI     5   	   Dmodel2clr-namespace:ViveroNegocio;assembly=ViveroNegocio     5   	     � Title$  AgregarPlantaWindow��5	   	   $	��450��6%   $	��800��62    � WindowStartupLocation$ CenterOwner=�5
   	    � DataContext 5        ViveroNegocio.Planta  5   
   .��5      � .+�5   
   ��  �� Padding$ 20q�6   $��10q�6   
�������$��1q�6=   ._�5      �� .+�5      �� $��22(�6   $��DemiBold"�6*   $��Agregar Planta��6@   $��0,0,0,20q�6V   $
��Left=�6h   �� 5      $ ��Nombre Común de la Planta��6   �� 5      -   5         ��Name$ txtNombreComun��5      $	��300��62   $
��Left=�6>   $
��0, 5q�6Y    �� 	MaxLength$ 50��5         TextBoxErrorTemplate =� ErrorTemplate# [  5      ��5      �� *NombreComun+ �� ValidatesOnExceptions .  �� UpdateSourceTrigger$ PropertyChanged=�.��5   S   5      �� 5      $%��Nombre Científico de la Planta��6   �� 5      -   5        $ txtNombreCientifico��5      $	��300��67   $
��Left=�6C   $
��0, 5q�6^   $ 50��5!      # [  5"      ��5       �� *NombreCientifico+ . $ PropertyChanged=�.��5"   S   5#      �� 5&      $��Tipo de Planta��6   �� 5'      -   5        	 ��Name$	 cmbTipoPlanta��5'      $	��300��62   $
��Left=�6>   $
��0, 5q�6Y   
 �� SelectedValue
 5(      �� *
TipoPlanta+$ PropertyChanged=�.@�5)      �� $��Herbacea��6#   �� 5*      $��Matorral��6#   �� 5+      $��Arbusto��6#   �� 5,      $��Arbol��6#   5-      �� 51      $��Descripción de la Planta��6   �� 52      -   5        $ txtDescripcion��52      $	��300��62   $
��Left=�6>   $
��0, 5q�6Y   $	 200��54      # [  55      ��53      �� *Descripcion+ . $ PropertyChanged=�.��55   S   56      �� 59      $��Tiempo de Riego (días)��6   �� 5:      -   5        $ txtTiempoRiego��5:      $	��300��62   $
��Left=�6>   $
��0, 5q�6Y   # [  5<      ��5;      �� *TiempoRiego+ . $ PropertyChanged=�.��5<   S   5=      �� 5@      $��Cantidad de Agua (litros)��6   �� 5A      -   5        $ txtCantidadAgua��5A      $	��300��63   $
��Left=�6?   $
��0, 5q�6Z   # [  5C      ��5B      �� *CantidadAgua+ . $ PropertyChanged=�.��5C   S   5D      �� 5G      $��Época de Crecimiento��6   �� 5H      -   5        $	 cmbEpoca��5H      $	��300��6-   $
��Left=�69   $	��0,5q�6T   
 5I      �� *Epoca+$ PropertyChanged=�.@�5J      �� $��Verano��6#   �� 5K      $��Invierno��6#   �� 5L      $��Otoño��6#   �� 5M      $��	Primavera��6#   5N      �� 5R      $��¿Es venenosa?��6   �� 5S      -   5         ��Name$ chkEsVenenosa��5S      $	��400��62   $
��Left=�6>   $
��0, 5q�6Y    d� 	IsChecked 5T      �� *
EsVenenosa+$ PropertyChanged=��� 5W      $��¿Es autóctona?��6   �� 5X      -	   5        $ chkEsAutoctona��5X      $	��400��63   $
��Left=�6?   $
��0, 5q�6Z    5Y      �� *EsAutoctona+$ PropertyChanged=��� 5\      -
   5         ��Name$ 
btnGuardar��5\      $��Guardar��6-   $	��400��6?   $
��Left=�6K   $��0, 10q�6f   ��5^      �� 5_       �� 
TargetType" ��6    .�5`      ��  �� Property � {� �� Value .  6:    �� Triggers 5a      ^� 5b   "    ^� 
Conditions 5c   &   �� 5d   *    �� Binding 5e   )   ��  �� ElementName$ txtNombreComun�� �� Path$ (Validation.HasError)� �� Value	 False5f   )   �� 5g   *    5h   )   �� $ txtNombreCientifico��$ (Validation.HasError)�	 False5i   )   �� 5j   *    5k   )   �� $ cmbTipoPlanta��$ (Validation.HasError)�	 False5l   )   �� 5m   *    5n   )   �� $ txtTiempoRiego��$ (Validation.HasError)�	 False5o   )   �� 5p   *    5q   )   �� $ txtCantidadAgua��$ (Validation.HasError)�	 False5r   )   �� 5s   *    5t   )   �� $ cmbEpoca��$ (Validation.HasError)�	 False5u   )   .0�5w   &   ��  � {� . 6B   5x   #   5z      5|      5}      5~      5      5�      
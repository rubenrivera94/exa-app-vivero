   M S B A M L   `   `   `  ���� D  @ViveroGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ViveroGUI	ViveroGUI  H DViveroNegocio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:ViveroNegocio;assembly=ViveroNegocioViveroNegocio &     ViveroGUI.ActualizarPlantaWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:ViveroGUI     Dmodel2clr-namespace:ViveroNegocio;assembly=ViveroNegocio       � Title$  ActualizarPlantaWindow��$	��800��$	��800�� � WindowStartupLocation$ CenterOwner=� � DataContext   ViveroNegocio.Planta  .��� .+���  �� Padding$ 20q�$��10q�
�������$��1q�._��� .+��� $��22(�$��DemiBold"�$��Actualizar Planta��$��0,0,0,20q�$
��Left=��� $ ��Nombre Común de la Planta���� -    ��Name$ txtNombreComun��$	��300��$
��Left=�$
��0, 5q� �� 	MaxLength$ 50��   TextBoxErrorTemplate =� ErrorTemplate# [  ���� *NombreComun+ �� ValidatesOnExceptions .  �� UpdateSourceTrigger$ PropertyChanged=�.���� $%��Nombre Científico de la Planta���� -   $ txtNombreCientifico��$	��300��$
��Left=�$
��0, 5q�$ 50��# [  ���� *NombreCientifico+ . $ PropertyChanged=�.���� $��Tipo de Planta���� -   	 ��Name$	 cmbTipoPlanta��$	��300��$
��Left=�$
��0, 5q�
 �� SelectedValue
 �� *
TipoPlanta+$ PropertyChanged=�.@��� $��Herbacea���� $��Matorral���� $��Arbusto���� $��Arbol���� $��Descripción de la Planta���� -   $ txtDescripcion��$	��300��$
��Left=�$
��0, 5q�$	 200��# [  ���� *Descripcion+ . $ PropertyChanged=�.���� $��Tiempo de Riego (días)���� -   $ txtTiempoRiego��$	��300��$
��Left=�$
��0, 5q�# [  ���� *TiempoRiego+ . $ PropertyChanged=�.���� $��Cantidad de Agua (litros)���� -   $ txtCantidadAgua��$	��300��$
��Left=�$
��0, 5q�# [  ���� *CantidadAgua+ . $ PropertyChanged=�.���� $��Época de Crecimiento���� -   $	 cmbEpoca��$	��300��$
��Left=�$	��0,5q�
 �� *Epoca+$ PropertyChanged=�.@��� $��Verano���� $��Invierno���� $��Otoño���� $��	Primavera���� $��¿Es venenosa?���� -    ��Name$ chkEsVenenosa��$	��400��$
��Left=�$
��0, 5q� d� 	IsChecked �� *
EsVenenosa+$ PropertyChanged=��� $��¿Es autóctona?���� -	   $ chkEsAutoctona��$	��400��$
��Left=�$
��0, 5q� �� *EsAutoctona+$ PropertyChanged=��� -
    ��Name$ btnActualizar��$��
Actualizar��$	��400��$
��Left=�$��0, 10q�����  �� 
TargetType" ��.���  �� Property � {� �� Value .   �� Triggers ^�  ^� 
Conditions ��  �� Binding ��  �� ElementName$ txtNombreComun�� �� Path$ (Validation.HasError)� �� Value	 False��  �� $ txtNombreCientifico��$ (Validation.HasError)�	 False��  �� $ cmbTipoPlanta��$ (Validation.HasError)�	 False��  �� $ txtTiempoRiego��$ (Validation.HasError)�	 False��  �� $ txtCantidadAgua��$ (Validation.HasError)�	 False��  �� $ cmbEpoca��$ (Validation.HasError)�	 False.0���  � {� . �� -   $ btnCancelar��$��Cancelar��$	��400��$
��Left=�$��0, 10q�
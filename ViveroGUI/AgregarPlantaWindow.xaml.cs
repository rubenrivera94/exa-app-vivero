using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViveroNegocio;


namespace ViveroGUI
{
    /// <summary>
    /// Lógica de interacción para AgregarPlantaWindow.xaml
    /// </summary>
    public partial class AgregarPlantaWindow : Window
    {
        public ViveroNegocio.Planta Planta { get; set; }

        public AgregarPlantaWindow()
        {
            InitializeComponent();

            // Inicializamos el objeto Planta y lo asignamos como DataContext
            Planta = new ViveroNegocio.Planta();
            this.DataContext = Planta;
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Asignar los valores de los ComboBox a las propiedades de Planta
                Planta.TipoPlanta = ((ComboBoxItem)cmbTipoPlanta.SelectedItem)?.Content.ToString();
                Planta.Epoca = ((ComboBoxItem)cmbEpoca.SelectedItem)?.Content.ToString();
                // Llamar al método Create para agregar la planta
                bool response = Planta.Create();

                if (response)
                {
                    MessageBox.Show("La planta se agregó correctamente.");
                    AgregarOtraPlanta();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al agregar la planta.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void AgregarOtraPlanta()
        {
            // Preguntar si se desea agregar otra planta
            string title = "Agregar Nueva Planta";
            string message = "¿Deseas agregar otra planta?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, title, buttons);

            if (result == MessageBoxResult.No)
            {
                this.Close();
            }
        }

        private void LimpiarCampos()
        {
            txtNombreComun.Text = string.Empty;
            txtNombreCientifico.Text = string.Empty;
            cmbTipoPlanta.SelectedIndex = -1;
            txtDescripcion.Text = string.Empty;
            txtTiempoRiego.Text = string.Empty;
            txtCantidadAgua.Text = string.Empty;
            cmbEpoca.SelectedIndex = -1;
            chkEsVenenosa.IsChecked = false;
            chkEsAutoctona.IsChecked = false;
        }

        private void txtTiempoRiego_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(txtTiempoRiego.Text, out int tiempoRiego))
            {
                Planta.TiempoRiego = tiempoRiego;
            }
            else
            {
                Planta.TiempoRiego = 0;
            }
        }

        private void txtCantidadAgua_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(txtCantidadAgua.Text, out int cantidadAgua))
            {
                Planta.CantidadAgua = cantidadAgua;
            }
            else
            {
                Planta.CantidadAgua = 0;
            }
        }
    }
}
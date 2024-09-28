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
    /// Lógica de interacción para ActualizarPlantaWindow.xaml
    /// </summary>
    public partial class ActualizarPlantaWindow : Window
    {
        // Declarar la variable plantaSeleccionada
        public ViveroNegocio.Planta planta { get; set; }


        public ActualizarPlantaWindow(int Id)
        {
            InitializeComponent();
            this.Title = string.Format("Actualizar Planta", Id);

            // Inicializamos el objeto Planta y lo asignamos como DataContext
            planta = new ViveroNegocio.Planta();
            this.DataContext = planta;

            CargarFormulario(Id);
        }

        private void CargarFormulario(int Id)
        {
            bool response = planta.Read(Id);
            if (response)
            {
                // Cargar los datos de la planta seleccionada en los campos del formulario
                txtNombreComun.Text = planta.NombreComun;
                txtNombreCientifico.Text = planta.NombreCientifico;
                txtDescripcion.Text = planta.Descripcion;
                txtTiempoRiego.Text = planta.TiempoRiego.ToString();
                txtCantidadAgua.Text = planta.CantidadAgua.ToString();
                chkEsVenenosa.IsChecked = planta.EsVenenosa;
                chkEsAutoctona.IsChecked = planta.EsAutoctona;

                // Seleccionar el valor en el ComboBox correspondiente al tipo de planta
                cmbTipoPlanta.SelectedValue = planta.TipoPlanta;
                // Seleccionar la época de crecimiento en el ComboBox
                cmbEpoca.SelectedValue = planta.Epoca;
            }
            else
            {
                MessageBox.Show($"La planta con ID {Id} no fue encontrada.");
            }
        }

        // Maneja el clic en el botón de actualizar para guardar los datos de la planta
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtTiempoRiego.Text, out int tiempoRiego) &&
                int.TryParse(txtCantidadAgua.Text, out int cantidadAgua))
            {
                planta.NombreComun = txtNombreComun.Text;
                planta.NombreCientifico = txtNombreCientifico.Text;
                planta.Descripcion = txtDescripcion.Text;
                planta.TiempoRiego = tiempoRiego; // Convertido a int
                planta.CantidadAgua = cantidadAgua; // Convertido a int
                planta.EsVenenosa = chkEsVenenosa.IsChecked.GetValueOrDefault(); // Manejo seguro del Nullable Boolean
                planta.EsAutoctona = chkEsAutoctona.IsChecked.GetValueOrDefault(); // Manejo seguro del Nullable Boolean

                // Obtener el valor seleccionado del ComboBox
                planta.TipoPlanta = ((ComboBoxItem)cmbTipoPlanta.SelectedItem)?.Content.ToString();

                // Obtener el valor seleccionado del ComboBox de la época
                planta.Epoca = ((ComboBoxItem)cmbEpoca.SelectedItem)?.Content.ToString();


                bool response = planta.Update();
                if (response)
                {
                    MessageBox.Show("La planta ha sido actualizada exitosamente.");
                    // Cerrar la ventana actual
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No fue posible actualizar la planta.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores válidos para el tiempo de riego y la cantidad de agua.");
            }
        }

        // Maneja el clic en el botón de cancelar
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar la ventana sin realizar cambios
            this.Close();
        }
    }
}
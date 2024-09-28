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

namespace ViveroGUI
{
    /// <summary>
    /// Lógica de interacción para ListarPlantaWindow.xaml
    /// </summary>
    public partial class ListarPlantaWindow : Window
    {
        ViveroNegocio.PlantaCollection plantaCollection;

        public ListarPlantaWindow()
        {
            InitializeComponent();
            CargarPlantas(); // Llama al método para cargar las plantas guardadas
        }

        private void CargarPlantas()
        {
            // Asignar la lista de plantas guardadas al DataGrid
            plantaCollection = new ViveroNegocio.PlantaCollection();
            dataGridPlantas.ItemsSource = plantaCollection.ReadAll(); // Asignar la lista actual de plantas
        }

        // Método para manejar la eliminación de una planta
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Eliminar la planta de la lista estática
            EliminarRegistroSeleccionado();
        }

        // Método para manejar la actualización de una planta
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            var filaSeleccionada = (ViveroNegocio.Planta)dataGridPlantas.SelectedItem;
            if (filaSeleccionada != null)
            {
                // Crear una nueva instancia de la ventana de actualización y mostrarla
                ActualizarPlantaWindow actualizarPlanta = new ActualizarPlantaWindow(filaSeleccionada.Id);
                actualizarPlanta.ShowDialog(); // Usamos ShowDialog en lugar de NavigationService
                actualizarPlanta.Owner = this; // Establece la ventana principal como ventana padre

                CargarPlantas(); // Recargar la lista después de la actualización
            }
            else
            {
                MessageBox.Show("Selecciona una planta para actualizar.");
            }
        }

        private void EliminarRegistroSeleccionado()
        {
            var filaSeleccionada = (ViveroNegocio.Planta)dataGridPlantas.SelectedItem;
            if (filaSeleccionada != null)
            {
                int plantaId = filaSeleccionada.Id;
                string title = "Eliminar Planta";
                string message = $"¿Estás seguro de que quieres eliminar la planta con ID {plantaId}?";

                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show(message, title, buttons);
                if (result == MessageBoxResult.Yes)
                {
                    var res = filaSeleccionada.Delete(plantaId)
                        ? MessageBox.Show($"Planta con ID {plantaId} eliminada correctamente.")
                        : MessageBox.Show("La planta no pudo ser eliminada.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una planta para eliminar.");
            }
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViveroGUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViveroNegocio.PlantaCollection plantaCollection;
        ViveroNegocio.PlantaReportes plantaReportes;

        public MainWindow()
        {
            InitializeComponent();
            plantaCollection = new ViveroNegocio.PlantaCollection();
            plantaReportes = new ViveroNegocio.PlantaReportes();
        }

        // Método para manejar el evento al hacer clic en "Agregar Planta"
        private void menuAgregarPlanta_Click(object sender, RoutedEventArgs e)
        {
            // Abrir la ventana para agregar planta
            AgregarPlantaWindow agregarPlantaWindow = new AgregarPlantaWindow();
            agregarPlantaWindow.Owner = this; // Establece la ventana principal como ventana padre
            agregarPlantaWindow.ShowDialog();
            // Cargar las plantas después de cerrar la ventana
            CargarGrilla();
        }

        // Método para manejar el evento al hacer clic en "Listar Plantas"
        private void menuListarPlantas_Click(object sender, RoutedEventArgs e)
        {
            // Abrir la ventana para listar plantas
            ListarPlantaWindow listarPlantaWindow = new ListarPlantaWindow();
            listarPlantaWindow.Owner = this; // Establece la ventana principal como ventana padre
            listarPlantaWindow.ShowDialog();
        }


        // Método para revisar la cantidad de plantas venenosas y no venenosas
        private void menuRevisarCantidadPlantasVenenosas_Click(object sender, RoutedEventArgs e)
        {
            int cantidadVenenosas = ObtenerCantidadPlantasVenenosas();
            int cantidadAutoctonas = ReporteCantidadPlantasAutoctonas();

            // Mostrar la información en un MessageBox
            MessageBox.Show($"Cantidad de plantas venenosas: {cantidadVenenosas}\nCantidad de plantas autoctonas: {cantidadAutoctonas}",
                "Cantidad de Plantas",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        // Métodos para obtener la cantidad de plantas desde PlantaReportes
        private int ObtenerCantidadPlantasVenenosas()
        {
            return plantaReportes.ReporteCantidadPlantasVenenosas();
        }

        private int ReporteCantidadPlantasAutoctonas()
        {
            return plantaReportes.ReporteCantidadPlantasAutoctonas();
        }

        // Método para cargar las plantas en la grilla
        private void CargarGrilla()
        {
            dgListarPlantas.ItemsSource = plantaCollection.ReadAll();
        }
    }
}

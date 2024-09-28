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
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el nombre de usuario y contraseña ingresados por el usuario
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Crear una instancia de la clase Login
            Login login = new Login();

            try
            {
                // Llamar al método IniciarSesion para obtener la contraseña almacenada en la base de datos
                string storedPasswordHash = login.IniciarSesion(username);

                // Si no se encontró ninguna contraseña almacenada, mostrar mensaje de error
                if (storedPasswordHash == null)
                {
                    lblMensaje.Content = "Usuario no encontrado.";
                    return;
                }

                // Validar la contraseña ingresada por el usuario con la almacenada usando SALT_Helper
                bool isPasswordValid = SALT_Helper.ValidateSaltyPassword(password, storedPasswordHash);

                // Verificar si la contraseña es válida
                if (isPasswordValid)
                {
                    // Si la contraseña coincide, mostrar mensaje de éxito
                    lblMensaje.Content = "Sesión iniciada correctamente.";
                }
                else
                {
                    // Si no coincide, mostrar mensaje de error
                    lblMensaje.Content = "La contraseña no coincide.";
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre alguna excepción
                lblMensaje.Content = $"Error al iniciar sesión: {ex.Message}";
            }
        }

    }
}

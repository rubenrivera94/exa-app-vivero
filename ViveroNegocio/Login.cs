using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViveroNegocio
{
    public class Login : ILoginPersistente
    {
        public string username { get; set; }
        public string password { get; set; }

        // Método para iniciar sesión
        public string IniciarSesion(string username)
        {
            try
            {
                // Llamar al procedimiento almacenado spLogin para obtener la contraseña encriptada almacenada
                var storedPasswordHash = CommonBCLogin.ModeloLogin.Database.SqlQuery<string>(
                    "EXEC spLogin @username",
                    new SqlParameter("@username", username)
                ).FirstOrDefault();

                // Verificar si el usuario existe (null si no existe)
                if (storedPasswordHash == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                return storedPasswordHash; // Retorna la contraseña hash almacenada
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al iniciar sesión: {ex.Message}");
            }
        }

        // Método para crear un nuevo usuario
        public bool CreateUser(string username, string password)
        {
            try
            {
                // Generar el salt
                byte[] salt = SALT_Helper.GetSalt();

                // Encriptar la contraseña usando el salt generado
                string saltedPasswordHash = SALT_Helper.GenerateSaltyPassword(password, salt);

                // Llamar al procedimiento almacenado spCreateUser para guardar el usuario y contraseña encriptada
                CommonBCLogin.ModeloLogin.Database.ExecuteSqlCommand(
                    "EXEC spCreateUser @username, @password",
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", saltedPasswordHash)
                );

                // Guardar los cambios
                CommonBCLogin.ModeloLogin.SaveChanges();

                return true; // Retorna true si la creación fue exitosa
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el usuario: {ex.Message}");
            }
        }
    }
}

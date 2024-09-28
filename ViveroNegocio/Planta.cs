using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace ViveroNegocio
{
    public class Planta : ObservableObject, IPersistente
    {
        // Propiedades
        public int Id { get; set; }

        private string _nombreComun;
        private string _nombreCientifico;
        private string _tipoPlanta;
        private string _descripcion;
        private int _tiempoRiego;
        private int _cantidadAgua;
        private string _epoca;
        private bool _esVenenosa;
        private bool _esAutoctona;

        // Validación propiedad NombreComun
        [Required(ErrorMessage = "El Nombre Común de la Planta es obligatorio.")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string NombreComun
        {
            get { return _nombreComun; }
            set
            {
                ValidateProperty(value);
                OnPropertyChanged(ref _nombreComun, value);
            }
        }

        // Validación propiedad NombreCientifico
        [Required(ErrorMessage = "El Nombre Científico es obligatorio.")]
        [MinLength(10, ErrorMessage = "Mínimo 10 caracteres.")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres.")]
        public string NombreCientifico
        {
            get { return _nombreCientifico; }
            set
            {
                ValidateProperty(value);
                OnPropertyChanged(ref _nombreCientifico, value);
            }
        }

        // Validación propiedad TipoPlanta
        [Required(ErrorMessage = "El Tipo de Planta es obligatorio.")]
        public string TipoPlanta
        {
            get { return _tipoPlanta; }
            set
            {
                ValidateProperty(value);
                OnPropertyChanged(ref _tipoPlanta, value);
            }
        }

        // Validación propiedad Descripcion
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres.")]
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                ValidateProperty(value);
                OnPropertyChanged(ref _descripcion, value);
            }
        }

        // Validación propiedad TiempoRiego
        [Required(ErrorMessage = "El Tiempo de Riego es obligatorio. Solo numeros enteros")]
        public int TiempoRiego
        {
            get { return _tiempoRiego; }
            set
            {
                OnPropertyChanged(ref _tiempoRiego, value);
            }
        }

        // Validación propiedad CantidadAgua
        [Required(ErrorMessage = "La Cantidad de Agua es obligatoria. Solo numeros enteros")]
        public int CantidadAgua
        {
            get { return _cantidadAgua; }
            set
            {
                OnPropertyChanged(ref _cantidadAgua, value);
            }
        }

        // Validación propiedad Epoca
        [Required(ErrorMessage = "La Época es obligatoria.")]
        public string Epoca
        {
            get { return _epoca; }
            set
            {
                ValidateProperty(value);
                OnPropertyChanged(ref _epoca, value);
            }
        }

        // Validación propiedad EsVenenosa
        public bool EsVenenosa
        {
            get { return _esVenenosa; }
            set
            {
                OnPropertyChanged(ref _esVenenosa, value);
            }
        }

        // Validación propiedad EsAutoctona
        public bool EsAutoctona
        {
            get { return _esAutoctona; }
            set
            {
                OnPropertyChanged(ref _esAutoctona, value);
            }
        }

        // Método para validar una propiedad
        private void ValidateProperty<T>(T value, [CallerMemberName] string name = "")
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name,
            });
        }

        // Método para crear una planta (con encriptación)
        public bool Create()
        {
            try
            {
                // Encriptar propiedades sensibles antes de guardarlas
                NombreComun = AES_Helper.EncryptString(NombreComun);
                NombreCientifico = AES_Helper.EncryptString(NombreCientifico);
                TipoPlanta = AES_Helper.EncryptString(TipoPlanta);
                Descripcion = AES_Helper.EncryptString(Descripcion);

                // Lógica para guardar la planta
                CommonBC.ModeloPlanta.spPlantaSave(
                    NombreComun,
                    NombreCientifico,
                    TipoPlanta,
                    Descripcion,
                    TiempoRiego,
                    CantidadAgua,
                    Epoca,
                    EsVenenosa,
                    EsAutoctona
                );
                CommonBC.ModeloPlanta.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la planta: {ex.Message}");
                return false;
            }
        }

        // Método para actualizar una planta (con encriptación)
        public bool Update()
        {
            try
            {
                // Encriptar propiedades sensibles antes de actualizarlas
                NombreComun = AES_Helper.EncryptString(NombreComun);
                NombreCientifico = AES_Helper.EncryptString(NombreCientifico);
                TipoPlanta = AES_Helper.EncryptString(TipoPlanta);
                Descripcion = AES_Helper.EncryptString(Descripcion);

                // Actualizar la planta
                CommonBC.ModeloPlanta.spPlantaUpdateById(
                    Id,
                    NombreComun,
                    NombreCientifico,
                    TipoPlanta,
                    Descripcion,
                    TiempoRiego,
                    CantidadAgua,
                    Epoca,
                    EsVenenosa,
                    EsAutoctona
                );
                CommonBC.ModeloPlanta.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Método para leer una planta
        public bool Read(int plantaId)
        {
            try
            {
                // Obtener la planta desde la base de datos usando Id
                var planta = CommonBC.ModeloPlanta.vw_Plantas.First(p => p.Id == plantaId);

                // Asignar propiedades desencriptadas a las propiedades de la clase
                this.Id = planta.Id;
                this.NombreComun = AES_Helper.DecryptString(planta.NombreComun);
                this.NombreCientifico = AES_Helper.DecryptString(planta.NombreCientifico);
                this.TipoPlanta = AES_Helper.DecryptString(planta.TipoPlanta);
                this.Descripcion = AES_Helper.DecryptString(planta.Descripcion);
                this.TiempoRiego = planta.TiempoRiego;
                this.CantidadAgua = planta.CantidadAgua;
                this.Epoca = planta.Epoca;

                // Conversión de bool? a bool usando el operador null-coalescing
                this.EsVenenosa = planta.EsVenenosa ?? false;
                this.EsAutoctona = planta.EsAutoctona ?? false;

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return false;
            }
        }


        // Método para eliminar una planta
        public bool Delete(int plantaId)
        {
            try
            {
                // Llama al procedimiento almacenado para eliminar la planta por su ID
                CommonBC.ModeloPlanta.spPlantaDeleteById(plantaId);
                CommonBC.ModeloPlanta.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return false;
            }
        }
    }
}
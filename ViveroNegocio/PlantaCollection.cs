using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroNegocio
{
    public class PlantaCollection
    {
        // Método para leer todas las plantas desde la vista 'vw_Plantas'
        public List<Planta> ReadAll()
        {
            var plantas = CommonBC.ModeloPlanta.vw_Plantas; // Acceso a la vista
            return ObtenerPlantas(plantas.ToList()); // Convierte a una lista de 'Planta'
        }

        // Método privado para transformar datos de la vista en objetos 'Planta'
        private List<Planta> ObtenerPlantas(List<ViveroData.vw_Plantas> plantasData)
        {
            List<Planta> plantaList = new List<Planta>();

            // Itera sobre cada registro de la vista
            foreach (ViveroData.vw_Plantas planta in plantasData)
            {
                Planta p = new Planta
                {
                    Id = planta.Id,
                    NombreComun = AES_Helper.DecryptString(planta.NombreComun), // Desencripta NombreComun
                    NombreCientifico = AES_Helper.DecryptString(planta.NombreCientifico), // Desencripta NombreCientifico
                    TipoPlanta = AES_Helper.DecryptString(planta.TipoPlanta), // Desencripta TipoPlanta
                    Descripcion = AES_Helper.DecryptString(planta.Descripcion), // Desencripta Descripción
                    TiempoRiego = planta.TiempoRiego,
                    CantidadAgua = planta.CantidadAgua,
                    Epoca = planta.Epoca,

                    // Conversión explícita de bool? a bool con valor por defecto
                    EsVenenosa = planta.EsVenenosa ?? false,
                    EsAutoctona = planta.EsAutoctona ?? false
                };

                // Agrega la planta a la lista
                plantaList.Add(p);
            }
            return plantaList;
        }

    }
}
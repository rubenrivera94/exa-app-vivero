using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroNegocio
{
    public class PlantaReportes
    {
        // Método para obtener la cantidad de plantas autoctonas
        public int ReporteCantidadPlantasAutoctonas()
        {
            // Convierte el resultado del procedimiento almacenado a un entero
            return Convert.ToInt32(CommonBC.ModeloPlanta.spObtenerCantidadPlantasAutoctonas().First().Value);
        }

        // Método para obtener la cantidad de plantas venenosas
        public int ReporteCantidadPlantasVenenosas()
        {
            // Convierte el resultado del procedimiento almacenado a un entero
            return Convert.ToInt32(CommonBC.ModeloPlanta.spObtenerCantidadPlantasVenenosas().First().Value);
        }
    }
}

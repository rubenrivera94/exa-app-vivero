using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroNegocio
{
    public class CommonBC
    {
        private static ViveroData.El_SaltoEntities _modeloPlanta;

        public static ViveroData.El_SaltoEntities ModeloPlanta
        {
            get
            {
                if (_modeloPlanta == null)
                {
                    _modeloPlanta = new ViveroData.El_SaltoEntities();
                }
                return _modeloPlanta ;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroNegocio
{
    internal class CommonBCLogin
    {
        private static ViveroData.LoginEntities _modeloLogin;

        public static ViveroData.LoginEntities ModeloLogin
        {
            get
            {
                if (_modeloLogin == null)
                {
                    _modeloLogin = new ViveroData.LoginEntities();
                }
                return _modeloLogin;
            }
        }
    }
}

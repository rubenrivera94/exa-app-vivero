using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroNegocio
{
    internal interface IPersistente
    {
        bool Create();
        bool Read(int Id);
        bool Update();
        bool Delete(int Id);
    }
}

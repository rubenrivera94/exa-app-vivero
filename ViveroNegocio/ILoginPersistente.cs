using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroNegocio
{
    public interface ILoginPersistente
    {
        string IniciarSesion(string username);
        bool CreateUser(string username, string password);
        
    }
}

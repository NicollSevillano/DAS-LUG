using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
{
    public interface IABMC<T> where T : ICodigo
    {
        void Alta(T pObject);
        void Baja(T pObject);
        void Modificar(T pObject);
        List<T> Consulta();
    }
}

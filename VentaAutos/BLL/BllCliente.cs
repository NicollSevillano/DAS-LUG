using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaz;
using Mapper;

namespace BLL
{
    public class BllCliente : IABMC<BeCliente>
    {
        MapperCliente mCliente = new MapperCliente();
        public void Alta(BeCliente pObject)
        {
            mCliente.Alta(pObject);
        }

        public void Baja(BeCliente pObject)
        {
            mCliente.Baja(pObject);
        }

        public List<BeCliente> Consulta()
        {
            return mCliente.Consulta();
        }

        public void Modificar(BeCliente pObject)
        {
            mCliente.Modificar(pObject);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Mapper;
using Interfaz;

namespace BLL
{
    public class BllVehiculo : IABMC<BeVehiculo>
    {
        MapperVehiculo mVehiculo = new MapperVehiculo();
        public void Alta(BeVehiculo pObject)
        {
            mVehiculo.Alta(pObject);
        }

        public void Baja(BeVehiculo pObject)
        {
            mVehiculo.Baja(pObject);
        }

        public List<BeVehiculo> Consulta()
        {
            return mVehiculo.Consulta();
        }

        public void Modificar(BeVehiculo pObject)
        {
            mVehiculo.Modificar(pObject);
        }
    }
}

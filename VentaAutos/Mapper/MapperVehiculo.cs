using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaz;
using DAL;
using System.Data;

namespace Mapper
{
    public class MapperVehiculo : IABMC<BeVehiculo>
    {
        DalVehiculo dVehiculo = new DalVehiculo();
        public void Alta(BeVehiculo pObject)
        {
            DataTable dT = dVehiculo.LeerVehiculo();
            DataRow dR = dT.NewRow();
            dR.ItemArray = new object[]
            {
                pObject.Codigo,
                pObject.Patente,
                pObject.Marca,
                pObject.Modelo,
                pObject.Año,
                pObject.Precio,
                pObject.Vendido,
                pObject.GetType().Name
            };
            dT.Rows.Add(dR);
            dVehiculo.EscribirVehiculo(dT);
        }

        public void Baja(BeVehiculo pObject)
        {
            DataTable dT = dVehiculo.LeerVehiculo();
            DataRow dR = dT.Rows.Find(pObject.Codigo);
            //Si para cumplir con la composición, si borramos 1 vehiculo 
            //su dueño no tiene otros vehiculos, también hay que borrarlos
            if(pObject.Cliente != null)
            {
                if (pObject.Cliente.lVehiculo.Count < 2)
                {
                    MapperCliente mCliente = new MapperCliente();
                    mCliente.Baja(pObject.Cliente);
                }
            }
            dR.Delete();
            dVehiculo.EscribirVehiculo(dT);
        }

        public List<BeVehiculo> Consulta()
        {
            DataTable dT = dVehiculo.LeerVehiculo();
            MapperCliente mCliente = new MapperCliente();
            List<BeVehiculo> lVehiculo = new List<BeVehiculo>();
            List<BeCliente> lCliente = mCliente.Consulta();
            foreach (DataRow dR in dT.Rows)
            {
                BeVehiculo a;
                if (dR.ItemArray[7] == "BeNormal")
                {
                    a = new BeNormal(dR.ItemArray);
                }
                else
                {
                    a = new BeCompetitivo(dR.ItemArray);
                }
                lVehiculo.Add(a);
                foreach (BeCliente item in lCliente)
                {
                    if(item.Codigo == dR.ItemArray[8].ToString())
                    {
                        item.lVehiculo.Add(a);
                        a.Cliente = item;
                    }
                }
            }
            return lVehiculo;
        }

        public void Modificar(BeVehiculo pObject)
        {
            DataTable dT = dVehiculo.LeerVehiculo();
            DataRow dR = dT.Rows.Add(pObject.Codigo);
            dR.ItemArray = new object[]
            {
                pObject.Codigo,
                pObject.Patente,
                pObject.Marca,
                pObject.Modelo,
                pObject.Año,
                pObject.Precio,
                pObject.Vendido,
                pObject.GetType().Name
            };
            dT.Rows.Add(dR);
            dVehiculo.EscribirVehiculo(dT);
        }
    }
}

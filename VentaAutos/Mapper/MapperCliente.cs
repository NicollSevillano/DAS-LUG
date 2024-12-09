using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Interfaz;

namespace Mapper
{
    public class MapperCliente : IABMC<BeCliente>
    {
        DalCliente dCliente = new DalCliente();
        public void Alta(BeCliente pObject)
        {
            DataTable dT = dCliente.LeerCliente();
            DataRow dR = dT.NewRow();
            dR.ItemArray = new object[]
            {
                pObject.Codigo,
                pObject.Nombre,
                pObject.Apellido,
                pObject.DNI,
            };
            dT.Rows.Add(dR);
            dCliente.EscribirCliente(dT);
        }

        public void Baja(BeCliente pObject)
        {
            DataTable dT = dCliente.LeerCliente();
            DataRow dR = dT.Rows.Find(pObject.Codigo);
            dR.Delete();
            dCliente.EscribirCliente(dT);
        }

        public List<BeCliente> Consulta()
        {
            DataTable dT = dCliente.LeerCliente();
            List<BeCliente> lCliente = new List<BeCliente>();
            foreach (DataRow item in dT.Rows)
            {
                BeCliente aux = new BeCliente(item.ItemArray);
                lCliente.Add(aux);
            }
            return lCliente;
        }

        public void Modificar(BeCliente pObject)
        {
            DataTable dT = dCliente.LeerCliente();
            DataRow dR = dT.Rows.Find(pObject.Codigo);
            dR.ItemArray = new object[]
            {
                pObject.Codigo,
                pObject.Nombre,
                pObject.Apellido,
                pObject.DNI,
            };
            dT.Rows.Add(dR);
            dCliente.EscribirCliente(dT);
        }
    }
}

using Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeCliente : ICodigo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public List<BeVehiculo> lVehiculo { get; set; }

        public BeCliente(object[] pObject)
        {
            Codigo = pObject[0].ToString();
            Nombre = pObject[1].ToString();
            Apellido = pObject[2].ToString();
            DNI = pObject[3].ToString();
        }
        public BeCliente(string pCodigo, string pNombre, string pApellido, string pDni)
        {
            Codigo = pCodigo; Nombre = pNombre; Apellido = pApellido; DNI = pDni; lVehiculo = new List<BeVehiculo>();
        }
    }
}

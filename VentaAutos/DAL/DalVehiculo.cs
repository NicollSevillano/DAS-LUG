using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalVehiculo
    {
        static string Path = "Vehiculo.xml";
        public DataTable LeerVehiculo()
        {
            DataTable aux = new DataTable("Vehiculo");
            if (File.Exists(Path))
            {
                aux.ReadXml(Path);
                aux.PrimaryKey = new DataColumn[] { aux.Columns[0] };
            }
            else
            {
                aux.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("IdVehiculo",typeof(string)),
                    new DataColumn("Patente", typeof(string)),
                    new DataColumn("Marca", typeof(string)),
                    new DataColumn("Modelo", typeof(string)),
                    new DataColumn("Año", typeof(string)),
                    new DataColumn("Precio", typeof(decimal)),
                    new DataColumn("Vendido",typeof(bool)),
                    new DataColumn("Tipo", typeof(string)),
                    new DataColumn("IdDueño", typeof(string))
                });
                aux.PrimaryKey = new DataColumn[] { aux.Columns[0] };
            }
            return aux;
        }
        public void EscribirVehiculo(DataTable pPath)
        {
            pPath.WriteXml(Path, XmlWriteMode.WriteSchema);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalCliente
    {
        static string Path = "Cliente.xml";
        public DataTable LeerCliente()
        {
            DataTable aux = new DataTable("Cliente");
            if (File.Exists(Path))
            {
                aux.ReadXml(Path);
                aux.PrimaryKey = new DataColumn[] { aux.Columns[0] };
            }
            else
            {
                aux.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("IdCliente", typeof(string)),
                    new DataColumn("Nombre", typeof(string)),
                    new DataColumn("Apellido", typeof(string)),
                    new DataColumn("DNI", typeof(string))
                });
                aux.PrimaryKey = new DataColumn[] { aux.Columns[0] };
            }
            return aux;
        }
        public void EscribirCliente(DataTable pPath)
        {
            pPath.WriteXml(Path, XmlWriteMode.WriteSchema);
        }
    }
}

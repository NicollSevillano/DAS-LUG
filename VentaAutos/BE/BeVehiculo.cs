using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz;

namespace BE
{
    public abstract class BeVehiculo : ICodigo
    {
        public string Codigo { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public decimal Precio { get; set; }
        public bool Vendido { get; set; }
        public BeCliente Cliente { get; set; }
        public BeVehiculo() { }
        public BeVehiculo(object[] pObject)
        {
            Codigo = pObject[0].ToString();
            Patente = pObject[1].ToString();
            Marca = pObject[2].ToString();
            Modelo = pObject[3].ToString();
            Año = pObject[4].ToString();
            Precio = decimal.Parse(pObject[5].ToString());
            Vendido = bool.Parse(pObject[6].ToString());
        }
        public BeVehiculo(string pCodigo, string pPatente, string pMarca, string pModelo, string pAño, decimal pPrecio, bool pVendido, BeCliente pCliente)
        {
            Codigo = pCodigo; Patente = pPatente; Marca = pMarca;
            Modelo = pModelo; Año = pAño; Precio = pPrecio;
            Vendido = pVendido; Cliente = pCliente;
        }
    }
}

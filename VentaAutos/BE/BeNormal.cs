﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeNormal : BeVehiculo
    {
        public BeNormal(object[] pObject) : base(pObject)
        {
        }

        public BeNormal(string pCodigo, string pPatente, string pMarca, string pModelo, string pAño, decimal pPrecio, bool pVendido, BeCliente pCliente) : base(pCodigo, pPatente, pMarca, pModelo, pAño, pPrecio, pVendido, pCliente)
        {
        }
    }
}

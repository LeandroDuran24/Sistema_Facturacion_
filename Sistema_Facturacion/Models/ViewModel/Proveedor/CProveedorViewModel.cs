using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Sistema_Facturacion.Models.Utilidades;

namespace Sistema_Facturacion.Models.ViewModel.Proveedor
{
    public class CProveedorViewModel :Proveedores
    {

        public List<Proveedores> proveedorList { get; set; } //lista para almcenar los usuarios
     
    }
}
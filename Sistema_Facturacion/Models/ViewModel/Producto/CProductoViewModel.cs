using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Sistema_Facturacion.Models.Utilidades;

namespace Sistema_Facturacion.Models.ViewModel.Producto
{
    public class CProductoViewModel :Productos
    {
        public List<Productos> productoList { get; set; } //lista para almcenar los productos

       
       
    }
}
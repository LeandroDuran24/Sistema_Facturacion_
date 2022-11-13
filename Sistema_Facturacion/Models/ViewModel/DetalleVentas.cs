
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models.ViewModel
{
    public class DetalleVentas
    {
        public int IdDetalleVentas { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public int Impuesto { get; set; }


        public DetalleVentas()
        {

        }
    }
}
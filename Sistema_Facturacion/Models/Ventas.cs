using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Ventas
    {
        
        public int IdVenta { get; set; }
        public int NoFactura { get; set; }
        [DisplayName("Fecha ")]
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string FormaPago { get; set; }
        public float SubTotal { get; set; }
        public float Descuento { get; set; }
        public float ImpuestoFactura { get; set; }
        public float Total { get; set; }
        public string EstadoFactura { get; set; }


        public Ventas()
        {
            IdVenta = 0;
            NoFactura = 0;
            FechaVenta = DateTime.Now;
            IdCliente = 0;
            IdUsuario = 0;
            FormaPago = "Efectivo";
            SubTotal = 0;
            Descuento = 0;
            ImpuestoFactura = 0;
            Total = 0;
            EstadoFactura = "";

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Inventario
    {
        [DisplayName("Id")]
        public int IdInventario { get; set; }

        [Required]
        [DisplayName("Producto")]
        public int IdProducto { get; set; }

        [Required]
        [DisplayName("Stock")]
        public int Cantidad { get; set; }

        [Required]
        [DisplayName("Stock Minimo")]
        public int Stock { get; set; }


        [Required]
        [DisplayName("Medida")]
        public string Medida { get; set; }

        [Required]
        [DisplayName("Precio Compra")]
        public double PrecioCompra { get; set; }

        [Required]
        [DisplayName("Precio Venta")]
        public double PrecioVenta { get; set; }


        public Inventario()
        {
            IdInventario = 0;
            IdProducto = 0;
            Cantidad = 0;
            Stock = 0;
            Medida = "";
            PrecioCompra = 0.0;
            PrecioVenta = 0.0;
        }


        public Inventario(int IdInventario)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Inventario where IdInventario=@IdInventario", new SqlConnection());
            dataAdapter.SelectCommand.Parameters.AddWithValue("@IdInventario", IdInventario);

            DataTable dt = ConexionDb.GetValuesInDataTable(dataAdapter);


            if (dt.Rows.Count > 0)
            {
                IdInventario = Convert.ToInt32(dt.Rows[0]["IdInventario"]);
                IdProducto = Convert.ToInt32(dt.Rows[0]["IdProducto"]);
                Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                Stock = Convert.ToInt32(dt.Rows[0]["Stock"]);
                Medida = Convert.ToString(dt.Rows[0]["Medida"]);
                PrecioCompra = Convert.ToDouble(dt.Rows[0]["PrecioCompra"]);
                PrecioVenta = Convert.ToDouble(dt.Rows[0]["PrecioVenta"]);
            }
            else
            {
                IdInventario = 0;
                IdProducto = 0;
                Cantidad = 0;
                Stock = 0;
                Medida = "";
                PrecioCompra = 0.0;
                PrecioVenta = 0.0;

            }

        }
    }
}
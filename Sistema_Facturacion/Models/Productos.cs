using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Facturacion.Models
{
    public class Productos
    {
        [DisplayName("Id Producto ")]
        public int IdProducto { get; set; }

        [DisplayName("Categoria Producto")]
        [Required(ErrorMessage = "Favor completar")]
        public int IdCategoriaProducto { get; set; }

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "Favor completar")]
        public int IdProveedor { get; set; }

        [Required]
        [DisplayName("Codigo Barra")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Favor completar")]
        public string Descripcion { get; set; }

    
        [DisplayName("Cantidad")]
        public int Stock { get; set; }

       
        [DisplayName("Stock Minimo")]
        public int StockMinimo { get; set; }

        
        [DisplayName("Medida")]
        public string Medida { get; set; }

        
        [DisplayName("Precio Compra")]
        public double PrecioCompra { get; set; }

        
        [DisplayName("Precio Venta")]
        public double PrecioVenta { get; set; }

       
        [DisplayName("Ganancia")]
        public double Utilidad { get; set; }

        [DisplayName("Calcular Impuesto ")]
        public bool TieneImpuesto { get; set; }

     


        public Productos()
        {
            IdProducto = 0;
            IdCategoriaProducto = 0;
            IdProveedor = 0;
            Codigo = "";
            Descripcion = "";
            Stock = 0;
            StockMinimo = 0;
            Medida = "";
            PrecioCompra = 0.0;
            PrecioVenta = 0.0;
            Utilidad = 0.0;
            TieneImpuesto = false;
         

        }


        public Productos(int IdProducto)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Productos where IdProducto=@IdProducto", new SqlConnection());
            dataAdapter.SelectCommand.Parameters.AddWithValue("@IdProducto", IdProducto);

            DataTable dt = ConexionDb.GetValuesInDataTable(dataAdapter);


            if (dt.Rows.Count > 0)
            {
                IdProducto = Convert.ToInt32(dt.Rows[0]["IdProducto"]);
                IdProveedor = Convert.ToInt32(dt.Rows[0]["IdProveedor"]);
                IdCategoriaProducto = Convert.ToInt32(dt.Rows[0]["IdCategoriaProducto"]);
                Codigo = Convert.ToString(dt.Rows[0]["Codigo"]);
                Descripcion = Convert.ToString(dt.Rows[0]["Descripcion"]);

                if (dt.Rows[0]["Stock"] != DBNull.Value)
                    Stock = Convert.ToInt32(dt.Rows[0]["Stock"]);
                if (dt.Rows[0]["StockMinimo"] != DBNull.Value)
                    StockMinimo = Convert.ToInt32(dt.Rows[0]["StockMinimo"]);
                if (dt.Rows[0]["Medida"] != DBNull.Value)
                    Medida = Convert.ToString(dt.Rows[0]["Medida"]);
                if (dt.Rows[0]["PrecioCompra"] != DBNull.Value)
                    PrecioCompra = Convert.ToDouble(dt.Rows[0]["PrecioCompra"]);
                if (dt.Rows[0]["PrecioVenta"] != DBNull.Value)
                    PrecioVenta = Convert.ToDouble(dt.Rows[0]["PrecioVenta"]);
                if (dt.Rows[0]["Utilidad"] != DBNull.Value)
                    Utilidad = Convert.ToDouble(dt.Rows[0]["Utilidad"]);
                TieneImpuesto = Convert.ToBoolean(dt.Rows[0]["TieneImpuesto"]);
               

            }
            else
            {
                IdProducto = 0;
                IdCategoriaProducto = 0;
                IdProveedor = 0;
                Codigo = "";
                Descripcion = "";
                Stock = 0;
                StockMinimo = 0;
                Medida = "";
                PrecioCompra = 0.0;
                PrecioVenta = 0.0;
                Utilidad = 0.0;
                TieneImpuesto = false;


            }

        }


    }
}
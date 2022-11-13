using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace Sistema_Facturacion.Models.ViewModel.Producto
{
    public class MInventarioViewModel : Productos
    {
        [Required]
        [DisplayName("Producto")]
        public string Producto { get; set; }
        public List<Productos> productoList { get; set; }


        public MInventarioViewModel()
        {
            productoList = GetProductos();
        }


        public MInventarioViewModel(int IdProducto) : base(IdProducto)
        {

            if (IdProducto > 0)
            {
                List<Productos> lista = new List<Productos>();
                lista = GetProductos("where IdProducto=" + (Convert.ToString(IdProducto))).ToList<Productos>();
                foreach (var item in lista)
                {
                    Producto = item.Descripcion;
                }

            }

            productoList = GetProductos();


        }

        public static List<Productos> GetProductos(string condicionBusqueda = "")
        {
            List<Productos> producto = new List<Productos>();

            string qwery = "SELECT IdProducto,Descripcion FROM [Productos] " + condicionBusqueda;



            DataTable dtProducto = Busqueda(qwery);
            producto = (from row in dtProducto.AsEnumerable()
                        select ConvertRowToProducto(row)).ToList();

            return producto;
        }

        public static Productos ConvertRowToProducto(DataRow row)
        {
            try
            {
                if (row == null)
                    return new Productos();

                Productos producto = new Productos
                {
                    IdProducto = Convert.ToInt32(row["IdProducto"] ?? 0),
                    Descripcion = row["Descripcion"].ToString() ?? "--",

                };

                return producto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable Busqueda(string Query)
        {
            return Sistema_Facturacion.Models.ConexionDb.GetValuesInDataTable(Query, 0);

        }


    }
}
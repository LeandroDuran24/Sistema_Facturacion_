using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace Sistema_Facturacion.Models.ViewModel.Facturacion
{
    public class MFacturacionViewModel : Ventas
    {
        [Required]
        [DisplayName("Cliente")]
        public string Cliente { get; set; }
        public List<Clientes> clienteList { get; set; }

        [Required]
        [DisplayName("Productos")]
        public string Productos { get; set; }
        public List<Productos> productoList { get; set; }


        public MFacturacionViewModel()
        {
            clienteList = GetClientes();
            productoList = GetProductos();
        }



        public static List<Clientes> GetClientes(string condicionBusqueda = "")
        {
            List<Clientes> cliente = new List<Clientes>();

            string qwery = "SELECT IdCliente,Nombre,Apellidos,Cedula,Direccion FROM [Clientes] " + condicionBusqueda;



            DataTable dtClientes = Busqueda(qwery);
            cliente = (from row in dtClientes.AsEnumerable()
                       select ConvertRowToClientes(row)).ToList();

            return cliente;
        }

        public static List<Productos> GetProductos(string condicionBusqueda = "")
        {
            List<Productos> producto = new List<Productos>();

            string qwery = "SELECT IdProducto,Codigo,Descripcion,Stock,Medida,PrecioVenta,TieneImpuesto FROM [Productos] " + condicionBusqueda;



            DataTable dtProductos = Busqueda(qwery);
            producto = (from row in dtProductos.AsEnumerable()
                        select ConvertRowToProductos(row)).ToList();

            return producto;
        }

        public static Clientes ConvertRowToClientes(DataRow row)
        {
            try
            {
                if (row == null)
                    return new Clientes();

                Clientes cliente = new Clientes
                {
                    IdCliente = Convert.ToInt32(row["IdCliente"] ?? 0),
                    Nombre = row["Nombre"].ToString() ?? "--",
                    Apellidos = row["Apellidos"].ToString() ?? "--",
                    Cedula = row["Cedula"].ToString() ?? "--",
                    Direccion = row["Direccion"].ToString() ?? "--",
                    

                };

                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Productos ConvertRowToProductos(DataRow row)
        {
            try
            {
                if (row == null)
                    return new Productos();

                Productos producto = new Productos
                {
                    IdProducto = Convert.ToInt32(row["IdProducto"] ?? 0),
                    Codigo = Convert.ToString(row["Codigo"] ?? "-"),
                    Descripcion = row["Descripcion"].ToString() ?? "--",
                    Stock = Convert.ToInt32(row["Stock"] ?? 0),
                    Medida = row["Medida"].ToString() ?? "--",
                    PrecioVenta = Convert.ToDouble(row["PrecioVenta"] ?? 0.0),
                    TieneImpuesto = Convert.ToBoolean(row["TieneImpuesto"]),

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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Facturacion.Models.ViewModel.Producto
{
    public class MProductoViewModel : Productos
    {

        [Required]
        [DisplayName("Categoria Producto")]
        public string Categoria { get; set; }
        public List<CategoriaProductos> categoriaList { get; set; }


        [Required]
        [DisplayName("Razon Social")]      
        public string RazonSocial { get; set; }
        [DisplayName("Representante")]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public List<Proveedores> proveedorList { get; set; }

        public MProductoViewModel()
        {
           
            proveedorList = GetProveedores();
            categoriaList = GetCategoria();

        }

        public MProductoViewModel(int IdProducto) :base(IdProducto)
        {
            if (IdCategoriaProducto > 0)
            {
                List<CategoriaProductos> lista = new List<CategoriaProductos>();
                  lista = GetCategoria("where IdCategoria="+(Convert.ToString(IdCategoriaProducto))).ToList<CategoriaProductos>();
                foreach (var item in lista)
                {
                    Categoria = item.Categoria;
                }
                
            }

            if (IdProveedor > 0)
            {
                List<Proveedores> lista = new List<Proveedores>();
                lista = GetProveedores("where IdProveedor=" + (Convert.ToString(IdProveedor))).ToList<Proveedores>();
                foreach (var item in lista)
                {
                    RazonSocial = item.RazonSocial;
                }

            }


            proveedorList = GetProveedores();
            categoriaList = GetCategoria("");
           
        }


        public static List<Proveedores> GetProveedores(string condicionBusqueda = "")
        {
            List<Proveedores> proveedores = new List<Proveedores>();

            string qwery = "SELECT IdProveedor,RazonSocial FROM [Proveedores]"+condicionBusqueda;

          

            DataTable dtProveedores = Busqueda(qwery);
            proveedores = (from row in dtProveedores.AsEnumerable()
                           select ConvertRowToProveedores(row)).ToList();

            return proveedores;
        }



        public static List<CategoriaProductos> GetCategoria(string condicionBusqueda = "")
        {
            List<CategoriaProductos> categoria = new List<CategoriaProductos>();

            string qwery = "SELECT IdCategoria,Nombre,Descripcion FROM [CategoriaProductos] "+condicionBusqueda;

            //if (condicionBusqueda !="")
            //    qwery += condicionBusqueda;

            DataTable dtCategoria = Busqueda(qwery);
            categoria = (from row in dtCategoria.AsEnumerable()
                           select ConvertRowToCategoria(row)).ToList();

            return categoria;
        }

        public static Proveedores ConvertRowToProveedores(DataRow row)
        {
            try
            {
                if (row == null)
                    return new Proveedores();

                Proveedores proveedor = new Proveedores
                {
                    IdProveedor = Convert.ToInt32(row["IdProveedor"] ?? 0),
                    RazonSocial = row["RazonSocial"].ToString() ?? "--",
                   
                };

                return proveedor;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public static CategoriaProductos ConvertRowToCategoria(DataRow row)
        {
            try
            {
                if (row == null)
                    return new CategoriaProductos();

                CategoriaProductos categoria = new CategoriaProductos
                {
                    IdCategoria = Convert.ToInt32(row["IdCategoria"] ?? 0),
                    Categoria= row["Nombre"].ToString() ??"--",
                    Descripcion = row["Descripcion"].ToString() ?? "--",

                };

                return categoria;
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
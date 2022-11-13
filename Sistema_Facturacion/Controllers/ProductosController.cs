using Sistema_Facturacion.Models;
using Sistema_Facturacion.Models.ViewModel.Producto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace Sistema_Facturacion.Controllers
{
    public class ProductosController : Controller
    {
        ConexionDb conexion = new ConexionDb();
        SqlCommand cmd = new SqlCommand();



        public ActionResult MProducto()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult MProducto(int IdCategoria, int IdProveedor, string Descripcion,string Codigo, bool Impuesto)
        {
            try
            {
                Productos producto = new Productos();
                producto.IdCategoriaProducto = IdCategoria;
                producto.IdProveedor = IdProveedor;
                producto.Descripcion = Descripcion;
                producto.Codigo = Codigo;
                producto.TieneImpuesto = Impuesto;
                if (ModelState.IsValid)
                {

                    GuardarProducto(producto);
                    return RedirectToAction("MProducto");
                }


                return View();

            }
            catch (Exception e)
            {
                return View();
            }
        }



        public ActionResult Inventario()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Inventario(List<Productos> inventario)
        {
            try
            {


                Productos inventarioProductos = new Productos();

                foreach (var producto in inventario)
                {
                    inventarioProductos.IdProducto = producto.IdProducto;
                    inventarioProductos.Stock = producto.Stock;
                    inventarioProductos.StockMinimo = producto.StockMinimo;
                    inventarioProductos.Medida = producto.Medida;
                    inventarioProductos.PrecioCompra = producto.PrecioCompra;
                    inventarioProductos.PrecioVenta = producto.PrecioVenta;
                }

                    GuardarInventario(inventarioProductos);
                    return RedirectToAction("Inventario");
                            

            }
            catch (Exception e)
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult CInventario()
        {
            try

            {
                CProductoViewModel viewModel = new CProductoViewModel();

                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdProducto,IdCategoriaProducto,IdProveedor,Codigo,Descripcion,Stock,StockMinimo,Medida,PrecioCompra,PrecioVenta,Utilidad,TieneImpuesto FROM Productos Where Estatus='A' "), new SqlConnection());

                DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

                viewModel.productoList = (from row in dataTable.AsEnumerable()
                                          select ConvertProductosRow(row)).ToList();

                return View(viewModel);
            }
            catch (Exception e)
            {

                return View();
            }

        }




        public ActionResult Editar(int IdProducto)
        {
            MProductoViewModel producto = new MProductoViewModel(IdProducto);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(MProductoViewModel producto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GuardarProducto(producto);
                    return RedirectToAction("CProductos");
                }


                return View();


            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult CProductos()
        {
            try

            {
                CProductoViewModel viewModel = new CProductoViewModel();

                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdProducto,IdCategoriaProducto,IdProveedor,Codigo,Descripcion,Stock,StockMinimo,Medida,PrecioCompra,PrecioVenta,Utilidad,TieneImpuesto FROM Productos Where Estatus='A' "), new SqlConnection());

                DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

                viewModel.productoList = (from row in dataTable.AsEnumerable()
                                           select ConvertProductosRow(row)).ToList();

                return View(viewModel);
            }
            catch (Exception e)
            {

                return View();
            }

        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CProductosInventario(int idProducto)
        {


            List<Productos> producto = new List<Productos>();
      
                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdProducto,IdCategoriaProducto,IdProveedor,Codigo,Descripcion,Stock,StockMinimo,Medida,PrecioCompra,PrecioVenta,Utilidad,TieneImpuesto FROM Productos Where Estatus='A' and IdProducto =@idProducto "), new SqlConnection());
                adapter.SelectCommand.Parameters.AddWithValue("@idProducto",  idProducto );


                DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);
                producto= (from row in dataTable.AsEnumerable()
                                          select ConvertProductosRow(row)).ToList();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string resultadoJson = jss.Serialize(producto);

                return resultadoJson;
           

        }




        public void Eliminar(int IdProducto)
        {
            try
            {
                // TODO: Add insert logic here
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarProducto";
                cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        #region METODOS 

        public void GuardarProducto(Productos productos)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarProductos";
            cmd.Parameters.AddWithValue("@Parametro", productos.IdProducto);
            cmd.Parameters.AddWithValue("@IdCategoriaProducto", productos.IdCategoriaProducto);
            cmd.Parameters.AddWithValue("@IdProveedor", productos.IdProveedor);
            cmd.Parameters.AddWithValue("@Codigo", productos.Codigo);
            cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
            cmd.Parameters.AddWithValue("@TieneImpuesto", productos.TieneImpuesto);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.CerrarConexion();

        }



        public void GuardarInventario(Productos productos)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarInventario";
            cmd.Parameters.AddWithValue("@Parametro", productos.IdProducto);          
            cmd.Parameters.AddWithValue("@Stock", productos.Stock);
            cmd.Parameters.AddWithValue("@StockMinimo", productos.StockMinimo);
            cmd.Parameters.AddWithValue("@Medida", productos.Medida);
            cmd.Parameters.AddWithValue("@PrecioCompra", productos.PrecioCompra);
            cmd.Parameters.AddWithValue("@PrecioVenta", productos.PrecioVenta);
            cmd.Parameters.AddWithValue("@Utilidad", productos.Utilidad);
            cmd.Parameters.AddWithValue("@TieneImpuesto", productos.TieneImpuesto);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.CerrarConexion();

        }



        //convierte cada usuario en una fila.
        public static Productos ConvertProductosRow(DataRow dr)
        {
            if (dr == null)
                return new Productos();

            Productos producto = new Productos();
          
            producto.IdProducto = Convert.ToInt32(dr["IdProducto"] ?? 0);
            producto.IdProveedor = Convert.ToInt32(dr["IdProveedor"] ?? 0);
            producto.IdCategoriaProducto = Convert.ToInt32(dr["IdCategoriaProducto"] ?? 0);
            producto.Codigo = Convert.ToString(dr["Codigo"] ?? 0);
            producto.Descripcion = Convert.ToString(dr["Descripcion"] ?? 0);

            if (dr["Stock"] != DBNull.Value)
                producto.Stock = Convert.ToInt32(dr["Stock"] ??0);
            if (dr["StockMinimo"] != DBNull.Value)
                producto.StockMinimo = Convert.ToInt32(dr["StockMinimo"] ?? "");
            if (dr["Medida"] != DBNull.Value)
                producto.Medida = Convert.ToString(dr["Medida"] ?? "");
            if (dr["PrecioCompra"] != DBNull.Value)
                producto.PrecioCompra = Convert.ToDouble(dr["PrecioCompra"] ?? "");
            if (dr["PrecioVenta"] != DBNull.Value)
                producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"] ?? "");
            if (dr["Utilidad"] != DBNull.Value)
                producto.Utilidad = Convert.ToDouble(dr["Utilidad"] ?? "");
            producto.TieneImpuesto = Convert.ToBoolean(dr["TieneImpuesto"] ?? 0);
          

            return producto;

        }


        #endregion
    }
}

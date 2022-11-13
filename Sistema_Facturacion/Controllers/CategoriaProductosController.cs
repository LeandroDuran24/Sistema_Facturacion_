using Sistema_Facturacion.Models;
using Sistema_Facturacion.Models.ViewModel.CategoriaProducto;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Sistema_Facturacion.Controllers
{
    public class CategoriaProductosController : Controller
    {

        ConexionDb conexion = new ConexionDb();
        SqlCommand cmd = new SqlCommand();
        [HttpGet]
        public ActionResult MCategoriaProducto()
        {

            return View();
        }

        [HttpPost]
        public ActionResult MCategoriaProducto(string Categoria, string Descripcion)
        {
            try
            {
                CategoriaProductos categoria = new CategoriaProductos();
                categoria.Descripcion = Descripcion;
                categoria.Categoria = Categoria;
                if (ModelState.IsValid)
                {
                    GuardarCategoria(categoria);

                    return View("MCategoriaProducto");
                }

                return View(categoria);

            }
            catch (Exception e)
            {
                throw;
                //return View();
            }
        }


        public ActionResult Editar(int IdCategoria)
        {
            CategoriaProductos categoria = new CategoriaProductos(IdCategoria);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Editar(int Id,string Categoria, string Descripcion)
        {
            try
            {
                CategoriaProductos categoria = new CategoriaProductos();
                categoria.IdCategoria = Id;
                categoria.Descripcion = Descripcion;
                categoria.Categoria = Categoria;
                if (ModelState.IsValid)
                {
                    GuardarCategoria(categoria);

                    return View("MCategoriaProducto");
                }


                return View();


            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult CCategoriaProductos()
        {

            try
            {
                CCategoriaProductoViewModel viewModel = new CCategoriaProductoViewModel();


                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdCategoria,Nombre,Descripcion FROM CategoriaProductos where Estatus='A' "), new SqlConnection());

                DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

                viewModel.categoriaList = (from row in dataTable.AsEnumerable()
                                           select ConvertCategoriaRow(row)).ToList();

                return View(viewModel);
            }
            catch (Exception e)
            {

                return View();
            }

        }


        [HttpPost]
        public bool Eliminar(int IdCategoria)
        {
            try
            {
                // TODO: Add insert logic here
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarCategoriaProductos";
                cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conexion.CerrarConexion();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }



        #region METODOS 

        public void GuardarCategoria(CategoriaProductos categoria)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarCategoriaProductos";
            cmd.Parameters.AddWithValue("@Parametro", categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@Categoria", categoria.Categoria);
            cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.CerrarConexion();

        }


        //convierte cada usuario en una fila.
        public static CategoriaProductos ConvertCategoriaRow(DataRow dr)
        {
            if (dr == null)
                return new CategoriaProductos();

            CategoriaProductos categoria = new CategoriaProductos();

            categoria.IdCategoria = Convert.ToInt32(dr["IdCategoria"] ?? 0);
            categoria.Categoria = Convert.ToString(dr["Nombre"] ?? "");
            categoria.Descripcion = Convert.ToString(dr["Descripcion"] ?? 0);


            return categoria;

        }


        #endregion


    }
}

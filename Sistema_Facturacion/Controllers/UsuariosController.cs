using Sistema_Facturacion.Models;
using Sistema_Facturacion.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Facturacion.Controllers
{
    public class UsuariosController : Controller
    {

        ConexionDb conexion = new ConexionDb();
        SqlCommand cmd = new SqlCommand();


        // GET: Usuarios
        public ActionResult MUsuario()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult MUsuario(Usuarios usuario)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    cmd.Connection = conexion.AbrirConexion();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertarUsuario";
                    cmd.Parameters.AddWithValue("@Parametro", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    cmd.Parameters.AddWithValue("@Clave", usuario.Clave);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conexion.CerrarConexion();
                    return RedirectToAction("Index");
                }

                return View();

            }
            catch
            {
                return View();
            }
        }


        public ActionResult Editar(int IdUsuario)
        {
            LoginViewModel viewModel = new LoginViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Editar(Usuarios usuario)
        {
            try
            {

                if(ModelState.IsValid)
                {
                    cmd.Connection = conexion.AbrirConexion();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertarUsuario";
                    cmd.Parameters.AddWithValue("@Parametro", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    cmd.Parameters.AddWithValue("@Clave", usuario.Clave);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conexion.CerrarConexion();

                    return RedirectToAction("CUsuarios");
                }


                return View();
               

            }
            catch (Exception)
            {

                return View();
            }
        }


        public ActionResult CUsuario()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdUsuario,Nombre,Apellidos,Usuario,Clave FROM Usuarios WHERE {0} like @StringBusqueda;", CUsuarioViewModel.CriterioBusqueda), new SqlConnection());
            adapter.SelectCommand.Parameters.AddWithValue("@stringBusqueda", "%" + CUsuarioViewModel.stringBusqueda + "%");

            DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

            CUsuarioViewModel.usuario = (from row in dataTable.AsEnumerable()
                                         select ConvertUserRow(row)).ToList();

            return View(CUsuarioViewModel.usuario);

        }

        [HttpPost]
        public ActionResult CUsuario(CUsuarioViewModel usuario)
        {
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdUsuario,Nombre,Apellidos,Usuario,Clave FROM Usuarios WHERE {0} like @StringBusqueda;", CUsuarioViewModel.CriterioBusqueda), new SqlConnection());
                adapter.SelectCommand.Parameters.AddWithValue("@stringBusqueda", "%" + CUsuarioViewModel.stringBusqueda + "%");

                DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

                CUsuarioViewModel.usuario = (from row in dataTable.AsEnumerable()
                                             select ConvertUserRow(row)).ToList();

                return View(CUsuarioViewModel.usuario);
            }
            catch (Exception)
            {

                return View();
            }
        }


        public ActionResult Delete(int IdUsuario)
        {
            try
            {
                // TODO: Add insert logic here

                Usuarios usuario = new Usuarios { IdUsuario = IdUsuario };

                    cmd.Connection = conexion.AbrirConexion();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EliminarUsuario";
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conexion.CerrarConexion();
                    return RedirectToAction("CUsuarios");
                
            }
            catch
            {
                return View("Error");
            }
        }



        #region metodos utiles
        //convierte cada usuario en una fila.
        public static Usuarios ConvertUserRow(DataRow dr)
        {
            if (dr == null)
                return new Usuarios();

            Usuarios usuario = new Usuarios();


            usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"] ?? 0);
            usuario.Nombre = Convert.ToString(dr["Nombre"] ?? 0);
            usuario.Apellidos = Convert.ToString(dr["Apellidos"] ?? 0);
            usuario.Usuario = Convert.ToString(dr["Usuario"] ?? "");
            usuario.Clave = Convert.ToString(dr["Clave"] ?? 0);


            return usuario;

        }
        #endregion



    }
}

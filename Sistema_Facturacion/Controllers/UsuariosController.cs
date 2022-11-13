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


      
        public ActionResult MUsuario()
        {
            MUsuarioViewModel user = new MUsuarioViewModel();
            return View(user);
        }

       
        [HttpPost]
        public ActionResult MUsuario(MUsuarioViewModel user)
        {
            try
            {
                if(ModelState.IsValid)
                {

                    user.IdTipoUsuario = user.idTipoUsuarioSelected;
                    GuardarUsuario(user);
                    return RedirectToAction("MUsuario");
                }
               

                return View();

            }
            catch (Exception e)
            {
                return View();
            }
        }


        public ActionResult Editar(int IdUsuario)
        {
            MUsuarioViewModel user = new MUsuarioViewModel(IdUsuario);
            return View(user);
        }

        [HttpPost]
        public ActionResult Editar(MUsuarioViewModel user)
        {
            try
            {

                if(ModelState.IsValid)
                {
                    GuardarUsuario(user);
                    return RedirectToAction("CUsuarios");
                }


                return View();
               

            }
            catch (Exception)
            {

                return View();
            }
        }


        public ActionResult CUsuarios()
        {
            CUsuarioViewModel viewModel = new CUsuarioViewModel();

            SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdUsuario,IdTipoUsuario,Nombre,Apellidos,Usuario,Clave FROM Usuarios Where Estatus='A'"), new SqlConnection());
           
            DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

            viewModel.usuarioList = (from row in dataTable.AsEnumerable()
                                         select ConvertUserRow(row)).ToList();

            return View(viewModel);

        }

       


        public void Eliminar(int IdUsuario)
        {
            try
            {
                // TODO: Add insert logic here
                    cmd.Connection = conexion.AbrirConexion();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EliminarUsuario";
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    conexion.CerrarConexion();
                  
            }
            catch (Exception e)
            {
                throw e; 
            }
        }



        #region metodos utiles

        public void GuardarUsuario(Usuarios user)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarUsuario";
            cmd.Parameters.AddWithValue("@Parametro", user.IdUsuario);
            cmd.Parameters.AddWithValue("@IdTipoUsuario", user.IdTipoUsuario);
            cmd.Parameters.AddWithValue("@Nombre", user.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", user.Apellidos);
            cmd.Parameters.AddWithValue("@Usuario", user.Usuario);
            cmd.Parameters.AddWithValue("@Clave", user.Clave);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.CerrarConexion();
        }



        //convierte cada usuario en una fila.
        public static Usuarios ConvertUserRow(DataRow dr)
        {
            if (dr == null)
                return new Usuarios();

            Usuarios usuario = new Usuarios();


            usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"] ?? 0);
            usuario.IdTipoUsuario = Convert.ToInt32(dr["IdTipoUsuario"] ?? 0);
            usuario.Nombre = Convert.ToString(dr["Nombre"] ?? 0);
            usuario.Apellidos = Convert.ToString(dr["Apellidos"] ?? 0);
            usuario.Usuario = Convert.ToString(dr["Usuario"] ?? "");
            usuario.Clave = Convert.ToString(dr["Clave"] ?? 0);


            return usuario;

        }
        #endregion



    }
}

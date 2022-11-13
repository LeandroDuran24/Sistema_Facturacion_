using Sistema_Facturacion.Models;
using Sistema_Facturacion.Models.ViewModel.Representante;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Facturacion.Controllers
{
    public class RepresentantesController : Controller
    {
        ConexionDb conexion = new ConexionDb();
        SqlCommand cmd = new SqlCommand();



        public ActionResult MRepresentante()
        {
            return View();
        }


        [HttpPost]
        public ActionResult MRepresentante(Representantes representantes)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    GuardarRepresentante(representantes);
                    return RedirectToAction("MRepresentante");
                }


                return View();

            }
            catch (Exception e)
            {
                return View();
            }
        }


        public ActionResult Editar(int IdRepresentante)
        {
            Representantes representantes = new Representantes(IdRepresentante);
            return View(representantes);
        }

        [HttpPost]
        public ActionResult Editar(Representantes representantes)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GuardarRepresentante(representantes);
                    return RedirectToAction("CRepresentantes");
                }


                return View();


            }
            catch (Exception)
            {

                return View();
            }
        }


        public ActionResult CRepresentantes()
        {
            CRepresentantesViewModel viewModel = new CRepresentantesViewModel();

            SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdRepresentante,Nombre,Apellidos,Cedula,Direccion,Celular,Email FROM Representantes where Estatus='A'"), new SqlConnection());

            DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

            viewModel.representanteList = (from row in dataTable.AsEnumerable()
                                     select ConvertRepresentanteRow(row)).ToList();

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult CRepresentantes(CRepresentantesViewModel viewModel)
        {
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdRepresentante,Nombre,Apellidos,Cedula,Direccion,Celular,Email FROM Representantes Where Estatus='A'"), new SqlConnection());


                DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

                viewModel.representanteList = (from row in dataTable.AsEnumerable()
                                         select ConvertRepresentanteRow(row)).ToList();

                return View(viewModel);
            }
            catch (Exception)
            {

                return View();
            }
        }


        public void Eliminar(int IdRepresentante)
        {
            try
            {
                // TODO: Add insert logic here
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarRepresentante";
                cmd.Parameters.AddWithValue("@IdRepresentante", IdRepresentante);
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

        public void GuardarRepresentante(Representantes representantes)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarRepresentante";
            cmd.Parameters.AddWithValue("@Parametro", representantes.IdRepresentante);
            cmd.Parameters.AddWithValue("@Nombre", representantes.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", representantes.Apellidos);
            cmd.Parameters.AddWithValue("@Cedula", representantes.Cedula);
            cmd.Parameters.AddWithValue("@Direccion", representantes.Direccion);
            cmd.Parameters.AddWithValue("@Celular", representantes.Celular);
            cmd.Parameters.AddWithValue("@Email", representantes.Email);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.CerrarConexion();

        }


        //convierte cada usuario en una fila.
        public static Representantes ConvertRepresentanteRow(DataRow dr)
        {
            if (dr == null)
                return new Representantes();

            Representantes representantes = new Representantes();


            representantes.IdRepresentante = Convert.ToInt32(dr["IdRepresentante"] ?? 0);
            representantes.Nombre = Convert.ToString(dr["Nombre"] ?? 0);
            representantes.Apellidos = Convert.ToString(dr["Apellidos"] ?? 0);
            representantes.Cedula = Convert.ToString(dr["Cedula"] ?? 0);
            representantes.Direccion = Convert.ToString(dr["Direccion"] ?? "");
            representantes.Email = Convert.ToString(dr["Email"] ?? 0);
            representantes.Celular = Convert.ToString(dr["Celular"] ?? 0);


            return representantes;

        }


        #endregion

    }
}
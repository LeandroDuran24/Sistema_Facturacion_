using Sistema_Facturacion.Models;
using Sistema_Facturacion.Models.ViewModel.Proveedor;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Sistema_Facturacion.Controllers
{
    public class ProveedoresController : Controller
    {
        ConexionDb conexion = new ConexionDb();
        SqlCommand cmd = new SqlCommand();



        public ActionResult MProveedor()
        {

            return View();
        }


        [HttpPost]
        public ActionResult MProveedor(Proveedores proveedor)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    GuardarProveedor(proveedor);
                    return RedirectToAction("MProveedor");
                }


                return View();

            }
            catch (Exception e)
            {
                return View();
            }
        }


        public ActionResult Editar(int IdProveedor)
        {
            MProveedorViewModel proveedor = new MProveedorViewModel(IdProveedor);
            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Editar(Proveedores provedor)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    GuardarProveedor(provedor);
                    return RedirectToAction("CProveedores");
                }


                return View();


            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult CProveedores()
        {
            try

            {
                CProveedorViewModel viewModel = new CProveedorViewModel();

                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdProveedor,IdRepresentante,RazonSocial,Direccion,Telefono,Email FROM Proveedores Where Estatus='A' "), new SqlConnection());

                DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

                viewModel.proveedorList = (from row in dataTable.AsEnumerable()
                                           select ConvertProveedoresRow(row)).ToList();

                return View(viewModel);
            }
            catch (Exception e)
            {

                return View();
            }

        }



        public void Eliminar(int IdProveedor)
        {
            try
            {
                // TODO: Add insert logic here
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarProveedor";
                cmd.Parameters.AddWithValue("@IdProveedor", IdProveedor);
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

        public void GuardarProveedor(Proveedores proveedor)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarProveedor";
            cmd.Parameters.AddWithValue("@Parametro", proveedor.IdProveedor);
            cmd.Parameters.AddWithValue("@IdRepresentante", proveedor.IdRepresentante);
            cmd.Parameters.AddWithValue("@RazonSocial", proveedor.RazonSocial);
            cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
            cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
            cmd.Parameters.AddWithValue("@Email", proveedor.Email);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.CerrarConexion();

        }


        //convierte cada usuario en una fila.
        public static Proveedores ConvertProveedoresRow(DataRow dr)
        {
            if (dr == null)
                return new Proveedores();

            Proveedores proveedor = new Proveedores();

            proveedor.IdProveedor = Convert.ToInt32(dr["IdProveedor"] ?? 0);
            if (dr["IdRepresentante"] != DBNull.Value)
                proveedor.IdRepresentante = Convert.ToInt32(dr["IdRepresentante"] ?? 0);
            proveedor.RazonSocial = Convert.ToString(dr["RazonSocial"] ?? 0);
            proveedor.Direccion = Convert.ToString(dr["Direccion"] ?? 0);
            proveedor.Telefono = Convert.ToString(dr["Telefono"] ?? 0);
            proveedor.Email = Convert.ToString(dr["Email"] ?? "");

            return proveedor;

        }


        #endregion
    }
}

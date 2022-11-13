using Sistema_Facturacion.Models;
using Sistema_Facturacion.Models.ViewModel.Cliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Facturacion.Controllers
{
    public class ClientesController : Controller
    {

        ConexionDb conexion = new ConexionDb();
        SqlCommand cmd = new SqlCommand();


        
        public ActionResult MCliente()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult MCliente(string Nombre,string Apellidos, string Cedula, string Direccion, string Telefono, string Celular)
        {
            try
            {

                Clientes cliente = new Clientes();
                cliente.Nombre = Nombre;
                cliente.Apellidos = Apellidos;
                cliente.Cedula = Cedula;
                cliente.Direccion = Direccion;
                cliente.Telefono = Telefono;
                cliente.Celular = Celular;
                if (ModelState.IsValid)
                {                 
                    GuardarCliente(cliente);
                    return View("MCliente");
                }


                return View();

            }
            catch (Exception e)
            {
               throw;
            }
        }


        public ActionResult Editar(int IdCliente)
        {
            Clientes cliente = new Clientes(IdCliente);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(int Id,string Nombre, string Apellidos, string Cedula, string Direccion, string Telefono, string Celular)
        {
            try
            {

                Clientes cliente = new Clientes();
                cliente.IdCliente = Id;
                cliente.Nombre = Nombre;
                cliente.Apellidos = Apellidos;
                cliente.Cedula = Cedula;
                cliente.Direccion = Direccion;
                cliente.Telefono = Telefono;
                cliente.Celular = Celular;
                if (ModelState.IsValid)
                {
                    GuardarCliente(cliente);
                    return View("MCliente");
                }


                return View();

            }
            catch (Exception e)
            {
                return View();
            }
        }



        public ActionResult CClientes()
        {
            CClienteViewModel viewModel = new CClienteViewModel();

            SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdCliente,Nombre,Apellidos,Cedula,Direccion,Telefono,Celular FROM Clientes WHERE Estatus='A'"), new SqlConnection());
         
            DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

            viewModel.clienteList = (from row in dataTable.AsEnumerable()
                                     select ConvertClientRow(row)).ToList();

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult CClientes(CClienteViewModel viewModel)
        {
            try
            {

               

                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT IdCliente,Nombre,Apellidos,Cedula,Direccion,Telefono,Celular FROM Clientes Where Estatus='A'"), new SqlConnection());
          

                DataTable dataTable = ConexionDb.GetValuesInDataTable(adapter);

                viewModel.clienteList = (from row in dataTable.AsEnumerable()
                                         select ConvertClientRow(row)).ToList();
                
                return View(viewModel);
            }
            catch (Exception)
            {

                return View();
            }
        }


        public bool Eliminar(int IdCliente)
        {
            try
            {
                // TODO: Add insert logic here
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarCliente";
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
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

        public void GuardarCliente(Clientes cliente)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarCliente";
            cmd.Parameters.AddWithValue("@Parametro", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
            cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
            cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
            cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@Celular", cliente.Celular);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.CerrarConexion();

        }


        //convierte cada usuario en una fila.
        public static Clientes ConvertClientRow(DataRow dr)
        {
            if (dr == null)
                return new Clientes();

            Clientes cliente = new Clientes();


            cliente.IdCliente = Convert.ToInt32(dr["IdCliente"] ?? 0);
            cliente.Nombre = Convert.ToString(dr["Nombre"] ?? 0);
            cliente.Apellidos = Convert.ToString(dr["Apellidos"] ?? 0);
            cliente.Cedula = Convert.ToString(dr["Cedula"] ?? 0);
            cliente.Direccion = Convert.ToString(dr["Direccion"] ?? "");
            cliente.Telefono = Convert.ToString(dr["Telefono"] ?? 0);
            cliente.Celular = Convert.ToString(dr["Celular"] ?? 0);


            return cliente;

        }


        #endregion

    }
}

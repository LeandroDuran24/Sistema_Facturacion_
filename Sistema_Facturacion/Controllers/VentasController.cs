using Sistema_Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Facturacion.Controllers
{
    public class VentasController : Controller
    {
        ConexionDb conexion = new ConexionDb();
        SqlCommand cmd = new SqlCommand();



        // GET: Ventas
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ventas/Create
        public ActionResult Facturacion()
        {
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        public ActionResult Facturacion(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ventas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

        [HttpPost]
        public ActionResult Facturar(List<Ventas> factura, List<DetalleVentas> productos, float SubTotal=0, float Descuento=0, float Total=0)
        {
            try
            {


                Ventas ventaFactura = new Ventas();
                DetalleVentas detalle = new DetalleVentas();

                foreach (var array in factura)
                {
                    ventaFactura.IdCliente = array.IdCliente;
                    ventaFactura.IdUsuario = array.IdUsuario;
                    ventaFactura.FechaVenta = DateTime.Now;
                    ventaFactura.FormaPago = "Efectivo";
                    ventaFactura.SubTotal = array.SubTotal;
                    ventaFactura.Descuento = array.Descuento;
                    ventaFactura.ImpuestoFactura = array.ImpuestoFactura;
                    ventaFactura.Total = array.Total;
                    ventaFactura.EstadoFactura = "A";
                }
                GuardarFactura(ventaFactura);

                foreach (var item in productos)
                {
                    detalle.IdProducto = item.IdProducto;
                    detalle.Precio = item.Precio;
                    detalle.Cantidad = item.Cantidad;
                    GuardarDetalle(detalle);
                }
                
                return View("Facturacion");


            }
            catch (Exception e)
            {
                return View();
            }
        }




        public void GuardarFactura(Ventas ventas)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarFactura";
            cmd.Parameters.AddWithValue("@Parametro", ventas.IdVenta);
            cmd.Parameters.AddWithValue("@IdCliente", ventas.IdCliente);
            cmd.Parameters.AddWithValue("@IdUsuario", ventas.IdUsuario);
            cmd.Parameters.AddWithValue("@FechaVenta", ventas.FechaVenta);
            cmd.Parameters.AddWithValue("@FormaPago", ventas.FormaPago);
            cmd.Parameters.AddWithValue("@SubTotal", ventas.SubTotal);
            cmd.Parameters.AddWithValue("@Descuento", ventas.Descuento);
            cmd.Parameters.AddWithValue("@ImpuestoFactura", ventas.ImpuestoFactura);
            cmd.Parameters.AddWithValue("@Total", ventas.Total);
            cmd.Parameters.AddWithValue("@EstadoFactura", ventas.EstadoFactura);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.CerrarConexion();

        }

        public void GuardarDetalle(DetalleVentas ventas)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertarDetalleFactura";
            cmd.Parameters.AddWithValue("@Parametro", ventas.IdVenta);
            cmd.Parameters.AddWithValue("@IdProducto", ventas.IdProducto);
            cmd.Parameters.AddWithValue("@Cantidad", ventas.Cantidad);
            cmd.Parameters.AddWithValue("@Precio", ventas.Precio);
            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conexion.CerrarConexion();

        }



    }
}

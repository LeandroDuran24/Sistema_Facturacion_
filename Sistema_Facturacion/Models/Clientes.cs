using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Clientes
    {
        [DisplayName("Id Cliente ")]
        public int IdCliente { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Direccion { get; set; }
       
        public string Telefono { get; set; }
     
        public string Celular { get; set; }



        public Clientes()
        {
            IdCliente = 0;
            Nombre ="";
            Apellidos = "";
            Cedula = "";
            Direccion = "";
            Telefono = "";
            Celular = "";
        }

        public Clientes(int IdCliente)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Clientes where IdCliente =@IdCliente",new SqlConnection());
            dataAdapter.SelectCommand.Parameters.AddWithValue("@IdCLiente", IdCliente);
            DataTable dt = ConexionDb.GetValuesInDataTable(dataAdapter);


            if (dt.Rows.Count > 0)
            {
                IdCliente = Convert.ToInt32(dt.Rows[0]["IdCliente"]);          
                Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                Apellidos = Convert.ToString(dt.Rows[0]["Apellidos"]);
                Cedula = Convert.ToString(dt.Rows[0]["Cedula"]);
                Direccion = Convert.ToString(dt.Rows[0]["Direccion"]);
                Telefono = Convert.ToString(dt.Rows[0]["Telefono"]);
                Celular = Convert.ToString(dt.Rows[0]["Celular"]);

            }
            else
            {
                IdCliente = 0;
                Nombre = "";
                Apellidos = "";
                Cedula = "";
                Direccion = "";
                Telefono = "";
                Celular = "";

            }
        }

    }

   
}
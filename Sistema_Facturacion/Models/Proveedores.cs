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
    public class Proveedores
    {
        [DisplayName("Id")]
        public int IdProveedor { get; set; }
        public int IdRepresentante { get; set; }

        [Required]
        [DisplayName("Razon Social")]
        public string RazonSocial { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }

       



        public Proveedores()
        {
            IdProveedor = 0;
            IdRepresentante = 0;
            RazonSocial = "";
            Direccion = "";
            Telefono = "";
            Email = "";
        }


        public Proveedores(int IdProveedor)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Proveedores where IdProveedor=@IdProveedor", new SqlConnection());
            dataAdapter.SelectCommand.Parameters.AddWithValue("@IdProveedor", IdProveedor);

            DataTable dt = ConexionDb.GetValuesInDataTable(dataAdapter);


            if (dt.Rows.Count > 0)
            {
                IdProveedor = Convert.ToInt32(dt.Rows[0]["IdProveedor"]);
                IdRepresentante = Convert.ToInt32(dt.Rows[0]["IdRepresentante"]);
                RazonSocial = Convert.ToString(dt.Rows[0]["RazonSocial"]);
                Direccion = Convert.ToString(dt.Rows[0]["Direccion"]);
                Telefono = Convert.ToString(dt.Rows[0]["Telefono"]);
                Email = Convert.ToString(dt.Rows[0]["Email"]);
             

            }
            else
            {
                IdProveedor = 0;
                IdRepresentante = 0;
                RazonSocial = "";
                Direccion = "";
                Telefono = "";
                Email = "";
            }

        }

    }
}
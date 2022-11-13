using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Representantes
    {
        [DisplayName("Id")]
        public int IdRepresentante { get; set; }

        [DisplayName("Representante")]
        public string Nombre { get; set; }

        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }

        [DisplayName("Cedula")]
        public string Cedula { get; set; }

        [DisplayName("Direccion")]
        public string Direccion { get; set; }
    

        [DisplayName("Celular")]
        public string Celular { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }


        public Representantes()
        {
            IdRepresentante = 0;
            Nombre = "";
            Apellidos = "";
            Cedula = "";
            Direccion = "";
            Celular = "";
            Email = "";
        }


        public Representantes(int IdRepresentate)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Representantes where IdRepresentante=@IdRepresentante", new SqlConnection());
            dataAdapter.SelectCommand.Parameters.AddWithValue("@IdRepresentante", IdRepresentate);

            DataTable dt = ConexionDb.GetValuesInDataTable(dataAdapter);


            if (dt.Rows.Count > 0)
            {
                IdRepresentante = Convert.ToInt32(dt.Rows[0]["IdRepresentante"]);
                Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                Apellidos = Convert.ToString(dt.Rows[0]["Apellidos"]);
                Cedula = Convert.ToString(dt.Rows[0]["Cedula"]);
                Direccion = Convert.ToString(dt.Rows[0]["Direccion"]);
                Celular = Convert.ToString(dt.Rows[0]["Celular"]);
                Email = Convert.ToString(dt.Rows[0]["Email"]);


            }
            else
            {
                IdRepresentate = 0;
                Nombre = "";
                Apellidos = "";
                Cedula = "";
                Celular = "";
                Email = "";
            }

        }


    }
}
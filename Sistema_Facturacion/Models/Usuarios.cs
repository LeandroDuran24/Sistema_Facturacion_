﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Usuarios
    {
        [Key]
        [DisplayName("Id Usuario ")]
        public int IdUsuario { get; set; }

        [DisplayName("Id Tipo Usuario ")]
        public int IdTipoUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

        [DisplayName("Fecha de creacion del Usuario ")]
        public DateTime FechaCreacion { get; set; }



        public Usuarios()
        {
            IdUsuario = 0;
            IdTipoUsuario = 0;
            Nombre = "";
            Apellidos = "";
            Usuario = "";
            Clave = "";
            FechaCreacion = DateTime.Now;
        }


        public Usuarios(int IdUsuario)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Usuarios where IdUsuario=@IdUsuario", new SqlConnection());
            dataAdapter.SelectCommand.Parameters.AddWithValue("@IdUsuario", IdUsuario);

            DataTable dt = ConexionDb.GetValuesInDataTable(dataAdapter);


            if (dt.Rows.Count > 0)
            {
                IdUsuario = Convert.ToInt32(dt.Rows[0]["IdUsuario"]);
                IdTipoUsuario = Convert.ToInt32(dt.Rows[0]["IdTipoUsuario"]);
                Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                Apellidos = Convert.ToString(dt.Rows[0]["Apellidos"]);
                Usuario = Convert.ToString(dt.Rows[0]["Usuario"]);
                Clave = Convert.ToString(dt.Rows[0]["Clave"]);
                FechaCreacion = Convert.ToDateTime(dt.Rows[0]["FechaCreacion"]);

                
            }
            else
            {
                IdUsuario = 0;
                IdTipoUsuario = 0;
                Nombre = "";
                Apellidos = "";
                Usuario = "";
                Clave = "";
                FechaCreacion = DateTime.Now;
            }

        }
    }

}
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
    public class CategoriaProductos
    {
        [DisplayName("Id")]
        public int IdCategoria { get; set; }
       
        [Required(ErrorMessage = "Favor completar")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Favor completar")]
        public string Descripcion { get; set; }

        public CategoriaProductos()
        {
            Categoria = "";
            Descripcion = "";
        }

        public CategoriaProductos(int IdCategoria)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from CategoriaProductos where IdCategoria=@IdCategoria", new SqlConnection());
            dataAdapter.SelectCommand.Parameters.AddWithValue("@IdCategoria", IdCategoria);

            DataTable dt = ConexionDb.GetValuesInDataTable(dataAdapter);


            if (dt.Rows.Count > 0)
            {
                IdCategoria = Convert.ToInt32(dt.Rows[0]["IdCategoria"]);
                Categoria = Convert.ToString(dt.Rows[0]["Nombre"]);  
                Descripcion = Convert.ToString(dt.Rows[0]["Descripcion"]);
           
            }
            else
            {
                Categoria = "";
                Descripcion = "";

            }

        }
    }
}
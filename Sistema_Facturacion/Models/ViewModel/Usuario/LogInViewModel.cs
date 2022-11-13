using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models.ViewModel
{
    public class LogInViewModel 
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Password { get; set; }

        public LogInViewModel()
        {

        }

        public LogInViewModel(string Usuario)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select top 1 * from Usuarios where Usuario=@Usuario", new SqlConnection());
            adapter.SelectCommand.Parameters.AddWithValue("@Usuario", Usuario);

            DataTable dt = ConexionDb.GetValuesInDataTable(adapter);

            if(dt.Rows.Count >0)
            {
                Username = Convert.ToString(dt.Rows[0]["Usuario"]);
                Password = Convert.ToString(dt.Rows[0]["Clave"]);
            }
            else
            {
                Username = "";
                Password = "";
            }
            



        }
    }
}
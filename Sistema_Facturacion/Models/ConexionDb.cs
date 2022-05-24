using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class ConexionDb
    {

        public static SqlConnection connectionString = new SqlConnection("Server=LEANDRODURAN\\SQLEXPRESS; DataBase=BarberShop; Integrated Security=true");


        public SqlConnection AbrirConexion()
        {

            if (connectionString.State == System.Data.ConnectionState.Closed)
                connectionString.Open();
            return connectionString;
        }

        public SqlConnection CerrarConexion()
        {
            if (connectionString.State == System.Data.ConnectionState.Open)
                connectionString.Close();
            return connectionString;
        }
    }
}
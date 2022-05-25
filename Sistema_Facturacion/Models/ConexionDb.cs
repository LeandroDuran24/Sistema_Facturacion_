using System;
using System.Collections.Generic;
using System.Data;
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


        //para cargar datos de un select a una tab la sql
        public static DataTable GetValuesInDataTable(SqlDataAdapter adapter)
        {
            ConexionDb cn = new ConexionDb();
            DataTable dataTable = new DataTable();
            adapter.SelectCommand.Connection = cn.AbrirConexion();

            try
            {

                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                dataTable = new DataTable();
            }
            finally
            {
                adapter.Dispose();
                cn.CerrarConexion();
            }

            return dataTable;
        }

        public static DataTable GetValuesInDataTable(string Query, int TipoCon = 0)
        {

            DataTable ret = new DataTable();
            //SqlConnection con= new SqlConnection(conexion);


            SqlDataAdapter adapter = new SqlDataAdapter(Query, connectionString);
            try
            {

                adapter.Fill(ret);
                connectionString.Open();
            }
            catch (Exception ex)
            {
                ret = new DataTable();
            }
            finally
            {
                adapter.Dispose();
                connectionString.Close();
            }

            return ret;
        }
    }
}
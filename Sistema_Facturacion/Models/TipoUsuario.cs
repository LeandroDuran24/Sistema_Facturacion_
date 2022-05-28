using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class TipoUsuario
    {
        [DisplayName("Id Tipo Usuario")]
        public int IdTipoUsuario { get; set; }
        [Required]
        public string Tipo { get; set; }

        public TipoUsuario()
        {
            IdTipoUsuario = 0;
            Tipo = "";
        }

        public static List<TipoUsuario> GetTipoUsuarios(string condicionBusqueda = "")
        {
            List<TipoUsuario> tipoUsuario = new List<TipoUsuario>();

            string qwery = "SELECT [IdTipoUsuario] ,[Tipo] FROM [TipoUsuario]";

            if (condicionBusqueda != "")
                qwery += condicionBusqueda;

            DataTable dtTipoUsuario = Busqueda(qwery);


            tipoUsuario = (from row in dtTipoUsuario.AsEnumerable()
                      select ConvertRowToCiudad(row)).ToList();

            return tipoUsuario;
        }

        public static TipoUsuario ConvertRowToCiudad(DataRow row)
        {
            try
            {
                if (row == null)
                    return new TipoUsuario();

                TipoUsuario tipoUsuario = new TipoUsuario
                {
                    IdTipoUsuario = Convert.ToInt32(row["IdTipoUsuario"] ?? 0),
                    Tipo = row["Tipo"].ToString() ?? "--"
                };

                return tipoUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable Busqueda(string Query)
        {
            return Sistema_Facturacion.Models.ConexionDb.GetValuesInDataTable(Query, 0);

        }

    }
}
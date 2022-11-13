using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace Sistema_Facturacion.Models.ViewModel.Proveedor
{
    public class MProveedorViewModel : Proveedores
    {

        [Required]
        [DisplayName("Representante")]
        public string Representante { get; set; }
        public List<Representantes> representanteList { get; set; }


        public MProveedorViewModel()
        {
            representanteList = GetRepresentantes();
        }

        public MProveedorViewModel(int IdRepresentante) : base(IdRepresentante)
        {

            if (IdRepresentante > 0)
            {
                List<Representantes> lista = new List<Representantes>();
                lista = GetRepresentantes("where IdRepresentante=" + (Convert.ToString(IdRepresentante))).ToList<Representantes>();
                foreach (var item in lista)
                {
                    Representante = item.Nombre;
                }

            }

            

            representanteList = GetRepresentantes();
            
        }


        public static List<Representantes> GetRepresentantes(string condicionBusqueda = "")
        {
            List<Representantes> representantes = new List<Representantes>();

            string qwery = "SELECT IdRepresentante,Nombre,Apellidos FROM [Representantes]" + condicionBusqueda;



            DataTable dtRepresentantes = Busqueda(qwery);
            representantes = (from row in dtRepresentantes.AsEnumerable()
                           select ConvertRowToRepresentantes(row)).ToList();

            return representantes;
        }



       

        public static Representantes ConvertRowToRepresentantes(DataRow row)
        {
            try
            {
                if (row == null)
                    return new Representantes();

                Representantes representantes = new Representantes
                {
                    IdRepresentante = Convert.ToInt32(row["IdRepresentante"] ?? 0),
                    Nombre = row["Nombre"].ToString() ?? "--",
                    Apellidos = row["Apellidos"].ToString() ?? "--",
                };

                return representantes;
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

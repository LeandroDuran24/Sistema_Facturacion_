using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Usuarios
    {


        [DisplayName("Id Usuario ")]
        public int IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Clave { get; set; }
        public DateTime FechaCreacion { get; set; }



        public Usuarios()
        {

        }


        public Usuarios(int IdUsuario)
        {

        }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Log
    {
        [DisplayName("Id Log")]
        public int IdLog { get; set; }
        [DisplayName("Id Usuario")]
        public int IdUsuario { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public Log()
        {

        }
    }
}
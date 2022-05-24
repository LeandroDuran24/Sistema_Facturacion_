using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class TipoUsuario
    {
        [DisplayName("Id Tipo Usuario")]
        public int IdTipo { get; set; }
        [Required]
        public string Tipo { get; set; }

        public TipoUsuario()
        {

        }
    }
}
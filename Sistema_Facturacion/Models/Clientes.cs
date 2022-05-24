using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Clientes
    {
        [DisplayName("Id Cliente ")]
        public int IdCliente { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Direccion { get; set; }
       
        public string Telefono { get; set; }
        [Required]
        public string Celular { get; set; }



        public Clientes()
        {

        }

    }

   
}
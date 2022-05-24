﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Proveedores
    {
        [DisplayName("Id Proveedor")]
        public int IdProveedor { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }


    }
}
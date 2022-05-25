using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Sistema_Facturacion.Models.Utilidades;

namespace Sistema_Facturacion.Models.ViewModel
{
    public class CUsuarioViewModel
    {
        public static List<Usuarios> usuario { get; set; } //lista para almcenar los usuarios
        public static CriterioBusquedaUsuarios criterioBusqueda { get; set; }
        public static string stringBusqueda { get; set; } = string.Empty;


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Sistema_Facturacion.Models.Utilidades;

namespace Sistema_Facturacion.Models.ViewModel
{
    public class CUsuarioViewModel :Usuarios
    {
        public  List<Usuarios> usuarioList { get; set; } //lista para almcenar los usuarios
        public  CriterioBusquedaUsuarios criterioBusqueda { get; set; }
        public  string stringBusqueda { get; set; } = string.Empty;


    }
}
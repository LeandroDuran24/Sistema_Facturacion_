using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models.ViewModel.Representante
{
    public class CRepresentantesViewModel :Representantes
    {
        public List<Representantes> representanteList { get; set; } //lista para almcenar los usuarios
    }
}
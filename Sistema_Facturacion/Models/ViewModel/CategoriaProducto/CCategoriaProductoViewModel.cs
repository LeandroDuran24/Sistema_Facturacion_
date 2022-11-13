using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models.ViewModel.CategoriaProducto
{
    public class CCategoriaProductoViewModel:CategoriaProductos
    {
        public List<CategoriaProductos> categoriaList { get; set; } //lista para almcenar los productos

    }
}
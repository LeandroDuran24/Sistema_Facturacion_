using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Sistema_Facturacion.Models
{
    public class Utilidades
    {

        public enum CriterioBusquedaUsuarios
        {
            Nombre,
            IdUsuario
        }

        public enum CriterioBusquedaClientes
        {
            Nombre,
            IdCliente
        }

        public enum CriterioBusquedaProveedores
        {
           
            RazonSocial,
            IdProveedor
        }

        public enum CriterioBusquedaProductos
        {

            Descripcion,
            Codigo,
            IdProveedor,
            IdCategoria
        }
    }
}
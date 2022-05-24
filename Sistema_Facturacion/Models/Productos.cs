using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Facturacion.Models
{
    public class Productos
    {
        [DisplayName("Id Producto ")]
        public string IdProducto { get; set; }
        [DisplayName("Id Categoria Producto")]
        public int IdCategoriaProducto { get; set; }
        [DisplayName("Id Proveedor")]
        public int Idproveedor { get; set; }
        [DisplayName("Id Medida")]
        public int IdMedida { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public double PrecioCompra{ get; set; }
        [Required]
        public double PrecioVenta { get; set; }
        [Required]
        public string Stock { get; set; }


        public Productos()
        {

        }


    }
}
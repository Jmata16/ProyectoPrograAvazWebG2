using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoModels
{
    public class Carrito
    {
        [Key]
        public int CarritoID { get; set; }

        [ForeignKey("ProductoID")]
        public int ProductoID { get; set; }

        [ForeignKey("Precio")]
        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
        
        public Producto Producto { get; set; }

    }
}

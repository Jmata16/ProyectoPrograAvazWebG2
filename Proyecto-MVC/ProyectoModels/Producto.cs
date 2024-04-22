using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoModels
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Favor ingrese el nombre del producto")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Favor ingrese la descripcion del producto")]
        public string Descripcion { get; set; }


        public string ImagenURL { get; set; }

        [Required(ErrorMessage = "Favor ingresar el precio del producto")]
        public decimal Precio { get; set; }



    }
}

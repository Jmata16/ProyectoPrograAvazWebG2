using System.ComponentModel.DataAnnotations;

namespace ProyectoModels
{
    public class UbicacionTienda
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Dirección es requerido.")]
        [StringLength(255, ErrorMessage = "El campo Dirección debe tener como máximo {1} caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Ciudad es requerido.")]
        [StringLength(100, ErrorMessage = "El campo Ciudad debe tener como máximo {1} caracteres.")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El campo País es requerido.")]
        [StringLength(100, ErrorMessage = "El campo País debe tener como máximo {1} caracteres.")]
        public string Pais { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoModels
{
    public class Usuarios
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; }

        [Required]
        public int Rol_ID { get; set; }
    }
}

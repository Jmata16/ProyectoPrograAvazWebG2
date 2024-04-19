using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoModels
{
    public class Usuarios
    {
        [JsonPropertyName("id")]
        [Key]
        public int ID { get; set; }

        [JsonPropertyName("nombre")]
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [JsonPropertyName("correoElectronico")]
        [Required]
        [StringLength(255)]
        public string CorreoElectronico { get; set; }

        [JsonPropertyName("contraseña")]
        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; }

         [JsonPropertyName("rol_ID")]
        [Required]
        public int Rol_ID { get; set; }
    }
}

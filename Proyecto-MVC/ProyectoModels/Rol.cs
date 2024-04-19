using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoModels
{
    public class Rol
    {
        [JsonPropertyName("Rol_ID")]
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("usuarios")] // Aquí pones el nombre exacto de la tabla en MySQL
    public class Usuario
    {
        [Key] // Indica que es la clave primaria
        public int Iduser { get; set; }

        [Required] // Nombre no puede ser nulo
        public required string Nombre { get; set; } // obligatorio al crear el objeto
    }
}

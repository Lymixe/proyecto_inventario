using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioAPI.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("dni")]
        [Required]
        public string Dni { get; set; } = string.Empty;

        [Column("nombres")]
        public string? Nombres { get; set; }

        [Column("apellidos")]
        public string? Apellidos { get; set; }

        [Column("correo")]
        public string? Correo { get; set; }

        [Column("password_hash")]
        public string? PasswordHash { get; set; }

        [Column("rol")]
        public string Rol { get; set; } = "usuario";
    }
}
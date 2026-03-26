using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioAPI.Models
{
    [Table("ubicaciones")]
    public class Ubicacion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("aula_host")]
        public string? AulaHost { get; set; }

        [Column("area_nombre")]
        public string? AreaNombre { get; set; }
    }
}
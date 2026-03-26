using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioAPI.Models
{
    [Table("detalles_cpu")]
    public class DetalleCpu
    {
        [Key]
        [Column("equipo_id")]
        public int EquipoId { get; set; }

        [Column("serie")]
        public string? Serie { get; set; }

        [Column("procesador")]
        public string? Procesador { get; set; }

        [Column("almacenamiento_tipo")]
        public string? AlmacenamientoTipo { get; set; }

        [Column("ram")]
        public string? Ram { get; set; }

        [Column("sistema_operativo")]
        public string? SistemaOperativo { get; set; }

        [Column("direccion_ip")]
        public string? DireccionIp { get; set; }

        [Column("direccion_mac")]
        public string? DireccionMac { get; set; }

        [Column("vlan")]
        public int? Vlan { get; set; }

        [Column("tiene_lectora")]
        public bool TieneLectora { get; set; } = false;

        [Column("conexion_internet")]
        public string? ConexionInternet { get; set; } = "No";
    }
}
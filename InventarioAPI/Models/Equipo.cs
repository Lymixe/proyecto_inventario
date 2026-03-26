using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioAPI.Models
{
    [Table("equipos")]
    public class Equipo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ubicacion_id")]
        public int? UbicacionId { get; set; }

        [Column("usuario_asignado_id")]
        public int? UsuarioAsignadoId { get; set; }

        [Column("kit_identificador")]
        public string? KitIdentificador { get; set; }

        [Column("nro_item")]
        public string? NroItem { get; set; }

        [Column("anio_inventario")]
        public int? AnioInventario { get; set; }

        [Column("tipo_equipo")]
        public string? TipoEquipo { get; set; }

        [Column("asset_name")]
        public string? AssetName { get; set; }

        [Column("asset_tag")]
        public string? AssetTag { get; set; }

        [Column("marca")]
        public string? Marca { get; set; }

        [Column("modelo")]
        public string? Modelo { get; set; }

        [Column("modelo_nro_total")]
        public int? ModeloNroTotal { get; set; }

        [Column("codigo")]
        public string? Codigo { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Operativo";

        [Column("nombre_location")]
        public string? NombreLocation { get; set; }

        [Column("ubicacion_origen")]
        public string? UbicacionOrigen { get; set; }

        [Column("ubicacion_destino")]
        public string? UbicacionDestino { get; set; }

        [Column("observaciones")]
        public string? Observaciones { get; set; }
    }
}
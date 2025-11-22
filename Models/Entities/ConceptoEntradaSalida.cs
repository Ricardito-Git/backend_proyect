using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_proyect.Models.Entities
{
    [Table("conceptos_entrada_salida")]
    public class ConceptoEntradaSalida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_concepto")]
        public int IdConcepto { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("description")]
        public string Descripcion { get; set; }
        
        [Required]
        [StringLength(1)]
        [Column("tipo_movimiento")]
        public string TipoMovimiento { get; set; } // E=Entrada, S=Salida
        
        [Column("activo")]
        public bool Activo { get; set; } = true;
        
        [Column("fecha_ult_mov")]
        public DateTime FechaUltMov { get; set; } = DateTime.Now;
        
        [Column("usuario_ult_mov")]
        public int? UsuarioUltMov { get; set; }

        [ForeignKey("UsuarioUltMov")]
        public virtual Usuario UsuarioModificacion { get; set; }
    }
}
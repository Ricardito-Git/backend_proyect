using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_proyect.Models.Entities
{
    [Table("racks")]
    public class Rack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_rack")]
        public int IdRack { get; set; }
        
        [Required]
        [Column("id_pasillo")]
        public int IdPasillo { get; set; }
        
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }
        
        [Required]
        [Column("columns")]
        public int Columnas { get; set; }
        
        [Required]
        [Column("nivel")]
        public int Nivel { get; set; }
        
        [Required]
        [Column("subnivel")]
        public int Subnivel { get; set; }
        
        [Column("activo")]
        public bool Activo { get; set; } = true;
        
        [Column("fecha_ult_mov")]
        public DateTime FechaUltMov { get; set; } = DateTime.Now;
        
        [Column("usuario_ult_mov")]
        public int? UsuarioUltMov { get; set; }

        // Navigation properties
        [ForeignKey("IdPasillo")]
        public virtual Pasillo Pasillo { get; set; }
        
        [ForeignKey("UsuarioUltMov")]
        public virtual Usuario UsuarioModificacion { get; set; }
    }
}
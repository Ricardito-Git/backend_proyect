using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_proyect.Models.Entities
{
    [Table("almacenes")]
    public class Almacen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_almacen")]
        public int IdAlmacen { get; set; }
        
        [Required]
        [Column("id_empresa")]
        public int IdEmpresa { get; set; }
        
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }
        
        [Required]
        [Column("pertenece_es")]
        public bool PerteneceEs { get; set; }
        
        [Column("activo")]
        public bool Activo { get; set; } = true;
        
        [Column("fecha_ult_mov")]
        public DateTime FechaUltMov { get; set; } = DateTime.Now;
        
        [Column("usuario_ult_mov")]
        public int? UsuarioUltMov { get; set; }

        // Navigation properties
        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }
        
        [ForeignKey("UsuarioUltMov")]
        public virtual Usuario UsuarioModificacion { get; set; }
    }
}
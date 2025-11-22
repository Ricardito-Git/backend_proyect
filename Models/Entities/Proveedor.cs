using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_proyect.Models.Entities
{
    [Table("proveedores")]
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_proveedor")]
        public int IdProveedor { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("nombre")]
        public string Nombre { get; set; }
        
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
//arturo


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_proyect.Models.Entities
{
    [Table("perfiles")]
    public class Perfil
    {
        [Key]
        [Column("id_perfil")]
        public int IdPerfil { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("descripcion")]
        public string Descripcion { get; set; }
        
        [Column("activo")]
        public bool Activo { get; set; } = true;
        
        [Column("fecha_ult_mov")]
        public DateTime FechaUltMov { get; set; }
        
        [Column("usuario_ult_mov")]
        public int? UsuarioUltMov { get; set; }

        // Navigation properties
        public virtual ICollection<Usuario> Usuarios { get; set; }
        
        [ForeignKey("UsuarioUltMov")]
        public virtual Usuario UsuarioModificacion { get; set; }
    }
}
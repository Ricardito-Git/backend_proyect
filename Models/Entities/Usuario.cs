//arturo

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_proyect.Models.Entities
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        
        [Required]
        [Column("id_perfil")]
        public int IdPerfil { get; set; }
        
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("password")]
        public string Password { get; set; }
        
        [Column("activo")]
        public bool Activo { get; set; } = true;
        
        [Column("fecha_ult_mov")]
        public DateTime FechaUltMov { get; set; }
        
        [Column("usuario_ult_mov")]
        public int? UsuarioUltMov { get; set; }

        // Navigation properties
        [ForeignKey("IdPerfil")]
        public virtual Perfil Perfil { get; set; }
        
        [ForeignKey("UsuarioUltMov")]
        public virtual Usuario UsuarioModificacion { get; set; }
    }
}
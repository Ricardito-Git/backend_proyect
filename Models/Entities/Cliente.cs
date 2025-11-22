using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_proyect.Models.Entities
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        
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

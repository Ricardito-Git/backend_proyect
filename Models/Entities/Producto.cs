using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_proyect.Models.Entities
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_producto")]
        public int IdProducto { get; set; }
        
        [Required]
        [StringLength(50)]
        [Column("codigo")]
        public string Codigo { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("description")]
        public string Descripcion { get; set; }
        
        [Column("fotografia")]
        public byte[] Fotografia { get; set; }
        
        [Column("activo")]
        public bool Activo { get; set; } = true;
        
        [Required]
        [Column("id_tipo")]
        public int IdTipo { get; set; }
        
        [Required]
        [Column("id_subtipo")]
        public int IdSubtipo { get; set; }
        
        [Required]
        [Column("id_familia")]
        public int IdFamilia { get; set; }
        
        [Required]
        [Column("id_presentacion")]
        public int IdPresentacion { get; set; }
        
        [Required]
        [Column("id_excepcion")]
        public int IdExcepcion { get; set; }
        
        [Required]
        [Column("id_estado")]
        public int IdEstado { get; set; }
        
        [Column("fecha_ult_mov")]
        public DateTime FechaUltMov { get; set; } = DateTime.Now;
        
        [Column("usuario_ult_mov")]
        public int? UsuarioUltMov { get; set; }

        // Navigation properties
        [ForeignKey("IdTipo")]
        public virtual TipoProducto TipoProducto { get; set; }
        
        [ForeignKey("IdSubtipo")]
        public virtual SubtipoProducto SubtipoProducto { get; set; }
        
        [ForeignKey("IdFamilia")]
        public virtual Familia Familia { get; set; }
        
        [ForeignKey("IdPresentacion")]
        public virtual Presentacion Presentacion { get; set; }
        
        [ForeignKey("IdExcepcion")]
        public virtual ExcepcionProducto ExcepcionProducto { get; set; }
        
        [ForeignKey("IdEstado")]
        public virtual EstadoProducto EstadoProducto { get; set; }
        
        [ForeignKey("UsuarioUltMov")]
        public virtual Usuario UsuarioModificacion { get; set; }
    }
}
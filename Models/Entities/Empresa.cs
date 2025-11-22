//arturo
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_proyect.Models.Entities
{
    [Table("empresas")]
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_empresa")]
        public int IdEmpresa { get; set; }
        
        [Required]
        [StringLength(255)]
        [Column("razon_social")]
        public string RazonSocial { get; set; }
        
        [Required]
        [StringLength(20)]
        [Column("rfc")]
        public string Rfc { get; set; }
        
        [StringLength(100)]
        [Column("calle")]
        public string Calle { get; set; }
        
        [StringLength(10)]
        [Column("no_exterior")]
        public string NoExterior { get; set; }
        
        [StringLength(10)]
        [Column("no_interior")]
        public string NoInterior { get; set; }
        
        [StringLength(100)]
        [Column("colonia")]
        public string Colonia { get; set; }
        
        [StringLength(10)]
        [Column("codigo_postal")]
        public string CodigoPostal { get; set; }
        
        [StringLength(20)]
        [Column("telefono")]
        public string Telefono { get; set; }
        
        [StringLength(100)]
        [Column("ciudad")]
        public string Ciudad { get; set; }
        
        [StringLength(100)]
        [Column("municipio")]
        public string Municipio { get; set; }
        
        [StringLength(100)]
        [Column("estado")]
        public string Estado { get; set; }
        
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
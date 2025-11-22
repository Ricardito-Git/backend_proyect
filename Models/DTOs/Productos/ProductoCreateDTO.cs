namespace backend_proyect.Models.DTOs.Productos
{
    public class ProductoCreateDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public byte[] Fotografia { get; set; }
        public int? IdTipo { get; set; }
        public int? IdSubtipo { get; set; }
        public int? IdFamilia { get; set; }
        public int? IdPresentacion { get; set; }
        public int? IdExcepcion { get; set; }
        public int? IdEstado { get; set; }
    }
}

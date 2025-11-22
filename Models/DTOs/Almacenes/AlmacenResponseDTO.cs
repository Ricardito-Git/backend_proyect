namespace backend_proyect.Models.DTOs.Almacenes
{
    public class AlmacenResponseDTO
    {
        public int IdAlmacen { get; set; }
        public string Nombre { get; set; }
        public string InformacionContacto { get; set; }
        public string Direccion { get; set; }
        public bool PerteneceCs { get; set; }
        public string Empresa { get; set; }
    }
}

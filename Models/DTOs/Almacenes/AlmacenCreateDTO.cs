namespace backend_proyect.Models.DTOs.Almacenes
{
    public class AlmacenCreateDTO
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string InformacionContacto { get; set; }
        public bool PerteneceCs { get; set; }
    }
}

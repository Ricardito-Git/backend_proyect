namespace backend_proyect.Models.DTOs.Usuarios
{
    public class UsuarioResponseDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int IdPerfil { get; set; }
        public string NombrePerfil { get; set; }
    }
}

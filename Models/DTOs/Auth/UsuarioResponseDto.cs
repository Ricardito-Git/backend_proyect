namespace backend_proyect.Models.DTOs.auth
{
    public class UsuarioResponseDto
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Perfil { get; set; }
        public string Token { get; set; }
    }
}
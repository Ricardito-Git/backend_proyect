namespace backend_proyect.Models.DTOs.auth
{
    public class RegistroDto
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int IdPerfil { get; set; } = 2; // Usuario por defecto
    }
}
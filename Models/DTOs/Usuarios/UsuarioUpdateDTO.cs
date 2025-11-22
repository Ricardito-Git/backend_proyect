namespace backend_proyect.Models.DTOs.Usuarios
{
    public class UsuarioUpdateDTO
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
    }
}

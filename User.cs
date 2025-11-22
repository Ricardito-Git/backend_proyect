namespace backend_proyect.Models
{
    public class User
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public DateTime Fecha_ult_mov { get; set; }
        public object Profile { get; internal set; }
        public bool Activo { get; internal set; }
    }
}
/*Completo*/
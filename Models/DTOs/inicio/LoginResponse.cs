namespace backend_proyect.Models.DTOs.inicio;

public class LoginResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public string Nombre { get; set; }
    public int IdUsuario { get; set; }
    public int IdPerfil { get; set; }
}

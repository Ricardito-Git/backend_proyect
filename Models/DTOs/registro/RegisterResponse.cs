namespace backend_proyect.Models.DTOs.registro;

public class RegisterResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public int IdUsuario { get; set; }
    public string Nombre { get; set; }
}

namespace backend_proyect.Models.DTOs.Clientes
{
    public class ClienteUpdateDTO
    {
        public int IdCliente { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string InformacionContacto { get; set; }
        public string Direccion { get; set; }
    }
}

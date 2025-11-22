namespace backend_proyect.Models.DTOs.Empresa
{
    public class EmpresaCreateDTO
    {
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Calle { get; set; }
        public int? NoExterior { get; set; }
        public int? NoInterior { get; set; }
        public string Colonia { get; set; }
        public int? CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
    }
}

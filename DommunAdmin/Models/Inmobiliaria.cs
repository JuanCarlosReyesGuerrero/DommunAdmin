namespace DommunAdmin.Models
{
    public class Inmobiliaria
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nit { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }
        public bool IsActive { get; set; }
    }
}

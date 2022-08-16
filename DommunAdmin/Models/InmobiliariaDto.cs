namespace DommunAdmin.Models
{
    public class InmobiliariaDto
    {
        public int id { get; set; }
        public string? codigo { get; set; }
        public string? nit { get; set; }
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }
        public bool isActive { get; set; }
    }
}

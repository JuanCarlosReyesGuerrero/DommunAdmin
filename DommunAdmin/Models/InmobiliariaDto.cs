using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DommunAdmin.Models
{
    public class InmobiliariaDto
    {
        public int id { get; set; }

        [Display(Name = "Código")]
        public string? codigo { get; set; }

        [Display(Name = "Nit")]
        public string? nit { get; set; }

        [Display(Name = "Nombre")]
        public string? nombre { get; set; }

        [Display(Name = "Dirección")]
        public string? direccion { get; set; }

        [Display(Name = "teléfono")]
        public string? telefono { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool isActive { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunAdmin.Models
{
    public class EstadoPropiedadDto
    {
        [HiddenInput]
        public int id { get; set; }

        [Display(Name = "Código")]
        public string? codigo { get; set; }

        [Display(Name = "Nombre")]
        public string? nombre { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool isActive { get; set; }

        [Display(Name = "Estado Propiedad")]
        public string fullName
        {
            get
            {
                return nombre;
            }
        }
    }
}

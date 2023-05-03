using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunAdmin.Models
{
    public class CaracteristicaPropiedadDto
    {
        [HiddenInput]
        [Display(Name = "Id")]
        public int? id { get; set; }

        [Display(Name = "Propiedad")]
        public int? propiedadId { get; set; }

        [Display(Name = "Caracteristica")]
        public int? caracteristicaId { get; set; }

        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool isActive { get; set; }
    }
}
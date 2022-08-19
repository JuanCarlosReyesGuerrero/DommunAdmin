using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunAdmin.Models
{
    public class FotografiaDto
    {
        [HiddenInput]
        public int id { get; set; }

        [Display(Name = "Fotografía")]
        public string? imagen { get; set; }

        [Display(Name = "Es Válida")]
        public bool valida { get; set; }

        [Display(Name = "Es principal")]
        public bool esPrincipal { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool isActive { get; set; }
    }
}

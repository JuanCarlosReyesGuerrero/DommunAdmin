using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Dtos
{
    public class FotografiaDto
    {
        [HiddenInput]
        public int Id { get; set; }
        public string? Imagen { get; set; }
        public bool Valida { get; set; }
        public bool EsPrincipal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
    }
}

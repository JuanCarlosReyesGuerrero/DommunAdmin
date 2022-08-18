using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Dtos
{
    public class FotografiaPropiedadDto
    {
        [HiddenInput]
        public int Id { get; set; }
        public int FotografiaId { get; set; }
        public bool PropiedadId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
    }
}

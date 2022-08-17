using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunAdmin.Models
{
    public class AgenteDto
    {
        [HiddenInput]
        public int id { get; set; }

        [Display(Name = "Slug")]
        public string? slug { get; set; }

        [Display(Name = "Nombres")]
        public string? nombres { get; set; }

        [Display(Name = "Apellidos")]
        public string? apellidos { get; set; }

        [Display(Name = "Email")]
        public string? email { get; set; }

        [Display(Name = "Foto Perfil")]
        public string? fotoPerfil { get; set; }

        [Display(Name = "Descripción")]
        public string? descripcionPerfil { get; set; }

        [Display(Name = "Celular")]
        public string? celular { get; set; }

        [Display(Name = "Facebook")]
        public string? facebook { get; set; }

        [Display(Name = "Twitter")]
        public string? twitter { get; set; }

        [Display(Name = "Linkedin")]
        public string? linkedin { get; set; }

        [Display(Name = "Instagram")]
        public string? instagram { get; set; }

        [Display(Name = "Website")]
        public string? website { get; set; }

        [Display(Name = "Inmobiliaria")]
        public int? inmobiliariaId { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool isActive { get; set; }
    }
}

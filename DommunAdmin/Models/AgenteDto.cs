using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunAdmin.Models
{
    public class AgenteDto
    {
        [HiddenInput]
        public int id { get; set; }
        public string? slug { get; set; }

        [Display(Name = "Nombres")]
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? email { get; set; }
        public string? fotoPerfil { get; set; }
        public string? descripcionPerfil { get; set; }
        public string? celular { get; set; }
        public string? facebook { get; set; }
        public string? twitter { get; set; }
        public string? linkedin { get; set; }
        public string? instagram { get; set; }
        public string? website { get; set; }
        public int? inmobiliariaId { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }
        public bool isActive { get; set; }
    }
}

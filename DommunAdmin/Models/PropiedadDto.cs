using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunAdmin.Models
{
    public class PropiedadDto
    {
        [HiddenInput]
        public int id { get; set; }

        [Display(Name = "Titulo")]
        public string? titulo { get; set; }

        [Display(Name = "Descripción")]
        public string? descripcion { get; set; }

        [Display(Name = "Precio")]
        public decimal precio { get; set; }

        [Display(Name = "Localización")]
        public string? localizacion { get; set; }

        [Display(Name = "Barrio")]
        public string? barrio { get; set; }

        [Display(Name = "Número Dormitorios")]
        public int dormitorios { get; set; }

        [Display(Name = "Número Baños")]
        public int banos { get; set; }

        [Display(Name = "Número Garajes")]
        public int garages { get; set; }

        [Display(Name = "Area m2")]
        public int area { get; set; }

        [Display(Name = "Año de Construcción")]
        public int anioConstruccion { get; set; }

        [Display(Name = "Características")]
        public string? caracteristicas { get; set; }

        [Display(Name = "Link Video")]
        public string? video { get; set; }

        [Display(Name = "Plano")]
        public string? plano { get; set; }

        [Display(Name = "Tipo Propiedad")]
        public int tipoPropiedadId { get; set; }

        [Display(Name = "Estado Propiedad")]
        public int estadoPropiedadId { get; set; }

        [Display(Name = "Ciudad")]
        public int ciudadId { get; set; }

        [Display(Name = "Agente")]
        public int agenteId { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool isActive { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunAdmin.Models
{
    public class PropiedadDto
    {
        [HiddenInput]
        public int id { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }
        public decimal precio { get; set; }
        public string? localizacion { get; set; }
        public string? barrio { get; set; }
        public int dormitorios { get; set; }
        public int banos { get; set; }
        public int garages { get; set; }
        public int area { get; set; }
        public int anioConstruccion { get; set; }
        public string? caracteristicas { get; set; }
        public string? video { get; set; }
        public string? plano { get; set; }
        public int tipoPropiedadId { get; set; }
        public int estadoPropiedadId { get; set; }
        public int ciudadId { get; set; }
        public int agenteId { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool isActive { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Dtos
{
    public class PropiedadDto
    {
        [HiddenInput]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Localizacion { get; set; }
        public string? Barrio { get; set; }
        public int Dormitorios { get; set; }
        public int Banos { get; set; }
        public int Garages { get; set; }
        public int Area { get; set; }
        public int AnioConstruccion { get; set; }
        public string? Caracteristicas { get; set; }
        public string? Video { get; set; }
        public string? Plano { get; set; }
        public int TipoPropiedadId { get; set; }
        public int EstadoPropiedadId { get; set; }
        public int CiudadId { get; set; }
        public int AgenteId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
    }
}

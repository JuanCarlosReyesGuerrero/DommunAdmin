using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunAdmin.Models
{
    public class PropiedadDto
    {
        [HiddenInput]
        public int id { get; set; }

        [Display(Name = "Tipo Oferta")]
        public int? tipoOfertaId { get; set; }

        [Display(Name = "Tipo Propiedad")]
        public int tipoPropiedadId { get; set; }

        [Display(Name = "Valor Venta")]
        public double valorVenta { get; set; }

        [Display(Name = "Valor Arriendo")]
        public double valorArriendo { get; set; }

        [Display(Name = "Incluye Administración")]
        public bool incluyeAdministracion { get; set; }

        [Display(Name = "Valor Administración")]
        public double valorAdministracion { get; set; }

        [Display(Name = "Valor M2")]
        public double valorMetro { get; set; }

        [Display(Name = "Ciudad")]
        public int ciudadId { get; set; }

        [Display(Name = "Direccion")]
        public string? direccion { get; set; }

        [Display(Name = "Barrio")]
        public string? barrio { get; set; }

        [Display(Name = "Localización")]
        public string? localizacion { get; set; }

        [Display(Name = "Estrato")]
        public int? estratoId { get; set; }

        [Display(Name = "Area Privada M2")]
        public decimal areaPrivada { get; set; }

        [Display(Name = "Area Construida M2")]
        public decimal areaConstruida { get; set; }

        [Display(Name = "Número de Piso")]
        public int? numeroPiso { get; set; }

        [Display(Name = "Area de Fondo")]
        public decimal areaFondo { get; set; }

        [Display(Name = "Tiempo Construido")]
        public int? tiempoConstruidoId { get; set; }

        [Display(Name = "Número Dormitorios")]
        public int? numeroHabitacionId { get; set; }

        [Display(Name = "Número Baños")]
        public int? numeroBanoId { get; set; }

        [Display(Name = "Número Parqueaderos")]
        public int? numeroParqueaderoId { get; set; }

        [Display(Name = "Tipo Parqueadero")]
        public int? tipoParqueaderoId { get; set; }

        [Display(Name = "Característica parqueadero")]
        public int? caracteristicaParqueaderoId { get; set; }

        [Display(Name = "Características")]
        public string? caracteristicas { get; set; }

        [Display(Name = "Link Video")]
        public string? video { get; set; }

        [Display(Name = "Descripción")]
        public string? descripcion { get; set; }
        [Display(Name = "Año de Construcción")]
        public int anioConstruccion { get; set; }
        [Display(Name = "Estado Propiedad")]
        public int estadoPropiedadId { get; set; }

        [Display(Name = "Agente")]
        public int agenteId { get; set; }

        [Display(Name = "Activo")]
        public bool isActive { get; set; }



        //[HiddenInput]
        //public int id { get; set; }
        //public int? tipoOfertaId { get; set; }
        //public int? tipoPropiedadId { get; set; }
        //public double? valorVenta { get; set; }
        //public double? valorArriendo { get; set; }
        //public bool incluyeAdministracion { get; set; }
        //public double? valorAdministracion { get; set; }
        //public double? valorMetro { get; set; }

        //public int? ciudadId { get; set; }
        //public string? direccion { get; set; }
        //public string? barrio { get; set; }
        //public string? localizacion { get; set; }

        //public int? estratoId { get; set; }
        //public decimal areaPrivada { get; set; }
        //public decimal areaConstruida { get; set; }

        //public int? numeroPiso { get; set; }
        //public decimal areaFondo { get; set; }
        //public int? tiempoConstruidoId { get; set; }
        //public int? numeroHabitacionId { get; set; }
        //public int? numeroBanoId { get; set; }
        //public int? numeroParqueaderoId { get; set; }
        //public int? tipoParqueaderoId { get; set; }
        //public int? caracteristicaParqueaderoId { get; set; }


        //public string? caracteristicas { get; set; }


        //public string? video { get; set; }
        //public string? descripcion { get; set; }
        //public int anioConstruccion { get; set; }
        //public int? estadoPropiedadId { get; set; }


        //public int? agenteId { get; set; }


        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public string? CreateUser { get; set; }
        //public string? ModifiedUser { get; set; }

        //[Display(Name = "Activo")]
        //public bool isActive { get; set; }
    }
}

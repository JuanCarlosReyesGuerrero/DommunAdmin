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

        [Display(Name = "Area de Fondo M2")]
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

        public TipoOfertaDto? tipoOferta { get; set; }
        public TipoPropiedadDto? tipoPropiedad { get; set; }
        public EstadoPropiedadDto? estadoPropiedad { get; set; }
        public CiudadDto? ciudad { get; set; }
        public AgenteDto? agente { get; set; }
        public EstratoDto? estrato { get; set; }

        public TiempoConstruidoDto? tiempoConstruido { get; set; }
        public TipoParqueaderoDto? tipoParqueadero { get; set; }
        public CaracteristicaParqueaderoDto? caracteristicaParqueadero { get; set; }
        public NumeroBanoDto? numeroBano { get; set; }
        public NumeroHabitacionDto? numeroHabitacion { get; set; }
        public NumeroParqueaderoDto? numeroParqueadero { get; set; }
    }
}

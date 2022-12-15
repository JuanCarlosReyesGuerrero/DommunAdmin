using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DommunAdmin.Models
{
    public class CaracteristicaDto
    {
        [HiddenInput]
        [Display(Name = "Id")]
        public int? id { get; set; }
  
        [Display(Name = "C�digo")]
        public string? codigo { get; set; }
        
        [Display(Name = "Tipo Caracter�stica")]
        public int? tipoCaracteristicaId { get; set; }
        
        [Display(Name = "Nombre")]
        public string? nombre { get; set; }
        
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }        
        public string? createUser { get; set; }
        public string? modifiedUser { get; set; }
        
        [Display(Name = "Activo")]
        public bool isActive { get; set; }
    }
}

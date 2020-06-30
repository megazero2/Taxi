using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Taxi.Web.Data.Entities
{
    public class TaxyEntity
    {
        public int Id { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "El {0} campo debe tener {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^([A-Za-z]{3}\d{3})$", ErrorMessage = "El campo {0} Debe iniciar con tres caracteres y terminar con tres nnumeros.")]
        public string Placa { get; set; }

        public ICollection<ViajeEntity> Viajes { get; set; }
        public UserEntity User { get; set; }
    }
}

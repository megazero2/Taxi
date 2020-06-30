using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Taxi.Web.Data.Entities
{
    public class ViajeEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha final")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime? EndDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha final")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime? EndDateLocal => EndDate?.ToLocalTime();

        [MaxLength(100, ErrorMessage = "The {0} field must have {1} characters.")]
        public string Source { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field must have {1} characters.")]
        public string Target { get; set; }

        public float Qualification { get; set; }

        public double SourceLatitude { get; set; }

        public double SourceLongitude { get; set; }

        public double TargetLatitude { get; set; }

        public double TargetLongitude { get; set; }
        public string Remarks { get; set; }

        public TaxyEntity Taxi { get; set; }

        public ICollection<ViajeEntity> Viajes { get; set; }
        public UserEntity User { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeetGroupApp.Models
{
    public class Reuniao
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0}")]
        public TimeSpan HoraInicio { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataFim { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0}")]
        public TimeSpan HoraFim { get; set; }

        
        public int NumeroSala { get; set; }

        [Display(Name = "Número de Pessoas")]
        public int Pessoas { get; set; }

        public bool Computador { get; set; }

        public bool Internet { get; set; }

        public bool Televisor { get; set; }
    }
}
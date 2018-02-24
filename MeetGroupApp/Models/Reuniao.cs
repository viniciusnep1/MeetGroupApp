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

        public DateTime DataInicio { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public DateTime DataFim { get; set; }

        public TimeSpan HoraFim { get; set; }

        public Sala Sala { get; set; }
    }
}
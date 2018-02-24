using System;

namespace MeetGroupApp.Models
{
    public class Sala
    {
        public Guid Id { get; set; }

        public int NumeroSala { get; set; }

        public int Pessoas { get; set; }

        public bool Disponibilidade { get; set; }

        public bool Computador { get; set; }

        public bool Internet { get; set; }

        public bool Televisor { get; set; }
    }
}
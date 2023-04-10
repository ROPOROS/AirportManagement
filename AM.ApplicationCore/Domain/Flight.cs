using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }

        public DateTime EffictiveArriaval { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }

        public ICollection<Passanger> Passangers { get; set; }// proproete de navigation

        [ForeignKey("Plane")]
        public int PlaneFk { get; set; }
        //[ForeignKey("PlaneFK")]
        public Plane Plane { get; set; }

        public string Airline { get; set; }
    }
}

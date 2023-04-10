using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class ReservationTicket
    {

        public DateTime DateReservation { get; set; }

        public double Prix { get; set; }

        [ForeignKey("PassangerFk")]
        public Passanger Passanger { get; set; }

        public string PassangerFk { get; set; }

        [ForeignKey("TicketFk")]
        public Ticket Ticket { get; set; }

        public int TicketFk { get; set; }
    }
}

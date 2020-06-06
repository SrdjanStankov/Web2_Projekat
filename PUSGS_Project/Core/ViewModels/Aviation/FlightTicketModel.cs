using Core.Entities;

namespace Core.ViewModels.Aviation
{
    public class FlightTicketModel
    {
        public long Id { get; set; }

        public string TicketOwnerEmail { get; set; }

        public long FlightId { get; set; }

        public long? FlightSeatId { get; set; }

        public double Discount { get; set; }

        public bool CanReject { get; set; }

        public FlightTicketModel()
        {
        }

        public FlightTicketModel(FlightTicket ticket)
        {
            if (ticket == null)
                return;

            Id = ticket.Id;
            TicketOwnerEmail = ticket.TicketOwnerEmail;
            FlightId = ticket.FlightId;
            FlightSeatId = ticket.FlightSeatId;
            Discount = ticket.Discount;
        }
    }
}
using Core.Entities;
using System;

namespace Core.ViewModels.Aviation
{
    public class FlightTicketDetailsModel
    {
        public long Id { get; set; }

        public string TicketOwnerEmail { get; set; }
        public FlightModel Flight { get; set; }

        public FlightSeatModel FlightSeat { get; set; }

        public double Discount { get; set; }

        public DateTime? DateCreated { get; set; }

        public double Rating { get; set; }

        public bool Accepted { get; set; }
        public bool CanCancel { get; set; }
        public bool CanRate { get; set; }

        public double TotalPrice { get; set; }

        public FlightTicketDetailsModel(FlightTicket ticket)
        {
            Id = ticket.Id;
            TicketOwnerEmail = ticket.TicketOwnerEmail;
            Flight = new FlightModel(ticket.Flight);
            FlightSeat = new FlightSeatModel(ticket.FlightSeat);
            Discount = ticket.Discount;
            DateCreated = ticket.DateCreated;
            Accepted = ticket.Accepted;
            Rating = ticket.Rating;
            CanCancel = ticket.Flight.CanCancelReservation();
            CanRate = ticket.Flight.CanRate();
            TotalPrice = ticket.Flight.GetTotalPrice(ticket.Discount);
        }
    }
}
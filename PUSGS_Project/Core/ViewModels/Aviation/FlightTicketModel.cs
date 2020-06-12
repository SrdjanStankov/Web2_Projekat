using Core.Entities;
using Core.Helpers;
using System;

namespace Core.ViewModels.Aviation
{
    public class FlightTicketModel
    {
        public long Id { get; set; }

        public string TicketOwnerEmail { get; set; }

        public long FlightId { get; set; }

        public long? FlightSeatId { get; set; }

        public double Discount { get; set; }

        public bool CanCancel { get; set; } = true;
        public bool CanRate { get; set; } = true;

        public bool Accepted { get; set; }

        public double Rating { get; set; }

        public FlightTicketModel()
        {
        }

        public FlightTicketModel(FlightTicket ticket) : this()
        {
            if (ticket == null)
                return;

            Id = ticket.Id;
            TicketOwnerEmail = ticket.TicketOwnerEmail;
            FlightId = ticket.FlightId;
            FlightSeatId = ticket.FlightSeatId;
            Discount = ticket.Discount;
            Accepted = ticket.Accepted;
            Rating = ticket.Rating;
            CanCancel = ticket.Flight?.CanCancelReservation() ?? true;
            CanRate = ticket.Flight?.CanRate() ?? true;
        }
    }
}
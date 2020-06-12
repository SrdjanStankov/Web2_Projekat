﻿using Core.Enumerations;
using Core.Helpers;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Flight
    {
        public long Id { get; set; }

        public long AviationCompanyId { get; set; }
        public AviationCompany AviationCompany { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public double TravelLength { get; set; }
        public double TicketPrice { get; set; }
        public int NumberOfChangeovers { get; set; }

        public Location From { get; set; }
        public Location To { get; set; }

        public ICollection<FlightTicket> Tickets { get; set; }
        public ICollection<FlightSeat> Seats { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        public int MaxSeatsPerRow { get; set; } = 4;

        public bool CanCancelReservation()
        {
            return DepartureTime == null
                || DateTimeHelper.IsLessInHours(DateTime.Now, DepartureTime.Value, AppConsts.MinAllowedFlightTicketHourDiff);
        }

        public bool CanRate()
        {
            return DepartureTime == null
                || !DateTimeHelper.IsLessInHours(DateTime.Now, DepartureTime.Value, 0);
        }

        public Flight()
        {
            Tickets = new HashSet<FlightTicket>();
            Seats = new HashSet<FlightSeat>();
            Ratings = new HashSet<Rating>();
        }
    }
}
﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.ViewModels.Aviation
{
    public class FlightModel
    {
        public long Id { get; set; }

        public long AviationCompanyId { get; set; }
        public string AviationCompanyName { get; set; }

        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public double TravelLength { get; set; }
        public double TicketPrice { get; set; }
        public int NumberOfChangeovers { get; set; }

        public LocationModel From { get; set; }
        public LocationModel To { get; set; }

        public ICollection<FlightTicketModel> Tickets { get; set; }
        public ICollection<FlightSeatModel> Seats { get; set; }

        public int MaxSeatsPerRow { get; set; } = 4;

        public double AverageRating { get; set; } = 0;

        public FlightModel()
        {
        }

        public FlightModel(Flight flight)
        {
            if (flight == null)
                return;

            Id = flight.Id;
            AviationCompanyId = flight.AviationCompanyId;
            AviationCompanyName = flight.AviationCompany?.Name ?? "";
            DepartureTime = flight.DepartureTime;
            ArrivalTime = flight.ArrivalTime;
            TravelLength = flight.TravelLength;
            TicketPrice = flight.TicketPrice;
            NumberOfChangeovers = flight.NumberOfChangeovers;

            From = new LocationModel(flight.From);
            To = new LocationModel(flight.To);

            Tickets = flight.Tickets.Select(t => new FlightTicketModel(t)).ToList();
            Seats = flight.Seats.Select(s => AviationMapper.MapSeat(s, flight.Tickets)).ToList();

            AverageRating = flight.GetAverageRating();

            MaxSeatsPerRow = flight.MaxSeatsPerRow;
        }
    }
}
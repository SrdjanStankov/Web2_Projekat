using System;

namespace Core.ViewModels.Aviation.Requests
{
    public class AddFlightRequestModel
    {
        public long AviationCompanyId { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public double TravelLength { get; set; }
        public double TicketPrice { get; set; }
        public int NumberOfChangeovers { get; set; }

        public LocationModel From { get; set; }
        public LocationModel To { get; set; }
    }
}
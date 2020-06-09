using System;

namespace Core.ViewModels.Aviation.Requests
{
    public class UpdateFlightRequestModel
    {
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public double? TravelLength { get; set; }
        public double? TicketPrice { get; set; }
        public int? NumberOfChangeovers { get; set; }
    }
}
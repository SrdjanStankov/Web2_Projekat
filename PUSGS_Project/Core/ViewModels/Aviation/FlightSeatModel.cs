using Core.Entities;
using System.Runtime.InteropServices;

namespace Core.ViewModels.Aviation
{
    public class FlightSeatModel
    {
        public long Id { get; set; }

        public long FlightId { get; set; }
        public long? ReservedById { get; set; }

        public FlightSeatModel()
        {
        }

        public FlightSeatModel(FlightSeat seat)
        {
            Id = seat.Id;
            FlightId = seat.FlightId;
        }
    }
}
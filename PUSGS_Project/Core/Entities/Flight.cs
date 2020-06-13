using Core.Enumerations;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public class Flight
    {
        public long Id { get; set; }
        public long AviationCompanyId { get; set; }
        public AviationCompany AviationCompany { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public Location From { get; set; }
        public Location To { get; set; }
        public int MaxSeatsPerRow { get; set; } = 4;
        public int NumberOfChangeovers { get; set; }
        public double TicketPrice { get; set; }
        public double TravelLength { get; set; }
        public ICollection<FlightTicket> Tickets { get; set; }
        public ICollection<FlightSeat> Seats { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        public Flight()
        {
            Tickets = new HashSet<FlightTicket>();
            Seats = new HashSet<FlightSeat>();
            Ratings = new HashSet<Rating>();
        }

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

        public double GetAverageRating()
        {
            return Tickets.Where(t => t.Rating > 0).Select(t => t.Rating).DefaultIfEmpty().Average();
        }

        /// <summary>
        /// Calculates total price based on discount (%)
        /// </summary>
        /// <param name="discount">Value in range [0,100]</param>
        /// <returns>Total price</returns>
        public double GetTotalPrice(double discount)
        {
            discount = Clip(discount, min: 0, max: 100);
            discount /= 100;

            return TicketPrice * discount;
        }

        private static double Clip(double value, double min, double max)
        {
            if (value > max)
            {
                return max;
            }
            return value < min ? min : value;
        }
    }
}
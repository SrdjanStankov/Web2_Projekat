using System;

namespace Core.ViewModels.CarViewModels
{
    public class CarReservationModel
    {
        public int PassengerNumber { get; set; }
        public string Type { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime TakeDate { get; set; }
        public int MaxCost { get; set; }
    }
}

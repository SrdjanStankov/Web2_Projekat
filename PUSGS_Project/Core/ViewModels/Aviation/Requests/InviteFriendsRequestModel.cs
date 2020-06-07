using System.Collections.Generic;

namespace Core.ViewModels.Aviation.Requests
{
    public class InviteFriendsRequestModel
    {
        public IEnumerable<FlightTicketModel> FlightTickets { get; set; }
    }
}
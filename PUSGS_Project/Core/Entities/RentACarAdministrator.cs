namespace Core.Entities
{
    public class RentACarAdministrator : User
    {
        public RentACarAdministrator() : base()
        {
            IsRentACarAdmin = true;
        }
    }
}
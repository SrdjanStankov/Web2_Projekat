namespace Core.Entities
{
    public class AviationAdministrator : User
    {
        public AviationAdministrator() : base()
        {
            IsAviationAdmin = true;
        }
    }
}
namespace Core.Entities
{
    public class SystemAdministrator : User
    {
        public SystemAdministrator() : base()
        {
            IsSystemAdmin = true;
        }
    }
}
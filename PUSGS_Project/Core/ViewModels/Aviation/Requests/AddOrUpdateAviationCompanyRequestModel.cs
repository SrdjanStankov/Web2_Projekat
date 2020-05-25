namespace Core.ViewModels.Aviation.Requests
{
    public class AddOrUpdateAviationCompanyRequestModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationModel Address { get; set; }
    }
}
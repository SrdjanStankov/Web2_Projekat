using Core.Entities;

namespace Core.ViewModels.RentACar
{
    public class BranchesModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long RentACarId { get; set; }

        public BranchesModel(Branch item)
        {
            Id = item.Id;
            Name = item.Name;
            Address = item.Address;
            RentACarId = item.RentACarId;
        }
    }
}
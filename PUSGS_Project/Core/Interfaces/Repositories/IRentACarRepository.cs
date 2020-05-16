using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IRentACarRepository
    {
        RentACar Get(long id);

        void Add(RentACar rentACar);

        void Delete(long id);

        void Update(RentACar rentACar);
    }
}

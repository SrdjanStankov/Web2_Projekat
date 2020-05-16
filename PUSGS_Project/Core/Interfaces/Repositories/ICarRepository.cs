using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICarRepository
    {
        Car Get(long id);

        void Add(Car car);

        void Delete(long id);

        void Update(Car car);
    }
}

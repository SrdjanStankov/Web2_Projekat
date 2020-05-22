using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Persistance.Repositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly ApplicationDbContext context;

        public RentACarRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(RentACar rentACar)
        {
            context.Add(rentACar);
            context.SaveChanges();
        }

        public void Delete(long id) => throw new NotImplementedException();

        public RentACar Get(long id) => context.Find<RentACar>(id);

        public IEnumerable<RentACar> GetAll() => context.Set<RentACar>().AsEnumerable();

        public void Update(RentACar rentACar) => throw new NotImplementedException();
    }
}

using DDD.NET.CORE.DOMAIN.ENTITIES.Car;
using System.Collections.Generic;

namespace DDD.NET.CORE.DOMAIN.Repositories.Contracts
{
    public interface ICarRepository
    {
        string GetEngine();
        Car Create(Car carEntitie);
        void Update(Car carEntitie);
        void Delete(int id);
        Car Get(int id);
        List<Car> Get();
    }
}

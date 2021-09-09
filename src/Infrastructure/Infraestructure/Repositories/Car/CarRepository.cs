using DDD.NET.CORE.DOMAIN.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DDD.NET.CORE.INFRAESTRUCTURE.Repositories.Car
{
    using DDD.NET.CORE.DOMAIN.ENTITIES.Car;

    public class CarRepository : ICarRepository
    {
        private ApplicationDbContext _dbContext;
        public CarRepository()
        {
            _dbContext = new ApplicationDbContext();

        }
        public Car Create(Car carEntitie)
        {
            _dbContext.Cars.Add(carEntitie);
            _dbContext.SaveChanges();
            return carEntitie;
        }
        public void Delete(int id)
        {
            _dbContext.Cars.Remove(_dbContext.Cars.Find(id));
            _dbContext.SaveChanges();
        }
        public Car Get(int id)
        {
            return _dbContext.Cars.Find(id);
        }
        public List<Car> Get()
        {
            return _dbContext.Cars.OrderBy(x => x.Name).ToList();
        }
        public string GetEngine()
        {
            return "V8";
        }
        public void Update(Car carEntitie)
        {
            var car = _dbContext.Cars.Find(carEntitie.Id);
            car.Name = carEntitie.Name;
            car.Model = carEntitie.Model;
            car.Engine = carEntitie.Engine;
            _dbContext.Cars.Update(car);
            _dbContext.SaveChanges();
        }
    }
}
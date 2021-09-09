using DDD.NET.CORE.DOMAIN.Repositories.Contracts;
using System.Collections.Generic;
using Mapster;

namespace DDD.NET.CORE.APPLICATION.Application.Services.Car
{
    using DDD.NET.CORE.APPLICATION.Application.Services.DTO.Car;
    using DDD.NET.CORE.DOMAIN.ENTITIES.Car;    

    public class CarService : ICarService
    {        
        ICarRepository _domainCarRepository;

        public CarService(ICarRepository domainCarRepository)
        {
            _domainCarRepository = domainCarRepository;
        }

        public CarDTO Create(CarCreateDTO CarCreateDTOEntitie)
        {
            var car = CarCreateDTOEntitie.Adapt<Car>();
            car = _domainCarRepository.Create(car);
            return car.Adapt<CarDTO>();
        }

        public void Delete(int id)
        {
            _domainCarRepository.Delete(id);
        }

        public CarDTO GetCar(int id)
        {
            var car = _domainCarRepository.GetCar(id);
            return car.Adapt<CarDTO>();
        }

        public List<CarDTO> GetCars()
        {
            var car = _domainCarRepository.GetCars();
            return car.Adapt<List<CarDTO>>();
        }

        public void Update(CarDTO CarDTOEntitie)
        {
            var car = CarDTOEntitie.Adapt<Car>();
            _domainCarRepository.Update(car);
        }
    }
}
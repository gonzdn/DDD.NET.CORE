using System.Collections.Generic;

namespace DDD.NET.CORE.APPLICATION.Application.Services.Car
{
    using DDD.NET.CORE.APPLICATION.Application.Services.DTO.Car;
    public interface ICarService
    {
        CarDTO Create(CarCreateDTO carEntitie);
        void Update(CarDTO carEntitie);
        void Delete(int id);
        CarDTO GetCar(int id);
        List<CarDTO> GetCars();
    }
}
using DDD.NET.CORE.APPLICATION.Application.Services.Car;
using DDD.NET.CORE.APPLICATION.Application.Services.DTO.Car;

namespace GraphQLServer.GraphQL
{
    public class Mutation
    {
        #region Property  
        private readonly ICarService _carService;
        #endregion

        #region Constructor  
        public Mutation(ICarService carService)
        {
            _carService = carService;
        }
        #endregion

        public CarDTO Create(CarCreateDTO car)
        {
            return _carService.Create(car);            
        }
        public bool Delete(int id)
        {
            _carService.Delete(id);
            return true;
        }
    }
}
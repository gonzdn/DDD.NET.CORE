using DDD.NET.CORE.APPLICATION.Application.Services.Car;
using DDD.NET.CORE.APPLICATION.Application.Services.DTO.Car;
using System.Linq;

namespace GraphQLServer.GraphQL
{
    public class Query
    {
        #region Property  
        private readonly ICarService _carService;
        #endregion

        #region Constructor  
        public Query(ICarService carService)
        {
            _carService = carService;
        }
        #endregion

        public IQueryable<CarDTO> Cars()
        {
            return _carService.GetCars().AsQueryable();
        }
    }
}

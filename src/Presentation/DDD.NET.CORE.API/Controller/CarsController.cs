using DDD.NET.CORE.APPLICATION.Application.Services.Car;
using DDD.NET.CORE.APPLICATION.Application.Services.DTO.Car;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DDD.NET.CORE.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        // GET api/cars
        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonConvert.SerializeObject(carService.GetCars());
        }

        // GET api/cars/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return JsonConvert.SerializeObject(carService.GetCar(id));
        }

        // POST api/cars
        [HttpPost]
        public ActionResult<string> Post(CarCreateDTO carPost)
        {            
            return JsonConvert.SerializeObject(carService.Create(carPost));
        }

        // PUT api/cars/5
        [HttpPut("{id}")]
        public void Put(int id, CarDTO carPost)
        {
            CarDTO carro = new CarDTO();
            carro = carPost;
            carro.Id = id;
            carService.Update(carro);
        }

        // DELETE api/cars/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            carService.Delete(id);
        }
    }
}
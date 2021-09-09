using System.Collections.Generic;
using DDD.NET.CORE.APPLICATION.Application.Services.Car;
using DDD.NET.CORE.APPLICATION.Application.Services.DTO.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(typeof(List<CarDTO>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(carService.Get());
        }

        // GET api/cars/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CarDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var response = carService.Get(id);
            if(response == null) return NotFound();
            return Ok();
        }

        // POST api/cars
        [HttpPost]
        [ProducesResponseType(typeof(CarDTO), StatusCodes.Status200OK)]
        public IActionResult Post(CarCreateDTO carPost)
        {
            return Ok(carService.Create(carPost));
        }

        // PUT api/cars/5
        [HttpPut]
        [ProducesResponseType(typeof(CarDTO), StatusCodes.Status200OK)]
        public IActionResult Put(CarDTO carPost)
        {
            carService.Update(carPost);
            return Ok();
        }

        // DELETE api/cars/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CarDTO), StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            carService.Delete(id);
            return Ok();
        }
    }
}
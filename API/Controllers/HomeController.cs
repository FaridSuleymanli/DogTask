using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.DAL;
using TestTask.Entities.DTOs;
using TestTask.Entities.Models;

namespace TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly TestTaskContext _context;
        private readonly IMapper _mapper;
        public HomeController(TestTaskContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Ping")]
        public ActionResult Ping()
        {
            return Ok("Dogs house service. Version 1.0.1");
        }

        [HttpGet]
        [Route("Dogs")]
        public async Task<ActionResult> GetAllDogs()
        {
            IEnumerable<DogsForGetDTO> dogs = _mapper.Map<IEnumerable<DogsForGetDTO>>(await _context.Dogs.ToListAsync());
            if (dogs == null)
            {
                return NotFound(new { message = "Dog list is empty" });
            }
            return Ok(dogs);
        }

        [HttpGet]
        [Route("Dogs/{id}")]
        public async Task<ActionResult> GetDogById(int id)
        {
            var dog = _mapper.Map<Dog, DogsForGetDTO>(await _context.Dogs.FirstOrDefaultAsync(d => d.Id == id));
            if (dog == null)
            {
                return BadRequest(new { error = $"Object with the given {id} was not found"});
            }
            return Ok(dog);
        }

        [HttpPost]
        [Route("Dog")]
        public async Task<ActionResult> CreateDog([FromBody] DogsForCreateDTO dog)
        {
            var newDog = _mapper.Map<Dog>(dog);

            await _context.Dogs.AddAsync(newDog);
            await _context.SaveChangesAsync();
            return Ok(dog);
        }
    }
}

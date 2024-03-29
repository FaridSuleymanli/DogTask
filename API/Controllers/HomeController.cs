﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Business.Abstract;
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
        private readonly IDogRepository _repository;
        public HomeController(TestTaskContext context, IMapper mapper, IDogRepository repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        [Route("Ping")]
        public ActionResult Ping()
        {
            return Ok("Dogs house service. Version 1.0.1");
        }

        [HttpGet]
        [Route("Dogs")]
        public ActionResult GetAllDogs(string attribute, string order, int page, int pageLimit)
        {
            //IEnumerable<DogsForGetDTO> dogs = _mapper.Map<IEnumerable<DogsForGetDTO>>(await _context.Dogs.ToListAsync());
            //if (dogs == null)
            //{
            //    return NotFound(new { message = "Dog list is empty" });
            //}
            var dogs = _repository.GetAllDogs(attribute, order, page, pageLimit);
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
            var existedDog = await _context.Dogs.FirstOrDefaultAsync(d => d.Name == dog.Name);
            if (existedDog != null)
            {
                return BadRequest(new { error = "Dog with the given name is already exist" });
            }

            var newDog = _mapper.Map<Dog>(dog);

            await _context.Dogs.AddAsync(newDog);
            await _context.SaveChangesAsync();
            return Ok(dog);
        }
    }
}

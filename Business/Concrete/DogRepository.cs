using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Business.Abstract;
using TestTask.DAL;
using TestTask.Entities.DTOs;
using TestTask.Entities.Models;

namespace TestTask.Business.Concrete
{
    public class DogRepository : IDogRepository
    {
        private readonly TestTaskContext _context;
        private readonly IMapper _mapper;
        //public static int PAGE_SIZE { get; set; } = 5;
        public DogRepository(TestTaskContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Dog> GetAllDogs(string attribute, string order, int page, int pageLimit)
        {
            var dogs = _context.Dogs.AsQueryable();
            #region Sorting
            dogs = dogs.OrderBy(d => d.Id);
            if (!string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(order))
            {
                if (attribute == "color")
                {
                    switch (order)
                    {
                        case "desc": dogs = dogs.OrderByDescending(d => d.Color);
                            break;
                        case "asc": dogs = dogs.OrderBy(d => d.Color);
                            break;
                    }
                }
                else if (attribute == "tail_length")
                {
                    switch (order)
                    {
                        case "desc":
                            dogs = dogs.OrderByDescending(d => d.Tail_Length);
                            break;
                        case "asc":
                            dogs = dogs.OrderBy(d => d.Tail_Length);
                            break;
                    }
                }
                else if (attribute == "weight")
                {
                    switch (order)
                    {
                        case "desc":
                            dogs = dogs.OrderByDescending(d => d.Weight);
                            break;
                        case "asc":
                            dogs = dogs.OrderBy(d => d.Weight);
                            break;
                    }
                }
            }
            #endregion
            var result = PaginationDTO<Dog>.Create(dogs, page, pageLimit);

            return dogs.ToList();
        }
    }
}

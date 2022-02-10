using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Entities.DTOs
{
    public class DogsForCreateDTO
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Tail_Length { get; set; }
        public int Weight { get; set; }
    }
}

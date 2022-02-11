using FluentValidation;
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

    public class DogValidator : AbstractValidator<DogsForCreateDTO>
    {
        public DogValidator()
        {
            RuleFor(d => d.Name).NotNull().WithMessage("Dog name cannot be empty or null");
            RuleFor(d => d.Tail_Length).GreaterThan(0).WithMessage("Tail length has to be greater than 0");
        }
    }
}

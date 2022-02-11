using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Entities.Models;

namespace TestTask.DAL
{
    public class TestTaskContext : DbContext
    {
        public TestTaskContext(DbContextOptions<TestTaskContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfigurationsFromAssembly(typeof(Dog).Assembly);
            model.Entity<Dog>().HasData
                (
                    new Dog { Id = 1, Name = "Neo", Color = "red & amber", Tail_Length = 22, Weight = 32 },
                    new Dog { Id = 2, Name = "Jessy", Color = "black & white", Tail_Length = 7, Weight = 14 }
                );
        }

        public virtual DbSet<Dog> Dogs { get; set; }
    }
}

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
        public virtual DbSet<Dog> Contacts { get; set; }
    }
}

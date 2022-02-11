using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Entities.Models;

namespace TestTask.Business.Abstract
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs(string attribute, string order, int page = 1);
    }
}

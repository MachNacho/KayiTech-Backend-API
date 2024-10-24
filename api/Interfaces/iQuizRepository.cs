using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface iQuizRepository
    {
       Task<List<Quiz>> GetALLAsync();
        Task<List<Quiz>> GetById(int id);
        
    }
}
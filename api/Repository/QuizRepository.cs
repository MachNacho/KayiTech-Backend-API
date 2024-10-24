using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class QuizRepository : iQuizRepository
    {
        private readonly ApplicationDBContext _context;
        public QuizRepository(ApplicationDBContext context) { _context = context; }//DB
        public async Task<List<Quiz>> GetALLAsync()
        {
            return await _context.quiz.ToListAsync();
        }

        public Task<List<Quiz>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
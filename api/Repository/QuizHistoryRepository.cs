using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class QuizHistoryRepository : iQuizHistoryRepository
    {
        public QuizHistoryRepository()
        {
        }
        public Task<List<QuizHistory>> GetByQuizID()
        {
            throw new NotImplementedException();
        }
    }
}
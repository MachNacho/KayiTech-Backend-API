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
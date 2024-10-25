using api.Models;

namespace api.Interfaces
{
    public interface iQuizHistoryRepository
    {
          Task<List<QuizHistory>> GetByQuizID();
    }
}
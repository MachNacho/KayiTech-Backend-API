using api.DTO.Quiz;
using api.Dtos.Question;
using api.Models;

namespace api.Interfaces
{
    public interface iQuizRepository
    {
        Task<List<Quiz>> GetALLAsync();
        Task<List<QuestionDTO>> GetById(int id);
        Task<Quiz> CreateQuizAsync(CreateQuizRequestDTO quizDTO);
        Task<Quiz> UpdateQuizAsync(Quiz quizModel,CreateQuizRequestDTO quizDTO);
        void DeleteQuizAsync(Quiz model);
    }
}
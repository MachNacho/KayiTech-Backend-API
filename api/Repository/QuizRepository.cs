using api.Data;
using api.DTO.Quiz;
using api.Dtos.Question;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class QuizRepository : iQuizRepository
    {
        private readonly ApplicationDBContext _context;
        public QuizRepository(ApplicationDBContext context) { _context = context; }//DB

        public async Task<Quiz> CreateQuizAsync(CreateQuizRequestDTO quizDTO)
        {
            var quizModel = quizDTO.ToQuizFromCreateDTO();
            await _context.quiz.AddAsync(quizModel);
            await _context.SaveChangesAsync();
            return(quizModel);

        }

        public void DeleteQuizAsync(Quiz model)
        {
            _context.quiz.Remove(model);
            _context.SaveChanges();
        }

        public async Task<List<Quiz>> GetALLAsync()
        {
            return await _context.quiz.Where(q => _context.quizQuestions.Any(o => o.quizID == q.Id)).ToListAsync();

        }
        public async Task<List<QuestionDTO>> GetById(int id)
        {
            //throw new NotImplementedException();
            return await _context.quizQuestions.Where(s => s.quizID == id).Select(s=>s.toQuestionDTO()).ToListAsync();
        }

        public async Task<Quiz> UpdateQuizAsync(Quiz quizModel, CreateQuizRequestDTO quizDTO)
        {
            quizModel.quizTitle = quizDTO.quizTitle;
            quizModel.SubjectCategory = quizDTO.SubjectCategory;
            quizModel.TimeLimitSeconds = quizDTO.TimeLimitSeconds;
            _context.SaveChanges();
            return(quizModel);
        }
    }
}
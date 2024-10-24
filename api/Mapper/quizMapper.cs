using api.DTO;
using api.DTO.Quiz;
using api.Models;

namespace api.Mapper
{
    public static class quizMapper
    {
        public static quizDTO toQuizDTO(this Quiz quizModel)
        {
            return new quizDTO{
                quizName = quizModel.quizTitle,
                QuizsubjectCatagory = quizModel.SubjectCategory,
                quizQuestions = quizModel.Questions.ToList(),
            };
        }
        public static Quiz ToQuizFromCreateDTO(this CreateQuizRequestDTO createQuizRequestDTO)
        {
            return new Quiz{
                quizTitle = createQuizRequestDTO.quizName,
                SubjectCategory = createQuizRequestDTO.QuizsubjectCatagory
            };
        }
    }
}
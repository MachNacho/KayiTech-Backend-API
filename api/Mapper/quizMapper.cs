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
                Id = quizModel.Id,
                quizTitle = quizModel.quizTitle,
                CreatedOn = quizModel.CreatedOn,
                TimeLimitSeconds = quizModel.TimeLimitSeconds,
                SubjectCategory = quizModel.SubjectCategory,
                Questions = quizModel.Questions.ToList(),

            };
        }
        public static Quiz ToQuizFromCreateDTO(this CreateQuizRequestDTO createQuizRequestDTO)
        {
            return new Quiz{
                quizTitle = createQuizRequestDTO.quizTitle,
                SubjectCategory = createQuizRequestDTO.SubjectCategory,
                TimeLimitSeconds = createQuizRequestDTO.TimeLimitSeconds
            };
        }
    }
}
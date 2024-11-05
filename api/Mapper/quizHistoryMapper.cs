using api.Dtos.QuizHistory;
using api.Models;

namespace api.Mapper
{
    public static class quizHistoryMapper
    {
        public static QuizHistory ToHistoryFromDTO(this NewHistoryDTO quizModel,QuizUser s)
        {
            return new QuizHistory{
                quizID = quizModel.quizID,
                Score = quizModel.Score,
                userID = s.Id,
                TimeTakenSeconds = quizModel.TimeTakenSeconds
            };
        }
    }
}
using api.Dtos.Question;
using api.Models;

namespace api.Mapper
{
    public static class quizQuestionMapper
    {
          public static QuizQuestions ToQuestionFromCreateDTO(this CreateQuestionDTO createQUESTIONDTO)
        {
            return new QuizQuestions{
                quizID = createQUESTIONDTO.quizID,
                QuestionTitle = createQUESTIONDTO.QuestionTitle,
                QuestionAnswer = createQUESTIONDTO.QuestionAnswer,
                QuestionOption1 = createQUESTIONDTO.QuestionOption1,
                QuestionOption2 = createQUESTIONDTO.QuestionOption2,
                QuestionOption3 = createQUESTIONDTO.QuestionOption3
            };
        }
    }
}

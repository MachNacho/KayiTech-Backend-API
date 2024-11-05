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
        public static QuestionDTO toQuestionDTO(this QuizQuestions O)
        {
            return new QuestionDTO{
                QuestionTitle = O.QuestionTitle,
                QuestionAnswer = O.QuestionAnswer,
                QuestionOption1 = O.QuestionOption1,
                QuestionOption2 = O.QuestionOption2,
                QuestionOption3 = O.QuestionOption3
            };        
        }
    }
}

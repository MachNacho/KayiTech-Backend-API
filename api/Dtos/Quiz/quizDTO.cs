using api.Models;

namespace api.DTO
{
    public class quizDTO
    {
        public string quizName { get; set; }
        public string QuizsubjectCatagory{ get; set; }
        public List<QuizQuestions> quizQuestions {get;set;}
    }
}
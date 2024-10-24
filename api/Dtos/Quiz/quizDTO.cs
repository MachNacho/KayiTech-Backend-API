using api.Models;

namespace api.DTO
{
    public class quizDTO
    {
        public string quizTitle { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int TimeLimitSeconds { get; set; }
        public string SubjectCategory { get; set; }
        public List<QuizQuestions> Questions {get; set;} = new List<QuizQuestions>();//"Foreign key"
    }
}
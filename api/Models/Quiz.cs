namespace api.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string quizTitle { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int TimeLimitSeconds { get; set; }
        public string SubjectCategory { get; set; }
        public List<QuizHistory> History {get; set;} = new List<QuizHistory>();//"Foreign key"
        public List<QuizQuestions> Questions {get; set;} = new List<QuizQuestions>();//"Foreign key"
    }
}
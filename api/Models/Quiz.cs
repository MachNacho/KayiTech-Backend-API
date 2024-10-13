namespace api.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string quizTitle { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int TimeLimitSeconds { get; set; }
        public string SubjectCategory { get; set; }
    }
}
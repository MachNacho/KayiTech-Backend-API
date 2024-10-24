namespace api.DTO.Quiz
{
    public class CreateQuizRequestDTO
    {
        public string quizTitle { get; set; }
        public int TimeLimitSeconds { get; set; }
        public string SubjectCategory { get; set; }
    }
}
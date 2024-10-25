namespace api.Models
{
    public class QuizQuestions
    {
        public int Id { get; set;}
        public Quiz quiz {get; set;}
        public int quizID { get; set; }
        public string QuestionTitle { get; set;}
        public string QuestionAnswer { get; set;}
        public string QuestionOption1 { get; set;}
        public string QuestionOption2 { get; set;}
        public string QuestionOption3 { get; set;}
    }
}
namespace api.Dtos.QuizHistory
{
    public class NewHistoryDTO
    {

        public int quizID { get; set; }

        public float Score { get; set;}
        public int TimeTakenSeconds { get; set; }
    }
}
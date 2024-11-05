namespace api.Dtos.QuizHistory
{
    public class historyDTO
    {
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public float Score { get; set;}
        public int TimeTakenSeconds { get; set; }
    }
}
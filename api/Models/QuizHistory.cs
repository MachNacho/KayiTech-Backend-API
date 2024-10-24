using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class QuizHistory
    {
        public int Id { get; set; }
        public Quiz quiz {get; set;}
        public int quizID { get; set; }
        public QuizUser user{ get; set; }
        public string userID { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public float Score { get; set;}
        public int TimeTakenSeconds { get; set; }
    }
}
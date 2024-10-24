using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.QuizHistory
{
    public class NewHistoryDTO
    {
        public float Score { get; set;}
        public int TimeTakenSeconds { get; set; }
    }
}
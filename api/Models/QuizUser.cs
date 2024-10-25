using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class QuizUser: IdentityUser // Inheirts from identity user class
    {
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set;}
        public List<QuizHistory> History {get; set;} = new List<QuizHistory>();//"Foreign key"
    }
}
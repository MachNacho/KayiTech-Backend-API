using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account
{
    public class LoginDTO //used to mask input data(allowing only neccasary data for login in) 
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
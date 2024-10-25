using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account
{
    public class RegisterDTO //used to mask input data(allowing only neccasary data for registering) 
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? UserFirstName { get; set; }
        [Required]
        public string? UserLastName { get; set;}
    }
}
namespace api.Dtos.Account
{
    public class NewUserDTO//output dto for the model User, only returning neccassary information
    {
        public string? UserName { get; set;}
        public string? Email { get; set;}
        public string? Token { get; set;}
        public string? userID { get; set;}
    }
}
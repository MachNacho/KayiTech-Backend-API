using api.Models;

namespace api.Interfaces
{
    public interface iTokenService // interface linking the service to the controller
    {
        string createToken( QuizUser user);
        
    }
}
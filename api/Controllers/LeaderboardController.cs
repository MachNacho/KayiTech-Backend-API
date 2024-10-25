using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/leaderboard")]
    //TODO set up controller
    public class LeaderboardController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public LeaderboardController(ApplicationDBContext context){
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        { 
            return Ok(await _context.QuizHistory.OrderBy(x => x.Score).Where(x => x.quizID == id).ToListAsync());
        }
    }
}
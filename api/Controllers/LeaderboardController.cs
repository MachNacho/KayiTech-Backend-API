using api.Data;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("/leaderboard")]
    //TODO do repo
    public class LeaderboardController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public LeaderboardController(ApplicationDBContext context){
            _context = context;
        }
        [HttpGet("Quiz{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        { 
            var a = await _context.QuizHistory.Include(x => x.user)
            .Where(x => x.quizID == id)
            .OrderByDescending(x => x.Score) // Primary order: highest score first
            .ThenBy(x => x.TimeTakenSeconds) // Secondary order: shortest time first
            .ToListAsync();

            return Ok(a.Select(a=>a.ToLeaderboardDTO()));
        }
    }
}
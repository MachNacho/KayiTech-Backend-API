using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/history")]
    [ApiController]
    public class QuizHistoryController : Controller
    {
        //TODO: CREATE CONTROLLER
        private readonly ApplicationDBContext _context;
        public QuizHistoryController(ApplicationDBContext context){
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
            //var userID = ;
            return Ok(await _context.QuizHistory.Where(x => x.quizID == id).ToListAsync());
        }
        [HttpPost]
        public IActionResult CreateHistory([FromBody]QuizHistory quizHistory){
            return Ok();
        }
    }
}
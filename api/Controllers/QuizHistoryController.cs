using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/history")]
    [ApiController]
    public class QuizHistoryController : Controller
    {
        
        private readonly ApplicationDBContext _context;
        public QuizHistoryController(ApplicationDBContext context){
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.quizHistory.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateHistory(){
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHistory([FromRoute]int id){return Ok();}
    }
}
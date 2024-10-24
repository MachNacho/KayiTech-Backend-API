using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

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
            return Ok(await _context.QuizHistory.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
            //var userID = ;
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateHistory(){
            return Ok();
        }
    }
}
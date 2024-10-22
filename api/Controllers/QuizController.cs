using api.Data;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controllers
{
    [Route("api/Quiz")]
    [ApiController]
    public class QuizController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public QuizController(ApplicationDBContext context){
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        { 
            return Ok(await _context.quiz.ToListAsync());
        }
        [HttpPost]
        public IActionResult CreateQuiz([FromBody]Quiz a){
            
            _context.quiz.Add(a);
            _context.SaveChanges();
            return Ok(_context.quiz.ToList());
        }
    }
}
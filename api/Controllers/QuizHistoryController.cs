using api.Data;
using api.Dtos.QuizHistory;
using api.Extensions;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("/history")]
    [ApiController]
    public class QuizHistoryController : Controller
    {
        //TODO: Repo

        private readonly ApplicationDBContext _context;
        private readonly UserManager<QuizUser> _userManager;
        public QuizHistoryController(ApplicationDBContext context,UserManager<QuizUser> userManager){
            _context = context;
            _userManager = userManager;
        }
        [HttpGet("Quiz/{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id){

            return Ok(await _context.QuizHistory.Where(x => (x.userID == "1")&&(x.quizID == id)).Select(s=>s.toHistoryDTO()).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateHistory([FromBody]NewHistoryDTO quizHistory){
            var Qhistory = quizHistory.ToHistoryFromDTO();
            await _context.QuizHistory.AddAsync(Qhistory);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
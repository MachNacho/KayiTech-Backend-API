using api.Data;
using api.DTO.Quiz;
using api.Mapper;
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
        public async Task<IActionResult> GetAll()
        { 
            return Ok(await _context.quiz.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        { 
            return Ok(_context.quiz.Include(x => x.Questions).FirstOrDefaultAsync(s=>s.Id == id));
        }

        [HttpPost]
        public IActionResult CreateQuiz([FromBody]CreateQuizRequestDTO quizDTO){
            var quizModel = quizDTO.ToQuizFromCreateDTO();
            _context.quiz.Add(quizModel);
            _context.SaveChanges();
             return CreatedAtAction(nameof(GetById), new{id = quizModel.Id},quizModel.toQuizDTO());
        }
        
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateQuiz([FromRoute]int id, [FromBody]CreateQuizRequestDTO quizDTO)
        {
            var quizModel = _context.quiz.FirstOrDefault(x =>x.Id==id);
            if (quizModel == null){return NotFound();}
            quizModel.quizTitle = quizDTO.quizName;
            quizModel.SubjectCategory = quizDTO.QuizsubjectCatagory;
            _context.SaveChanges();
            return Ok(quizModel.toQuizDTO());
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteQuiz([FromRoute]int id)
        {
            var quizModel = _context.quiz.FirstOrDefault(x => x.Id==id);
            if (quizModel == null){return NotFound();}
            _context.quiz.Remove(quizModel);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
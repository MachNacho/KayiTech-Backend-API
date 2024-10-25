using api.Data;
using api.DTO.Quiz;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("/Quiz")]
    [ApiController]
    public class QuizController: ControllerBase
    {
        private readonly iQuizRepository _iQuizRepository;
        private readonly ApplicationDBContext _context;
        public QuizController(ApplicationDBContext context,iQuizRepository iQuizRepository){
            _context = context;
            _iQuizRepository = iQuizRepository;
        }

        [HttpGet] //read all
        public async Task<IActionResult> GetAll()
        { 
            var q =await _iQuizRepository.GetALLAsync();
            return Ok(q.Select(q => q.toQuizDTO()).ToList());
        }
        [HttpGet("{id}")]// read one record
        public async Task<IActionResult> GetById([FromRoute]int id)
        { 
            return Ok(await _iQuizRepository.GetById(id));
        }

        [HttpPost]//Create quiz
        public async Task<IActionResult> CreateQuiz([FromBody]CreateQuizRequestDTO quizDTO){
            Quiz a = await _iQuizRepository.CreateQuizAsync(quizDTO);
            return CreatedAtAction(nameof(GetById), new{id = a.Id},a.toQuizDTO());
        }
        
        [HttpPut]//Update quiz
        [Route("{id}")]
        public async Task<IActionResult> UpdateQuiz([FromRoute]int id, [FromBody]CreateQuizRequestDTO quizDTO)
        {
           var quizModel = _context.quiz.FirstOrDefault(x =>x.Id==id);
            if (quizModel == null){return NotFound();}
            Quiz q = await _iQuizRepository.UpdateQuizAsync(quizModel,quizDTO);
            return Ok(q.toQuizDTO());
        }


        [HttpDelete]//Delete quiz
        [Route("{id}")]
        public IActionResult DeleteQuiz([FromRoute]int id)
        {
            var quizModel = _context.quiz.FirstOrDefault(x => x.Id==id);
            if (quizModel == null){return NotFound();}
            _iQuizRepository.DeleteQuizAsync(quizModel);
            return NoContent();
        }

    }
}
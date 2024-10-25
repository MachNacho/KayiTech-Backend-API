
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
=======
﻿using api.Data;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//before continuing eny further, understand that as far as i can see, for now at least, there is no quiz table, so all the "nameOfQuizTable" can get replaced once that table is made
namespace api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuizController : ControllerBase
	{
		private readonly ApplicationDBContext dbContext;
		public QuizController(ApplicationDBContext dbContext)
		{
			this.dbContext = dbContext;
		}
		[HttpGet]
		public Task<ActionResult<List<Quiz>>> getQuiz(int id) {
			var quiz = await dbContext."nameOfQuizTable".toListAsync();
			
			if (quiz is null)
				return NotFound("quiz not found");

			return Ok(quiz);
				}
		[HttpPost]
		public async Task<ActionResult<List<Quiz>>> addQuiz(Quiz quiz) { 
		dbContext."nameOfQuizTable".Add(quiz);
			await dbContext.SaveChangesAsync();
			return Ok(quiz);
		}
		[HttpPut]
		public async Task<ActionResult<List<Quiz>>> updateQuiz(Quiz updated) { 
		var dbQuiz= await dbContext."nameOfQuizTable".FindAsync(updated.Id);
			if (dbQuiz is null)
				return NotFound("quiz not found");


			dbQuiz.QuizId = updated.Id;
			dbQuiz.Title=updated.quizTitle;
			dbQuiz.createdOn=updated.CreatedOn;
			dbQuiz.TimeLimit=updated.TimeLimitSeconds;

			await dbContext.SaveChangesAsync();

			return Ok(await dbContext."nameOfQuizTable".toListAsync());
		}
		[HttpDelete]
		public async Task<ActionResult<List<Quiz>>> deleteQuiz(int id) { 
		var dbQuiz= await dbContext."nameOfQuizTable".findAsync(id);
			if(dbQuiz is null)
				return NotFound("quiz not found");

			dbContext."NameOfQuizTable".Remove(dbQuiz);

			await dbContext.SaveChangesAsync();
			return Ok(await dbContext."nameOfQuizTable".toListAsync());
		}
	}
}

using api.Data;
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

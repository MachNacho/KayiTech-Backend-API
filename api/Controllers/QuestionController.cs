using api.Data;
using api.Dtos.Question;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
//TODO fix repo on controller
namespace api.Controllers
{
    [ApiController]
    [Route("/Question")]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public QuestionController(ApplicationDBContext context) { _context = context; }//DB

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] CreateQuestionDTO createQuestionDTO)
        {
            var question = createQuestionDTO.ToQuestionFromCreateDTO();
            await _context.quizQuestions.AddAsync(question);
            await _context.SaveChangesAsync();
            return Ok(question);
        }

        [HttpPut]//Update quiz
        [Route("{id}")]
        public async Task<IActionResult> AddQuestion([FromRoute] int id, [FromBody] CreateQuestionDTO createQuestionDTO)
        {
            var questionModel = _context.quizQuestions.FirstOrDefault(x => x.Id == id);
            if (questionModel == null){return NotFound();}
            questionModel.QuestionTitle = createQuestionDTO.QuestionTitle;
            questionModel.QuestionOption1 = createQuestionDTO.QuestionOption1;
            questionModel.QuestionAnswer = createQuestionDTO.QuestionAnswer;
            questionModel.QuestionOption2 = createQuestionDTO.QuestionOption2;
            questionModel.QuestionOption3 = createQuestionDTO.QuestionOption3;
            _context.SaveChanges();
            return Ok(questionModel);
        }

        [HttpDelete]//Delete quiz
        [Route("{id}")]
        public IActionResult DeleteQuiz([FromRoute]int id)
        {
            var questionModel = _context.quizQuestions.FirstOrDefault(x => x.Id == id);
            if (questionModel == null){return NotFound();}
            _context.quizQuestions.Remove(questionModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
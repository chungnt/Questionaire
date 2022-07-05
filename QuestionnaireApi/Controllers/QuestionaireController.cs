using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionnaireApi.Services;

namespace QuestionnaireApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;
        public QuestionaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }
        [HttpGet("form/{id}")]
        public async Task<IActionResult> GetForm(int id)
        {
            var form = await _questionnaireService.GetFormById(id);
            return Ok(form);
        }
        [HttpGet("form/{formId}/questions/{questionId}")]
        public async Task<IActionResult> GetFormQuestion(int formId, int questionId)
        {
            var form = await _questionnaireService.GetFormById(formId);
            if (form == null)
                return NotFound();
            var question = await _questionnaireService.GetQuestionById(questionId);
            return Ok(question);
        }
        [HttpPost("form/{id}")]
        public async Task<IActionResult> SubmitForm(int id)
        {
            return Ok();
        }
        [HttpPost("form/{formId}/questions/{questionId}")]
        public async Task<IActionResult> SubmitAnswer(int formId, int questionId, string answer)
        {
            return Ok();
        }
    }
}

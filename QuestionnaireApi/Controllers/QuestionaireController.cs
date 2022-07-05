using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using QuestionnaireApi.Models;
using QuestionnaireApi.Services;

namespace QuestionnaireApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IQuestionnaireAnswerService _questionnaireAnswerService;
        
        public QuestionaireController(IQuestionnaireService questionnaireService, 
            IQuestionnaireAnswerService questionnaireAnswerService)
        {
            _questionnaireService = questionnaireService;
            _questionnaireAnswerService = questionnaireAnswerService;
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
        [HttpPost("form/{formId}/questions/{questionId}/answer")]
        public async Task<IActionResult> SubmitAnswer([FromBody] Answer answer, int formId, int questionId)
        {
            answer.FormId = formId;
            answer.QuestionId = questionId;
            string userId = string.Empty;
            if (string.IsNullOrEmpty(answer.UserId))
            {
                if (Request.Cookies.ContainsKey("userId"))
                {
                    userId = Request.Cookies["userId"];
                }
                //generate random userId for anonymous user
                string cookieValue = Guid.NewGuid().ToString();
                Response.Cookies.Append("userId", cookieValue,
                    new CookieOptions
                    {
                        Path = "/",
                        Expires = DateTime.Now.AddDays(3)
                    });
                userId = cookieValue;

                answer.UserId = userId;
            }
            var formState = await _questionnaireAnswerService.AddAnswer(answer);
            return Ok(formState);
        }
    }
}

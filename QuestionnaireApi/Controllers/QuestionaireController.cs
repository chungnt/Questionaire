using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using Questionaire.Lib;
using Questionaire.Lib.Models;
using Questionnaire.Services;

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
            if (form != null)
                return Ok(new ApiResponse<Form>()
                {
                    Success = true,
                    Message = "Success.",
                    Result = form
                });
            else
            {
                return BadRequest(new ApiResponse<FormState>()
                {
                    Success = false,
                    Message = "An error has occurred when querying form.",
                    Result = null
                });
            }
        }
        [HttpGet("form/{formId}/questions/{questionId}")]
        public async Task<IActionResult> GetFormQuestion(int formId, int questionId)
        {
            var form = await _questionnaireService.GetFormById(formId);
            if (form == null)
                return NotFound();
            var question = await _questionnaireService.GetQuestionById(questionId);
            if (question != null)
                return Ok(new ApiResponse<Question>()
                {
                    Success = true,
                    Message = "Success.",
                    Result = question
                });
            else
            {
                return BadRequest(new ApiResponse<FormState>()
                {
                    Success = false,
                    Message = "An error has occurred when querying form question.",
                    Result = null
                });
            }
        }
        [HttpPost("form/{formId}/questions/{questionId}/answer")]
        public async Task<IActionResult> SubmitAnswer([FromBody] Answer answer, int formId, int questionId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    return BadRequest(BadRequest(new ApiResponse<IEnumerable<ModelError>>()
                    {
                        Success = false,
                        Message = "Data invalid.",
                        Result = allErrors
                    }));
                }
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
                if (formState != null)
                    return Ok(new ApiResponse<FormState>()
                    {
                        Success = true,
                        Message = "Answer submitted successfully.",
                        Result = formState
                    });
                else
                {
                    return BadRequest(new ApiResponse<FormState>()
                    {
                        Success = false,
                        Message = "An error has occurred when submitting answer.",
                        Result = null
                    });
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(new ApiResponse<string>()
                {
                    Success = false,
                    Message = "An exception has occurred.",
                    Result = ex.Message
                });
            }
        }
    }
}

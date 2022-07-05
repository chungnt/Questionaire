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
    }
}

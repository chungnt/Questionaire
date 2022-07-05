using QuestionnaireApi.Models;

namespace QuestionnaireApi.Services
{
    public interface IQuestionnaireAnswerService
    {
        Task<IEnumerable<Models.Answer>> GetAllNotes();
        Task<FormState?> AddAnswer(Models.Answer item);
    }
}

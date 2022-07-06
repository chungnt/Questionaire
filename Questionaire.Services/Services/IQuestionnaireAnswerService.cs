using Questionaire.Lib.Models;

namespace Questionnaire.Services
{
    public interface IQuestionnaireAnswerService
    {
        Task<IEnumerable<Answer>> GetAllNotes();
        Task<FormState?> AddAnswer(Answer item);
    }
}

using Questionaire.Entities;

namespace Questionaire.Repositories
{
    public interface IQuestionaireAnswerRepository
    {
        Task<IEnumerable<Lib.Models.Answer>> GetAllNotes();
        Task AddAnswer(Lib.Models.Answer item);
    }
}

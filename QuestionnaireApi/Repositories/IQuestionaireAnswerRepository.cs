namespace QuestionnaireApi.Repositories
{
    public interface IQuestionaireAnswerRepository
    {
        Task<IEnumerable<Models.Answer>> GetAllNotes();
        Task AddAnswer(Models.Answer item);
    }
}

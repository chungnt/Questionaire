namespace QuestionnaireApi.Services
{
    public interface IQuestionnaireAnswerService
    {
        Task<IEnumerable<Models.Answer>> GetAllNotes();
        Task AddAnswer(Models.Answer item);
    }
}

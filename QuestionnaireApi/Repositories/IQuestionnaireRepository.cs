using QuestionnaireApi.Entities;

namespace QuestionnaireApi.Repositories
{
    public interface IQuestionnaireRepository
    {
        public Task<Form?> GetFormById(int id);
        public Task<Question?> GetQuestionById(int id);
        public Task<QuestionInfo?> GetQuestionInfoById(int id);
    }
}

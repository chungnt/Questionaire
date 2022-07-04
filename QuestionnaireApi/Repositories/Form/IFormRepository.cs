using QuestionnaireApi.Entities;

namespace QuestionnaireApi.Repositories
{
    public interface IFormRepository
    {
        public Task<Form> GetFormById(int id);
    }
}

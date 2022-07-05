using QuestionnaireApi.Models;
namespace QuestionnaireApi.Services
{
    public interface IQuestionnaireService
    {
        public Task<Form?> GetFormById(int id);
        public Task<Question?> GetQuestionById(int id);
        public Task<QuestionInfo?> GetQuestionInfoById(int id);
    }
}

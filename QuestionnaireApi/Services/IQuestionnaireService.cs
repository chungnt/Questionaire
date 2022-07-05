using QuestionnaireApi.Models;
namespace QuestionnaireApi.Services
{
    public interface IQuestionnaireService
    {
        public Task<Form?> GetFormById(int id);
        public Task<Question?> GetQuestionById(int id);
        public Task<QuestionInfo?> GetQuestionInfoById(int id);
        public Task<FormState?> UpdateFormState(int formId, string userId, int questionId, string formState = "incomplete");
        public Task<User?> GetUserById(string userId);
        public Task<User?> InsertUser(string userId);
        public Task<IEnumerable<Country>?> GetCountries();
        public Task<IEnumerable<Country>?> GetNotPermittedCountries();
    }
}

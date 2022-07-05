using Microsoft.EntityFrameworkCore;
using QuestionnaireApi.Entities;

namespace QuestionnaireApi.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly QuestionaireDbContext _questionaireDbContext;
        public QuestionnaireRepository(QuestionaireDbContext questionaireDbContext)
        {
            _questionaireDbContext = questionaireDbContext;
        }
        public async Task<Form?> GetFormById(int id)
        {
            return await _questionaireDbContext.Forms
                .Include(x => x.Question)
                .ThenInclude(x => x.QuestionInfo)
                .ThenInclude(x => x.Type)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<FormState?> UpdateFormState(int formId, string userId, int questionId, string formState = "incomplete")
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            var form = await _questionaireDbContext.Forms.FirstOrDefaultAsync(x => x.Id == formId);
            var question = await _questionaireDbContext.Questions.FirstOrDefaultAsync(x => x.Id == questionId);
            if (form == null)
                throw new Exception("FormId not exist.");
            if (questionId == form.Question.Last().Id)
                formState = "completed";
            var formStateEntity = new FormState()
                {
                    Form = await _questionaireDbContext.Forms.FirstOrDefaultAsync(x => x.Id == formId),
                    User = await _questionaireDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId),
                    CurrentQuestion = question,
                    FormStateType = await _questionaireDbContext.FormStateTypes.FirstOrDefaultAsync(x => x.Name == formState)
                };
                await _questionaireDbContext.FormStates.AddAsync(formStateEntity);
            await _questionaireDbContext.SaveChangesAsync();
            return formStateEntity;
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        public async Task<Question?> GetQuestionById(int id)
        {
            return await _questionaireDbContext.Questions
                .Include(x => x.QuestionInfo)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User?> InsertUser(string userId)
        {
            var user = new User() { UserId = userId };
            await _questionaireDbContext.Users.AddAsync(user);
            await _questionaireDbContext.SaveChangesAsync();
            return user;
        }
        public async Task<QuestionInfo?> GetQuestionInfoById(int id)
        {
            return await _questionaireDbContext.QuestionInfos.FindAsync(id);
        }
        public async Task<User?> GetUserById(string userId)
        {
            return await _questionaireDbContext.Users.FindAsync(userId);
        }
        public async Task<IEnumerable<Country>?> GetCountries()
        {
            return await _questionaireDbContext.Countries.ToListAsync();
        }
        public async Task<IEnumerable<Country>?> GetNotPermittedCountries()
        {
            return await _questionaireDbContext.Countries.Where(x => !x.IsAllowed).ToListAsync();
        }
    }
}

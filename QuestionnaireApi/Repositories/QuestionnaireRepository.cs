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

        public async Task<Question?> GetQuestionById(int id)
        {
            return await _questionaireDbContext.Questions
                .Include(x => x.QuestionInfo)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<QuestionInfo?> GetQuestionInfoById(int id)
        {
            return await _questionaireDbContext.QuestionInfos.FindAsync(id);
        }
    }
}

using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuestionnaireApi.Entities;
using QuestionnaireApi.Models;

namespace QuestionnaireApi.Repositories
{
    public class QuestionaireAnswerRepository : IQuestionaireAnswerRepository
    {
        private readonly QuestionaireAnswerDbContext _context = null;
		private readonly IMapper _mapper;

		public QuestionaireAnswerRepository(IMapper mapper, IOptions<QuestionaireAnswerDbContextOptions> options)
        {
            _context = new QuestionaireAnswerDbContext(options);
			_mapper = mapper;

		}
		public async Task<IEnumerable<Models.Answer>> GetAllNotes()
		{
			try
			{
				var results = await _context.Answers
					.FindSync(_ => true).ToListAsync();
				return _mapper.Map<ICollection<Models.Answer>>(results);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		public async Task AddAnswer(Models.Answer item)
		{
			try
			{
				var entity = _mapper.Map<Entities.Answer>(item);
				await _context.Answers.InsertOneAsync(entity);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}

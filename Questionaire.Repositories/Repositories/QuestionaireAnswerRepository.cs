using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Questionaire.Lib.Models;
using Questionaire.Entities;

namespace Questionaire.Repositories
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
		public async Task<IEnumerable<Questionaire.Lib.Models.Answer>> GetAllNotes()
		{
			try
			{
				var results = await _context.Answers
					.FindSync(_ => true).ToListAsync();
				return _mapper.Map<ICollection<Questionaire.Lib.Models.Answer>>(results);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		public async Task AddAnswer(Questionaire.Lib.Models.Answer item)
		{
			try
			{
				var entity = _mapper.Map<Questionaire.Entities.Answer>(item);
				await _context.Answers.InsertOneAsync(entity);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}

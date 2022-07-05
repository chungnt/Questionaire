using QuestionnaireApi.Repositories;
using QuestionnaireApi.Models;
using AutoMapper;

namespace QuestionnaireApi.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionnaireRepository _questionnaireRepository;
        public QuestionnaireService(IQuestionnaireRepository questionnaireRepository, IMapper mapper)
        {
            _questionnaireRepository = questionnaireRepository;
            _mapper = mapper;
        }
        public async Task<Form?> GetFormById(int id)
        {
            var entity = await _questionnaireRepository.GetFormById(id);
            return _mapper.Map<Form>(entity);
        }

        public async Task<Question?> GetQuestionById(int id)
        {
            var entity = await _questionnaireRepository.GetQuestionById(id);
            return _mapper.Map<Question>(entity);
        }

        public async Task<QuestionInfo?> GetQuestionInfoById(int id)
        {
            var entity = await _questionnaireRepository.GetQuestionInfoById(id);
            return _mapper.Map<QuestionInfo>(entity);
        }
    }
}

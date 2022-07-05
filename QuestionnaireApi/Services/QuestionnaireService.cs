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
        public async Task<User?> GetUserById(string userId)
        {
            var entity = await _questionnaireRepository.GetUserById(userId);
            return _mapper.Map<User>(entity);
        }
        public async Task<User?> InsertUser(string userId)
        {
            var entity = await _questionnaireRepository.InsertUser(userId);
            return _mapper.Map<User>(entity);
        }
        public async Task<QuestionInfo?> GetQuestionInfoById(int id)
        {
            var entity = await _questionnaireRepository.GetQuestionInfoById(id);
            return _mapper.Map<QuestionInfo>(entity);
        }
        public async Task<FormState?> UpdateFormState(int formId, string userId, int questionId, string formState = "incomplete")
        {
            var formStateEntity = await _questionnaireRepository.UpdateFormState(formId, userId, questionId, formState);
            return _mapper.Map<FormState>(formStateEntity);
        }
        public async Task<IEnumerable<Country>?> GetCountries()
        {
            var entity = await _questionnaireRepository.GetCountries();
            return _mapper.Map<IEnumerable<Country>>(entity);
        }
        public async Task<IEnumerable<Country>?> GetNotPermittedCountries()
        {
            var entity = await _questionnaireRepository.GetCountries();
            return _mapper.Map<IEnumerable<Country>>(entity);
        }
    }
}

using QuestionnaireApi.Models;
using QuestionnaireApi.Repositories;

namespace QuestionnaireApi.Services
{
    public class QuestionnaireAnswerService : IQuestionnaireAnswerService
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IQuestionaireAnswerRepository _answerRepository;
        public QuestionnaireAnswerService(IQuestionaireAnswerRepository answerRepository, 
            IQuestionnaireService questionnaireService)
        {
            _answerRepository = answerRepository;
            _questionnaireService = questionnaireService;
        }

        public async Task AddAnswer(Answer item)
        {
            var question = await _questionnaireService.GetQuestionById(item.QuestionId);
            if (question == null)
                throw new Exception("QuestionId does not exist.");
            item.Question = question.Title;
            foreach (var info in item.AnswerInfos)
            {
                var questionInfo = await _questionnaireService.GetQuestionInfoById(info.QuestionInfoId);
                if (questionInfo != null)
                    info.QuestionInfo = questionInfo.Title;
            }
            await _answerRepository.AddAnswer(item);
        }

        public async Task<IEnumerable<Answer>> GetAllNotes()
        {
            return await _answerRepository.GetAllNotes();
        }
    }
}

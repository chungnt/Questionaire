using Questionaire.Lib.Models;
using Questionaire.Repositories;

namespace Questionnaire.Services
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

        public async Task<FormState?> AddAnswer(Answer answer)
        {
            try
            {
                var form = await _questionnaireService.GetFormById(answer.FormId);
                var question = await _questionnaireService.GetQuestionById(answer.QuestionId);
                var user = await _questionnaireService.GetUserById(answer.UserId);
                var notPermittedCountries = await _questionnaireService.GetNotPermittedCountries();
                var notPermittedCountryNames = notPermittedCountries.Select(x => x.Name);

                if (question == null)
                    throw new Exception("QuestionId does not exist.");

                if (user == null)
                {
                    user = await _questionnaireService.InsertUser(answer.UserId);
                }
                answer.Form = form.Title;
                answer.Question = question.Title;
                var formState = "incomplete";

                foreach (var info in answer.AnswerInfos)
                {
                    var questionInfo = await _questionnaireService.GetQuestionInfoById(info.QuestionInfoId.Value);
                    if (questionInfo != null)
                        info.QuestionInfo = questionInfo.Title;
                    if (questionInfo.Type == "country" && notPermittedCountryNames.Contains(info.Answer))
                        formState = "completed";

                }

                var formStateModel = await _questionnaireService.UpdateFormState(form.Id, user.UserId, question.Id, formState);
                await _answerRepository.AddAnswer(answer);
                return formStateModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Answer>> GetAllNotes()
        {
            return await _answerRepository.GetAllNotes();
        }
    }
}

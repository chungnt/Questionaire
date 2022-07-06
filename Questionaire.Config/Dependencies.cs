using Microsoft.Extensions.DependencyInjection;
using Questionaire.Repositories;
using Questionnaire.Services;

namespace QuestionnaireApi
{
    public static class Dependencies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
            services.AddScoped<IQuestionnaireService, QuestionnaireService>();
            services.AddScoped<IQuestionaireAnswerRepository, QuestionaireAnswerRepository>();
            services.AddScoped<IQuestionnaireAnswerService, QuestionnaireAnswerService>();
        }
    }
}

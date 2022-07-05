using AutoMapper;
using QuestionnaireApi.Common;
using QuestionnaireApi.Entities;
using QuestionnaireApi.Repositories;
using QuestionnaireApi.Services;

namespace QuestionnaireApi
{
    public static class StartupExtensions
    {

        public static void CreateDbIfNotExists(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<QuestionaireDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
            services.AddScoped<IQuestionnaireService, QuestionnaireService>();
        }
        public static void AddMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }
    }
}

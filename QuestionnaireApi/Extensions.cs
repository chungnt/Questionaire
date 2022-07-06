using AutoMapper;
using Microsoft.Extensions.Logging;
using Questionaire.Common;
using Questionaire.Entities;

namespace QuestionnaireApi
{
    public static class Extensions
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
        public static void AddOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<QuestionaireAnswerDbContextOptions>(builder.Configuration.GetSection("ConnectionStrings:Answer"));
        }
        public static void AddMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }
    }
}

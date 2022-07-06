using Questionaire.Lib.Helpers;
using System.Text.Json;

namespace Questionaire.Entities
{
    public static class DbInitializer
    {
        public static void Initialize(QuestionaireDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Forms.Any() || context.Questions.Any() || context.QuestionInfos.Any())
            {
                return;
            }
            var questionInfoTypes = new List<QuestionInfoType>() 
            { 
                new QuestionInfoType(){ Name = "text" },
                new QuestionInfoType(){ Name = "select" },
                new QuestionInfoType(){ Name = "datetime" },
                new QuestionInfoType(){ Name = "country" },
            };
            context.QuestionInfoTypes.AddRange(questionInfoTypes);
            context.SaveChanges();
            var formStateTypes = new List<FormStateType>()
            {
                new FormStateType(){ Name = "completed" },
                new FormStateType(){ Name = "incomplete" }
            };
            context.FormStateTypes.AddRange(formStateTypes);
            context.SaveChanges();
            var personalQuestionInfos = new List<QuestionInfo>() 
            {
                new QuestionInfo() {
                    Title = "Title",
                    Type = questionInfoTypes[1],
                    SelectOptions = "Mr.|Ms.|Mrs."
                },
                new QuestionInfo() {
                    Title = "First name",
                    Type = questionInfoTypes[0]
                },
                new QuestionInfo() {
                    Title = "Last name",
                    Type = questionInfoTypes[0],
                },
                new QuestionInfo() {
                    Title = "Date of birth",
                    Type = questionInfoTypes[2],
                },
                new QuestionInfo() {
                    Title = "Country of residence",
                    Type = questionInfoTypes[3],
                },
            };
            var addressQuestionInfos = new List<QuestionInfo>()
            {
                new QuestionInfo() {
                    Title = "House",
                    Type = questionInfoTypes[0]
                },
                new QuestionInfo() {
                    Title = "Work",
                    Type = questionInfoTypes[0]
                }
            };
            var occupationQuestionInfos = new List<QuestionInfo>()
            {
                new QuestionInfo() {
                    Title = "Occupation",
                    Type = questionInfoTypes[1],
                    SelectOptions = "Teacher|Farmer|Actor|Engineer"
                },
                new QuestionInfo() {
                    Title = "Job Title",
                    Type = questionInfoTypes[0]
                },
                new QuestionInfo() {
                    Title = "Business Type",
                    Type = questionInfoTypes[0]
                }
            };
            context.QuestionInfos.AddRange(personalQuestionInfos);
            context.QuestionInfos.AddRange(addressQuestionInfos);
            context.QuestionInfos.AddRange(occupationQuestionInfos);
            context.SaveChanges();

            var questions = new List<Question>()
            {
                new Question() 
                { 
                    Title = "Personal Information",
                    QuestionInfo = personalQuestionInfos
                },
                new Question()
                {
                    Title = "Address",
                    QuestionInfo = addressQuestionInfos
                },
                new Question()
                {
                    Title = "Occupation",
                    QuestionInfo = occupationQuestionInfos
                },
            };
            context.Questions.AddRange(questions);
            context.SaveChanges();
            var forms = new List<Form>() 
            {
                new Form()
                {
                    Title = "Questionaire",
                    Question = questions
                }
            };
            context.Forms.AddRange(forms);
            context.SaveChanges();

            var countryFile = Helpers.MapPath(@"Data\countries.json");
            var fileContent = File.ReadAllText(countryFile);
            var countries = JsonSerializer.Deserialize<List<Country>>(fileContent, new JsonSerializerOptions() 
            {
                PropertyNameCaseInsensitive = true
            });
            context.Countries.AddRange(countries);
            context.SaveChanges();
        }
    }
}

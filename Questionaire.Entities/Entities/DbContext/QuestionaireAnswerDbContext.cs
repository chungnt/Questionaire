using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Questionaire.Entities
{
    public class QuestionaireAnswerDbContextOptions
    {
        public string Host { get; set; } = string.Empty;
        public string DbName { get; set; } = string.Empty;
        public string Collection { get; set; } = string.Empty;
    }
    public class QuestionaireAnswerDbContext
    {
        private readonly IMongoDatabase _database;
        public QuestionaireAnswerDbContext(IOptions<QuestionaireAnswerDbContextOptions> options)
        {
            MongoClient client = new MongoClient(options.Value.Host);
            _database = client.GetDatabase(options.Value.DbName);
        }
        public IMongoCollection<Answer> Answers
        {
            get
            {
                var collection = _database.GetCollection<Answer>("answers");
                if (collection != null)
                {
                    return collection;
                }
                _database.CreateCollection("answers");
                return _database.GetCollection<Answer>("answers");
            }
        }
    }
}

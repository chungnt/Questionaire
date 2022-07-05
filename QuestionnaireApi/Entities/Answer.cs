using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuestionnaireApi.Entities
{
    public class Answer
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
        public ICollection<AnswerInfo> AnswerInfos { get; set; } = new List<AnswerInfo>();
    }
}

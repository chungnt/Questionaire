using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Questionaire.Entities
{
    public class Answer
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string Form { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
        public ICollection<AnswerInfo> AnswerInfos { get; set; } = new List<AnswerInfo>();
    }
}

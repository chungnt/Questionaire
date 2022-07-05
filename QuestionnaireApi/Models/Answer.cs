using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace QuestionnaireApi.Models
{
    [Serializable]
    public class Answer
    {
        public string UserId { get; set; } = string.Empty;
        public int QuestionId { get; set; }
        public string Question { get; set; } = string.Empty;
        public ICollection<AnswerInfo> AnswerInfos { get; set; } = new List<AnswerInfo>();
    }
}

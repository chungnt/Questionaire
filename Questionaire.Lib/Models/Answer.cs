
using System.ComponentModel.DataAnnotations;

namespace Questionaire.Lib.Models
{
    [Serializable]
    public class Answer
    {
        public string UserId { get; set; } = string.Empty;
        [Required]
        public int FormId { get;set; }
        public string Form { get; set; } = string.Empty;
        [Required]
        public int QuestionId { get; set; }
        public string Question { get; set; } = string.Empty;
        [Required]
        public ICollection<AnswerInfo> AnswerInfos { get; set; } = new List<AnswerInfo>();
    }
}

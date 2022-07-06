using System.ComponentModel.DataAnnotations;

namespace Questionaire.Lib.Models
{
    [Serializable]
    public class AnswerInfo
    {
        public string QuestionInfo { get; set; } = string.Empty;
        [Required]
        public int QuestionInfoId { get; set; }
        [Required]
        public string Answer { get; set; } = string.Empty;
    }
}

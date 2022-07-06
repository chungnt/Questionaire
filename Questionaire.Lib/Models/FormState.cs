using System.ComponentModel.DataAnnotations;

namespace Questionaire.Lib.Models
{
    public class FormState
    {
        public int Id { get; set; }
        [Required]
        public int FormId { get; set; }
        [Required]
        public int CurrentQuestionId { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        public string FormStateType { get; set; } = string.Empty;
        [Required]
        public int FormStateTypeId { get; set; }
    }
}

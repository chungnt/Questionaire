namespace QuestionnaireApi.Models
{
    public class FormState
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int CurrentQuestionId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string FormStateType { get; set; } = string.Empty;
        public int FormStateTypeId { get; set; }
    }
}

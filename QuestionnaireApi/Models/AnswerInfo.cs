namespace QuestionnaireApi.Models
{
    [Serializable]
    public class AnswerInfo
    {
        public string QuestionInfo { get; set; } = string.Empty;
        public int QuestionInfoId { get; set; }
        public string Answer { get; set; } = string.Empty;
    }
}

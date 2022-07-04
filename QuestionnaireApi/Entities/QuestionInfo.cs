namespace QuestionnaireApi.Entities
{
    public class QuestionInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public QuestionInfoType? Type { get; set; }
        public string SelectOptions { get; set; } = string.Empty; //In case type is SELECT
        public ICollection<Question> Question { get; set; } = new List<Question>();
    }
}

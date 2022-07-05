namespace QuestionnaireApi.Models
{
    public class QuestionInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Type { get; set; } = string.Empty;
        public int? TypeId { get; set; }
        public ICollection<string> SelectOptions { get; set; } = new List<string>();
    }
}

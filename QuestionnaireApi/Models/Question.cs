using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireApi.Models
{
    [Serializable]
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public ICollection<QuestionInfo> QuestionInfo { get; set; } = new List<QuestionInfo>();
    }
}

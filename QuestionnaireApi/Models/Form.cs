using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireApi.Models
{
    [Serializable]
    public class Form
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<Question> Question { get; set; } = new List<Question>();
    }
}

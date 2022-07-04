using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireApi.Entities
{
    public class Question
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public ICollection<QuestionInfo> QuestionInfo { get; set; } = new List<QuestionInfo>();
        public ICollection<Form> Form { get; set; } = new List<Form>();
    }
}

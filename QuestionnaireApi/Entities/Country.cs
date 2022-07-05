using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireApi.Entities
{
    public class Country
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Code { get; set; } = String.Empty;
        public bool IsAllowed { get; set; }
    }
}

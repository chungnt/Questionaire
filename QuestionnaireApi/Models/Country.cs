using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireApi.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Code { get; set; } = String.Empty;
        public bool IsAllowed { get; set; }
    }
}

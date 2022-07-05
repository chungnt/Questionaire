using System.ComponentModel.DataAnnotations;

namespace QuestionnaireApi.Entities
{
    public class User
    {
        [Key]
        public string UserId { get; set; } = string.Empty;
    }
}

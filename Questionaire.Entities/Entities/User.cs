using System.ComponentModel.DataAnnotations;

namespace Questionaire.Entities
{
    public class User
    {
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
    }
}

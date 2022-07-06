using System.ComponentModel.DataAnnotations;

namespace Questionaire.Lib.Models
{
    public class User
    {
        [Required]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
    }
}

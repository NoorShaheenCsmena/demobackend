using System.ComponentModel.DataAnnotations;

namespace banner.Models
{
    public class User : BaseModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}

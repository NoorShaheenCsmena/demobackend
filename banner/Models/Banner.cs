using System.Text.Json.Serialization;

namespace banner.Models
{
    public class Banner: BaseModel
    {
        public string Title { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
    }
}

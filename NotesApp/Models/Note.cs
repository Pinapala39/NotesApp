using System.ComponentModel.DataAnnotations;

namespace EnteryourWorld.Models
{
    public class Note
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description   { get; set; }
    }
}

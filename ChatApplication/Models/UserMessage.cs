using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Models
{
    public class UserMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
        [Required]
        public DateTime DatePublished { get; set; }

        //Navigation properties to show relationships
        
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Models
{
    public class AdminMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
        [Required]
        public DateTime DatePublished { get; set; }

        //Navigation properties to show relationships

        public int AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}

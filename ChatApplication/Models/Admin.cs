using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nickname { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        //Navigation properties to show relationships

        public List<AdminMessage> AdminMessages { get; set; }
    }
}

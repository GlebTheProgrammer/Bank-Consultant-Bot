using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.DbConfiguration
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<AdminMessage> AdminMessages { get; set; }
        public DbSet<BotMessage> BotMessages { get; set; }
    }
}

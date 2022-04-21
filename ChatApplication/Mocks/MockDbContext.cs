using ChatApplication.Models;

namespace ChatApplication.Mocks
{
    public static class MockDbContext
    {
        public static List<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                FullName = "Ilya Vdovenko",
                Nickname = "Ilya",
                Email = "Ilya@gmail.com",
                Password = "123456789"
            },
            new User()
            {
                Id = 2,
                FullName = "Gleb Sukristik",
                Nickname = "Glebyshka",
                Email = "gleb15a@gmail.com",
                Password = "quertyquerty"
            },
            new User()
            {
                Id = 3,
                FullName = "Admin Admin",
                Nickname = "Admin",
                Email = "admin@admin.com",
                Password = "adminadmin"
            }
        };
        public static List<UserMessage> userMessages = new List<UserMessage>()
        {
            new UserMessage()
            {
                Id = 1,
                Text = "Hello World",
                UserId = 1,
                DatePublished = DateTime.Now
            },
            new UserMessage()
            {
                Id = 2,
                Text = "My name is Ilya",
                UserId = 1,
                DatePublished = DateTime.Now
            },
            new UserMessage()
            {
                Id = 3,
                Text = "Glebyshka is here",
                UserId = 2,
                DatePublished = DateTime.Now
            },
        };
        public static List<Admin> admins = new List<Admin>();
        public static List<AdminMessage> adminMessages = new List<AdminMessage>();
        public static List<BotMessage> botMessages = new List<BotMessage>();

    }
}

using ChatApplication.Interfaces;
using ChatApplication.Models;

namespace ChatApplication.Mocks
{
    public class MockChatRepository : IChatRepository
    {
        public bool AddAdminMessage(AdminMessage message)
        {
            message.Id = MockDbContext.adminMessages.Count + 1;
            MockDbContext.adminMessages.Add(message);
            return true;
        }

        public bool AddBotMessage(BotMessage message)
        {
            message.Id = MockDbContext.botMessages.Count + 1;
            MockDbContext.botMessages.Add(message);
            return true;
        }

        public bool AddNewAdmin(Admin admin)
        {
            admin.Id = MockDbContext.admins.Count + 1;
            MockDbContext.admins.Add(admin);
            return true;
        }

        public bool AddNewUser(User user)
        {
            user.Id = MockDbContext.users.Count + 1;
            MockDbContext.users.Add(user);
            return true;
        }

        public bool AddUserMesage(UserMessage message)
        {
            message.Id = MockDbContext.userMessages.Count + 1;
            MockDbContext.userMessages.Add(message);
            return true;
        }

        public bool DeleteUser(User user)
        {
            MockDbContext.users.Remove(user);
            return true;
        }

        public Admin GetAdminByEmail(string email)
        {
            return MockDbContext.admins.FirstOrDefault(admin => admin.Email == email);
        }

        public Admin GetAdminById(int id)
        {
            return MockDbContext.admins.FirstOrDefault(admin => id == admin.Id);
        }

        public Admin GetAdminByInputData(LoginAdmin loginAdmin)
        {
            return MockDbContext.admins.FirstOrDefault(admin => admin.Password == loginAdmin.Password &&
                                                     admin.Nickname == loginAdmin.Nickname &&
                                                     admin.Email == loginAdmin.Email);
        }

        public IEnumerable<AdminMessage> GetAllAdminMessagesById(int adminId)
        {
            return MockDbContext.adminMessages.Where(admin => admin.Id == adminId);
        }

        public IEnumerable<AdminMessage> GetAllAdminMessagesForSpecialUserById(int adminId, int userId)
        {
            return MockDbContext.adminMessages.Where(admins => admins.Id == adminId && admins.UserId == userId);
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return MockDbContext.admins;
        }

        public IEnumerable<BotMessage> GetAllBotMessages()
        {
            return MockDbContext.botMessages;
        }

        public IEnumerable<BotMessage> GetAllBotMessagesForSpecialUserByUserId(int userId)
        {
            return MockDbContext.botMessages.Where(botMessages => botMessages.UserId == userId);
        }

        public IEnumerable<UserMessage> GetAllUserMessagesById(int userId)
        {
            return MockDbContext.userMessages.Where(userMessages => userMessages.UserId == userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return MockDbContext.users;
        }

        public User GetUserByEmail(string email)
        {
            return MockDbContext.users.FirstOrDefault(user => user.Email == email);
        }

        public User GetUserByFullNameAndEmail(string fullName, string email)
        {
            return MockDbContext.users.FirstOrDefault(user => user.FullName == fullName && user.Email == email);
        }

        public User GetUserById(int id)
        {
            return MockDbContext.users.FirstOrDefault(user =>user.Id == id);
        }

        public User GetUserByInputData(LoginUser loginUser)
        {
            return MockDbContext.users.FirstOrDefault(user => user.Password == loginUser.Password &&
                                                     user.Nickname == loginUser.Nickname &&
                                                     user.Email == loginUser.Email);
        }
    }
}

using ChatApplication.DbConfiguration;
using ChatApplication.Interfaces;
using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Domain
{
    public class SqlChatRepository : IChatRepository
{
        private readonly ChatDbContext context;
        public SqlChatRepository(ChatDbContext context)
        {
            this.context = context;
        }

        //Md5 Encryption Section Starts Here

        private static string CreateMd5FromString(string password)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }

        private bool CheckIfPasswordInputMatchesWithUserPassord(int id, string password)
        {
            User user = context.Users.FirstOrDefault(x => x.Id == id);

            string userMd5Passoword = user.Password;
            string inputMd5Password = CreateMd5FromString(password);

            if (userMd5Passoword == inputMd5Password)
                return true;
            else
                return false;
        }

        private bool CheckIfPasswordInputMatchesWithAdminPassord(int id, string password)
        {
            Admin admin = context.Admins.FirstOrDefault(x => x.Id == id);

            string adminMd5Passoword = admin.Password;
            string inputMd5Password = CreateMd5FromString(password);

            if (adminMd5Passoword == inputMd5Password)
                return true;
            else
                return false;
        }

        //Md5 Encryption Section Ends Here

        //Getting Data From Db Section Starts Here

        public Admin GetAdminByEmail(string email)
        {
            return context.Admins.FirstOrDefault(x => x.Email == email);
        }

        public Admin GetAdminById(int id)
        {
            return context.Admins.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AdminMessage> GetAllAdminMessagesById(int adminId)
        {
            return context.AdminMessages.Where(x => x.AdminId == adminId);
        }

        public IEnumerable<AdminMessage> GetAllAdminMessagesForSpecialUserById(int adminId, int userId)
        {
            return GetAllAdminMessagesById(adminId).Where(x => x.UserId == userId);
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return context.Admins.ToList();
        }
        public Admin GetAdminByInputData(LoginAdmin loginAdmin)
        {
            return context.Admins.FirstOrDefault(x => x.Password == CreateMd5FromString(loginAdmin.Password) &&
                                                     x.Nickname == loginAdmin.Nickname &&
                                                     x.Email == loginAdmin.Email);
        }

        public IEnumerable<BotMessage> GetAllBotMessages()
        {
            return context.BotMessages.ToList();
        }

        public IEnumerable<BotMessage> GetAllBotMessagesForSpecialUserByUserId(int userId)
        {
            return context.BotMessages.Where(x => x.UserId == userId);
        }

        public IEnumerable<UserMessage> GetAllUserMessagesById(int userId)
        {
            return context.UserMessages.Where(x => x.UserId == userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.FirstOrDefault(x => x.Email == email);
        }
        public User GetUserByFullNameAndEmail(string fullName, string email)
        {
            return context.Users.FirstOrDefault(x => x.Email == email && x.FullName == fullName);
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(x =>x.Id == id);
        }
        public User GetUserByInputData(LoginUser loginUser)
        {
            return context.Users.FirstOrDefault(x => x.Password == CreateMd5FromString(loginUser.Password) && 
                                                     x.Nickname == loginUser.Nickname &&
                                                     x.Email == loginUser.Email);
        }

        //Getting Data From Db Section Ends Here

        //Adding Data Into Db Section Starts Here

        public bool AddNewUser(User user)
        {
            try
            {
                user.Password = CreateMd5FromString(user.Password);
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddNewAdmin(Admin admin)
        {
            try
            {
                admin.Password = CreateMd5FromString(admin.Password);
                context.Admins.Add(admin);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddUserMesage(UserMessage message)
        {
            try
            {
                context.UserMessages.Add(message);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddAdminMessage(AdminMessage message)
        {
            try
            {
                context.AdminMessages.Add(message);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddBotMessage(BotMessage message)
        {
            try
            {
                context.BotMessages.Add(message);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Adding Data Into Db Section Ends Here

        //Delete Data From Db Section Starts Here
        public bool DeleteUser(User user)
        {
            try
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Delete Data From Db Section Ends Here
    }
}

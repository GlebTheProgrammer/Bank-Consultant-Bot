﻿using ChatApplication.Models;

namespace ChatApplication.Interfaces
{
    public interface IChatRepository
    {

        //Getting Data From Db Section Starts Here

        public IEnumerable<User> GetAllUsers();
        public IEnumerable<Admin> GetAllAdmins();
        public IEnumerable<UserMessage> GetAllUserMessagesById(int userId);
        public IEnumerable<AdminMessage> GetAllAdminMessagesById(int adminId);
        public IEnumerable<AdminMessage> GetAllAdminMessagesForSpecialUserById(int adminId, int userId);
        public IEnumerable<BotMessage> GetAllBotMessages();
        public IEnumerable<BotMessage> GetAllBotMessagesForSpecialUserByUserId(int userId);
        public User GetUserById(int id);
        public User GetUserByEmail(string email);
        public User GetUserByFullNameAndEmail(string fullName, string email);
        public User GetUserByInputData(LoginUser loginUser);
        public Admin GetAdminById(int id);
        public Admin GetAdminByEmail(string email);
        public Admin GetAdminByInputData(LoginAdmin loginAdmin);

        //Getting Data From Db Section Ends Here

        //Adding Data Into Db Section Starts Here

        public bool AddNewUser(User user);
        public bool AddNewAdmin(Admin admin);
        public bool AddUserMesage(UserMessage message);
        public bool AddAdminMessage(AdminMessage message);
        public bool AddBotMessage(BotMessage message);

        //Adding Data Into Db Section Ends Here

        //Delete Data From Db Section Starts Here

        public bool DeleteUser(User user);

        //Delete Data From Db Section Ends Here

    }
}

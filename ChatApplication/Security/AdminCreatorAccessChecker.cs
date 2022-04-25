using ChatApplication.Interfaces;

namespace ChatApplication.Security
{
    public class AdminCreatorAccessChecker : IAdminCreatorAccessChecker
    {
        string accessCode = "1234567";
        public bool checkForAccessCode(string accessCode)
        {
            if (accessCode != this.accessCode)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

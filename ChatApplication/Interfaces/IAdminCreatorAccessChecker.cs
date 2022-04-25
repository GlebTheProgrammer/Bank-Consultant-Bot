namespace ChatApplication.Interfaces
{
    public interface IAdminCreatorAccessChecker
    {
        public bool checkForAccessCode(string accessCode);
    }
}

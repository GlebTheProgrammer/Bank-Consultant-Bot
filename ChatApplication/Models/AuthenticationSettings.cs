namespace ChatApplication.Models
{
    public static class AuthenticationSettings
    {
        public static int LoginAttempts { get; set; } = 0;
        public static bool newAccoutCreated { get; set; } = false;
        public static bool newAdminCreated { get; set; } = true;
    }
}

namespace ChatApplication.Models
{
    public enum ToDoAction
    {
        DeleteUser = 1,
        ShowDialog = 2,
        DeleteDialog = 3,
        FindMessageByInput = 4
    }
    public static class AdminAction
    {
        public static ToDoAction action = 0;
    }
}

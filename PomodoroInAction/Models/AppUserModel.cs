namespace PomodoroInAction.Models
{
    // Entity that will be used in controller for deserializing json
    public class AppUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

namespace Market.Auth.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password  { get; set; }
        public role Role { get; set; }
    }

    public enum role
    {
        User,
        Admin
    }
}

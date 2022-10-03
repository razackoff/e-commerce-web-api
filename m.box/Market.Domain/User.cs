namespace Market.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string Locality { get; set; }
        public Gender UserGender { get; set; } 
        public string Password { get; set; }
        public enum Gender
        {
            Male,
            Female
        }
    }
}

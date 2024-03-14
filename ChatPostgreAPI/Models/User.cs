namespace ChatPostgreAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string? UserName { get; set; }
        public bool? IsUserVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Disabled { get; set; }
    }
}

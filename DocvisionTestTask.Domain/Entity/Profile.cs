namespace DocvisionTestTask.Domain.Entity
{
    public class Profile
    {
        public int Id { get; set; }
        public string First_name { get; set; } = string.Empty;
        public string Last_name { get; set; } = string.Empty;
        public string Sure_name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        //Foreign key
        public int User_id { get; set; }
        public User User { get; set; }
    }
}

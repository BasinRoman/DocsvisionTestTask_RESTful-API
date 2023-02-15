namespace DocvisionTestTask.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
        public InBox InBox { get; set; }
    }
}
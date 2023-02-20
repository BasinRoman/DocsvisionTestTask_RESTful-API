using System.ComponentModel.DataAnnotations;

namespace DocvisionTestTask.Domain.Entity
{
    public class Profile
    {
        public int Id { get; set; } 
        
        public string First_name { get; set; } = "Имя не заполнено";
        public string Last_name { get; set; } = "Фпмилия не заполнено";
        public string Sure_name { get; set; } = "Отчество не заполнено";
        public string Email { get; set; } = "Email не заполнен";

        //Foreign key
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

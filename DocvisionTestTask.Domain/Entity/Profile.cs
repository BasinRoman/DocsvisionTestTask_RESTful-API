using System.ComponentModel.DataAnnotations;

namespace DocvisionTestTask.Domain.Entity
{
    // Описание сущности для таблицы БД Profile
    public class Profile
    {
        public int Id { get; set; } 
        
        public string firstName { get; set; } = "Имя не заполнено";
        public string lastName { get; set; } = "Фамилия не заполнено";
        public string sureName { get; set; } = "Отчество не заполнено";
        public string Email { get; set; } = "Email не заполнен";

        //Foreign key
        public int userId { get; set; }
        public User User { get; set; }
    }
}

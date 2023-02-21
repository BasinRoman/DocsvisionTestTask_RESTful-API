
namespace DocvisionTestTask.Domain.Entity
{
    // Описание сущности для таблицы БД inBox
    public class inBox
    {  
        public int id { get; set; }
        public string emailSubject { get; set; } = "Тема письма отсутствует";
        public DateTime emailDate { get; set; } = DateTime.MinValue;
        public string emailFrom { get; set; } = "Отправитель не указан";
        public string emailTo { get; set; } = "Адресат не указан";
        public string emailBody { get; set; } = "Отсутствует содержание письма";
        
        //ForeignKey 
        public int userId { get; set; }
        public User User { get; set; }
    }
}

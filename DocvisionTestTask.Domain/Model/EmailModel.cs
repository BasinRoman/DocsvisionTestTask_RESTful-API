using System.ComponentModel.DataAnnotations;


namespace DocvisionTestTask.Domain.Model
{
    // Модель для контроллера EmailController
    public class EmailModel
    {
        [StringLength(300, ErrorMessage = "Длина темы письма не должна превышать 300 символов")]
        public string emailSubject { get; set; } = "Пустая тема письма";
        public DateTime emailDate { get; set; } = DateTime.MinValue;
        [StringLength(50, ErrorMessage = "Превышен лимит, ФИО не должно превышать 50 символов")]
        public string emailFrom { get; set; } = "Отправитель не указан";
        [StringLength(50, ErrorMessage = "Превышен лимит, ФИО не должно превышать 50 символов")]
        public string emailTo { get; set; } = "Получатель не указан";
        [StringLength(5000, ErrorMessage = "Превышен лимит, текст письма не должен превышать 1500 символов")]
        public string emailBody { get; set; } = "Пустое письмо";
    }
}

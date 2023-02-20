using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocvisionTestTask.Domain.Model
{
    public class EmailModel
    {
        public string emailSubject { get; set; } = "Пустая тема письма";
        public DateTime emailDate { get; set; } = DateTime.MinValue;
        public string emailFrom { get; set; } = "Отправитель не указан";
        public string emailTo { get; set; } = "Получатель не указан";
        public string emailBody { get; set; } = "Пустое письмо";
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocvisionTestTask.Domain.Entity
{
    public class User
    {
        
        public int id { get; set; }
        
        public string Login { get; set; }
        public string Password { get; set; }

        // Связи
        //
        // Связь для таблицы Profile
        public Profile Profile { get; set; }

        // Связь для таблицы Inbox 
        public ICollection<inBox> inBox { get; set; }
    }
}
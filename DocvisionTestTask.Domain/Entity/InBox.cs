using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocvisionTestTask.Domain.Entity
{
    public class inBox
    {  
        public int id { get; set; }
        public string emailSubject { get; set; } = string.Empty;
        public DateTime emailDate { get; set; } = DateTime.MinValue;
        public string emailFrom { get; set; } = string.Empty;
        public string emailTo { get; set; } = string.Empty;
        public string emailBody { get; set; } = string.Empty;

        //ForeignKey 
        public int userId { get; set; }
        public User User { get; set; }
    }
}

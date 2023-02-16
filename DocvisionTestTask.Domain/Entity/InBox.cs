using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocvisionTestTask.Domain.Entity
{
    public class InBox
    {
        public int Id { get; set; }
        public string Email_subject { get; set; } = string.Empty;
        public DateTime Email_date { get; set; } = DateTime.MinValue;
        public string Email_from { get; set; } = string.Empty;
        public string Email_to { get; set; } = string.Empty;
        public string Email_body { get; set; } = string.Empty;
        
        //ForeignKey
        public int User_id { get; set; }
        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Activity : BaseEntity
    {        
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Schedule { get; set; }   
        public string Day {get; set;}   
        public string Hour {get; set;}
        public string Career {get; set;}
        public string ActivityType {get; set;}
        public List<Rapportuer> Rapportuers { get; set; }   
        public List<Attendee> Attendees { get; set; }
    }
}

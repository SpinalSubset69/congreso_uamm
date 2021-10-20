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
        public string Schedule { get; set; }
        public int RapportuerId {get; set;}
        public int CareerId {get; set;}
        public int ActivityTypeId {get; set;}
        //ForeignKeys
        [ForeignKey("RapportuerId")]   
        public Rapportuer Rapportuer { get; set; }
        [ForeignKey("CareerId")]   
        public Career Career { get; set; }
        [ForeignKey("ActivityTypeId")]   
        public ActivityType ActivityType { get; set; }        
        public IEnumerable<Attendee> Attendees { get; set; }
    }
}

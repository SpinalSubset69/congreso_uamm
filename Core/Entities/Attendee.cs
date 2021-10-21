using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{    
    public class Attendee : BaseEntity
    {
        public string Name { get; set; }
        public string StudentNumber {get; set;}
        public string Email { get; set; }
        public string RegisterAt {get; set;}
        public string Career {get; set;}             
        public List<Activity> Activities {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Participant : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string RegisterDate {get; set;}

        public Career Career {get; set;}
        public int CareerId {get; set;}        
    }
}
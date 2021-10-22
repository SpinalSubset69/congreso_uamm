using System;

namespace API.Dtos
{
    public class ActivityWithNoAttendeesToReturnDto
    {        
        public int Id {get; set;}
         public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Schedule { get; set; }  
        public string Hour {get; set;} 
        public string Day {get; set; }  
        public string Career {get; set;}      
    }
}
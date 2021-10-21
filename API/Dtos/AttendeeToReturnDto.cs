using System.Collections.Generic;

namespace API.Dtos
{
    public class AttendeeToReturnDto
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string StudentNumber {get; set;}
        public string Email { get; set; }        
        public string RegisterAt {get; set;}
        public string Career {get; set;}
        public List<ActivityWithNoAttendeesToReturnDto> Activities {get; set;}
    }
}
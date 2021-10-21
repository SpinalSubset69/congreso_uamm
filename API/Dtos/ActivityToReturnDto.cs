using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class ActivityToReturnDto
    {
        public int Id {get; set;}
         public string Name { get; set; }
        public string Place { get; set; }
        public string Schedule { get; set; }
        public List<RapportuerToReturnDto> Rapportuers { get; set; }
        public string Career {get; set;}
        public string ActivityType {get; set;}
        public List<AtendeeWithNoActivitiesToReturnDto> Attendees {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ParticipantToReturnDto
    {
        public string Name;
        public string Email { get; set; }
        public string Career { get; set; }
    }
}
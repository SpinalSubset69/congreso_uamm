using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ParticipantsForCountSpecification : BaseSpecification<Participant>
    {
        public ParticipantsForCountSpecification(ParticipantSpecParams participantParams)
        : base(x => 
         (!string.IsNullOrEmpty(participantParams.Search) || x.Name.ToLower().Contains(participantParams.Search))
        )
        {
            
        }
    }
}
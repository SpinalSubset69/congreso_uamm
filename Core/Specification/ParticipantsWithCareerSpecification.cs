using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ParticipantsWithCareerSpecification : BaseSpecification<Participant>  
    {
        public ParticipantsWithCareerSpecification(ParticipantSpecParams participantParams)
        :base (x => 
        (!string.IsNullOrEmpty(participantParams.Search) || x.Name.ToLower().Contains(participantParams.Search))
        )
        {
            AddIncludes(x => x.Career);
            AddOrderBy(x => x.RegisterDate);
            ApplyPaging(participantParams.pageSize * (participantParams.PageIndex - 1), participantParams.pageSize);

            if(!string.IsNullOrEmpty(participantParams.Sort)){
                switch(participantParams.Sort){
                    case "name":
                    AddOrderBy(x => x.Name);
                    break;
                }
            }
        }
    }
}
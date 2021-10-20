using Core.Entities;

namespace Core.Specification
{
    public class AttendeeSpecification : BaseSpecification<Attendee>
    {  
        public AttendeeSpecification(AttendeeSpecParams attendeeParams)
        :base( x =>
            (string.IsNullOrEmpty(attendeeParams.Search) || x.Name.ToLower().Contains(attendeeParams.Search.ToLower())) ||
            (string.IsNullOrEmpty(attendeeParams.Search) || x.Career.Name.ToLower().Contains(attendeeParams.Search.ToLower())) ||
            (string.IsNullOrEmpty(attendeeParams.Search) || x.Activity.Name.ToLower().Contains(attendeeParams.Search.ToLower()))
        )
        {
            AddIncludes(x => x.Career);
            AddIncludes(x => x.Activity);
            ApplyPaging(attendeeParams.PageSize * (attendeeParams.PageIndex - 1), attendeeParams.PageSize);


        }
    }
}
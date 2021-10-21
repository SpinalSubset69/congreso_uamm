using Core.Entities;

namespace Core.Specification
{
    public class AttendeeSpecification : BaseSpecification<Attendee>
    {
        public AttendeeSpecification(string number) : base(x => x.StudentNumber == number)
        {            
            AddIncludes(x => x.Activities);
        }
        public AttendeeSpecification(AttendeeSpecParams attendeeParams)
        : base(x =>
            (string.IsNullOrEmpty(attendeeParams.Search) || x.Name.ToLower().Contains(attendeeParams.Search.ToLower())) ||
            (string.IsNullOrEmpty(attendeeParams.Search) || x.Career.ToLower().Contains(attendeeParams.Search.ToLower()))

        )
        {           
            AddIncludes(x => x.Activities);
            ApplyPaging(attendeeParams.PageSize * (attendeeParams.PageIndex - 1), attendeeParams.PageSize);
        }
    }
}
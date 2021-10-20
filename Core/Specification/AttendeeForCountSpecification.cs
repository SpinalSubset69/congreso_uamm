using Core.Entities;

namespace Core.Specification
{
    public class AttendeeForCountSpecification : BaseSpecification<Attendee>
    {
        public AttendeeForCountSpecification(AttendeeSpecParams attendeeParams)
        :base( x =>
            (string.IsNullOrEmpty(attendeeParams.Search) || x.Name.ToLower().Contains(attendeeParams.Search.ToLower())) ||
            (string.IsNullOrEmpty(attendeeParams.Search) || x.Career.Name.ToLower().Contains(attendeeParams.Search.ToLower())) ||
            (string.IsNullOrEmpty(attendeeParams.Search) || x.Activity.Name.ToLower().Contains(attendeeParams.Search.ToLower()))
        ){}
    }
}
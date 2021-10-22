using Core.Entities;

namespace Core.Specification
{
    public class AttendeeForCountSpecification : BaseSpecification<Attendee>
    {
        public AttendeeForCountSpecification(AttendeeSpecParams attendeeParams)
        : base(x =>
        (string.IsNullOrEmpty(attendeeParams.Carrera) || x.Career.ToLower().Contains(attendeeParams.Carrera)) &&
         (string.IsNullOrEmpty(attendeeParams.Dia) || x.Day.ToLower().Contains(attendeeParams.Dia)) &&
         (string.IsNullOrEmpty(attendeeParams.Hora) || x.Day.ToLower().Contains(attendeeParams.Hora))
        )
        { }
    }
}
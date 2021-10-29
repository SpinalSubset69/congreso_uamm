using Core.Entities;

namespace Core.Specification
{
    public class StudentForCountSpecification : BaseSpecification<Student>
    {
        public StudentForCountSpecification(StudentSpecParams attendeeParams)
        : base(x =>
        (string.IsNullOrEmpty(attendeeParams.Carrera) || x.Career.ToLower().Contains(attendeeParams.Carrera)) &&
         (string.IsNullOrEmpty(attendeeParams.Dia) || x.Day.ToLower().Contains(attendeeParams.Dia)) &&
         (string.IsNullOrEmpty(attendeeParams.Hora) || x.Day.ToLower().Contains(attendeeParams.Hora))
        )
        { }
    }
}
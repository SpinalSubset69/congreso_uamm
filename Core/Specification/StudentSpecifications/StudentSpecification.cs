using Core.Entities;

namespace Core.Specification
{
    public class StudentSpecification : BaseSpecification<Student>
    {
        public StudentSpecification(string number) : base(x => x.StudentNumber == number)
        {         
            AddIncludes(x => x.Activities);
        }
        public StudentSpecification(StudentSpecParams attendeeParams)
        : base(x =>
        (string.IsNullOrEmpty(attendeeParams.Carrera) || x.Career.ToLower().Contains(attendeeParams.Carrera)) &&
        (string.IsNullOrEmpty(attendeeParams.Dia) || x.Day.ToLower().Contains(attendeeParams.Dia)) &&
        (string.IsNullOrEmpty(attendeeParams.Hora) || x.Day.ToLower().Contains(attendeeParams.Hora))
        )

        {           
            AddIncludes(x => x.Activities);
            ApplyPaging(attendeeParams.PageSize * (attendeeParams.PageIndex - 1), attendeeParams.PageSize);

            if (!string.IsNullOrEmpty(attendeeParams.Ordenar))
            {
                switch (attendeeParams.Ordenar)
                {
                    case "nombre":
                        AddOrderBy(x => x.Name);
                        break;
                    case "carrera":
                        AddOrderBy(x => x.Career);
                        break;
                    case "hora":
                        AddOrderBy(x => x.Hour);
                        break;
                    case "dia":
                        AddOrderBy(x => x.Day);
                        break;
                }
            }
        }
    }
}
using Core.Entities;

namespace Core.Specification
{
    public class ActivitySpecifications : BaseSpecification<Activity>
    {
        public ActivitySpecifications(int? id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.Rapportuers);
            AddIncludes(x => x.Attendees);
        }
        public ActivitySpecifications()
        {
            AddIncludes(x => x.Rapportuers);
            AddIncludes(x => x.Attendees);
        }
        public ActivitySpecifications(ActivitySpecParams activityParams)
        : base(x =>
         (string.IsNullOrEmpty(activityParams.Carrera) || x.Career.ToLower().Contains(activityParams.Carrera.ToLower())) &&
         (string.IsNullOrEmpty(activityParams.Tipo) || x.ActivityType.ToLower().Contains(activityParams.Tipo.ToLower())) &&
         (string.IsNullOrEmpty(activityParams.Dia) || x.Day.ToLower().Contains(activityParams.Dia.ToLower())) &&
         (string.IsNullOrEmpty(activityParams.Hora) || x.Hour.ToLower().Contains(activityParams.Hora.ToLower()))
        )
        {
            AddIncludes(x => x.Rapportuers);
            AddIncludes(x => x.Attendees);
            ApplyPaging(activityParams.PageSize * (activityParams.PageIndex - 1), activityParams.PageSize);

            if (!string.IsNullOrEmpty(activityParams.Ordenar))
            {
                switch (activityParams.Ordenar)
                {
                    case "carrera":
                        AddOrderBy(s => s.Career);
                        break;
                    case "fecha":
                        AddOrderBy(s => s.Schedule);
                        break;
                    case "hora":
                        AddOrderBy(s => s.Hour);
                        break;
                    case "dia":
                        AddOrderBy(s => s.Day);
                        break;
                    default:
                        AddOrderByDesc(s => s.Schedule);
                        break;
                }
            }
        }
    }
}
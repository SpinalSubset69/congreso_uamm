

using Core.Entities;

namespace Core.Specification
{
    public class ActivityForCountSpecification: BaseSpecification<Activity>
    {
        public ActivityForCountSpecification(ActivitySpecParams activityParams)
        :base(x => 
         (string.IsNullOrEmpty(activityParams.Carrera) || x.Career.ToLower().Contains(activityParams.Carrera.ToLower())) &&
         (string.IsNullOrEmpty(activityParams.Tipo) || x.ActivityType.ToLower().Contains(activityParams.Tipo.ToLower())) &&
         (string.IsNullOrEmpty(activityParams.Dia) || x.Day.ToLower().Contains(activityParams.Dia.ToLower())) &&
         (string.IsNullOrEmpty(activityParams.Hora) || x.Hour.ToLower().Contains(activityParams.Hora.ToLower()))
        )
        {
            
        }
    
        
    }
        
}
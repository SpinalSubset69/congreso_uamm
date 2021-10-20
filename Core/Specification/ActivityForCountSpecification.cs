

using Core.Entities;

namespace Core.Specification
{
    public class ActivityForCountSpecification: BaseSpecification<Activity>
    {
        public ActivityForCountSpecification(ActivitySpecParams activityParams)
        :base(x => (string.IsNullOrEmpty(activityParams.Search) || x.Name.ToLower().Contains(activityParams.Search.ToLower()))        
        )
        {
            
        }
    
        
    }
        
}
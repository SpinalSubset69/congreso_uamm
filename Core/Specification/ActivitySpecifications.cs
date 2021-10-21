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
         (string.IsNullOrEmpty(activityParams.Search) || x.Name.ToLower().Contains(activityParams.Search.ToLower()))
        )
        {    
            AddIncludes(x => x.Rapportuers);
            AddIncludes(x => x.Attendees);                           
            AddOrderBy(s => s.Schedule);
            ApplyPaging(activityParams.PageSize * (activityParams.PageIndex - 1), activityParams.PageSize);

            if (!string.IsNullOrEmpty(activityParams.Sort))
            {
                switch (activityParams.Sort)
                {
                    case "name":
                        AddOrderBy(s => s.Name);
                        break;
                    case "career":
                        AddOrderBy(s => s.Career);
                        break;
                    case "type":
                        AddOrderBy(s => s.ActivityType);
                        break;
                    case "ponente":
                        AddOrderByDesc(s => s.Rapportuers);
                        break;
                    default:
                        AddOrderByDesc(s => s.Schedule);
                        break;
                }
            }
        }
    }
}
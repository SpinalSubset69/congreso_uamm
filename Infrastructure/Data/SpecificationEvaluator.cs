using System.Linq;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator <T> where T : BaseEntity
    {
        public static IQueryable<T> GetQueryable(IQueryable<T> inputQuery, ISpecification<T> spec){
            var query = inputQuery;

            if(spec.Criteria != null){
                query = query.Where(spec.Criteria);
            }
            if(spec.OrderBy != null){
                query = query.OrderBy(spec.OrderBy);
            }

            if(spec.isPaggingEnabled){
                query = query.Skip(spec.skip).Take(spec.take);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query;
        } 
    }
}
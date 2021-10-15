using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    ///
    /// <summary>
    /// Properties of the specifications
    ///</summary>
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; set;}
        Expression<Func<T, Object>> OrderBy {get; set;}
        Expression<Func<T, Object>> OrderByDesc {get; set;}
        List<Expression<Func<T, Object>>> Includes {get; set;}
        int take {get; set;}
        int skip {get; set;}
        bool isPaggingEnabled {get; set;}
    }
}
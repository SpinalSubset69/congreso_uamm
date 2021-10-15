using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {   
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }

        public int take { get; set; }

        public int skip { get; set; }

        public bool isPaggingEnabled { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, Object>>>();

        protected void AddIncludes(Expression<Func<T, Object>> include){
            Includes.Add(include);
        }
        protected void ApplyPaging(int skip, int take){
            this.skip = skip;
            this.take = take;
            isPaggingEnabled = true;
        }

        protected void AddOrderBy(Expression<Func<T, Object>> orderByExpression){
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<T, Object>> orderByDesc){
            OrderByDesc = orderByDesc;
        }
    }
}
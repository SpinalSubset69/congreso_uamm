using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<int> CountAsync(); 
        Task<T> GetEntityWithSpecs();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
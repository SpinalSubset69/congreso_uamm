using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly UammDbContext _context;
        public GenericRepository(UammDbContext context)
        {
            _context = context;

        }       

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
             return await ApplySpecification(spec).CountAsync();
        }

        public Task<T> GetEntityWithSpecs()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> SaveAsync(T entity) 
        {
             _context.Set<T>().Add(entity);
             return await _context.SaveChangesAsync();             
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQueryable(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
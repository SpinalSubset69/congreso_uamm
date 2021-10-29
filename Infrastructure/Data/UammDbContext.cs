using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UammDbContext : DbContext
    {
        public UammDbContext(DbContextOptions<UammDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students {get; set;}          
    }
}
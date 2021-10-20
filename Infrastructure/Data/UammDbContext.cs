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
        public DbSet<Attendee> Attendees {get; set;}
        public DbSet<Career> Careers {get; set;}
        public DbSet<Rapportuer> Rapportuers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
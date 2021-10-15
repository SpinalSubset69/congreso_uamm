using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ParticipantsDbContext : DbContext
    {
        public ParticipantsDbContext(DbContextOptions<ParticipantsDbContext> options) : base(options)
        {
            
        }
        public DbSet<Participant> Participants {get; set;}
        public DbSet<Career> Careers {get; set;}
    }
}
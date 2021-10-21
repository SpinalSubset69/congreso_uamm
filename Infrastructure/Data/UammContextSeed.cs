using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class UammContextSeed
    {
        public static async Task SeedDatabaseAsync(UammDbContext _context, ILoggerFactory _logger)
        {
            try
            {               
                if (!_context.Rapportuers.Any())
                {
                    var rapportuersData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedInfo/Rapportuers.json");
                    var rapportuers = JsonSerializer.Deserialize<List<Rapportuer>>(rapportuersData);
                    foreach (var rapportuer in rapportuers)
                    {                        
                        _context.Rapportuers.Add(rapportuer);
                    }

                    
                    await _context.SaveChangesAsync();
                }                
                if (!_context.Activities.Any())
                {
                    var activitiesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedInfo/Activities.json");
                    var activities = JsonSerializer.Deserialize<List<Activity>>(activitiesData);
                    foreach (var activity in activities)
                    {                       
                        _context.Activities.Add(activity);
                    }
                    await _context.SaveChangesAsync();
                }
                if (!_context.Attendees.Any())
                {
                    var attendeesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedInfo/Attendees.json");
                    var attendees = JsonSerializer.Deserialize<List<Attendee>>(attendeesData);

                    foreach (var attendee in attendees)
                    {                        
                        _context.Attendees.Add(attendee);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = _logger.CreateLogger<UammContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
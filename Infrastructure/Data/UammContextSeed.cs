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
                if (!_context.Students.Any())
                {
                    var studentsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedInfo/Students.json");
                    var students = JsonSerializer.Deserialize<List<Student>>(studentsData);

                    foreach (var student in students)
                    {                        
                        _context.Students.Add(student);
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
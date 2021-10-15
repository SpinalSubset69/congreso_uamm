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
    public class ParticipantsContextSeed
    {
        public static async Task SeedDatabaseAsync(ParticipantsDbContext _context, ILoggerFactory _logger)
        {
            try{
                if (!_context.Careers.Any())
            {
                var careersData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedInfo/Careers.json");
                var careers = JsonSerializer.Deserialize<List<Career>>(careersData);
                foreach(var carerr in careers){
                    _context.Careers.Add(carerr);
                }
                await _context.SaveChangesAsync();
            }
            if (!_context.Participants.Any())
            {
                var participantsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedInfo/Participants.json");
                var participants = JsonSerializer.Deserialize<List<Participant>>(participantsData);

                foreach (var participant in participants)
                {
                    _context.Participants.Add(participant);
                }
                await _context.SaveChangesAsync();
            }
            }catch(Exception ex){
                var logger = _logger.CreateLogger<ParticipantsContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
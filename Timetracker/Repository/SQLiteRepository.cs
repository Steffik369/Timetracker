using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timetracker.Models;

namespace Timetracker.Repository
{
    public class SQLiteRepository : ITimetrackerRepository
    {
        private readonly TimetrackerDbContext timetrackerContext;
        public SQLiteRepository(TimetrackerDbContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context), "Given context is NULL!");

            timetrackerContext = context;
        }

        public async Task AddItemAsync(JobItem jobItem)
        {
            if (jobItem is null) throw new ArgumentNullException(nameof(jobItem), "Given item is NULL!");

            await timetrackerContext.AddAsync(jobItem);
            await timetrackerContext.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(JobItem jobItem)
        {
            if (jobItem is null) throw new ArgumentNullException(nameof(jobItem), "Given item is NULL!");

            timetrackerContext.Remove(jobItem);
            await timetrackerContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            timetrackerContext.Dispose();
        }

        public async Task<JobItem> GetItemAsync(Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentOutOfRangeException(nameof(id), "Given id was empty!");

            return await timetrackerContext.JobItems.Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<JobItem>> GetItemsAsync()
        {
            return await timetrackerContext.JobItems.ToListAsync();
        }

        public async Task UpdateItemAsync(JobItem jobItem)
        {
            if (jobItem is null) throw new ArgumentNullException(nameof(jobItem), "Given item is NULL!");

            timetrackerContext.Update(jobItem);
            await timetrackerContext.SaveChangesAsync();
        }
    }
}

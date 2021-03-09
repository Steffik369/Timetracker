using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timetracker.Models;

namespace Timetracker.Repository
{
    interface ITimetrackerRepository : IDisposable
    {
        Task AddItemAsync(JobItem jobItem);

        Task<List<JobItem>> GetItemsAsync();

        Task<JobItem> GetItemAsync(Guid id);

        Task UpdateItemAsync(JobItem jobItem);

        Task DeleteItemAsync(JobItem jobItem);
    }
}

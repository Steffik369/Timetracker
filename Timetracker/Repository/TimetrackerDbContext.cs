using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timetracker.Models;

namespace Timetracker.Repository
{
    public class TimetrackerDbContext : DbContext
    {
        public TimetrackerDbContext(DbContextOptions<TimetrackerDbContext> options) : base(options)
        { }

        public DbSet<JobItem> JobItems { get; set; }
    }
}

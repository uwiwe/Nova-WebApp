using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nova_WebApp.Server.Models;

namespace Nova_WebApp.Server.Data
{
    public class Nova_WebAppServerContext : DbContext
    {
        public Nova_WebAppServerContext (DbContextOptions<Nova_WebAppServerContext> options)
            : base(options)
        {
        }

        public DbSet<Nova_WebApp.Server.Models.User> User { get; set; } = default!;
    }
}

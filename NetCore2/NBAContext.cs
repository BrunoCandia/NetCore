using Microsoft.EntityFrameworkCore;
using NetCore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2
{
    public class NBAContext : DbContext
    {
        public NBAContext(DbContextOptions<NBAContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}

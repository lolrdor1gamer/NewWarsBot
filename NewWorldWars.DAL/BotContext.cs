using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewWorldWars.DAL
{
    public class BotContext : DbContext
    {
        public BotContext(DbContextOptions<BotContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<WarEvent> WarEvents { get; set; }
    }
}

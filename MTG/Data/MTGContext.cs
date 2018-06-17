using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MTG.Models
{
    public class MTGContext : DbContext
    {
        public MTGContext (DbContextOptions<MTGContext> options)
            : base(options)
        {
        }

        public DbSet<MTG.Models.Card> Card { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameBuddiAPI.Models;

namespace GameBuddiAPI.Data
{
    public class GameBuddiAPIContext : DbContext
    {
        public GameBuddiAPIContext (DbContextOptions<GameBuddiAPIContext> options)
            : base(options)
        {
        }

        public DbSet<GameBuddiAPI.Models.User> User { get; set; } = default!;

        public DbSet<GameBuddiAPI.Models.Review> Review { get; set; } = default!;

        public DbSet<GameBuddiAPI.Models.ReviewComment> ReviewComment { get; set; } = default!;
    }
}

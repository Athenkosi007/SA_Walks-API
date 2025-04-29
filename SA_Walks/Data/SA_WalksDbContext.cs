using Microsoft.EntityFrameworkCore;
using SA_Walks.API.Models.Domain;

namespace SA_Walks.API.Data
{


    public class SA_WalksDbContext : DbContext
    {
        public SA_WalksDbContext(DbContextOptions<SA_WalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }

}

using  Microsoft.EntityFrameworkCore;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("cb0df157-43ac-4a7a-9cc1-d5fdfe50236b"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("78d9fb01-25b7-494c-8d4b-6c389e1b1e33"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("f5241c79-fea3-4330-b7c3-2a293330be89"),
                    Name = "Hard"
                }
            };

            //Seed difficulties into the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed Data for Regions
            var regions = new List<Region>
            {
                new Region()
                {
                    Id = Guid.Parse("52757937-a2e0-46bc-bbca-8cc05a9672ba"),
                    Code = "EC",
                    Name = "Eastern Cape",
                    RegionImageUrl = "https://www.southaustralia.com/globalassets/regions/sa/sa-region.jpg"
                },
            
            
                new Region()
                {
                    Id = Guid.Parse("7fdc10db-d19b-4190-8573-64ce42cf401a"),
                    Code = "GP",
                    Name = "Western Cape",
                    RegionImageUrl = "https://www.southaustralia.com/globalassets/regions/sa/sa-region.jpg"
                },
            
            
                new Region()
                {
                    Id = Guid.Parse("97fbee3a-a04d-4ab6-ba5e-54c0ce39ebfe"),
                    Code = "MPA",
                    Name = "Mpumalanga",
                    RegionImageUrl = "https://www.southaustralia.com/globalassets/regions/sa/sa-region.jpg"
                },
            
            
                new Region()
                {
                    Id = Guid.Parse("9f36b0fd-e93a-418a-84c9-d6bd773ee215"),
                    Code = "KZN",
                    Name = "KwaZulu-Natal",
                    RegionImageUrl = "https://www.southaustralia.com/globalassets/regions/sa/sa-region.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("1bb825d9-f26f-4c5c-a319-030a55aec9fc"),
                    Code = "FS",
                    Name = "Free State",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("1dceacbf-1d64-4fb7-a45b-daeb1505ece4"),
                    Code = "L",
                    Name = "Limpopo",
                    RegionImageUrl = null
                }
            };
            modelBuilder.Entity<Region>().HasData(regions);

            modelBuilder.Entity<Walk>()
                .HasOne(w => w.Difficulty)
                .WithMany()
                .HasForeignKey(w => w.DifficultyId);

            modelBuilder.Entity<Walk>()
                .HasOne(w => w.Region)
                .WithMany()
                .HasForeignKey(w => w.RegionId);
        }
    }

}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SA_Walks.API.Data
{
    public class SA_WalksAuthDbContext: IdentityDbContext
    {
        public SA_WalksAuthDbContext(DbContextOptions<SA_WalksAuthDbContext> options) : base(options)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "0c03ddbb-4b32-471f-832d-4069e859b0a3";
            var writerRoleId = "7aa64b50-30b5-4a0a-99a5-ffa294e98069";

            var roles = new List<IdentityRole>
            {
              
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    NormalizedName = "Reader".ToUpper(),
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    NormalizedName = "Writer".ToUpper(),
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

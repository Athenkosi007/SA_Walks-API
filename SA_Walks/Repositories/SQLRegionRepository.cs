using Microsoft.EntityFrameworkCore;
using SA_Walks.API.Data;
using SA_Walks.API.Models.Domain;

namespace SA_Walks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly SA_WalksDbContext dbContext;

        public SQLRegionRepository(SA_WalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        
    }
}

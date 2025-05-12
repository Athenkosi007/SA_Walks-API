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

        public async Task<Region> CreateAsync(Region region)
        {
            //region.Id = Guid.NewGuid();
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
               
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion != null)
            {
                existingRegion.Code = region.Code;
                existingRegion.Name = region.Name;
                existingRegion.RegionImageUrl = region.RegionImageUrl;
                await dbContext.SaveChangesAsync();
                return existingRegion;
            }
            else
            {
                return null;
            }
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
           var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x=> x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }
            //delete region
            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;


        }
    }
}

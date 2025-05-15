using SA_Walks.API.Models.Domain;
using SA_Walks.API.Data;
using Microsoft.EntityFrameworkCore;

namespace SA_Walks.API.Repositories
{
    public class SQLWalkRepository: IWalkRepository
    {

        private readonly SA_WalksDbContext dbContext;
        public SQLWalkRepository(SA_WalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            //Add the walk to the database
            await dbContext.Walks.AddAsync(walk);

            //Save the changes to the database
            await dbContext.SaveChangesAsync();

            //Return the walk
            return walk;
        }


        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }
            else
            {
                existingWalk.Name = walk.Name;
                existingWalk.Description = walk.Description;
                existingWalk.LengthInKm = walk.LengthInKm;
                existingWalk.WalkImageUrl = walk.WalkImageUrl;
                existingWalk.DifficultyId = walk.DifficultyId;
                existingWalk.RegionId = walk.RegionId;

                await dbContext.SaveChangesAsync();
                return existingWalk;
            }
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }
            else
            {
                dbContext.Walks.Remove(existingWalk);
                await dbContext.SaveChangesAsync();
                return existingWalk;
            }
        }
    }
}

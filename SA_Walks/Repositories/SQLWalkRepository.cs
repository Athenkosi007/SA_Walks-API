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


        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true, int pageNumber=1, int pageSize = 1000)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //Filter the walks based on the filterOn and filterQuery parameters
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
                else if (filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Description.Contains(filterQuery));
                }
            }

            //Sort the walks based on the sortBy and isAscending parameters

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    //ternary operator to check if isAscending is true or false
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    //ternary operator to check if isAscending is true or false
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            //Paginate the walks based on the pageNumber and pageSize parameters
            var skipPages = (pageNumber - 1) * pageSize;
            walks = walks.Skip(skipPages).Take(pageSize);

            //Return the walks as a list
            return await walks.Skip(skipPages).Take(pageSize).ToListAsync();



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

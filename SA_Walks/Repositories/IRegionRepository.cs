
using SA_Walks.API.Models.Domain;

namespace SA_Walks.API.Repositories
{
    public interface IRegionRepository
    {
       Task<List<Region>> GetAllAsync();
    }
}

using Microsoft.AspNetCore.Identity;

namespace SA_Walks.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}

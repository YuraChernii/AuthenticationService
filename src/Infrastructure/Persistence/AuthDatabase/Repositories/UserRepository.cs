using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.AuthDatabase.Repositories
{
    public class UserRepository(AuthContext context) : IUserRepository
    {
        public async Task<User?> GetUserAsync(string userName) =>
            await context.Users.FirstOrDefaultAsync(x => x.UserName.Equals(userName));

        public async Task SaveChangesAsync() =>
            await context.SaveChangesAsync();
    }
}
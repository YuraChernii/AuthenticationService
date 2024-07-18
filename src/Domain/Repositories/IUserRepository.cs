using Core.Entities;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string userName);
        Task SaveChangesAsync();
    }
}
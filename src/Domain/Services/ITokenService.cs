namespace Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
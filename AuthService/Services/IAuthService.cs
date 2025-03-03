using System.Threading.Tasks;
using AuthService.Models;

namespace AuthService.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> Authenticate(AuthRequest request);
    }
}
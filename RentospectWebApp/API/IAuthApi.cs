using Refit;
using RentospectWebApp.DTOs;

namespace RentospectWebApp.API
{
    public interface IAuthApi
    {
        [Post("/api/auth/login")]
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
}

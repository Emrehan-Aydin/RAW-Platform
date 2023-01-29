using RAWAPI.Domain.Entities.Identity;

namespace RAWAPI.Application.Abstractions.Token {
    public interface ITokenHandler
    {
        Domain.Dtos.Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}

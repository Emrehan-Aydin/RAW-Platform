using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAWAPI.Application.Abstractions.Services.Authentications {
    public interface IInternalAuthentication
    {
        Task<Domain.Dtos.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task<Domain.Dtos.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}

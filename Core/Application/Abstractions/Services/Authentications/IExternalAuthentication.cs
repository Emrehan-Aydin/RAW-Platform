using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAWAPI.Application.Abstractions.Services.Authentications {
    public interface IExternalAuthentication
    {
        Task<Domain.Dtos.Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);
        Task<Domain.Dtos.Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}

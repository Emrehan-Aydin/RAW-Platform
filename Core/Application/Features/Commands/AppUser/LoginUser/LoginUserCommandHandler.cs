using RAWAPI.Application.Abstractions.Services;
using MediatR;
using RAWAPI.Domain.Dtos.Request.User;
using RAWAPI.Domain.Dtos.Response.User;
using RAWAPI.Application.Exceptions;
using RAWAPI.Domain.Dtos;

namespace RAWAPI.Application.Features.Commands.AppUser.LoginUser {
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;
        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            try {
                var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);
                return new LoginUserSuccessCommandResponse() {
                    IsSucceed = true,
                    Message = "Giriş Başarılı",
                    Token = token
                };
            }
            catch(AuthenticationErrorException ex){
                return new LoginUserSuccessCommandResponse() {
                    IsSucceed = false,
                    Message = ex.Message,
                };
            }
            catch(Exception ex) when(ex!=null) {
                return new LoginUserSuccessCommandResponse() {
                    IsSucceed = false,
                    Message = ex.Message,
                };
            }
            
          
        }
    }
}
using MediatR;
using Newtonsoft.Json;
using RAWAPI.Domain.Dtos.Request.DashBoard;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RAW.Client.TokenService {
    public static class TokenHelper {

        public static void SaveToken(HttpResponse response,string token) {
            try {
                response.Cookies.Append("Token", token, new CookieOptions { Expires = DateTime.Now.AddDays(1) });
            }
            catch (Exception ex) when (ex != null) {
                return;
            }
        }

        public static string GetCurrentUserToken(HttpRequest request) {
			try {
				return request.Cookies["Token"];
			}
			catch (Exception ex) when (ex != null){
				return string.Empty;
			}
        }

        public static void ClearToken(HttpResponse request) {
            try {
                request.Cookies.Delete("Token");
            }
            catch (Exception ex) when (ex != null) {
                return;
            }
        }

        public static bool IsAuth(HttpRequest request) {
            try {
                return request.Cookies["Token"]!=null;
            }
            catch (Exception ex) when (ex != null) {
                return false;
            }
        }

        public static string GetUserId(HttpRequest request) {
            try {
                string token = GetCurrentUserToken(request);
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);
                Claim guId = jsonToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                return guId.Value;
            }
            catch (Exception ex) when (ex != null) {
                return string.Empty;
            }
        }



        
    }
}
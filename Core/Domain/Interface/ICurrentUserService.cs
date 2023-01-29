namespace RAWAPI.Domain.Interface {
    public interface ICurrentUserService {
        void Authenticate(string token);
        bool Logout();
        string GetUserId();
        string GetUserName();
        string GetUserEmail();
        List<string> GetRoles();
        bool IsAuthenticated();
        string GetIpAddress();
        string GetToken();
    }
}

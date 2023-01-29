namespace RAWAPI.Domain.Dtos.Response.User{
    public class GetAllUsersQueryResponse
    {
        public object Users { get; set; }
        public int TotalUsersCount { get; set; }
    }
}
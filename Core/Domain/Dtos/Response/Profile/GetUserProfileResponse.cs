namespace RAWAPI.Domain.Dtos.Response.Profile {
    public  class GetUserProfileResponse {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Abstract { get; set; }
        public string PhotoUrl { get; set; }
    }
}

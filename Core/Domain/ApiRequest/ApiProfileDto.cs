namespace RAWAPI.Domain.ApiRequest {
    public class ApiProfileDto {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Abstract { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }
}

using RAW.Client.Dto;

public class LoginRequestDto : PageResponse{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}
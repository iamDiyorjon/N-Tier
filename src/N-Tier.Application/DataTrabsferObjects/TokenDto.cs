
//public record TokenDto(
//    string accessToken,
//    string? refreshToken,
//    DateTime expireDate);

public class TokenDto
{
    public string AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime ExpireDate { get; set; }
}
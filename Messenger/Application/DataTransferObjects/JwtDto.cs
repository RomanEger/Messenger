namespace Application.DataTransferObjects;

public record JwtDto(string AccessToken, string RefreshToken);
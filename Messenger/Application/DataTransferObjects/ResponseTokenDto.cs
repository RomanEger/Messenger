namespace Application.DataTransferObjects;

public record ResponseTokenDto(AccessTokenDto AccessTokenDto, string RefreshToken);
namespace Application.DataTransferObjects;

public record AuthenticationResult(string Token, UserDto User);
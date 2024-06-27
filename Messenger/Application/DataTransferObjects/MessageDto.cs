namespace Application.DataTransferObjects;

public record MessageDto(string Message, string UserName, Guid ChatId, Guid MessageType);
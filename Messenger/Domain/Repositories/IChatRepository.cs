using Domain.Entities;

namespace Domain.Repositories;

public interface IChatRepository
{
    Task CreateAsync(Chat newChat);
    
    Task GetByNameAsync(string chatName);

    void Update(Chat chat);

    void Delete(Chat chat);

    void Delete(Guid id);
}
using Domain.Entities;

namespace Domain.Repositories;

public interface IChatMemberRepository
{
    Task AddMemberAsync(ChatMember chatMember);

    void RemoveMember(ChatMember chatMember);
}
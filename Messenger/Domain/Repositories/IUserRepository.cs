using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<bool> CreateAsync(User newUser);

    Task<User?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<User?> FindByConditionAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default);

    void Update(User user);

    void Delete(User user);
}
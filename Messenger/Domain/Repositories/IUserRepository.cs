using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User newUser);

    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<User?> GetByConditionAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default);

    void Update(User user);

    void Delete(User user);
}
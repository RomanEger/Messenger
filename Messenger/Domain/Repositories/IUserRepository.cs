using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Abstractions;

public interface IUserRepository
{
    Task CreateAsync(User newUser);

    Task<User> GetAsync(Expression<Func<User, bool>> expression);
    
    Task<IEnumerable<>>
}
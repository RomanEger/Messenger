using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task<User?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<User?> FindByConditionAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<bool> CreateAsync(User newUser)
    {
        return await dbContext.Users.AddAsync(newUser) is not null;
    }

    public void Update(User user)
    {
        dbContext.Users.Update(user);
    }

    public void Delete(User user)
    {
        dbContext.Users.Remove(user);
    }
}
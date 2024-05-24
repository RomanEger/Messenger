using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<User?> GetByConditionAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task CreateAsync(User newUser)
    {
        await dbContext.Users.AddAsync(newUser);
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
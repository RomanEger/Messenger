using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public Task<User?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<User?> FindByConditionAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default)
    {
        return dbContext.Users.AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<bool> CreateAsync(User newUser)
    {
        if(newUser.IsValid)
            return await dbContext.Users.AddAsync(newUser) is not null;
        return false;
    }

    public void Update(User user)
    {
        if(user.IsValid)
            dbContext.Users.Update(user);
    }

    public void Delete(User user)
    {
        dbContext.Users.Remove(user);
    }
}
using Microsoft.EntityFrameworkCore;
using PlainMinimalApi.Abstract.Repositories;
using PlainMinimalApi.Context;
using PlainMinimalApi.Entities;
using PlainMinimalApi.Extensions;

namespace PlainMinimalApi.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _ctx;

    public UserRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<User?> GetById(string id)
    {
        var user = await _ctx.Users.Where(u => u.Email == id).FirstOrDefaultAsync();

        return user;
    }

    public async Task<IList<User>> FindByName(string name)
    {
        var user = await _ctx.Users.Where(u => u.Name!.Equals(name, StringComparison.InvariantCultureIgnoreCase))
            .ToListAsync();

        return user;
    }

    public async Task<User> Create(User u)
    {
        var user = _ctx.Users.Add(u);
        await _ctx.SaveChangesAsync();

        return user.Entity;
    }

    public async Task<User?> Update(string id, User u)
    {
        var user = await this.GetById(id);

        if (user != null)
        {
            user.Name = u.Name ?? user.Name;
            user.LastName = u.LastName ?? user.LastName;
            
            // TODO: Encrypt
            user.Password = u.Password ?? user.Password;
            
            // TODO: Image
        }

        await _ctx.SaveChangesAsync();

        return user;
    }

    public async Task<User> Delete(string id)
    {
        var user = await this.GetById(id);
        if (user is null)
            throw new Exception("User not found");
        
        _ctx.Users.Remove(user);

        await _ctx.SaveChangesAsync();
        return user;
    }

    public async Task<PaginatedList<User>> GetAll(int page, int limit)
    {
        var users = await PaginatedList<User>.CreateAsync(
            _ctx.Users.OrderBy(u => u.Email), page, limit
        );

        return users;
    }
}
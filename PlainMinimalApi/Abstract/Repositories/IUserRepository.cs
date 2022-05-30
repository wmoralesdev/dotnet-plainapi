using PlainMinimalApi.Entities;
using PlainMinimalApi.Extensions;

namespace PlainMinimalApi.Abstract.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(string id);

    Task<IList<User>> FindByName(string name);

    Task<User> Create(User u);

    Task<User?> Update(string id, User u);

    Task<User> Delete(string id);

    Task<PaginatedList<User>> GetAll(int page, int limit);
}
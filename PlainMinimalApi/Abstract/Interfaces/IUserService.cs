using PlainMinimalApi.Entities;
using PlainMinimalApi.Extensions;
using PlainMinimalApi.ViewModels;

namespace PlainMinimalApi.Abstract.Interfaces;

public interface IUserService
{
    Task<User> GetById(string id);

    Task<IList<User>> FindByName(string name);

    Task<User> Create(User u);

    Task<User> Login(LoginVm login);

    Task<User> Update(User u);

    Task<User> Delete(string id);

    Task<PaginatedList<User>> GetAll(int page, int limit);
}
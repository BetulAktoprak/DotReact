using DotReact.Domain.Entities;
using DotReact.Domain.Interfaces;
using DotReact.Infrastructure.Context;

namespace DotReact.Infrastructure.Repositories;
public class UserRepository(AppDbContext context) : GenericRepository<User>(context), IUserRepository
{
}

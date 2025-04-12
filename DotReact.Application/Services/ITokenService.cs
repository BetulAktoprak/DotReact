using DotReact.Domain.Entities;

namespace DotReact.Application.Services;
public interface ITokenService
{
    string CreateToken(User user);
}

using DotReact.Application.Features.Services;
using DotReact.Application.Features.Users.Commands;
using DotReact.Application.Services;
using DotReact.Domain.Interfaces;
using MediatR;

namespace DotReact.Application.Features.Users.Handlers;
public class LoginUserCommandHandler(
    IUserRepository userRepository,
    ITokenService tokenService) : IRequestHandler<LoginUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.LoginUserDto;
        var users = await userRepository.FindAsync(u => u.Email == dto.Email && u.Password == dto.Password);
        var user = users.FirstOrDefault();

        if (user is null)
        {
            return Result<string>.Failure("Kullanıcı adı veya şifre hatalı");
        }

        var token = tokenService.CreateToken(user);

        return Result<string>.Success(token);
    }
}

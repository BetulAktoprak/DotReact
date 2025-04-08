using DotReact.Application.Features.Services;
using DotReact.Application.Features.Users.Commands;
using DotReact.Domain.Entities;
using DotReact.Domain.Interfaces;
using MediatR;

namespace DotReact.Application.Features.Users.Handlers;
public class RegisterUserCommandHandler(
    IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<RegisterUserCommand, Result<User>>
{
    public async Task<Result<User>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.User;
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password
        };

        await userRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<User>.Success(user);
    }
}

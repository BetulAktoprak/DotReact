using DotReact.Application.Features.Services;
using DotReact.Application.Features.Users.DTOs;
using MediatR;

namespace DotReact.Application.Features.Users.Commands;
public sealed record LoginUserCommand(LoginUserDto LoginUserDto) : IRequest<Result<string>>;


using DotReact.Application.Features.Services;
using DotReact.Application.Features.Users.DTOs;
using DotReact.Domain.Entities;
using MediatR;

namespace DotReact.Application.Features.Users.Commands;
public sealed record RegisterUserCommand(
    RegisterUserDto User) : IRequest<Result<User>>;


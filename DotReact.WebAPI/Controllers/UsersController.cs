using DotReact.Application.Features.Users.Commands;
using DotReact.Application.Features.Users.DTOs;
using DotReact.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotReact.WebAPI.Controllers;

public class UsersController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserDto userDto)
    {
        var result = await mediator.Send(new RegisterUserCommand(userDto));

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Error);
    }
}

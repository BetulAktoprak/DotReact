﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotReact.WebAPI.Abstractions;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    public readonly IMediator _mediator;

    protected ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}

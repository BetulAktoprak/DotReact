﻿using DotReact.Domain.Entities;
using MediatR;

namespace DotReact.Application.Features.Products.Queries;
public sealed record GetProductByIdQuery(Guid Id) : IRequest<Product>;

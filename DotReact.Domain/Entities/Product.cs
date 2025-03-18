using DotReact.Domain.Abstractions;

namespace DotReact.Domain.Entities;
public sealed class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int Stock { get; set; }
}

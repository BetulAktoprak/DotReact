namespace DotReact.Domain.Abstractions;
public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
}

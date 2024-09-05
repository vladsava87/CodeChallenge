namespace Interfaces;

public interface IBaseObject
{
    public int Id { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
}
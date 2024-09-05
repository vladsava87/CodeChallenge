namespace Interfaces.Data;

public interface ICoffeeModel : IBaseObject
{
    public string Name { get; set; }
    public string Description { get; set; }
}
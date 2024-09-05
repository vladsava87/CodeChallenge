namespace Api.Response;

public class CoffeeResponse
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}
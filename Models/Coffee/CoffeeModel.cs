using Interfaces.Data;

namespace Models.Coffee;

public class CoffeeModel : BindableBase, ICoffeeModel
{
    private int _id;
    public int Id
    {
        get => _id;
        set => Set(ref _id, value);
    }
    
    private DateTimeOffset _createdAt;
    public DateTimeOffset CreatedAt 
    {
        get => _createdAt;
        set => Set(ref _createdAt, value);
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    }
    
    private string _description;
    public string Description
    {
        get => _description;
        set => Set(ref _description, value);
    }
    
    private string _image;
    public string Image
    {
        get => _image;
        set => Set(ref _image, value);
    }
}
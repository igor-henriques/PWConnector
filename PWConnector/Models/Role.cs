namespace PWConnector.Models;

public record Role
{
    public int Id { get; private init; }
    public string Name { get; private init; }

    public Role(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}
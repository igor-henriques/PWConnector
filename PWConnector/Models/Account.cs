namespace PWConnector.Models;

public record Account
{
    public int Id { get; private init; }
    public string Login { get; private init; }
    public List<Role> Roles { get; set; }

    public Account(int id, string login = null, List<Role> roles = null)
    {
        this.Id = id;
        this.Login = login;
        this.Roles = roles ?? Roles ?? new List<Role>();
    }

    public void SetRoles(List<Role> roleList)
    {
        Roles = roleList;
    }
}
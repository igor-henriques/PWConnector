namespace PWConnector.Utils;

public static class Mapper
{
    public static Role ToRole(this Tuple<int, string> serverResponse)
    {
        return new Role(serverResponse.Item1, serverResponse.Item2);
    }

    public static List<Role> ToRoleList(this List<Tuple<int, string>> serverResponse)
    {
        return serverResponse.Select(ToRole).ToList();
    }
}
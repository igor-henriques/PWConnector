namespace PWConnector.Context;

public class DatabaseConnection
{
    public string HOST { get; set; }
    public string DB { get; set; }
    public string USER { get; set; }
    public string PASSWORD { get; set; }

    public static DatabaseConnection GetDatabaseConnection()
    {
        return JsonConvert.DeserializeObject<DatabaseConnection>(File.ReadAllText("./Database.json"));
    }

    public static string GetConnectionString()
    {
        var data = JsonConvert.DeserializeObject<DatabaseConnection>(File.ReadAllText("./Database.json"));
        return $"Persist Security Info=False;server={data.HOST};database={data.DB};uid={data.USER};pwd={data.PASSWORD}";
    }
}
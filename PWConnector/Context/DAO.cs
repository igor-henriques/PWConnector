namespace PWConnector.Context;

public class DAO
{
    private static readonly MySqlConnection _conn = new MySqlConnection(DatabaseConnection.GetDatabaseConnection().HOST);

    public static async Task<List<Account>> GetAccounts()
    {
        return await ConnectionControl(async () =>
        {
            MySqlCommand cmd = new MySqlCommand("SELECT id FROM users", _conn) { CommandType = CommandType.Text };
            DataTable dt = new DataTable();
            await new MySqlDataAdapter(cmd.CommandText, _conn).FillAsync(dt);

            return dt.Rows.Cast<int>().Select(x => new Account(x)).ToList();
        });        
    }

    private static async Task<List<Account>> ConnectionControl(Func<Task<List<Account>>> function)
    {
        if (!_conn.State.HasFlag(ConnectionState.Open))
            await _conn.OpenAsync();

        var response = await function();

        if (!_conn.State.HasFlag(ConnectionState.Closed))
            await _conn.CloseAsync();

        return response;
    }
}
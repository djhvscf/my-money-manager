using SQLite;

namespace MyMoneyManager.DataAccess
{
    public interface ISQLConnection
    {
        SQLiteAsyncConnection GetConnection();
    }
}

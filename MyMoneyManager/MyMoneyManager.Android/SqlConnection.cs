using MyMoneyManager.DataAccess;
using MyMoneyManager.Droid;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlConnection))]
namespace MyMoneyManager.Droid
{
    public class SqlConnection : ISQLConnection
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var docsPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(docsPath, "mymoneymanager.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
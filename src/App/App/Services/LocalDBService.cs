using PCLStorage;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace App.Services
{
    public class LocalDBService: ILocalDBService
    {
        public LocalDBService()
        {
            // initialize SQLitePCL
            SQLitePCL.Batteries_V2.Init();
        }


        private const string _db = "local.db";
        private SQLiteAsyncConnection _conn = null;
        private SQLiteAsyncConnection Connect()
        {
            if (_conn == null)
            {
                // default storage path
                IFolder folder = FileSystem.Current.LocalStorage;
                // establish a connection
                _conn = new SQLiteAsyncConnection(Path.Combine(folder.Path, _db), false);
                // create table
                _conn.GetConnection().CreateTable<Models.TestTable>();
            }

            return _conn;
        }

        public async Task Upsert<T>(T item)
        {            
            await Connect().InsertOrReplaceAsync(item);
        }

        public async Task Delete<T>(T item)
        {
            await Connect().DeleteAsync(item);
        }

        public async Task<IList<T>> List<T>(string sql, params object[] args) where T : new()
        {
            return await Connect().QueryAsync<T>(sql, args);
        }
    }
}
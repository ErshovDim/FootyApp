using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace FootyApp
{
    public class BaseStadium
    {
        readonly SQLiteAsyncConnection _database;

        public BaseStadium(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Stadium>().Wait();
        }

        public Task<List<Stadium>> GetStadiumsAsync()
        {
            return _database.Table<Stadium>().ToListAsync();
        }

        public Task<int> SaveStadiumAsync(Stadium stadium)
        {
            return _database.InsertAsync(stadium);
        }
    }
}
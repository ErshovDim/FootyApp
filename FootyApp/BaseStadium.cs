using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

        public async Task<ObservableCollection<Stadium>> GetStadiumsAsync()
        {
            var StadiumList = await _database.Table<Stadium>().ToListAsync();
            return new ObservableCollection<Stadium>(StadiumList);
        }

        public Task<List<Stadium>> GetStadiumsFromSizeAsync(int SizeField)
        {
            return _database.Table<Stadium>().Where(x => x.Size == SizeField).ToListAsync();

        }

        public Task<List<Stadium>> GetStadiumsFromTypeAsync(string TypeField)
        {
            return _database.Table<Stadium>().Where(x => x.Type == TypeField ).ToListAsync();
        }

        public Task<List<Stadium>> GetStadiumsFromTypeAndSizeAsync(string TypeField, int SizeField)
        {
           
           // return _database.QueryAsync<Stadium>($"SELECT * FROM Stadium WHERE (Type = {TypeField}) AND (Size = {SizeField})");
            return _database.Table<Stadium>().Where(x => x.Type == TypeField && x.Size == SizeField).ToListAsync();
        }


        public Task<int> SaveStadiumAsync(Stadium stadium)
        {
            return _database.InsertAsync(stadium);
        }
    }
}
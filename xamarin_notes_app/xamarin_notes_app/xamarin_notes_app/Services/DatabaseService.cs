using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Helper;
using xamarin_notes_app.Models;

namespace xamarin_notes_app.Services
{
    public sealed class DatabaseService<T> where T : new()
    {
        public static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags));
        static SQLiteAsyncConnection _database => lazyInitializer.Value;

        public static DatabaseService<T> dbInstance = null;
        private static readonly object dbLock=new object();

        public static DatabaseService<T> GetDatabaseService
        {
            get
            {
                if (dbInstance == null)
                {
                    lock (dbInstance)
                    {
                        dbInstance = new DatabaseService<T>();
                        CreateTablesAsync();
                    }
                }
                return dbInstance;
            }
        }

        private static async void CreateTablesAsync()
        {
            try
            {
              await _database.CreateTablesAsync(CreateFlags.None,typeof(TaskData)).ConfigureAwait(false);
              await _database.CreateTablesAsync(CreateFlags.None, typeof(ProfileModel)).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} :Error in createTable", e.Message);
            }
        }
        

        public async Task<List<T>> GetAllDataFromDBAsync()
        {
            try
            {
                return await _database.Table<T>().ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in GetDbData {0} ", e.Message);
                return null;
            }
        }

        public void InsertAllDataAsync(List<T> data)
        {
            try
            {
                _database.InsertAllAsync(data);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Error while inserting data", e.Message);
            }
        }

        public void InsertItemAsync(T item)
        {
            try
            {
                _database.InsertAsync(item);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Error in inserting single item", e.Message);
            }

        }
    }
}

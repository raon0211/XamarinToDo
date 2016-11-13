using MvvmCross.Plugins.Sqlite;
using Now.Core.Abstract;
using Now.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Now.Core.Concrete
{
    public class DataService : IDataService
    {
        private readonly SQLiteConnection connection;

        public DataService(IMvxSqliteConnectionFactory factory)
        {
            connection = factory.GetConnection("data.db");
            connection.CreateTable<TodoItem>();
        }

        public IEnumerable<TodoItem> List()
        {
            return connection.Table<TodoItem>();
        }

        public void Remove(TodoItem item)
        {
            connection.Delete<TodoItem>(item.Id);
        }

        public void Add(TodoItem item)
        {
            connection.Insert(item);
        }

        public void Update(TodoItem item)
        {
            connection.InsertOrReplace(item);
        }
    }
}

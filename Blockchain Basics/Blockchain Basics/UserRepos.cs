using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain_Basics
{
    public class UserRepos
    {
        SQLiteConnection database;
        static object locker = new object();
        public UserRepos(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<User>();
        }
        public IEnumerable<User> GetItems()
        {
            return database.Table<User>().ToList();
        }
        public User GetItem(int id)
        {
            return database.Get<User>(id);
        }
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
        public int SaveItem(User item)
        {
            if (item.id != 0)
            {
                database.Update(item);
                return item.id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}

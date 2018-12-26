using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dinner.Models;
using SQLite;

namespace Dinner.Data
{
    public class DishDatabase
    {
        readonly SQLiteAsyncConnection database;

        public DishDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Dish>().Wait();
        }

        public Task<List<Dish>> GetDishesAsync()
        {
            return database.Table<Dish>().ToListAsync();
        }

        public Task<Dish> GetDishAsync(int id)
        {
            return database.Table<Dish>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveDishAsync(Dish item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteDishAsync(Dish item)
        {
            return database.DeleteAsync(item);
        }

        internal Task<List<Dish>> GetRandomDishedAsync()
        {

            var vegtables = database.Table<Dish>().Where(x => x.IsMeat == false).OrderBy(x => Guid.NewGuid()).Take(1).ToListAsync();
            var meats = database.Table<Dish>().Where(x => x.IsMeat == true).OrderBy(x => Guid.NewGuid()).Take(1).ToListAsync();
            return meats;
        }
    }
}

using Laundry.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

//Реализация базы данных SQLite
namespace Laundry.Services
{
    public static class DB
    {
        static SQLiteAsyncConnection db;
        static SQLiteAsyncConnection db_users;

        //Инициализация БД
        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "My_data.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Item>();
        }

        static async Task Init_user()
        {
            if (db_users != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "My_data_2.db");
            db_users = new SQLiteAsyncConnection(databasePath);
            await db_users.CreateTableAsync<User>();
        }

        //Добавление заказов в ДБ
        public static async Task AddOrder(string name_order,
            string color_order,
            string fabric_structure_1,
            string fabric_structure_2,
            string fabric_structure_3,
            string fabric_structure_4,
            string fabric_structure_5,
            string fabric_structure_6,
            string fabric_structure_7,
            string fabric_structure_8,
            string fabric_structure_9,
            string size_order,
            string furniture_1,
            string furniture_2,
            string furniture_3,
            string furniture_4,
            string furniture_5,
            string furniture_6,
            string defects_order,
            string symbols_1,
            string symbol_2,
            string symbol_3,
            string symbol_4,
            string symbol_5,
            string symbol_6,
            string delivery_in,
            string delivery_out,
            string adress,
            string pay)
        {
            await Init();
            var order = new Item
            {
                Name_order = name_order,
                Color_order = color_order,
                Fabric_structure_1 = fabric_structure_1,
                Fabric_structure_2 = fabric_structure_2,
                Fabric_structure_3 = fabric_structure_3,
                Fabric_structure_4 = fabric_structure_4,
                Fabric_structure_5 = fabric_structure_5,
                Fabric_structure_6 = fabric_structure_6,
                Fabric_structure_7 = fabric_structure_7,
                Fabric_structure_8 = fabric_structure_8,
                Fabric_structure_9 = fabric_structure_9,
                Size_order = size_order,
                Furniture_order_1 = furniture_1,
                Furniture_order_2 = furniture_2,
                Furniture_order_3 = furniture_3,
                Furniture_order_4 = furniture_4,
                Furniture_order_5 = furniture_5,
                Furniture_order_6 = furniture_6,
                Defects_order = defects_order,
                Symbol_order_1 = symbols_1,
                Symbol_order_2 = symbol_2,
                Symbol_order_3 = symbol_3,
                Symbol_order_4 = symbol_4,
                Symbol_order_5 = symbol_5,
                Symbol_order_6 = symbol_6,
                Delivery_in_order = delivery_in,
                Delivery_out_order = delivery_out,
                Adress_order = adress,
                Pay_order = pay,
                Status_order = "В обработке"
            };
            var Id = await db.InsertAsync(order);
        }

        //Добавление пользователя в ДБ
        public static async Task AddUser(string name_user,
            string number_user,
            string mail_user,
            string password_user
            )
        {
            await Init_user();
            var user = new User
            {
                Name_user = name_user,
                Number_user = number_user,
                Mail_user = mail_user,
                Password_user = password_user,
            };
            var Id = await db_users.InsertAsync(user);
        }
        
        //Удалить заказ из ДБ
        public static async Task RemoveOrder(int Id)
        {
            await Init();
            await db.DeleteAsync<Item>(Id);
        }

        //Получить данные по заказу
        public static async Task<IEnumerable<Item>> GetOrder()
        {
            await Init();
            var order = await db.Table<Item>().ToListAsync();
            return order;
        }

        //Получить данные о пользователе
        public static async Task<IEnumerable<User>> GetUser()
        {
            await Init_user();
            var user = await db_users.Table<User>().ToListAsync();
            return user;
        }
    }
}

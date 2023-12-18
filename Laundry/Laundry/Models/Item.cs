using SQLite;
using System;

namespace Laundry.Models
{
    //Класс для хранения данных Заказов
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name_order { get; set; }
        public string Color_order { get; set; }
        public string Fabric_structure_1 { get; set; }
        public string Fabric_structure_2 { get; set; }
        public string Fabric_structure_3 { get; set; }
        public string Fabric_structure_4 { get; set; }
        public string Fabric_structure_5 { get; set; }
        public string Fabric_structure_6 { get; set; }
        public string Fabric_structure_7 { get; set; }
        public string Fabric_structure_8 { get; set; }
        public string Fabric_structure_9 { get; set; }
        public string Size_order { get; set; }
        public string Furniture_order_1 { get; set; }
        public string Furniture_order_2 { get; set; }
        public string Furniture_order_3 { get; set; }
        public string Furniture_order_4 { get; set; }
        public string Furniture_order_5 { get; set; }
        public string Furniture_order_6 { get; set; }
        public string Defects_order { get; set; }
        public string Symbol_order_1 { get; set; }
        public string Symbol_order_2 { get; set; }
        public string Symbol_order_3 { get; set; }
        public string Symbol_order_4 { get; set; }
        public string Symbol_order_5 { get; set; }
        public string Symbol_order_6 { get; set; }
        public string Delivery_in_order { get; set; }
        public string Delivery_out_order { get; set; }
        public string Adress_order { get; set; }
        public string Pay_order { get; set; }
        public string Status_order { get; set; }
    }

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name_user { get; set; }
        public string Number_user { get; set; }
        public string Mail_user { get; set; }
        public string Password_user { get; set; } 
    }

}
using Laundry.Models;
using Laundry.Services;
using Laundry.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laundry.ViewModels
{
    //
    public class NewItemViewModel : BaseViewModel
    {
        private string name;
        private string color;
        private string fabric_1;
        private string fabric_2;
        private string fabric_3;
        private string fabric_4;
        private string fabric_5;
        private string fabric_6;
        private string fabric_7;
        private string fabric_8;
        private string fabric_9;
        private string size;
        private string furniture_1;
        private string furniture_2;
        private string furniture_3;
        private string furniture_4;
        private string furniture_5;
        private string furniture_6;
        private string defects;
        private string symbol_1;
        private string symbol_2;
        private string symbol_3;
        private string symbol_4;
        private string symbol_5;
        private string symbol_6;
        private string delivery_in;
        private string delivery_out;
        private string adress;
        private string pay;
        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Color
        {
            get => color;
            set => SetProperty(ref color, value);
        }

        public string Fabric_1
        {
            get => fabric_1;
            set => SetProperty(ref fabric_1, value);
        }
        public string Fabric_2
        {
            get => fabric_2;
            set => SetProperty(ref fabric_2, value);
        }
        public string Fabric_3
        {
            get => fabric_3;
            set => SetProperty(ref fabric_3, value);
        }

        public string Fabric_4
        {
            get => fabric_4;
            set => SetProperty(ref fabric_4, value);
        }

        public string Fabric_5
        {
            get => fabric_5;
            set => SetProperty(ref fabric_5, value);
        }

        public string Fabric_6
        {
            get => fabric_6;
            set => SetProperty(ref fabric_6, value);
        }

        public string Fabric_7
        {
            get => fabric_7;
            set => SetProperty(ref fabric_7, value);
        }

        public string Fabric_8
        {
            get => fabric_8;
            set => SetProperty(ref fabric_8, value);
        }

        public string Fabric_9
        {
            get => fabric_9;
            set => SetProperty(ref fabric_9, value);
        }
        public string Size
        {
            get => size;
            set => SetProperty(ref size, value);
        }
        public string Furniture_1
        {
            get => furniture_1;
            set => SetProperty(ref furniture_1, value);
        }

        public string Furniture_2
        {
            get => furniture_2;
            set => SetProperty(ref furniture_2, value);
        }
        public string Furniture_3
        {
            get => furniture_3;
            set => SetProperty(ref furniture_3, value);
        }
        public string Furniture_4
        {
            get => furniture_4;
            set => SetProperty(ref furniture_4, value);
        }
        public string Furniture_5
        {
            get => furniture_5;
            set => SetProperty(ref furniture_5, value);
        }
        public string Furniture_6
        {
            get => furniture_6;
            set => SetProperty(ref furniture_6, value);
        }

        public string Defects
        {
            get => defects;
            set => SetProperty(ref defects, value);
        }

        public string Symbol_1
        {
            get => symbol_1;
            set => SetProperty(ref symbol_1, value);
        }
        public string Symbol_2
        {
            get => symbol_2;
            set => SetProperty(ref symbol_2, value);
        }
        public string Symbol_3
        {
            get => symbol_3;
            set => SetProperty(ref symbol_3, value);
        }
        public string Symbol_4
        {
            get => symbol_4;
            set => SetProperty(ref symbol_4, value);
        }
        public string Symbol_5
        {
            get => symbol_5;
            set => SetProperty(ref symbol_5, value);
        }
        public string Symbol_6
        {
            get => symbol_6;
            set => SetProperty(ref symbol_6, value);
        }

        public string Delivery_in
        {
            get => delivery_in;
            set => SetProperty(ref delivery_in, value);
        }
        public string Delivery_out
        {
            get => delivery_out;
            set => SetProperty(ref delivery_out, value);
        }
        public string Adress
        {
            get => adress;
            set => SetProperty(ref adress, value);
        }
        public string Pay
        {
            get => pay;
            set => SetProperty(ref pay, value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        //Отменить ввод данных для заказа
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
        //Сохрнаить данные по заказу
        private async void OnSave()

        {
            if (name != null)
            {
                await DB.AddOrder(name, color, fabric_1, fabric_2, fabric_3, fabric_4, fabric_5, fabric_6, fabric_7, fabric_8, fabric_9, size, furniture_1, furniture_2, furniture_3, furniture_4, furniture_5, furniture_6, defects, symbol_1, symbol_2, symbol_3, symbol_4, symbol_5, symbol_6, delivery_in, delivery_out, adress, pay);

                await Shell.Current.GoToAsync("..");
                return;
            }
            await Shell.Current.DisplayAlert("Заполните поле: Наименование изделия!", "Для оформления заказа необходимо заполнить как можно больше полей", "Ok");

        }
    }
}

using Laundry.Models;
using Laundry.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Laundry.Services;
using Command = Xamarin.Forms.Command;

namespace Laundry.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> Item { get; set; }
        public AsyncCommand LoadItemsCommand { get; }
        public AsyncCommand<Item> RemoveCommand { get; }
        public Command AddItemCommand_ { get; }
       
        Item selectedItem;
       
        public ItemsViewModel()
        {
            Title = "Заказы";   
            Item = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new AsyncCommand(Refresh);
            RemoveCommand = new AsyncCommand<Item>(Remove);
            AddItemCommand_ = new Command(OnAddItem);
            
        }
        public Item SelectedItem
        {
            get => selectedItem;
            set
            {
                SelectedItem = null;
                OnPropertyChanged();
            }
        }

        //Добавить новый заказ
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
            await Refresh();
        }

        //Удалить заказ
        async Task Remove(Item order)
        {
            if (order == null)
                return;
            await DB.RemoveOrder(order.Id);
            await Refresh();
        }
        //Обновить список заказов
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Item.Clear();
            var items = await DB.GetOrder();
            Item.AddRange(items);
            IsBusy = false;
        }

    }
}
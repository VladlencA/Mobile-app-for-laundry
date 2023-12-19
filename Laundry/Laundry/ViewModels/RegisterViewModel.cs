using Laundry.Services;
using Laundry.Views;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Laundry.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string name_user;
        private string number_user;
        private string mail_user;
        private string password_user;
        public Command LoginCommand_ { get; }

        public RegisterViewModel()
        {
            LoginCommand_ = new Command(Save_user);
            this.PropertyChanged +=
                (_, __) => LoginCommand_.ChangeCanExecute();

        }
        

        public string Name_user
        {
            get => name_user;
            set => SetProperty(ref name_user, value);
        }

        public string Number_user
        {
            get => number_user;
            set => SetProperty(ref number_user, value);
        }

        public string Mail_user
        {
            get => mail_user;
            set => SetProperty(ref mail_user, value);
        }
        public string Password_user
        {
            get => password_user;
            set => SetProperty(ref password_user, value);
        }

        private async void Save_user()
        {
            if (name_user != null & number_user !=null & mail_user !=null &password_user !=null)
            {
                await DB.AddUser(name_user, number_user, mail_user, password_user);
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                return;
            }
            await Shell.Current.DisplayAlert("Заполните все поля!", "Для регистрации нужно заполнить все поля", "Ok");

        }

    }
}
